using DevExpress.XtraEditors;
using Humanizer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aromapp
{
    public partial class AddProduct : DevExpress.XtraEditors.XtraForm
    {

        public event EventHandler OnProductAdded;
        NumberFormatInfo nfi;
        public AddProduct()
        {
            InitializeComponent();
            nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ",";



            priceP.Leave += pricePLeave;
            prodName.Leave += prodLeave;
            priceSD.Leave += priceSDLeave;
            priceSG.Leave += priceSGLeave;

            prodName.Click += prodClick;


            priceP.Click += pricePClick;

            priceSD.Click += priceSDClick;
            priceSG.Click += priceSGClick;


        }

        public void OnAdded(EventArgs e)
        {

            if (e != null)
            {

                EventHandler eh = OnProductAdded;

                if (eh != null)
                {

                    eh(this, e);
                }
            }
        }

        string SelectedTable = "produits";
        private void Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Tyype.SelectedIndex == 3|| Tyype.SelectedIndex == 4)
            {
                SelectedTable = "emballage";
            }
            else
            {
                SelectedTable = "produits";
            }
        }

        private void Type_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Tyype.Text))
            {
                Tyype.Text = "Type";

            }
        }

        private void Unit_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Unit.Text))
            {
                Unit.Text = "Unité";

            }
        }
        #region Hints


        void prodLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(prodName.Text))
            {
                HintUtils.ShowHint(prodName);

            }
        }
        /*  void prodRefLeave(object sender, EventArgs e)
          {
              if (string.IsNullOrEmpty(prodRef.Text))
              {
                  HintUtils.ShowHint(prodRef);

              }
              else
              {
                  string name;
                  if (!DBHelper.IsProductIDAvailable(prodRef.Text,out name))
                  {
                      MessageBoxer.showErrorMsg("Cette référence existe déjà, avec le nom: "+name);
                      prodRef.Focus();
                  }
              }
          }*/
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
     



        #endregion

        public void ClearTexts()
        {
            priceP.Text = "";
            prodName.Text = "";
            priceSD.Text = "";
            priceSG.Text = "";
        

            HintUtils.ShowHint(priceP);
            HintUtils.ShowHint(prodName);
            HintUtils.ShowHint(priceSD);
            HintUtils.ShowHint(priceSG);



        }
        public void OkButton_Click(object sender, EventArgs e)
        {
            string BarCodePref;
            DialogResult result = DialogResult.None;

            if (
                   priceP.Text == priceP.Tag.ToString() ||
                   priceSD.Text == priceSD.Tag.ToString() ||
                   priceSG.Text == priceSG.Tag.ToString() ||
                   prodName.Text == prodName.Tag.ToString() ||
                   string.IsNullOrEmpty(prodName.Text) ||

                   string.IsNullOrEmpty(priceP.Text) ||
                   string.IsNullOrEmpty(priceSD.Text) ||
                   string.IsNullOrEmpty(priceSG.Text) ||
                   Tyype.SelectedItem == null ||
                   Unit.SelectedItem == null)
            {
                MessageBoxer.showGeneralMsg("Veuillez remplir les informations requises");
                return;
            }

            using (DBHelper helper = new DBHelper())
            {
                DataTable table = helper.searchForProduct((Tyype.SelectedItem.ToString() == "Emabllage"
                    || Tyype.SelectedItem.ToString()=="Sachet")?"emballage":"produits", prodName.Text);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (suppName.Text.ToLower().Equals(table.Rows[i][1].ToString().ToLower()) 
                        && prodName.Text.ToLower().Equals(table.Rows[i][2].ToString().ToLower()))
                    {
                        result = MessageBox.Show("Le produit "+prodName.Text+" ("+
                            table.Rows[i][0].ToString()+")"+ " avec le même fournisseur existe déjà, continuer ?", "Message",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        break;
                    }
                }
            }
            if (result==DialogResult.Yes||result==DialogResult.None)
            {

               
                
                    Product product = new Product();
                    product.Name = prodName.Text.Trim();
                    product.PriceP = double.Parse(priceP.Text.Trim().Replace(".", ","));
                    product.PriceD = double.Parse(priceSD.Text.Trim().Replace(".", ","));
                    product.PriceG = double.Parse(priceSG.Text.Trim().Replace(".", ","));
                    product.Quantity = 0;
                    product.Type = Tyype.SelectedItem.ToString();
                    product.Unit = Unit.SelectedItem.ToString();
                    product.StockAlert = double.Parse(Alert.Text.Trim().Replace(".", ","));



                    using (DBHelper helper = new DBHelper())
                    {
                        BarCodePref = helper.getStoreBarCode();
                        string id = "1";
                        if (helper.getSupplierID(suppName.Text, out id))
                        {
                            product.c_fr = id;

                        }
                        else
                        {
                            product.c_fr = DBHelper.generateID("FR", Tables.Fourniseur);
                            Supplier supplier = new Supplier(product.c_fr, suppName.Text);
                            helper.InsertSupplier(supplier);
                        }
                    }

                    string prodID = (SelectedTable == "produits") ? DBHelper.IsProductIDAvailable() : "";

                    product.ID = (prodID != "") ? prodID : DBHelper.generateID((SelectedTable == "produits") ? "PR" : "FL",
                        (SelectedTable == "produits") ? Tables.produits : Tables.emballage);

                    product.BarCode = BarCodePref + DateTime.Now.Year + DateTime.Now.Month +
                    DateTime.Now.Day + DateTime.Now.ToString("HH:mm:ss").Replace(":", "") +
                    product.ID.Replace((SelectedTable == "produits")
                    ? "PR" : "FL", "").TrimStart('0');


                    using (DBHelper helper = new DBHelper())
                    {
                        if (helper.AddEmptyInvoice(product) > 0)
                        {

                            if (helper.AddProduct(product, product.Quantity) > 0)
                            {
                                helper.AddProductToStock(product, 0);

                                MessageBoxer.showGeneralMsg("Produit ajouté");
                                ClearTexts();

                                OnAdded(e);

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
                return;
            }
        }
        Dictionary<string, string> ids;
        AutoCompleteStringCollection collection;

        private void AddProduct_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Unit.Text))
            {
                Unit.Text = "Unité";
            }
            if (string.IsNullOrWhiteSpace(Tyype.Text))
            {
                Tyype.Text = "Type";

            }
        }

        private void Annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void priceP_TextChanged(object sender, EventArgs e)
        {

        }

        private void priceSD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBoxer.showGeneralMsg("Veuillez saisir uniquement des chiffres");

                e.Handled = true;
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



        private void QT_TextChanged(object sender, EventArgs e)
        {

        }

        private void QT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBoxer.showGeneralMsg("Veuillez saisir uniquement des chiffres");

                e.Handled = true;
            }
        }

        private void Alert_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBoxer.showGeneralMsg("Veuillez saisir uniquement des chiffres");

                e.Handled = true;
            }
        }

        private void priceSG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBoxer.showGeneralMsg("Veuillez saisir uniquement des chiffres");

                e.Handled = true;
            }
        }

        private void Alert_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Alert.Text))
            {
                HintUtils.ShowHint(Alert);
            }

        }

        private void Alert_Click(object sender, EventArgs e)
        {

            HintUtils.HideHint(Alert);

        }

        private void prodRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
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
                priceSGClick(sender, e);
                priceSG.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void priceSG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Alert_Click(sender, e);
                Alert.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void supp_TextChanged(object sender, EventArgs e)
        {
            if (suppName.Text != suppName.Tag.ToString())
            {

                using (DBHelper helper = new DBHelper())
                {
                    collection = helper.GetSupplierNames(suppName.Text, out ids);
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

        private void suppName_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(suppName);
        }

        private void suppName_Leave(object sender, EventArgs e)
        {
            HintUtils.ShowHint(suppName);
        }

        private void Alert_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                suppName_Click(sender, e);
                suppName.Focus();
                e.SuppressKeyPress = true;

            }
        }
    }
}