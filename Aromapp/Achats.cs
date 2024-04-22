using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aromapp
{
    public partial class Achats : DevExpress.XtraEditors.XtraUserControl
    {

        AddPurchase addPurchase;
        BackgroundWorker worker = new BackgroundWorker();
        bool searching = false;
        string searchBy;
        public event EventHandler QTChanged;

        public Achats()
        {
            InitializeComponent();
            this.Load += Achats_Shown;
            BuyedProducts.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            BuyedProducts.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(255, 64, 64, 64),
                Font = new Font("Calibri", 9.25f)
            };
            BuyedProducts.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(63, 81, 181),
                Font = new Font("Calibri", 9.25f, FontStyle.Bold)
            };
            worker.RunWorkerCompleted += worker_workCompleted;
            worker.DoWork += worker_Work;
        }
        public virtual void OnQTChanged(EventArgs e)
        {

            EventHandler eh = QTChanged;
            if (eh != null)
            {
                eh(this, e);


            }
        }
        private void iconButton6_Click(object sender, EventArgs e)
        {
            addPurchase = new AddPurchase();
            addPurchase.QTChanged += QTChangedOnUS;
            addPurchase.ShowDialog();
        }

        private void QTChangedOnUS(object sender, EventArgs e)
        {

            OnQTChanged(e);
        }

        int currentPage = 1, limit = 100;
        BindingSource bindingSource;
        DataTable table;
        DBHelper helper = new DBHelper();
        bool tableFull = false;
        private void BuyedProducts_Scroll(object sender, ScrollEventArgs e)
        {
            int totalHeight = 0;


            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
            {

                foreach (DataGridViewRow row in BuyedProducts.Rows)
                {
                    totalHeight += row.Height;

                }

                int lastDisplayedRowIndex = BuyedProducts.FirstDisplayedScrollingRowIndex + BuyedProducts.DisplayedRowCount(true) - 1;

                if (totalHeight - BuyedProducts.Height < BuyedProducts.VerticalScrollingOffset)
                {
                    if (currentPage == 1)
                    {
                        bindingSource = new BindingSource();
                        table = helper.selectPurchases(limit, currentPage);
                        bindingSource.DataSource = table;
                        BuyedProducts.FirstDisplayedScrollingRowIndex = BuyedProducts.CurrentRow.Index;
                        BuyedProducts.DataSource = bindingSource;
                    }
                    else if (currentPage != 1 && !tableFull)
                    {
                        bindingSource = new BindingSource();
                        DataTable Newtable = helper.selectPurchases(limit, currentPage);
                        table.Merge(Newtable);
                        bindingSource.DataSource = table;
                        BuyedProducts.DataSource = bindingSource;

                        if (Newtable.Rows.Count < limit)
                        {
                            tableFull = true;
                        }

                        if (lastDisplayedRowIndex >= 0 && lastDisplayedRowIndex < BuyedProducts.Rows.Count)
                        {
                            BuyedProducts.FirstDisplayedScrollingRowIndex = lastDisplayedRowIndex;

                        }

                    }


                    if (!tableFull)
                    {
                        currentPage++;

                    }

                }
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            RefreshTable();

            using (DBHelper helper = new DBHelper())
            {
                LastWeekTotal = helper.SelectLastPurchaseTotal();
                lastWP.Text = LastWeekTotal.ToString("F2") + " DA";
            }
        }

        public void RefreshTable()
        {
            bindingSource = new BindingSource();
            table = helper.selectPurchases(100, 1);
            bindingSource.DataSource = table;
            BuyedProducts.DataSource = bindingSource;
        }

        private void BuyedProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Supplier supplier = helper.selectSupplierInfo(BuyedProducts.SelectedRows[0].Cells[3].Value.ToString());

            netTotalText.Text = BuyedProducts.SelectedRows[0].Cells[5].Value.ToString();
            paidAmtText.Text = BuyedProducts.SelectedRows[0].Cells[8].Value.ToString();
            dueText.Text = BuyedProducts.SelectedRows[0].Cells[9].Value.ToString();

            custNameText.Text = supplier.Nom;
            custPhoneText.Text = supplier.Tel;

            EmailText.Text = supplier.Email;
            custAddrText.Text = supplier.Activite;
            Address.Text = supplier.Adresse;



        }


        private void search_Leave(object sender, EventArgs e)
        {
            if (search.Text.Trim() == "")
            {
                HintUtils.ShowHint(search);
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(search);

        }
        private void amount_Leave(object sender, EventArgs e)
        {
            if (amount.Text.Trim() == "")
            {
                HintUtils.ShowHint(amount);
            }
        }

        int selection = -1;

        private void searchButton_Click(object sender, EventArgs e)
        {

            DBHelper helper = new DBHelper();
            searching = true;
            DataTable data = helper.searchForPurchases(search.Text.ToLower(), selection);
            BuyedProducts.DataSource = data;




        }



        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = guna2DateTimePicker1.Value.Date;
            string day = date.Day.ToString("D2"), month = date.Month.ToString("D2");


            string dateString = day + "-" + month + "-" + date.Year.ToString();
            DBHelper helper = new DBHelper();
            selection = 4;
            currentPage = 1;

            DataTable data = helper.searchForPurchases(dateString, selection);
            BuyedProducts.DataSource = data;
        }

        double LastWeekTotal = 0;

        private void amount_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(amount);

        }
        void worker_workCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lastWP.Text = LastWeekTotal.ToString("F2") + " DA";
            BuyedProducts.DataSource = table;

        }

        private void Achats_Shown(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }

          private void iconButton5_Click(object sender, EventArgs e)
        {
            if (BuyedProducts.SelectedRows[0].Cells[3].Value != null)
            {
                if (BuyedProducts.SelectedRows[0].Cells[3].Value.ToString() != "1") 
                {
               
                    EditSupplierForm supplier = new EditSupplierForm(BuyedProducts.SelectedRows[0].Cells[3].Value.ToString());
                    supplier.ShowDialog();

                }
                else
                {
                    MessageBoxer.showGeneralMsg("Cette ligne n'est pas modifiable");
                }
            }
                  
            else
            {
                MessageBoxer.showGeneralMsg("Sélectionnez une facture pour modifier son fournisseur");

            }


}

        void PasswoCorrect(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper();
            string BillID = BuyedProducts.SelectedRows[0].Cells[0].Value.ToString();
            double due = double.Parse(amount.Text.Replace(".", ","));

            helper.UpdatePurchasePaidAmount(BillID, due, Properties.Settings.Default.LoggedInUserName);

            DataTable table = helper.selectPurchases(100, 1);
            HintUtils.ShowHint(amount);
            BuyedProducts.DataSource = table;

        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(amount.Text) && amount.Text != amount.Tag.ToString())
            {
                if (custNameText.Text != "Null")
                {
                    double due = double.Parse(dueText.Text.Replace(".", ","));
                    if (due != 0)
                    {
                        PasswoCorrect(sender,e);
                    }
                    else
                    {
                        MessageBoxer.showGeneralMsg("La facture est déjà réglée");

                    }
                }
                else
                {
                    MessageBoxer.showGeneralMsg("Sélectionnez une facture pour modifier son montant reglé");

                }
            }
            else
            {
                MessageBoxer.showGeneralMsg("Entrez une valeur");

            }
        }

        private void search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DBHelper helper = new DBHelper();
                searching = true;
                DataTable data = helper.searchForPurchases(search.Text.ToLower(), selection);
                BuyedProducts.DataSource = data;
                e.SuppressKeyPress = true;
            }
        }

        void CheckIfPurchaseDeleted(object sender, FormClosingEventArgs e)
        {
            if (DeletedPurchase)
            {
                table = helper.selectPurchases(limit, currentPage);
                BuyedProducts.DataSource = table;
                DeletedPurchase = false;

            }
        }
        private void BuyedProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (BuyedProducts.SelectedRows[0].Cells[1].Value.ToString() != "Ajout"
                && !string.IsNullOrEmpty(BuyedProducts.SelectedRows[0].Cells[1].Value.ToString()))
            {

                Sale sale = new Sale();

                sale.N = BuyedProducts.SelectedRows[0].Cells[0].Value.ToString();
                sale.Date = BuyedProducts.SelectedRows[0].Cells[2].Value.ToString();

                sale.TotalHT = decimal.Parse(BuyedProducts.SelectedRows[0].Cells[5].Value.ToString());

                sale.Type = BuyedProducts.SelectedRows[0].Cells[1].Value.ToString();

                sale.Date = BuyedProducts.SelectedRows[0].Cells[2].Value.ToString();
                Supplier supplier = new Supplier();
                supplier.Tel = custPhoneText.Text;
                supplier.Adresse = custAddrText.Text;
                supplier.Nom = custNameText.Text;

                PurchaseInfo purchaseInfo = new PurchaseInfo(sale, supplier);
                purchaseInfo.FormClosing += CheckIfPurchaseDeleted;
                purchaseInfo.ShowDialog();
            }
            else
            {
                MessageBoxer.showGeneralMsg("Cette ligne n'est pas modifiable");
            }

        }

        void worker_Work(object sender, DoWorkEventArgs e)
        {
            table = helper.selectPurchases(limit, currentPage);
            LastWeekTotal = helper.SelectLastPurchaseTotal();

        }

        private void amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBox.Show("Veuillez saisir uniquement des chiffres");

                e.Handled = true;
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {

        }

        public static bool DeletedPurchase { get; set; }
    }
}
