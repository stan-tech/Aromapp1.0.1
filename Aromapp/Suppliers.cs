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
using System.Xml.Linq;

namespace Aromapp
{
    public partial class Suppliers : DevExpress.XtraEditors.XtraUserControl
    {
        BackgroundWorker worker = new BackgroundWorker();
        int limit = 100, currentPage = 1;
        int DebtsNumber;
        DataTable table;

        public Suppliers()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            this.Load += Suppliers_Shown;
            worker.RunWorkerCompleted += worker_workCompleted;
            worker.DoWork += worker_Work;

            suppliersTable.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            suppliersTable.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(255, 64, 64, 64),
                Font = new Font("Calibri", 9.25f)
            };
            suppliersTable.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(63, 81, 181),
                Font = new Font("Calibri", 9.25f, FontStyle.Bold),
                ForeColor = Color.White
            };
            prods.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            prods.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(255, 64, 64, 64),
                Font = new Font("Calibri", 9.25f)
            };
            prods.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(63, 81, 181),
                Font = new Font("Calibri", 9.25f, FontStyle.Bold),
                ForeColor = Color.White
            };


        }

        void worker_Work(object sender, DoWorkEventArgs e)
        {

            table = new DataTable();
            table = DBHelper.GetSuppliers(limit:limit,currentPage:currentPage);

            using (DBHelper helper = new DBHelper())
            {
                DebtsNumber = helper.GetDebtsNumber("a");

            }

        }

        void worker_workCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            suppliersTable.DataSource = table;
            DebtsText.Text = DebtsNumber.ToString();
            SuppsNumber.Text = table.Rows.Count.ToString();


        }

        private void suppliersTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            iconButton5_Click(sender, e);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            string id = suppliersTable.SelectedRows[0].Cells[0].Value.ToString();
            if (id!="1")
            {
                if (!string.IsNullOrEmpty(id))
                {
                    EditSupplierForm editSupplierForm = new EditSupplierForm(id);
                    editSupplierForm.ShowDialog();
                } 
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string id = suppliersTable.SelectedRows[0].Cells[0].Value.ToString();

            if (id != "1")
            {
                DialogResult result = MessageBox.Show("  Êtes vous sûr ?", ""
                                       , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (DBHelper helper = new DBHelper())
                    {
                        helper.DeleteSupplier(id);
                        suppliersTable.DataSource = DBHelper.GetSuppliers(limit, currentPage);
                    }
                }
            }
            else
            {
                MessageBoxer.showGeneralMsg("Vous ne pouvez pas supprimer cet élément, c'est le fournisseur par défaut");
            }
        }

        private void Ajouter_Click(object sender, EventArgs e)
        {
            AddSupplier addSupplier = new AddSupplier();
            addSupplier.ShowDialog();

        }

        private void Suppliers_Shown(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }

        private void Debts_MouseEnter(object sender, EventArgs e)
        {
            DebtsText.ForeColor = Color.Blue;
        }

        private void Debts_MouseLeave(object sender, EventArgs e)
        {
            DebtsText.ForeColor = Color.White;
        }
        private void DebtsText_Click(object sender, EventArgs e)
        {
            Debts debts = new Debts();
            debts.ClientsDebt = false;

            debts.ShowDialog();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            table = DBHelper.GetSuppliers(limit, 1);
            suppliersTable.DataSource = table;
            SuppsNumber.Text = table.Rows.Count.ToString();
            DebtsText.Text = DebtsNumber.ToString();

        }

        private void suppliersTable_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                iconButton1_Click(sender, e);
            }
        }

        private void searchText_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(searchText);
        }

        private void searchText_Leave(object sender, EventArgs e)
        {
            HintUtils.ShowHint(searchText);
        }

        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {

                using (DBHelper helper = new DBHelper())
                {
                    suppliersTable.DataSource = helper.searchSuppliers(searchText.Text);
                }


                e.SuppressKeyPress = true;
            }
        }

        private void clientsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Supplier s = DBHelper.GetSupplier(suppliersTable.SelectedRows[0].Cells[0].Value.ToString());

            NameText.Text = s.Nom;
            PhoneText.Text = s.Tel;
            act.Text = s.Activite;
            AddrText.Text = s.Adresse;
            date.Text = s.DateAjout;

            if (!string.IsNullOrEmpty(suppliersTable.SelectedRows[0].Cells[0].Value.ToString()))
            {
                using (DBHelper helper = new DBHelper())
                {
                    prods.DataSource = helper.SelectProductBySupplierID(s.C_fr);
                    dettes.Text = helper.GetDebtsByID(s.C_fr).ToString();
                    TotalAchat.Text = helper.GetTotalSupplierPurchases(s.C_fr).ToString();
                } 
            }
        }
    }
}
