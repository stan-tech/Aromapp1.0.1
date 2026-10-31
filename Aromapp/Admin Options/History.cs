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
    public partial class History : DevExpress.XtraEditors.XtraForm
    {
        BackgroundWorker worker = new BackgroundWorker();
        DataTable table = new DataTable();
        int limit = 100, currentPage = 1;
        bool searching = false, tableFull = false;
        public History()
        {
            InitializeComponent();

            HistTable.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            HistTable.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(255, 64, 64, 64),
                Font = new System.Drawing.Font("Calibri", 9.25f)
            };

            HistTable.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(63, 81, 181),
                Font = new System.Drawing.Font("Calibri", 9.25f, FontStyle.Bold),
                ForeColor = Color.White
            };
            worker.DoWork += LoadHist;
            worker.RunWorkerCompleted += LoadHisCompleted;

            if (Transaction.Text == "")
            {
                Transaction.Text = "Transaction";
            }
        }

  
        void LoadHist(object sender, DoWorkEventArgs e)
        {

            using (DBHelper helper = new DBHelper())
            {
                table = helper.getHistory(limit, currentPage);
            }
        }
        void LoadHisCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HistTable.Invoke((Action)(() => { HistTable.DataSource = table; }));
        }

        private void History_Shown(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            searching = true;
            using (DBHelper helper = new DBHelper())
            {
                HistTable.DataSource = helper.searchHistory(1, guna2DateTimePicker1.Value.Date.ToString().Replace("/", "-"));
            }
        }

        private void HistTable_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
            {
                int totalHeight = 0;



                foreach (DataGridViewRow row in HistTable.Rows)
                    totalHeight += row.Height;


                if (!searching)
                {

                    if (HistTable.VerticalScrollingOffset == 0 && e.NewValue < e.OldValue)
                    {
                        if (currentPage > 1)
                        {
                            currentPage--;
                            AddTable(currentPage);
                            tableFull = false;

                        }
                        else
                        {
                            AddTable(1);
                        }
                    }

                    if (totalHeight - HistTable.Height < HistTable.VerticalScrollingOffset && HistTable.Rows.Count >= limit)
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

        private void iconButton4_Click(object sender, EventArgs e)
        {
            searching = false;

            using (DBHelper helper = new DBHelper())
            {
                HistTable.DataSource = helper.getHistory(limit, 1);

            }

        }

        private void searchText_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchText.Text))
            {
                HintUtils.ShowHint(searchText);
            }
        }

        private void searchText_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(searchText);
        }

        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searching = true;

                using (DBHelper helper = new DBHelper())
                {
                    HistTable.DataSource = helper.searchHistory(0, searchText.Text.ToLower());
                }

                e.SuppressKeyPress = true;
            }
        }

        private void Transaction_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (DBHelper helper = new DBHelper())
            {
                searching = true;

                switch (Transaction.SelectedIndex)
                {
                    case 0:
                        HistTable.DataSource = helper.searchHistory(2, "Vente");

                        break;
                    case 1:
                        HistTable.DataSource = helper.searchHistory(2, "Achat");

                        break;
                    case 2:
                        HistTable.DataSource = helper.searchHistory(2, "Ajout");

                        break;
                    case 3:
                        HistTable.DataSource = helper.searchHistory(2, "Dette");

                        break;

                }
            }
        }

        List<string> IDs = new List<string>();
        bool rowSelected = false;
        private void HistTable_SelectionChanged(object sender, EventArgs e)
        {
            if (rowSelected)
            {
                IDs = new List<string>();

                for (int i = 0; i < HistTable.SelectedRows.Count; i++)
                {
                    if (HistTable.SelectedRows[i].Cells[0].Value != null)
                    {
                        IDs.Add(HistTable.SelectedRows[i].Cells[0].Value.ToString());

                    }
                }

                if (HistTable.SelectedRows.Count > 1)
                {
                    delete.Text = "Supprimer  " + HistTable.SelectedRows.Count.ToString();

                }
                else
                {
                    delete.Text = "Supprimer  " + HistTable.SelectedRows[0].Cells[0].Value.ToString();

                }
            }
        }

        void PasswoCorrect(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                if (helper.DeleteFromHistory(IDs, all) > 0)
                {
                    delete.Text = delete.Tag.ToString();
                    IDs.Clear();
                    HistTable.DataSource = helper.getHistory(limit, 1);
                }
                else
                {
                    MessageBoxer.showErrorMsg("Une erreur s'est produite");
                }
            }
        }
        bool all = false;
        private void delete_Click(object sender, EventArgs e)
        {
            all = false;
            DeleteCallBack();
        }
        public void DeleteCallBack()
        {
            if (all)
            {
                DialogResult result = MessageBox.Show("  Êtes vous sûr ?", ""
                                                  , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    
                    PasswoCorrect(new object(),EventArgs.Empty);
                    
                }
            }

            else if (IDs.Count > 0)
            {
                DialogResult result = MessageBox.Show("  Êtes vous sûr ?", ""
                                             , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    PasswoCorrect(new object(), EventArgs.Empty);

                }
            }
            else
            {
                MessageBoxer.showGeneralMsg("Selectionnez au moins une ligne");
            }
        }
        private void HistTable_MouseClick(object sender, MouseEventArgs e)
        {
            rowSelected = true;
            HistTable_SelectionChanged(sender, e);

        }

        private void HistTable_Leave(object sender, EventArgs e)
        {
            rowSelected = false;

        }

        private void Transaction_TextChanged(object sender, EventArgs e)
        {
            if(Transaction.Text == "")
            {
                Transaction.Text = "Transaction";
            }
        }

        private void Transaction_Leave(object sender, EventArgs e)
        {
            if (Transaction.Text == "")
            {
                Transaction.Text = "Transaction";
            }
        }

        private void History_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(570, 560);
            this.MaximumSize = new System.Drawing.Size(570, 560);
            this.MinimumSize = new System.Drawing.Size(570, 560);
            guna2DateTimePicker1.Value = DateTime.Now;
            this.CenterToScreen();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            all = true;
            DeleteCallBack();
        }

        public void AddTable(int currentPage)
        {
            BindingSource bindingSource = new BindingSource();
            rowSelected = false;

            using (DBHelper helper = new DBHelper())
            {
                table = helper.getHistory(limit, currentPage);

            }
            bindingSource.DataSource = table;
            HistTable.DataSource = bindingSource;
        }
    }
}