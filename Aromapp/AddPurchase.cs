using DevExpress.Data.Mask.Internal;
using DevExpress.XtraEditors;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Aromapp
{
    public partial class AddPurchase : DevExpress.XtraEditors.XtraForm
    {
        NumberFormatInfo nfi;
        string BarCodePref;
        public event EventHandler QTChanged;
        string SelectedTable = "produits";

        public AddPurchase()
        {
            InitializeComponent();

            CartTable.Columns.Clear();
            CartTable.Columns.AddRange(new DataColumn[9] { new DataColumn("Ref"),new DataColumn("Date"),
                new DataColumn("Ref produits"),new DataColumn("Nom de produits"),new DataColumn("Unité"),
                new DataColumn("Prix"), new DataColumn("Quantité"), new DataColumn("Montant HT") , new DataColumn("À vendre") }); ;

            tva.SelectedIndex = 0;
            prodName.Leave += prodLeave;
            prodRef.Leave += prodRefLeave;

            priceP.Leave += pricePLeave;

            priceSD.Leave += priceSDLeave;
            priceSG.Leave += priceSGLeave;
            QT.Leave += QTLeave;
            Amount.Leave += AmountLeave;
            suppName.Leave += suppNameLeave;

            prodName.Click += prodClick;

            priceP.Click += pricePClick;

            priceSD.Click += priceSDClick;
            priceSG.Click += priceSGClick;


            QT.Click += QTClick;
            Amount.Click += AmountClick;
            suppName.Click += suppNameClick;



            nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ",";

            using (helper = new DBHelper())
            {
                BarCodePref = helper.getStoreBarCode();
            }
        }




        string selectedType = string.Empty, selectedUnit = string.Empty;
        public static DataTable CartTable = new DataTable
               ();
        DBHelper helper = new DBHelper();
        bool billlAdded = false;

        List<PurchaseLine> purchases = new List<PurchaseLine>();
        PurchaseLine purchaseLine = new PurchaseLine();

        #region Hints


        void prodLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(prodName.Text))
            {
                HintUtils.ShowHint(prodName);

            }
        }
        void prodRefLeave(object sender, EventArgs e)
        {
            HintUtils.ShowHint(prodRef);
        }
        void pricePLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(priceP.Text))
            {
                HintUtils.ShowHint(priceP);

            }
        }
        void priceSDLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(priceSD.Text))
            {
                HintUtils.ShowHint(priceSD);

            }
        }
        void priceSGLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(priceSG.Text))
            {
                HintUtils.ShowHint(priceSG);

            }
        }
        void QTLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(QT.Text))
            {
                HintUtils.ShowHint(QT);

            }
        }
        void AmountLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Amount.Text))
            {
                HintUtils.ShowHint(Amount);

            }
        }
        void suppNameLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(suppName.Text))
            {
                suppName.Text = suppName.Tag.ToString();
                suppName.ForeColor = Color.Gray;

            }
        }
        void prodClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(prodName);

        }
     
        void pricePClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(priceP);
        }
        void priceSDClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(priceSD);
        }
        void priceSGClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(priceSG);
        }

        void QTClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(QT);
        }
        void suppNameClick(object sender, EventArgs e)
        {
            if(suppName.Text == suppName.Tag.ToString())
            {
                suppName.Text = "";
                suppName.ForeColor = Color.Black;


            }
        }
        void AmountClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(Amount);
        }

        #endregion

        public virtual void OnQTChanged(EventArgs e)
        {

            EventHandler eh = QTChanged;
            if (eh != null)
            {
                eh(this, e);


            }
        }

        public void ClearTexts()
        {
            priceP .Text= "";
            prodName.Text = "";
            priceSD.Text = "";
            priceSG.Text = "";
            QT.Text = "";
            Amount.Text = "";
            prodRef.Text = "";

            HintUtils.ShowHint(priceP);
            HintUtils.ShowHint(prodName);
            HintUtils.ShowHint(prodRef);

            HintUtils.ShowHint(priceSD);
            HintUtils.ShowHint(priceSG);
            HintUtils.ShowHint(QT);
            suppName.Text = suppName.Tag.ToString();
            suppName.ForeColor = Color.Gray;
            HintUtils.ShowHint(Amount);
          




        }



        private void AddPurchase_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(825, 678);

            this.CenterToScreen();

            if (string.IsNullOrWhiteSpace(Unit.Text))
            {
                Unit.Text = "Unité";
            }
            if (string.IsNullOrWhiteSpace(Typpe.Text))
            {
                Typpe.Text = "Type";

            }
            if (string.IsNullOrWhiteSpace(tva.Text))
            {
                tva.Text = "TVA";
            }

        }

        private void Unit_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Unit.Text))
            {
                Unit.Text = "Unité";

            }
        }

        private void Type_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Typpe.Text))
            {
                Typpe.Text = "Type";

            }
        }

        private void priceSG_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(priceSG);

        }
  

        List<Product> prodCart = new List<Product>();
        public void AddToCart()
        {
            double price;
            string prodID = (SelectedTable == "produits") ?
                    "PR" + int.Parse(prodRef.Text).ToString("D4") :
                    "FL" + int.Parse(prodRef.Text).ToString("D4");

            purchaseLine.PrixVG = double.Parse(priceSG.Text.Replace(".", ","));
            purchaseLine.PrixVD = double.Parse(priceSD.Text.Replace(".", ","));
            purchaseLine.Quantité = double.Parse(QT.Text.Replace(".", ","));
            purchaseLine.Unit = Unit.SelectedItem.ToString();
            purchaseLine.Type = "Bon";
            purchaseLine.C_PR = prodID;
            purchaseLine.Nomproduit = prodName.Text;
            purchaseLine.PrixHT = double.Parse(priceP.Text.Replace(".", ","));
            purchaseLine.avendre = avendre.Checked;

            purchaseLine.DateA = DateTime.Now.Date;


            nettotalText.Text = (double.Parse(nettotalText.Text.ToString()) +
                (purchaseLine.Quantité * purchaseLine.PrixHT)).ToString();

            product.ID = prodID;
            product.PriceP = purchaseLine.PrixHT;
            product.Name = purchaseLine.Nomproduit;
            product.Unit = purchaseLine.Unit;
            product.Quantity = purchaseLine.Quantité;
            product.BarCode = BarCodePref + DateTime.Now.Year + DateTime.Now.Month +
                DateTime.Now.Day + product.ID.Replace("PR", "").TrimStart('0');

            string suppID;
            helper.getSupplierID(suppName.Text, out suppID);
            product.c_fr = suppID;


            if (string.IsNullOrEmpty(product.c_fr))
            {
                product.c_fr = DBHelper.generateID("FR", Tables.Fourniseur);
                Supplier supplier = new Supplier(product.c_fr, suppName.Text);

                using (DBHelper helper = new DBHelper())
                {
                    helper.InsertSupplier(supplier);

                }     
            }

            if (Typpe.SelectedItem != null)
            {
                product.Type = Typpe.SelectedItem.ToString();

            }
            else
            {
                MessageBoxer.showGeneralMsg("Séléctionnez un type");
                return;
            }
            product.StockAlert = double.Parse(StockAlert.Text.Replace(".", ","));

            prodCart.Add(product);


            if (!double.TryParse(priceP.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out price))
            {
                purchaseLine.PrixHT = double.Parse(priceP.Text.Trim());
            }
            else
            {
                purchaseLine.PrixHT = double.Parse(purchaseLine.PrixHT.ToString().Replace(".", ","));

            }

            purchaseLine.PrixVG = double.Parse(priceSG.Text);
            purchaseLine.PrixVD = double.Parse(priceSD.Text);
            purchaseLine.Quantité = double.Parse(QT.Text);
            purchaseLine.MontantHT = purchaseLine.PrixHT * purchaseLine.Quantité;
            purchaseLine.Unit = Unit.SelectedItem.ToString();
            purchaseLine.Type = Typpe.SelectedItem.ToString();
            purchaseLine.Nomproduit = prodName.Text;



            CartTable.Rows.Add(purchaseLine.N, purchaseLine.DateA.ToString().Replace("00;00;00", ""), purchaseLine.C_PR, purchaseLine.Nomproduit
            , purchaseLine.Unit, purchaseLine.PrixHT, purchaseLine.Quantité, purchaseLine.MontantHT, purchaseLine.avendre);

            PurchaseLine line = purchaseLine;

            purchases.Add(line);
            cart.DataSource = CartTable;
            purchaseLine = new PurchaseLine();
            product = new Product();
            purchaseLine.N = line.N;

        }
        private void Ajouter_Click(object sender, EventArgs e)
        {
            if(QT.Text.Trim() == "0")
            {
                MessageBoxer.showGeneralMsg("Modifiez la quantité");
                return;

            }

            if (prodRef.Text!=""&&
                prodName.Text != ""&&
                priceP.Text != "" &&
                priceSD.Text != "" &&
                priceSG.Text != "" &&
                QT.Text != "" &&
                StockAlert.Text != "" &&
                prodRef.Text != prodRef.Tag.ToString()&&
                StockAlert.Text != StockAlert.Tag.ToString() &&
                prodName.Text != prodName.Tag.ToString() &&
                priceP.Text != priceP.Tag.ToString() &&
                priceSD.Text != priceSD.Tag.ToString() &&
                priceSG.Text != priceSG.Tag.ToString() &&
                QT.Text != QT.Tag.ToString())
            {
                bool newProd = true;
                string newProdID = (SelectedTable == "produits")?
                    "PR" + int.Parse(prodRef.Text).ToString("D4"):
                    "FL" + int.Parse(prodRef.Text).ToString("D4");

                foreach (string id in listBox1.Items)
                {
                    if (id == newProdID)
                    {
                        newProd = false;
                    }
                }

                if (!billlAdded)
                {
                    purchaseLine.N = DBHelper.generateID(string.Empty, Tables.Achat);
                    billlAdded = true;

                }


                if (!newProd)
                {
                    try
                    {
                        purchaseLine.C_PR = (SelectedTable == "produits") ?
                    "PR" + int.Parse(prodRef.Text).ToString("D4") :
                    "FL" + int.Parse(prodRef.Text).ToString("D4");


                    }
                    catch (FormatException)
                    {


                    }
                    finally
                    {
                        AddToCart();

                    }

                }
                else
                {
                    MessageBoxer.showErrorMsg("Cette référence n'existe pas");
                }
            }
            else
            {
                MessageBoxer.showGeneralMsg("Veuillez remplir tous les champs");

            }




        }

        private void prodRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;
                    Control obj = sender as Control;
                    listBox1MouseDown(sender, new MouseEventArgs(MouseButtons.Left, 1, obj.Location.X, obj.Location.Y, 0));
                    listBox1_SelectedIndexChanged(sender, e);

                }

                prodClick(sender, e);
                prodName.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void prodName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pricePClick(sender, e);
                priceP.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void priceP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                priceSDClick(sender, e);
                priceSD.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void priceSD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                priceSG_Click(sender, e);
                priceSG.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void priceSG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                QTClick(sender, e);
                QT.Focus();
                e.SuppressKeyPress = true;

            }
        }


        void PerformPurchase(object sender, EventArgs e)
        {



            if (!Spend.cancel)
            {
                if (collection != null)
                {
                    if (collection.Contains(suppName.Text))
                    {
                        foreach (var item in suppNames)
                        {
                            if (item.Value.Equals(suppName.Text))
                            {
                                purchases[0].C_FR = item.Key.ToString();
                                break;

                            }

                        }

                    }
                }



                if (string.IsNullOrEmpty(Amount.Text) || Amount.Text.Contains("Mon"))
                {
                    Amount.Text = nettotalText.Text.Clone().ToString();
                }

                foreach (PurchaseLine p in purchases)
                {
                    p.NomFour = suppName.Text;
                }

                if (helper.AddPurchase(purchases, Math.Round(double.Parse(nettotalText.Text), 2), "Regler",
                    Math.Round(double.Parse(Amount.Text), 2), float.Parse(tva.SelectedItem.ToString()),
                     prodCart, spend) > 0) // Net total value is in the amount place for testing
                {
                    OnQTChanged(e);
                    System.Windows.Forms.MessageBox.Show("Achat ajoutée");
                    
                    CartTable.Rows.Clear();
                    nettotalText.Text = "0";
                    prodCart = new List<Product>();
                    Spend.cancel = true;
                    purchases = new List<PurchaseLine>();
                    billlAdded = false;
                    ClearTexts();


                }
            }
        }



        public static bool spend = false;
        void CloseSpend(object sender, EventArgs e)
        {

            spendForm.Hide();
        }

        Spend spendForm;
        private void Valider_Click(object sender, EventArgs e)
        {

            if (suppName.Text == "Nom de fournisseur..." || string.IsNullOrEmpty(suppName.Text))
            {
                if (System.Windows.Forms.MessageBox.Show
              ("Continuer sans Nom de fournisseur?",
              "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (CartTable.Rows.Count > 0)
                    {
                        CofrimAction();

                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Le panier est vide!");
                    }
                }
            }
            else
            {
                if (CartTable.Rows.Count > 0)
                {
                    CofrimAction();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Le panier est vide!");
                }
            }




        }

        public void CofrimAction()
        {



            spendForm = new Spend();

            spendForm.FormClosing += PerformPurchase;

            spendForm.StartPosition = FormStartPosition.CenterScreen;

            spendForm.Show();


        }
  
        private void prodRef_TextChanged(object sender, EventArgs e)
        {
            /*            using (DBHelper helper = new DBHelper())
                        {
                            Task<AutoCompleteStringCollection> getRefs =
                                Task.Run(() =>
                                {

                                    return helper.searchForIDs(prodRef.Text);
                                })
                                .ContinueWith(previous =>
                                {

                                    listBox1.BeginInvoke((Action)(() =>
                                    {
                                        listBox1.DataSource = previous.Result;

                                        //prodRef.AutoCompleteCustomSource = previous.Result;
                                        //prodRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                                    }));

                                    return previous.Result;
                                });


                        }
            */

            if (!string.IsNullOrEmpty(prodRef.Text))
            {
                listBox1.DataSource = helper.searchForIDs(SelectedTable,prodRef.Text);
            }
           
        }
        

        Product product = new Product();
        bool isManuallySelected = false;
        public void listBox1MouseDown(object sender, MouseEventArgs e)
        {
            isManuallySelected = true;
        }

        private void Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedType = Typpe.SelectedItem.ToString();
        }


        private void retirer_Click(object sender, EventArgs e)
        {
            List<string> deletedIDs = new List<string>();
            if (rowsSelected != null)
            {
                for (int i = 0; i < rowsSelected.Count; i++)
                {

                    nettotalText.Text = (double.Parse(nettotalText.Text) - (double.Parse(rowsSelected[i].Cells[5].Value.ToString()) *
             double.Parse(rowsSelected[i].Cells[6].Value.ToString()))).ToString();

                    deletedIDs.Add(rowsSelected[i].Cells[2].Value.ToString());

                    CartTable.Rows.RemoveAt(rowsSelected[i].Index);



                }


                for (int i = 0; i < deletedIDs.Count; i++)
                {
                    for (int j = 0; j < purchases.Count; j++)
                    {
                        if (purchases[j].C_PR == deletedIDs[i])
                        {
                            purchases.Remove(purchases[j]);
                            if (purchases.Count == 0)
                            {
                                break;
                            }
                        }
                    }

                    for (int k = 0; k < prodCart.Count; k++)
                    {
                        if (prodCart[k].ID == deletedIDs[i])
                        {
                            prodCart.Remove(prodCart[k]);

                            if (prodCart.Count == 0)
                            {
                                break;
                            }
                        }
                    }
                }

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Veuillez sélectionner au moins une ligne");
            }
        }

        DataGridViewSelectedRowCollection rowsSelected;
        private void cart_SelectionChanged(object sender, EventArgs e)
        {
            subtotalText.Text = "0";
            rowsSelected = cart.SelectedRows;

            for (int i = 0; i < rowsSelected.Count; i++)
            {
                subtotalText.Text = (double.Parse(subtotalText.Text) + double.Parse(rowsSelected[i].Cells[5].Value.ToString()) *
    double.Parse(rowsSelected[i].Cells[6].Value.ToString())).ToString();
            }
        }

        private void effacerbtn_Click(object sender, EventArgs e)
        {
            if (CartTable.Rows.Count > 0)
            {
                DialogResult result = System.Windows.Forms.MessageBox.Show("Cette action est irréversible, cliquez sur oui pour continuer", "Vous êtes sûr ?", MessageBoxButtons.YesNo);


                if (result == DialogResult.Yes)
                {
                    subtotalText.Text = "0";
                    nettotalText.Text = "0";
                    CartTable.Rows.Clear();
                    prodCart.Clear();
                    purchases.Clear();



                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Le pannier est vide", "", MessageBoxButtons.OK);

            }
        }

        AutoCompleteStringCollection collection;
        Dictionary<string, string> suppNames;
        private void suppName_TextChanged(object sender, EventArgs e)
        {

            if (suppName.Text != suppName.Tag.ToString())
            {

                using (DBHelper helper = new DBHelper())
                {
                    collection = helper.GetSupplierNames(suppName.Text, out suppNames);

                }


                try
                {
                    if (string.IsNullOrEmpty(suppName.Text))
                    {

                        suppName.BeginInvoke((Action)(() =>
                        {


                            suppName.AutoCompleteCustomSource = collection;
                            suppName.AutoCompleteMode = AutoCompleteMode.Suggest;
                            suppName.AutoCompleteSource = AutoCompleteSource.CustomSource;

                        }));



                    }
                }
                catch (Exception ex)
                {

                    System.Windows.Forms.MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

             
        }
        string selection;
        public void FillFields(object sender, EventArgs e)
        {

            using (DBHelper helper = new DBHelper())
            {
                product = helper.GetProductByID(SelectedTable,selection);


                prodRef_Click(sender, e);
                prodRef.Text = (SelectedTable== "produits")?product.ID.Replace("PR", "").TrimStart('0'):
                    product.ID.Replace("FL", "").TrimStart('0');

                prodClick(sender, e);
                prodName.Text = product.Name;
                pricePClick(sender, e);

                priceP.Text = product.PriceP.ToString(nfi);
                priceSDClick(sender, e);

                priceSD.Text = product.PriceD.ToString();
                priceSG_Click(sender, e);

                priceSG.Text = product.PriceG.ToString();

                QTClick(sender, e);
                QT.Text = "0";

                StockAlert_Click(sender, e);
                StockAlert.Text = product.StockAlert.ToString();

                suppNameClick(sender, e);
                suppName.Text = helper.getSupplierInfo(product.c_fr).Nom;

                string prodType = product.Type.Trim();
                string unit = product.Unit;
                switch (prodType.ToLower())
                {
                    case "homme":
                        Typpe.SelectedIndex = 0;

                        break;
                    case "femme":
                        Typpe.SelectedIndex = 1;

                        break;
                    case "unisexe":
                        Typpe.SelectedIndex = 2;

                        break;
                    case "emballage":
                        Typpe.SelectedIndex = 3;

                        break;
                    case "sachet":
                        Typpe.SelectedIndex = 4;

                        break;
                }

                Unit.Select();
                switch (unit)
                {
                    case "G":
                        Unit.SelectedIndex = 2;

                        break;
                    case "U":
                        Unit.SelectedIndex = 0;

                        break;
                    case "L":
                        Unit.SelectedIndex = 1;

                        break;
                    case "KG":
                        Unit.SelectedIndex = 3;

                        break;
                    case "M":
                        Unit.SelectedIndex = 4;

                        break;
                }


            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (isManuallySelected)
            {
                selection = listBox1.SelectedItem.ToString();
                FillFields(sender, e);
            }

        }

        private void listBox1_DataSourceChanged(object sender, EventArgs e)
        {
            isManuallySelected = false;
        }

        private void Unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedType = Unit.SelectedItem.ToString();

        }

        private void prodRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBoxer.showGeneralMsg("Veuillez saisir uniquement des chiffres");

                e.Handled = true;
            }
        }

        private void StockAlert_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(StockAlert.Text))
            {
                HintUtils.ShowHint(StockAlert);
            }
        }

        private void StockAlert_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(StockAlert);
        }

        private void StockAlert_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBoxer.showGeneralMsg("Veuillez saisir uniquement des chiffres");

                e.Handled = true;
            }
        }

        private void prodRef_MouseClick(object sender, MouseEventArgs e)
        {
            if (prodRef.Text == prodRef.Tag.ToString())
            {
                prodRef.Text = "";
                prodRef.ForeColor = Color.Black;

            }
        }

        private void prodRef_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                HintUtils.HideHint(prodRef);

            }
            else
            {
                MessageBoxer.showGeneralMsg("Veuillez séléctionner une catégorie premièrement");
                return;
            }
        }

        private void tva_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tva_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tva.Text))
            {
                tva.Text = "TVA";
            }
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            if(keys == (Keys.Control |Keys.N))
            {
                Ajouter_Click(new object(),EventArgs.Empty);
                prodRef_Click(new object(), EventArgs.Empty);
                prodRef.Select();

            }

            if (keys == (Keys.Control | Keys.B))
            {
                Valider_Click(new object(), EventArgs.Empty);
                prodRef_Click(new object(), EventArgs.Empty);
                prodRef.Select();
            }

            if (keys == (Keys.Control | Keys.E))
            {
                effacerbtn_Click(new object(), EventArgs.Empty);
              
            }
            return base.ProcessCmdKey(ref message, keys);


        }

        private void AddPurchase_FormClosing(object sender, FormClosingEventArgs e)
        {

           
           
            if (cart.Rows.Count >0)
            {
                DialogResult result = System.Windows.Forms.MessageBox.Show("Êtes vous sûr ?", "Message", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        AutoCompleteStringCollection Namescollection;
        List<Product> products;
        Product selectedProduct = new Product();

        private void prodName_TextChanged(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                try
                {
                    Namescollection = helper.GetProductsNames(SelectedTable,prodName.Text, out products);

                }
                catch (Exception)
                {

                }
            }

            try
            {
                if (string.IsNullOrEmpty(prodName.Text))
                {
                    prodName.BeginInvoke((Action)(() => {

                        prodName.AutoCompleteCustomSource = Namescollection;
                        prodName.AutoCompleteMode = AutoCompleteMode.Suggest;
                        prodName.AutoCompleteSource = AutoCompleteSource.CustomSource;


                    }));
                }

                foreach (Product option in products)
                {
                    if (option.Name.Equals(prodName.Text))
                    {
                        selection = option.ID;

                        FillFields(sender, e);
                        break;
                    }
                }


            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                SelectedTable = "produits";
            }
            else
            {
                SelectedTable = "emballage";
            }
        }

       

        private void priceP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBoxer.showGeneralMsg("Veuillez saisir uniquement des chiffres");

                e.Handled = true;
            }
        }



    }
}