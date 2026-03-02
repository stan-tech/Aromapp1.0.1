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
    public partial class Ventes : DevExpress.XtraEditors.XtraUserControl
    {

        BackgroundWorker worker = new BackgroundWorker();
        Timer timer1;
        string saleType = "";
        int selection = 1;
        static bool deletedBill;
        bool searching = false;
        BindingSource bindingSource;
        int limit = 100, currentPage = 1;
        bool tableFull = false;
        DataTable table;
        DBHelper helper = new DBHelper();
        public Ventes()
        {
            InitializeComponent();
            timer1 = new Timer();
            timer1.Tick += timer1_Tick;
            this.Load += Ventes_Load;
            worker.RunWorkerCompleted += worker_workCompleted;
            worker.DoWork += worker_Work;
            soldProducts.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            soldProducts.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(255, 64, 64, 64),
                Font = new Font("Calibri", 9.25f)
            };
            soldProducts.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(63, 81, 181),
                Font = new Font("Calibri", 9.25f, FontStyle.Bold)
            };

        }



        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ventes_Load(object sender, EventArgs e)
        {
            guna2DateTimePicker1.ValueChanged -= guna2DateTimePicker1_ValueChanged;
            guna2DateTimePicker1.Value = DateTime.Now;
            guna2DateTimePicker1.ValueChanged += guna2DateTimePicker1_ValueChanged;
            timer1.Start();
        }

        int x = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            x++;
            if (x >= 1)
            {
                timer1.Stop();
                worker.RunWorkerAsync();

            }
        }

        private void iconButton4_Click_1(object sender, EventArgs e)
        {
            searching = false;
            tableFull = false;
            saleType = "";
            selection = 1;

            Bon.Checked = false;
            Factures.Checked = false;
            currentPage = 1;

            searchText.Text = string.Empty;

            HintUtils.ShowHint(searchText);

            loadData load = new loadData(RefreshData);

            soldProducts.Invoke(load);
        }

        public delegate void loadData();

        public void Loaddata()
        {

            soldProducts.DataSource = bindingSource;

        }

        public void RefreshData()
        {
            bindingSource = new BindingSource();
            table = helper.selectSales(limit, 1,"");
            bindingSource.DataSource = table;
            soldProducts.DataSource = bindingSource;

        }
        void worker_workCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadData load = new loadData(Loaddata);

            soldProducts.Invoke(load);

        }

      

         public void AddTable(int currentPage)
        {
            BindingSource bindingSource = new BindingSource();
            using (DBHelper helper = new DBHelper())
            {
                table = helper.selectSales(limit, currentPage,"");

            }

            if (table.Rows.Count < limit)
            {
                tableFull = true;
            }
            else
            {
                tableFull = false;

            }

            bindingSource.DataSource = table;
            soldProducts.DataSource = bindingSource;
        }

        private void soldProducts_Scroll(object sender, ScrollEventArgs e)
        {
            int totalHeight = 0;

            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
            {
                foreach (DataGridViewRow row in soldProducts.Rows)
                    totalHeight += row.Height;

                if (!tableFull)
                {

                    if (soldProducts.VerticalScrollingOffset == 0 && e.NewValue < e.OldValue)
                    {
                        if (currentPage > 1)
                        {
                            currentPage--;

                            if (!searching)
                            {
                                AddTable(currentPage);
                            }
                            else
                            {
                                SearchSales(currentPage,selection, saleType);   
                            }
                            tableFull = false;

                        }
                        else
                        {
                            if (!searching)
                            {
                                AddTable(currentPage);
                            }
                            else
                            {
                                SearchSales(1, selection, saleType);
                            }
                        }
                    }

                    if (totalHeight - soldProducts.Height < soldProducts.VerticalScrollingOffset)
                    {
                        if (currentPage == 1)
                        {
                            if (!searching)
                            {
                                AddTable(currentPage);
                            }
                            else
                            {
                                SearchSales(currentPage, selection, saleType);
                            }


                        }
                        else if (currentPage != 1 && !tableFull)
                        {
                            if (!searching)
                            {
                                AddTable(currentPage);
                            }
                            else
                            {
                                SearchSales(currentPage, selection, saleType);
                            }

                            if (table.Rows.Count < limit)
                            {
                                tableFull = true;
                            }

                        }

                        if (!tableFull)
                        {
                            currentPage++;

                        }

                    }


                }

            }


        }
        string clientID;
        private void soldProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (soldProducts.SelectedRows[0].Index!= soldProducts.RowCount-1)
            {
                DBHelper helper = new DBHelper();
                clientID = helper.selectCLientID(soldProducts.SelectedRows[0].Cells[0].Value.ToString());
                Client client = helper.selectClientInfo(clientID);
                Sale sale = new Sale();
                sale.Type = soldProducts.SelectedRows[0].Cells[1].Value.ToString();
                sale.TotalHT = decimal.Parse(soldProducts.SelectedRows[0].Cells[5].Value.ToString());
                sale.ModeReglement = soldProducts.SelectedRows[0].Cells[7].Value.ToString();
                sale.RemiseTotal = decimal.Parse(soldProducts.Rows[0].Cells[6].Value.ToString());
                sale.MontantRegler = decimal.Parse(soldProducts.SelectedRows[0].Cells[9].Value.ToString());
                //sale.MontantRest = decimal.Parse(soldProducts.SelectedRows[0].Cells[9].Value.ToString());
                netTotalText.Text = sale.TotalHT.ToString();
                vatText.Text = "0";
                discountText.Text = sale.RemiseTotal.ToString();
                custNameText.Text = client.Nom;
                custPhoneText.Text = client.Tel;
                custAddrText.Text = client.Adresse;
                paidAmtText.Text = sale.MontantRegler.ToString();
                try
                {
                    dueText.Text = soldProducts.SelectedRows[0].Cells[10].Value.ToString();

                    if (dueText.Text.Trim() == "")
                    {
                        dueText.Text = "Non disponible";

                    }
                }
                catch
                {

                    dueText.Text = "Non disponible";
                }
            }
            else
            {
                MessageBoxer.showGeneralMsg("Sélectionnez une facture pour voir son contenu");

            }

        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {
            if (Bon.Checked)
            {
                Bon.Checked = false;
            }
            if (Factures.Checked)
            {
                currentPage = 1;
                searching = true;
                saleType = "Facture";
                selection = 4;

                SearchSales(1, selection, saleType);
            }
        }

        private void Bon_Click(object sender, EventArgs e)
        {
            if (Factures.Checked)
            {
                Factures.Checked = false;
            }
            if (Bon.Checked)
            {
                currentPage = 1;
                searching = true;
                saleType = "Bon";
                selection = 4;
                SearchSales(1, selection, saleType);
            }
        }


        private void search_Leave(object sender, EventArgs e)
        {
            if (searchText.Text.Trim() == "")
            {
                HintUtils.ShowHint(searchText);
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(searchText);

        }

        private void amount_Leave(object sender, EventArgs e)
        {
            if (amount.Text.Trim() == "")
            {
                HintUtils.ShowHint(amount);
            }
        }

        private void amount_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(amount);

        }

        private void search_TextChanged(object sender, EventArgs e)
        {

        }

        void RefreshTable(object sender, FormClosedEventArgs e)
        {

            
                table = helper.selectSales(100, 1,"");
                soldProducts.DataSource = table;
           


        }
        private void soldProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (soldProducts.SelectedRows[0].Index != soldProducts.RowCount - 1)
            {
                Sale sale = new Sale();

                sale.N = soldProducts.SelectedRows[0].Cells[0].Value.ToString();
                sale.Date = soldProducts.SelectedRows[0].Cells[2].Value.ToString();

                sale.TotalHT = decimal.Parse(soldProducts.SelectedRows[0].Cells[5].Value.ToString());

                sale.Type = soldProducts.SelectedRows[0].Cells[1].Value.ToString();

                sale.Date = soldProducts.SelectedRows[0].Cells[2].Value.ToString();
                sale.MontantRegler = decimal.Parse(paidAmtText.Text);
                sale.MontantRest = decimal.Parse(dueText.Text);
                Client client = new Client();
                client.C_CL = soldProducts.SelectedRows[0].Cells[3].Value.ToString();
                client.Tel = custPhoneText.Text;
                client.Adresse = custAddrText.Text;
                client.Nom = custNameText.Text;

                SaleInfo saleInfo = new SaleInfo(sale, client);
                saleInfo.FormClosed += RefreshTable;
                saleInfo.StartPosition = FormStartPosition.CenterScreen;
                saleInfo.FormBorderStyle = FormBorderStyle.FixedSingle;
                saleInfo.MaximizeBox = false;
                saleInfo.MinimizeBox = false;
                saleInfo.Show();
            }
            else
            {
                MessageBoxer.showGeneralMsg("Sélectionnez une facture pour voir son contenu");

            }

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = guna2DateTimePicker1.Value.Date;
            string day = date.Day.ToString("D2"), month = date.Month.ToString("D2");

            searching = true;
            string dateString = day + "-" + month + "-" + date.Year.ToString();
            DBHelper helper = new DBHelper();
            currentPage = 1;

            DataTable data = helper.searchForSales(dateString, 5);
            soldProducts.DataSource = data;

        }



        void PasswoCorrect(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                string BillID = soldProducts.SelectedRows[0].Cells[0].Value.ToString();

                helper.UpdatePaidAmount(BillID, decimal.Parse(amount.Text), Confirm.SelectedUser.Name);

                DataTable table = helper.selectSales(100, 1,"");
                amount.Text = "";
                HintUtils.ShowHint(amount);
                soldProducts.DataSource = table;
            }

        }
        private void iconButton2_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(amount.Text) && amount.Text != amount.Tag.ToString())
            {
                if (custNameText.Text != "Null")
                {
                    if (double.Parse(dueText.Text) != 0)
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

        void worker_Work(object sender, DoWorkEventArgs e)
        {

            bindingSource = new BindingSource();
            table = helper.selectSales(limit, currentPage,"");
            bindingSource.DataSource = table;





        }
      

        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searching = true;
                currentPage = 1;
                SearchSales(1, selection, saleType);
                e.SuppressKeyPress = true;

            }

        }

        public void SearchSales(int currentPage, int selection, string saleType)
        {

            BindingSource bindingSource = new BindingSource();


            string searchStr = (saleType != "Bon" && saleType != "Facture")?searchText.Text.ToLower():saleType;
            

            using (DBHelper helper = new DBHelper())
            {
                table = helper.searchForSales(searchStr, selection, currentPage, limit);

            }

            if (table.Rows.Count < limit)
            {
                tableFull = true;
            }
            else
            {
                tableFull = false;

            }

            bindingSource.DataSource = table;
            soldProducts.DataSource = bindingSource;
        }

        private void amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBox.Show("Veuillez saisir uniquement des chiffres");

                e.Handled = true;
            }
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            if (clientID!="X" && !string.IsNullOrEmpty(clientID))
            {
                if (netTotalText.Text.Trim() != "Null")
                {
                    EditClient edit = new EditClient(clientID);
                    edit.ShowDialog();
                }
                else
                {
                    MessageBoxer.showGeneralMsg("Séléctionnez une facture pour modifier son client");
                }
            }
            else
            {
                MessageBoxer.showGeneralMsg("Séléction non modifiable");

            }
        }

        private void searchText_Leave(object sender, EventArgs e)
        {
            HintUtils.ShowHint(searchText);

        }

        private void searchText_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(searchText);
        }

        private void EffSauv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = "";

            switch (EffSauv.SelectedIndex)
            {
                case 1:
                    selectedType = "T";
                    break;
                case 0:
                    selectedType = "";

                    break;
            }

            bindingSource = new BindingSource();
            table = helper.selectSales(limit, 1,selectedType);
            bindingSource.DataSource = table;
            soldProducts.DataSource = bindingSource;
        }

        public static bool DeletedBill { get => deletedBill; set => deletedBill = value; }
    }
}
