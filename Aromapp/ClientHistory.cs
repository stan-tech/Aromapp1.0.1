using DevExpress.Data.Helpers;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Aromapp
{
    public partial class ClientHistory : DevExpress.XtraEditors.XtraForm
    {
        public string C_CL { get; set; }
        BackgroundWorker worker;
        DataTable table;
        Client client;
        bool saved = false;
        public ClientHistory(string c_cl)
        {
            C_CL = c_cl;
            worker = new BackgroundWorker();
            worker.DoWork += LoadData;
            worker.RunWorkerCompleted += LoadDataCompleted;
            InitializeComponent();

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
                Font = new Font("Calibri", 9.25f, System.Drawing.FontStyle.Bold),
                ForeColor = Color.White
            };

        }

        private void ClientHistory_Load(object sender, EventArgs e)
        {
            custRef.Text = C_CL;
            
            Bon.Checked = true;

            using(DBHelper helper = new DBHelper())
            {
                 client = helper.selectClientInfo(C_CL);

                dettes.Text = helper.GetTotalClientDebt(C_CL).ToString("F2")+" DA";

                TotalAchat.Text = helper.GetTotalClientPurchases(C_CL).ToString("F2")+" DA";
                
            }
            custNameText.Text = client.Nom;

            worker.RunWorkerAsync();
        }
        void LoadData(object sender, DoWorkEventArgs e)
        {
            table = new DataTable();

            using (DBHelper helper = new DBHelper())
            {
                table = helper.getSalesByClientID(C_CL, saved, Bon.Checked);

            }   
        }
        void LoadDataCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            soldProducts.DataSource = table;
        }

        private void Factures_Click(object sender, EventArgs e)
        {
            Factures.Checked = true;

            if (Bon.Checked)
            {
                Bon.Checked = false;
            }

            using (DBHelper helper = new DBHelper())
            {
                soldProducts.DataSource = helper.getSalesByClientID(C_CL, saved, Bon.Checked);

            }

        }

        private void EffSauv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(EffSauv.SelectedIndex==0)
            {
                saved = false;
            }
            else
            {
                saved = true;
            }

            using (DBHelper helper = new DBHelper())
            {
                soldProducts.DataSource = helper.getSalesByClientID(C_CL, saved, Bon.Checked);

            }
        }

        private void Bon_Click(object sender, EventArgs e)
        {
            Bon.Checked = true;

            if (Factures.Checked)
            {
                Factures.Checked = false;
            }

            using (DBHelper helper = new DBHelper())
            {
                soldProducts.DataSource = helper.getSalesByClientID(C_CL, saved, Bon.Checked);

            }

        }

        void RefreshTable(object sender, FormClosedEventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                soldProducts.DataSource = helper.getSalesByClientID(C_CL, saved, Bon.Checked);

            }
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
                sale.MontantRegler = decimal.Parse(soldProducts.SelectedRows[0].Cells[9].Value.ToString());
                sale.MontantRest = decimal.Parse(soldProducts.SelectedRows[0].Cells[10].Value.ToString());
                Client client = this.client;
                client.C_CL = C_CL;

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

        public void RefreshInfo(object sender,EventArgs e)
        {
            ClientHistory_Load(new object(),e);
            using (DBHelper helper = new DBHelper())
            {
                soldProducts.DataSource = helper.getSalesByClientID(C_CL, saved, Bon.Checked);

            }
        }
        private void iconButton4_Click(object sender, EventArgs e)
        {
            Lend lend = new Lend(C_CL);
            lend.Done += RefreshInfo;
            lend.ShowDialog();
        }
    }
}