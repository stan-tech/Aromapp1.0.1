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
using ZXing.Common;
using ZXing;

namespace Aromapp
{
    public partial class StockForm : DevExpress.XtraEditors.XtraUserControl
    {

        BackgroundWorker worker;
        DataTable table = new DataTable();
        int limit = 100;
        int currentPage = 1;
        public StockForm()
        {
            InitializeComponent();
            this.Load += StockForm_Shown;
            invTable.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            invTable.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(255, 64, 64, 64),
                Font = new System.Drawing.Font("Calibri", 9.25f)
            };

            invTable.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(63, 81, 181),
                Font = new System.Drawing.Font("Calibri", 9.25f, FontStyle.Bold),
                ForeColor = Color.White
            };
            worker = new BackgroundWorker();
            worker.DoWork += LoadData;
            worker.RunWorkerCompleted += LoadDataCompleted;

            if (Tyype.Text == "")
            {
                Tyype.Text = "Type";
            }
        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Tyype.Text))
            {
                Tyype.Text = "Type";

            }
        }

        private void StockForm_Shown(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }
        string NumberOfProducts, ShortageNumber;
        bool searching = false, tableFull = false;
        void LoadData(object sender, DoWorkEventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                table = helper.GetInventory(limit, currentPage);
                NumberOfProducts = helper.GetScarceProductsNumber(out ShortageNumber);

            }
        }
        private void generateBarcode(PictureBox pB, string ID)
        {
            string labelText = "";
            using (DBHelper helper = new DBHelper())
            {
                labelText = helper.getProductBarcode(ID);

            }
            int width = QR.Width - 10;
            int height = QR.Height - 10;

            EncodingOptions options = new EncodingOptions
            {
                Width = width,
                Height = height
            };

            BarcodeWriter barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE
            };

            try
            {
                barcodeWriter.Options = options;
                Bitmap barcodeImage = barcodeWriter.Write(labelText);
                pB.Image = barcodeImage;
            }
            catch (Exception)
            {
                MessageBoxer.showGeneralMsg("Code-QR non disponible");
            }

        }
        void LoadDataCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            invTable.Invoke((Action)(() => {

                invTable.DataSource = table;
            }));

            articleN.Invoke((Action)(() => { articleN.Text = NumberOfProducts; }));
            shortageN.Invoke((Action)(() => { shortageN.Text = ShortageNumber; }));

        }

        private void invTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (invTable.SelectedRows[0].Cells[1].Value!=null)
            {
                double entre = double.Parse(invTable.SelectedRows[0].Cells[3].Value.ToString())
                      , sortie = double.Parse(invTable.SelectedRows[0].Cells[4].Value.ToString())
                      , achat = double.Parse(invTable.SelectedRows[0].Cells[5].Value.ToString())
                      , vente = double.Parse(invTable.SelectedRows[0].Cells[2].Value.ToString());

                NameText.Text = invTable.SelectedRows[0].Cells[1].Value.ToString();
                VenteText.Text = sortie.ToString();
                AchatText.Text = entre.ToString();
                date.Text = DBHelper.getAddedDate(invTable.SelectedRows[0].Cells[0].Value.ToString());
                retenus.Text = ((vente - achat) * sortie).ToString() + " " + retenus.Tag.ToString();
                generateBarcode(QR, invTable.SelectedRows[0].Cells[0].Value.ToString()); 
            }

        }
        public void Search()
        {

            using (DBHelper helper = new DBHelper())
            {
                if (searchText.Text != searchText.Tag.ToString())
                {
                    invTable.DataSource = helper.searchForItem(searchText.Text.ToLower());

                }
            }
        }

        
        private void Tyype_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper();

            switch (Tyype.SelectedIndex)
            {

                case 0:
                    invTable.DataSource = helper.GetStockByType("%%", 100, 1);
                    break;
                default:
                    invTable.DataSource = helper.GetStockByType(Tyype.SelectedItem.ToString().Trim(), 100, 1);

                    break;
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

        private void Ajouter_Click(object sender, EventArgs e)
        {
            History history = new History();
            history.ShowDialog();
        }

        private void shortageN_MouseEnter(object sender, EventArgs e)
        {
            shortageN.ForeColor = Color.Blue;

        }

        private void shortageN_MouseLeave(object sender, EventArgs e)
        {
            shortageN.ForeColor = Color.White;

        }

        private void shortageN_Click(object sender, EventArgs e)
        {
            ScarceProducts sp = new ScarceProducts();
            sp.ShowDialog();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                invTable.DataSource = helper.GetInventory(limit, 1);

                NumberOfProducts = helper.GetScarceProductsNumber(out ShortageNumber);

                shortageN.Text = ShortageNumber;
                articleN.Text = NumberOfProducts;
            }

        }

        private void invTable_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
            {
                int totalHeight = 0;



                foreach (DataGridViewRow row in invTable.Rows)
                    totalHeight += row.Height;


                if (!searching)
                {

                    if (invTable.VerticalScrollingOffset == 0 && e.NewValue < e.OldValue)
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
                    if (totalHeight - invTable.Height < invTable.VerticalScrollingOffset && invTable.Rows.Count >= limit)
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

        private void iconButton5_Click(object sender, EventArgs e)
        {
            if (invTable.SelectedRows[0].Cells[0].Value != null)
            {
                Product ne = new Product();
                ne.ID = invTable.SelectedRows[0].Cells[0].Value.ToString();
                ProdView prod = new ProdView(ne);

                prod.ShowDialog();

            }
        }

        string selectedID;
        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (invTable.SelectedRows[0].Cells[0].Value != null)
            {
                selectedID = invTable.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult result = MessageBox.Show("  Êtes vous sûr ?", ""
                                     , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (DBHelper helper = new DBHelper())
                    {
                        if (helper.DeleteProducts(new List<string>() { selectedID }) > 0)
                        {
                            if (helper.DeleteFromStock(selectedID) > 0)
                            {
                                MessageBoxer.showGeneralMsg("Article supprimé");

                            }
                            else
                            {
                                MessageBoxer.showErrorMsg("Une erreur s'est produite");

                            }
                        }
                        else
                        {
                            MessageBoxer.showErrorMsg("Une erreur s'est produite");

                        }
                    }
                }
            }
            else
            {
                MessageBoxer.showGeneralMsg("Selectionnez au moins une ligne");

            }

        }

        private void Tyype_Leave(object sender, EventArgs e)
        {
            if (Tyype.Text == "")
            {
                Tyype.Text = "Type";
            }
        }

        private void Tyype_TextChanged(object sender, EventArgs e)
        {
            if (Tyype.Text == "")
            {
                Tyype.Text = "Type";
            }
        }

        public void AddTable(int currentPage)
        {
            BindingSource bindingSource = new BindingSource();

            using (DBHelper helper = new DBHelper())
            {
                table = helper.GetInventory(limit, currentPage);

            }
            bindingSource.DataSource = table;
            invTable.DataSource = bindingSource;
        }

        public void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
                e.SuppressKeyPress = true;


            }

        }

    }
}
