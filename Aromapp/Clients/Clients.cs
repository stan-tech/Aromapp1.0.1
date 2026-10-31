using DevExpress.XtraEditors;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aromapp
{
    public partial class Clients : DevExpress.XtraEditors.XtraUserControl
    {

        BackgroundWorker worker;
        DataTable table;

        int client_number;
        int limit = 100;
        int currentPage = 1;
        Size currentSize;
        bool searching = false, tableFull = false;


        public Clients()
        {
            InitializeComponent();
            this.Load += Clients_Shown;
            currentSize = this.Size;
            clientsTable.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            clientsTable.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = System.Drawing.Color.White,
                SelectionBackColor = System.Drawing.Color.FromArgb(255, 64, 64, 64),
                Font = new Font("Calibri", 9.25f)
            };
            clientsTable.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = System.Drawing.Color.FromArgb(63, 81, 181),
                Font = new Font("Calibri", 9.25f, FontStyle.Bold),
                ForeColor = System.Drawing.Color.White
            };

            worker = new BackgroundWorker();
            worker.DoWork += LoadDataInBackground;
            worker.RunWorkerCompleted += LoadingCompleted;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Clients_Load(object sender, EventArgs e)
        {

        }

        int debts = 0;
        void LoadDataInBackground(object sender, DoWorkEventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                table = helper.GetClients(limit, currentPage);
                client_number = helper.GetClientsNumber();
                debts = helper.GetDebtsNumber("v");
            }

        }


        void LoadingCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            clientsTable.DataSource = table;
            ClientsNumber.Text = client_number.ToString();
            Debts.Text = debts.ToString();
        }

        private void Clients_Shown(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }

        private void Debts_MouseEnter(object sender, EventArgs e)
        {
            Debts.ForeColor = System.Drawing.Color.Blue;
        }

        private void Debts_MouseLeave(object sender, EventArgs e)
        {
            Debts.ForeColor = System.Drawing.Color.White;
        }

        private void Debts_Click(object sender, EventArgs e)
        {
            Debts debts = new Debts();
            debts.ClientsDebt = true;

            debts.ShowDialog();
        }

        BindingSource bindingSource;

        private void search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchText.Text))
            {
                HintUtils.ShowHint(searchText);
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(searchText);
        }

        private void clientsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = clientsTable.SelectedRows[0];
            string clientID = clientsTable.SelectedRows[0].Cells[0].Value.ToString();
            List<string> MostBuyedprods;
            using (DBHelper helper = new DBHelper())
            {
                dettes.Text = helper.GetTotalClientDebt(clientID).ToString();
                date.Text =(!string.IsNullOrEmpty(row.Cells[5].Value.ToString()))? 
                    DateTime.Parse(row.Cells[5].Value.ToString()).ToString("dd/MM/yyyy"): "Non disponible";
                MostBuyedprods = helper.GetMostBuyedProducts(clientID);
                mostbuyed.Text = string.Join(", ", MostBuyedprods);

                if (mostbuyed.Text.Length == 0)
                {
                    mostbuyed.Text = "Non disponible";
                }
                TotalAchat.Text = helper.GetTotalClientPurchases(clientID).ToString();
            }


            custAddrText.Text = (row.Cells[4].Value != null)?row.Cells[4].Value.ToString():"Non disponible";
            custPhoneText.Text = (row.Cells[2].Value != null)?row.Cells[2].Value.ToString() : "Non disponible";
            custNameText.Text = (row.Cells[1].Value != null)?row.Cells[1].Value.ToString() : "Non disponible";

        }

        private void Ajouter_Click(object sender, EventArgs e)
        {
            AddClient addClient = new AddClient();

            addClient.ShowDialog();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                clientsTable.DataSource = helper.GetClients(limit, 1);
                ClientsNumber.Text = helper.GetClientsNumber().ToString();
                Debts.Text = helper.GetDebtsNumber("v").ToString();

            }
        }

        private void searchText_IconRightClick(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                clientsTable.DataSource = helper.searchClients(searchText.Text, false);
            }
        }

        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchText_IconRightClick(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        public void AddTable(int currentPage)
        {
            bindingSource = new BindingSource();
            using (DBHelper helper = new DBHelper())
            {
                table = helper.GetClients(limit, currentPage);

            }
            bindingSource.DataSource = table;
            clientsTable.DataSource = bindingSource;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            string s = clientsTable.SelectedRows[0].Cells[0].Value.ToString();

            if (clientsTable.SelectedRows.Count > 0)
            {
                if (s.ToLower()!="x")
                {
                    EditClient editClient = new EditClient(s);

                    editClient.ShowDialog();
                }
                else
                {
                    MessageBoxer.showGeneralMsg("Cette ligne n'est pas modifiable");
                }

            }
            else
            {
                MessageBoxer.showGeneralMsg("Veuillez selectionner un client");
            }
        }

        string DeleteID;
        private void PasswoCorrectDelete(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                helper.DeleteClient(DeleteID);
                clientsTable.DataSource = helper.GetClients(limit, 1);


            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            DeleteID = clientsTable.SelectedRows[0].Cells[0].Value.ToString();

            if (DeleteID != null)
            {
                DialogResult result = MessageBox.Show("  Êtes vous sûr ?", ""
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    Confirm confirm = new Confirm();
                    confirm.Passed += PasswoCorrectDelete;

                    confirm.ShowDialog();


                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBoxer.showGeneralMsg("Veuillez selectionner un client");
            }
        }

        private void loyalBtn_Click(object sender, EventArgs e)
        {
            LoyalClients loyals = new LoyalClients();
            loyals.ShowDialog();
        }

        private void clientsTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X,Cursor.Position.Y);
        }

        private void clientsTable_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                iconButton1_Click(sender, e);
            }
        }

        private void historiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string c_cl = clientsTable.SelectedRows[0].Cells[0].Value.ToString();
            ClientHistory history = new ClientHistory(c_cl);
            history.ShowDialog();
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = clientsTable.SelectedRows[0].Cells[0].Value.ToString();
            if (!string.IsNullOrEmpty(s))
            {
                if (s.ToLower() != "x")
                {
                    EditClient editClient = new EditClient(s);

                    editClient.ShowDialog();
                }
                else
                {
                    MessageBoxer.showGeneralMsg("Cette ligne n'est pas modifiable");
                }
            }
        }

        private void clientsTable_Scroll(object sender, ScrollEventArgs e)
        {
            int totalHeight = 0;



            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
            {
                foreach (DataGridViewRow row in clientsTable.Rows)
                    totalHeight += row.Height;


                if (!searching)
                {

                    if (clientsTable.VerticalScrollingOffset == 0 && e.NewValue < e.OldValue)
                    {
                        if (currentPage > 1)
                        {
                            currentPage--;
                            AddTable(currentPage);

                        }
                        else
                        {
                            AddTable(1);
                        }
                    }

                    if (totalHeight - clientsTable.Height < clientsTable.VerticalScrollingOffset)
                    {
                        if (currentPage == 1)
                        {
                            AddTable(currentPage);

                        }
                        else if (currentPage != 1 && !tableFull)
                        {
                            AddTable(currentPage);

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
    }
}
