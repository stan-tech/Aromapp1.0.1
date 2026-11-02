using Aromapp.Models;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
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
using System.Windows.Forms;

namespace Aromapp
{
    public partial class ChangePriceOrRemove : DevExpress.XtraEditors.XtraForm
    {

        public static double OptionalPrice { get; set; }
        public event EventHandler OnPriceChanged;
        PriceChangingProps ChangingProps;

        List<string> modifiedProducts { get; set; }

        public bool removed = false;

        public bool deleteExisting { get; set; }
        public bool deleteNew { get; set; }

        public event EventHandler Removed;

        public ChangePriceOrRemove(PriceChangingProps changingProps,List<string> modifiedProducts)
        {
            InitializeComponent();
            ChangingProps = changingProps;
            this.modifiedProducts = modifiedProducts;
        }


        public virtual void OnRemoved(EventArgs e)
        {
            EventHandler removed = Removed;

            if (removed != null)
            {
                removed(this, e);
            }

        }

     

        public void PriceChanged(EventArgs e)
        {

            if (e != null)
            {

                EventHandler eh = OnPriceChanged;

                if (eh != null)
                {

                    eh(ChangingProps, e);
                }
            }
        }
        private void OkBtn_Click(object sender, EventArgs e)
        {
            string s = newPrice.Text;


            if (qtt.Text.Length == 0)
            {
                MessageBox.Show("Entrez un numéro s'il vous plait");
                OptionalPrice = 0;
            }
            else
            {

                double qty = double.Parse(qtt.Text.Replace(",", "."));
                double totalBulk = double.Parse(totalText.Text.Replace("DA", "").Trim());


                if(qty != ChangingProps.Quantity)
                {
                    modifiedProducts.Add(ChangingProps.ProdRef);
                }

                if(string.IsNullOrEmpty(newPrice.Text) || newPrice.Text == newPrice.Tag.ToString())
                {
                    ChangingProps.NewPrice = double.Parse(ProductPriceTxt.Text.ToString(), CultureInfo.InvariantCulture);
                }
                else
                {
                    ChangingProps.NewPrice = double.Parse(newPrice.Text.ToString(), CultureInfo.InvariantCulture);

                }
                ChangingProps.Quantity = qty;

                PriceChanged(e);

            }

        }
        void newPrice_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(newPrice.Text))
            {
                HintUtils.ShowHint(newPrice);

            }
        }
        void newPrice_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(newPrice);
        }

        private void Qt_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                OkBtn_Click(sender, e);

            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void ChangePriceOrRemove_Load(object sender, EventArgs e)
        {
            this.Text += " " + ChangingProps.ProdRef;

            if (deleteExisting)
            {
                supprimer.Enabled = false;
            }
            else
            {
                supprimer.Enabled = true;

            }
            if (deleteNew)
            {
                returnStock.Enabled = false;
            }
            else
            {
                returnStock.Enabled = true;

            }

            qtt.Text = ChangingProps.Quantity.ToString();
            qtt.Select();
            totalText.Text = ChangingProps.TotalBulk.ToString("F2") + " DA";
            ProductPriceTxt.Text = (ChangingProps.TotalBulk / ChangingProps.Quantity).ToString();
            ChangingProps.NewPrice = double.Parse(ProductPriceTxt.Text.ToString(), CultureInfo.InvariantCulture);


        }

        private void annuler_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private void qtt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OkBtn_Click(sender, e);

                e.SuppressKeyPress = true;


            }
        }

        private void qtt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBox.Show("Veuillez saisir uniquement des chiffres");

                e.Handled = true;
            }
        }

        private void qtt_TextChanged(object sender, EventArgs e)
        {
            bool priceModified = newPrice.Text != newPrice.Tag.ToString() &&
                !string.IsNullOrEmpty(newPrice.Text);

            if (priceModified)
            {

                OptionalPrice = double.Parse(newPrice.Text);

            }

            if (!string.IsNullOrEmpty(qtt.Text) && qtt.Text != qtt.Tag.ToString())
            {
                double totalPrice = ChangingProps.TotalBulk;
                
                CultureInfo culture = CultureInfo.InvariantCulture;

                if (!double.TryParse(qtt.Text, NumberStyles.Any, culture, out double quantity)
                    || quantity <= 0)
                {
                    totalText.Text = "0.00 DA";
                    ChangingProps.NewPrice = 0;
                    return;
                }

                double unitPrice = priceModified ? OptionalPrice : totalPrice;

                double total = unitPrice * quantity;

                totalText.Text = total.ToString("F2", culture) + " DA";

                ChangingProps.NewPrice = double.Parse(ProductPriceTxt.Text.ToString(), CultureInfo.InvariantCulture);


            }
            else
            {
                totalText.Text = (0).ToString("F2") + " DA";

                ChangingProps.NewPrice = 0;

            }



        }

        private void newPrice_TextChanged(object sender, EventArgs e)
        {

            double totalPrice = ChangingProps.TotalBulk;

          
            try
            {
                    
                double.TryParse(newPrice.Text, out double p);
                OptionalPrice = p;
            }
            catch
            {
                MessageBox.Show("Veuillez saisir uniquement des chiffres");
                return;
            }
                

            double newRtail = OptionalPrice;


           totalText.Text = (OptionalPrice > 0 ) 
                ? (newRtail * double.Parse(qtt.Text.Replace(".", ","))).ToString("F2") + " DA"
                : totalText.Text;

            ChangingProps.NewPrice = double.Parse(ProductPriceTxt.Text.ToString(), CultureInfo.InvariantCulture);

        }

        private void supprimer_Click(object sender, EventArgs e)
        {
            PasswoCorrectNoReturn(sender, e);


        }

        private void PasswoCorrectNoReturn(object sender, EventArgs e)
        {
            RemoveProd(false);
            OnRemoved(e);
        }

        public void RemoveProd(bool returnProd)
        {
            DBHelper helper = new DBHelper();



            int affected = 0;
            affected = helper.RemoveProductFromBill(0, ChangingProps.ProdRef, ChangingProps.SaleRef, returnProd, Convert.ToDecimal(ChangingProps.Quantity), deleteExisting);


            if (affected == -1)
            {
                MessageBoxer.showGeneralMsg("La vante a été supprimée");
                SaleInfo.DeletedProduct = true;
                SaleInfo.DeletedBill = true;

                this.Close();

            }

            if (affected == 0)
            {
                if (!deleteNew)
                {
                    if (helper.RemoveProductFromBill(0, ChangingProps.ProdRef, ChangingProps.SaleRef, returnProd, Convert.ToDecimal(ChangingProps.Quantity), deleteExisting) > 0)
                    {
                        SaleInfo.DeletedProduct = true;
                        this.Close();

                    }
                    else
                    {
                        MessageBoxer.showErrorMsg("Une erreur s'est produite");
                    }
                }
                else
                {
                    SaleInfo.DeletedProduct = true;
                    this.Close();
                }


            }
            else
            {
                SaleInfo.DeletedProduct = true;
                this.Close();
            }
        }

        void PasswoCorrectReturn(object sender, EventArgs e)
        {
            RemoveProd(true);
            OnRemoved(e);

        }
        private void returnToStock_Click(object sender, EventArgs e)
        {
            PasswoCorrectReturn(sender, e);
        }
    }
}

