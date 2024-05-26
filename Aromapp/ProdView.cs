using DevExpress.XtraEditors;
using iTextSharp.text.pdf.qrcode;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.Common;
using ZXing;
using Org.BouncyCastle.Crypto;
using System.Collections.ObjectModel;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Aromapp
{
    public partial class ProdView : DevExpress.XtraEditors.XtraForm
    {
        Product product { get; set; }
        string barcodeText;
        public ProdView(Product product)
        {
            InitializeComponent();

            using (DBHelper helper = new DBHelper())
            {
                product = helper.GetProductByID(product.ID.Contains("PR") ? "produits" : "emballage", product.ID);
                this.product = product;
                barcodeText = helper.getProductBarcode(product.ID);


            }
            MaingroupBox.Text = MaingroupBox.Tag.ToString() + " " + product.ID;
            pSuppText.Text = product.SupplierName;
            pNameText.Text = product.Name;
            quantityText.Text = product.Quantity.ToString();
            sppuText.Text = product.PriceG.ToString();
            rsppu.Text = product.PriceD.ToString();

            dateAddedText.Text = DBHelper.getAddedDate(product.ID);

            bppuText.Text = product.PriceP.ToString();

            generateBarcode(barcodeText);

            BARCODE.Text = barcodeText;
            SA.Text = product.StockAlert.ToString();


            switch (product.Unit)
            {
                case "U":

                    Unit.SelectedIndex = 0;
                    break;

                case "L":
                    Unit.SelectedIndex = 1;

                    break;
                case "G":
                    Unit.SelectedIndex = 2;

                    break;
                case "K":
                    Unit.SelectedIndex = 3;

                    break;
                case "M":
                    Unit.SelectedIndex = 4;

                    break;
            }
            switch (product.Type.ToLower())
            {
                case "homme":
                    Tyype.SelectedIndex = 0;

                    break;

                case "femme":
                    Tyype.SelectedIndex = 1;

                    break;
                case "unisexe":
                    Tyype.SelectedIndex = 2;

                    break;
                case "emballage":
                    Tyype.SelectedIndex = 3;

                    break;
                case "sachet":
                    Tyype.SelectedIndex = 4;

                    break;
            }
        }
        public void RefreshForm()
        {
            using (DBHelper helper = new DBHelper())
            {
                product = helper.GetProductByID(product.ID.Contains("PR") ? "produits" : "emballage", product.ID);

            }

            pSuppText.Text = product.SupplierName;
            pNameText.Text = product.Name;
            quantityText.Text = product.Quantity.ToString();
            sppuText.Text = product.PriceG.ToString();
            rsppu.Text = product.PriceD.ToString();

            dateAddedText.Text = DBHelper.getAddedDate(product.ID);

            bppuText.Text = product.PriceP.ToString();
            SA.Text = product.StockAlert.ToString();

            switch (product.Unit)
            {
                case "Unité":

                    Unit.SelectedIndex = 0;
                    break;

                case "Litre":
                    Unit.SelectedIndex = 1;

                    break;
                case "Gramme":
                    Unit.SelectedIndex = 2;

                    break;
                case " Kilogramme":
                    Unit.SelectedIndex = 3;

                    break;
                case "Mètre":
                    Unit.SelectedIndex = 4;

                    break;
            }
            switch (product.Type)
            {
                case "Parfum / Homme":
                    Tyype.SelectedIndex = 0;

                    break;

                case "Parfum / Femme":
                    Tyype.SelectedIndex = 1;

                    break;
                case "Parfum / Unisexe":
                    Tyype.SelectedIndex = 2;

                    break;
                case " Emabllage":
                    Tyype.SelectedIndex = 3;

                    break;
                case "Sachet":
                    Tyype.SelectedIndex = 4;

                    break;
            }

        }

        private void generateBarcode(string barcodeText)
        {


            int width = pictureBox1.Width - 20;
            int height = pictureBox1.Height - 20;

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
                Bitmap barcodeImage = barcodeWriter.Write(barcodeText);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = barcodeImage;

            }
            catch (Exception)
            {
                MessageBoxer.showGeneralMsg("Code-QR non disponible");
            }

        }
        private void ProdView_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(770, 660);

            MaximumSize = new System.Drawing.Size(770, 660);
            MinimumSize = new System.Drawing.Size(770, 660);

            this.CenterToScreen();

            if (string.IsNullOrWhiteSpace(Unit.Text))
            {
                Unit.Text = "Unité";
            }
            if (string.IsNullOrWhiteSpace(Tyype.Text))
            {
                Tyype.Text = "Type";

            }

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string selectedColumn = "";
        bool supplierSearch = false;
        private void updateChoiceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplierSearch = false;

            switch (updateChoiceBox.SelectedIndex)
            {
                case 0:
                    selectedColumn = "c_pr";
                    amount_Click(sender, e);
                    amount.Text = pSuppText.Text;
                    break;
                case 1:
                    selectedColumn = "nom";
                    amount_Click(sender, e);
                    amount.Text = pNameText.Text;
                    break;
                case 2:
                    selectedColumn = "q_stock";
                    amount_Click(sender, e);
                    amount.Text = quantityText.Text;
                    break;
                case 3:
                    selectedColumn = "prix_achat";
                    amount_Click(sender, e);
                    amount.Text = bppuText.Text;
                    break;
                case 5:
                    selectedColumn = "prix_venteHT";
                    amount_Click(sender, e);
                    amount.Text = rsppu.Text;
                    break;
                case 4:
                    selectedColumn = "prixvgros";
                    amount_Click(sender, e);
                    amount.Text = sppuText.Text;
                    break;
                case 6:
                    selectedColumn = "stock_alerte";
                    amount_Click(sender, e);
                    amount.Text = SA.Text;
                    break;
                case 7:
                    supplierSearch = true;
                    selectedColumn = "c_fr";
                    amount_Click(sender, e);
                    amount.Text = pSuppText.Text;
                    break;
            }


        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            string c_fr = product.c_fr;

            if (selectedColumn == "c_fr")
            {
                using (DBHelper helper = new DBHelper())
                {
                    
                    helper.getSupplierID(amount.Text,out c_fr);

                    if (!string.IsNullOrEmpty(amount.Text))
                    {
                        if (!helper.getSupplierID(amount.Text, out c_fr))
                        {
                            c_fr = DBHelper.generateID("FR", Tables.Fourniseur);
                            helper.InsertSupplier(new Supplier(c_fr, amount.Text));
                        } 
                    }
                   
                }
            }

            if (!string.IsNullOrEmpty(selectedColumn))
            {
                using (DBHelper helper = new DBHelper())
                {
                    try
                    {
                        if (helper.ModifyProduct(selectedColumn, (!supplierSearch)?amount.Text:c_fr, MaingroupBox.
                            Text.Replace(MaingroupBox.Tag.ToString(),"")))
                        {
                            MessageBoxer.showGeneralMsg("Produit modifié");

                            RefreshForm();

                        }
                    }
                    catch (Exception)
                    {

                        MessageBoxer.showErrorMsg("Valeur non supportée!");
                    }

                }
            }
            else
            {
                MessageBoxer.showGeneralMsg("Choisissez la valeur à modifier");
            }
        }

        private void amount_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(amount);

        }

        private void amount_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(amount.Text))
            {
                HintUtils.ShowHint(amount);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("  Êtes vous sûr ?", ""
                                     , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            List<string> prodIDs = new List<string> { pSuppText.Text };

            if (result == DialogResult.Yes)
            {


                using (DBHelper helper = new DBHelper())
                {
                    if (helper.DeleteProducts(prodIDs) > 0)
                    {

                        MessageBoxer.showGeneralMsg("Produit supprimé");

                        this.Close();

                    }
                }

            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            string BarCodePref;
            string Barcode;
            if (string.IsNullOrEmpty(barcodeText))
            {
                using (DBHelper helper = new DBHelper())
                {
                    BarCodePref = helper.getStoreBarCode();


                    Barcode = BarCodePref + DateTime.Now.Year + DateTime.Now.Month +
                         DateTime.Now.Day + product.ID.Replace("PR", "").TrimStart('0');
                    generateBarcode(Barcode);


                }


                using (SQLiteConnection connection = new SQLiteConnection(DBHelper.connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand("update produits set c_bare = '" + Barcode + "' where c_prd= '" +
                        pSuppText.Text + "';", connection))
                    {
                        connection.Open();
                        if (command.ExecuteNonQuery() > 0)
                        {
                            connection.Close();

                            MessageBoxer.showGeneralMsg("QR Généré");

                        }
                        else
                        {
                            connection.Close();

                            MessageBoxer.showErrorMsg("Une erreur s'est produite");
                        }

                    }

                }
            }
            else
            {
                MessageBoxer.showGeneralMsg("Le code QR existe déjà");

            }

        }
        Dictionary<string, string> ids;
        AutoCompleteStringCollection collection;

        private void amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !supplierSearch)
            {
                if (!string.IsNullOrEmpty(amount.Text))
                {
                    iconButton3_Click(sender, e);
                }
                e.SuppressKeyPress = true;
            }
        }

        private void amount_TextChanged(object sender, EventArgs e)
        {
            if (supplierSearch)
            {
                using (DBHelper helper = new DBHelper())
                {
                    collection = helper.GetSupplierNames(amount.Text, out ids);
                }


                try
                {
                    if (string.IsNullOrEmpty(amount.Text))
                    {
                        amount.BeginInvoke((Action)(() =>
                        {


                            amount.AutoCompleteCustomSource = collection;
                            amount.AutoCompleteMode = AutoCompleteMode.Suggest;
                            amount.AutoCompleteSource = AutoCompleteSource.CustomSource;

                        }));



                    }
                }
                catch (Exception ex)
                {

                    System.Windows.Forms.MessageBox.Show("An error occurred: " + ex.Message);
                } 
            }
        }
    }
}