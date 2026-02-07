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
    public partial class RemoveFromPurchases : DevExpress.XtraEditors.XtraForm
    {
        string prodId;
        public string ProdID { set { prodId = value; } }
        public decimal Quantity { get; set; }
        public string saleID { get; set; }

        public bool removed = false;

        public RemoveFromPurchases(string ProdId, decimal quantity, string saleID)
        {
            Quantity = quantity;
            this.prodId = ProdId;
            InitializeComponent();
            this.saleID = saleID;
        }
        private void RemoveProduct_Load(object sender, EventArgs e)
        {
            this.Text += " " + prodId;

        }



        private void supprimer_Click(object sender, EventArgs e)
        {
            Confirm confirm = new Confirm();
            confirm.Passed += PasswoCorrectNoReturn;
            confirm.ShowDialog();


        }

        private void PasswoCorrectNoReturn(object sender, EventArgs e)
        {


            RemoveProd(false);


        }

        public void RemoveProd(bool returnProd)
        {
            DBHelper helper = new DBHelper();
            int affected = 0;
            affected = helper.RemoveProductFromPurchase(prodId, saleID, returnProd, prodId, Quantity);


            if (affected == -1)
            {
                MessageBoxer.showGeneralMsg("L'achat a été supprimée");
                PurchaseInfo.DeletedProduct = true;
                PurchaseInfo.DeletedSale = true;
                this.Close();

            }

            if (affected == 0)
            {
                if (helper.RemoveProductFromPurchase(prodId, saleID, returnProd, prodId, Quantity) > 0)
                {
                    SaleInfo.DeletedProduct = true;
                    this.Close();

                }

            }
            else
            {
                PurchaseInfo.DeletedProduct = true;
                this.Close();
            }
        }
        void PasswoCorrectReturn(object sender, EventArgs e)
        {
            RemoveProd(true);

        }
        private void Modifier_Click(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                if (helper.checkProdQT(prodId) > 0)
                {
                    Confirm confirm = new Confirm();
                    confirm.Passed += PasswoCorrectReturn;
                    confirm.ShowDialog();
                }
                else
                {
                    MessageBoxer.showErrorMsg("Le produit n'existe plus dans le stock");

                }
            }
        }
    }
}