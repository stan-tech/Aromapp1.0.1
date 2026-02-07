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
    public partial class RemoveProduct : DevExpress.XtraEditors.XtraForm
    {
        string prodId;
        public string ProdID { set { prodId = value; } }
        public decimal Quantity { get; set; }
        public string saleID { get; set; }

        public bool removed = false;

        public bool modif { get; set; }
        public bool modifNew { get; set; }

        public event EventHandler Removed;



        public virtual void OnRemoved(EventArgs e)
        {
            EventHandler removed = Removed;

            if(removed != null)
            {
                removed(this,e);
            }

        }

        public RemoveProduct(string ProdId, decimal quantity, string saleID)
        {
            Quantity = quantity;
            this.prodId = ProdId;
            InitializeComponent();
            this.saleID = saleID;
        }

        private void RemoveProduct_Load(object sender, EventArgs e)
        {
            this.Text += " " + prodId;

            if (modif)
            {
                supprimer.Enabled = false;
            }
            else
            {
                supprimer.Enabled = true;

            }
            if (modifNew)
            {
                returnStock.Enabled = false;
            }
            else
            {
                returnStock.Enabled = true;

            }

        }



        private void supprimer_Click(object sender, EventArgs e)
        {
            PasswoCorrectNoReturn(sender,e);


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
            affected = helper.RemoveProductFromBill(0,prodId, saleID, returnProd, Quantity, modif) ;


            if (affected == -1)
            {
                MessageBoxer.showGeneralMsg("La vante a été supprimée");
                SaleInfo.DeletedProduct = true;
                SaleInfo.DeletedBill = true;
                
                this.Close();

            }

            if (affected == 0)
            {
                if (!modifNew)
                {
                    if (helper.RemoveProductFromBill(0,prodId, saleID, returnProd, Quantity, modif) > 0)
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
        private void Modifier_Click(object sender, EventArgs e)
        {
            PasswoCorrectReturn(sender,e);
        }
    }
}