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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Aromapp
{
    public partial class Qt : DevExpress.XtraEditors.XtraForm
    {
        private int remise1;

        public long Quantity { get; set; }
<<<<<<< HEAD
        public static double OptionalPrice { get; set; }
=======
        public static double Remise { get; set; }
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409

        public event EventHandler Added;
        public double totalBulk { get; set; }
        public double totalRetail { get; set; }

        //public event EventHandler Added;

        public Qt()
        {
            InitializeComponent();
<<<<<<< HEAD
            OptionalPrice = totalRetail;
=======
            Remise = 0;
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409
        }

        public void OnAdded(EventArgs e)
        {

            if (e != null)
            {

                EventHandler eh = Added;

                if (eh != null)
                {

                    eh(this, e);
                }
            }
        }
        public Qt(int quantity, int remise1)
        {
            Quantity = quantity;
            this.remise1 = remise1;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            string s = newPrice.Text;
=======
            string s = reduction.Text;
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409

            if (qtt.Text.Length == 0)
            {
                MessageBox.Show("Entrez un numéro s'il vous plait");
<<<<<<< HEAD
                OptionalPrice = 0;
            }
            else
            {
                Comptoire.quantity = double.Parse(qtt.Text.ToString().Replace(".",","));
                
                SaleInfo.quantity = double.Parse(qtt.Text.Replace(".", ","));

                 Comptoire.detail = detail.Checked;
=======
                Remise = 0;
            }
            else
            {
                Comptoire.quantity = int.Parse(qtt.Text.ToString());
                
                SaleInfo.quantity = int.Parse(qtt.Text.ToString());

                if (detail.Checked)
                {
                    Comptoire.detail = detail.Checked;

                                    

                    SaleInfo.detail = detail.Checked;
                    OnAdded(e);
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409

                Comptoire.NewPrice = Comptoire.detail ? double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ",")) :
                    double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ","));

                SaleInfo.detail = detail.Checked;

               
                   OnAdded(e);
                
            }

        }



        private void Qt_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                iconButton3_Click(sender, e);

            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Qt_Load(object sender, EventArgs e)
        {

<<<<<<< HEAD
            qtt.Select();
=======
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409
            totalRetailText.Text = totalRetail.ToString("F2") + " DA";
            totalBulkText.Text = totalBulk.ToString("F2")+" DA";

        }

        private void annuler_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void detail_Click(object sender, EventArgs e)
        {
            gros.Checked = false;
<<<<<<< HEAD
            Comptoire.NewPrice = double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ","));
            SaleInfo.NewPrice = double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ","));
=======
            Comptoire.NewPrice = double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text);
            SaleInfo.NewPrice = double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text);
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409




        }

        private void gros_Click(object sender, EventArgs e)
        {
            detail.Checked = false;
<<<<<<< HEAD
            Comptoire.NewPrice = double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ","));
            SaleInfo.NewPrice = double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ","));
=======
            Comptoire.NewPrice = double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text);
            SaleInfo.NewPrice = double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text);
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409



        }

        private void qtt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iconButton3_Click(sender, e);

                e.SuppressKeyPress = true;


            }
        }

        private void remise_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iconButton3_Click(sender, e);

                e.SuppressKeyPress = true;


            }
        }

        private void detail_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void gros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iconButton3_Click(sender, e);

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

        private void reduc_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            HintUtils.HideHint(newPrice);
=======
            HintUtils.HideHint(reduction);
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409
        }

        private void reduc_Leave(object sender, EventArgs e)
        {
<<<<<<< HEAD
            HintUtils.ShowHint(newPrice);
=======
            HintUtils.ShowHint(reduction);
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409
        }

        private void qtt_KeyDown1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
<<<<<<< HEAD
                iconButton3_Click(sender, e);
                e.SuppressKeyPress = true;
                this.Close();
=======
                reduc_Click(sender, e);
                e.SuppressKeyPress = true;
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409

            }  
        }

        private void qtt_TextChanged(object sender, EventArgs e)
        {
<<<<<<< HEAD
            bool priceModified = newPrice.Text != newPrice.Tag.ToString() &&
                !string.IsNullOrEmpty(newPrice.Text);
            if (priceModified)
            {
                
                OptionalPrice = double.Parse(newPrice.Text);
=======
            if(reduction.Text== reduction.Tag.ToString() || string.IsNullOrEmpty(reduction.Text))
            {
                Remise = 0;

            }
            else
            {
                Remise = double.Parse(reduction.Text);
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409

            }

            if (!string.IsNullOrEmpty(qtt.Text)&& qtt.Text != qtt.Tag.ToString())
            {

<<<<<<< HEAD


                totalBulkText.Text = !priceModified?(totalBulk * double.Parse(qtt.Text.Replace(".",","))).ToString("F2") + " DA"
                    : (OptionalPrice * double.Parse(qtt.Text.Replace(".", ","))).ToString("F2") + " DA";
                totalRetailText.Text = !priceModified ? (totalRetail * double.Parse(qtt.Text.Replace(".", ","))).ToString("F2") + " DA"
                    : (OptionalPrice * double.Parse(qtt.Text.Replace(".", ","))).ToString("F2") + " DA";

                Comptoire.NewPrice = (!detail.Checked) ? double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ",")) :
double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ","));

                SaleInfo.NewPrice = (!detail.Checked) ? double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ",")) :
         double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ","));
=======
                double newRtail = totalRetail - Remise
                    , newtotal = totalBulk - Remise;


                totalBulkText.Text = (newtotal * double.Parse(qtt.Text)).ToString("F2") + " DA";
                totalRetailText.Text = (newRtail * double.Parse(qtt.Text)).ToString("F2") + " DA";

                Comptoire.NewPrice = (!detail.Checked) ? double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text) :
double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text);

                SaleInfo.NewPrice = (!detail.Checked) ? double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text) :
         double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text);
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409


            }
            else
            {
                totalBulkText.Text = (0).ToString("F2") + " DA";
                totalRetailText.Text = (0).ToString("F2") + " DA";

                Comptoire.NewPrice =0;

                SaleInfo.NewPrice = 0;
            }

     

        }

        private void reduc_TextChanged(object sender, EventArgs e)
        {

          
          
<<<<<<< HEAD
            if (!string.IsNullOrEmpty(newPrice.Text) && newPrice.Text != newPrice.Tag.ToString())
            {
                OptionalPrice = double.Parse(newPrice.Text);

                double newRtail = OptionalPrice;


                totalBulkText.Text = (newRtail * double.Parse(qtt.Text.Replace(".", ","))).ToString("F2") + " DA";
                totalRetailText.Text = (newRtail * double.Parse(qtt.Text.Replace(".", ","))).ToString("F2") + " DA";
=======
            if (!string.IsNullOrEmpty(reduction.Text) && reduction.Text != reduction.Tag.ToString())
            {
                Remise = double.Parse(reduction.Text);

                double newRtail = totalRetail - Remise
                   , newtotal = totalBulk - Remise;


                totalBulkText.Text = (newtotal * double.Parse(qtt.Text)).ToString("F2") + " DA";
                totalRetailText.Text = (newRtail * double.Parse(qtt.Text)).ToString("F2") + " DA";
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409

            }
            else
            {
<<<<<<< HEAD
                OptionalPrice = (detail.Checked) ? totalRetail : totalBulk;
                totalBulkText.Text = (totalBulk * double.Parse(qtt.Text.Replace(".", ","))).ToString("F2") + " DA";
                totalRetailText.Text = (totalRetail * double.Parse(qtt.Text.Replace(".", ","))).ToString("F2") + " DA";
=======
                Remise = 0;
                totalBulkText.Text = (totalBulk * double.Parse(qtt.Text)).ToString("F2") + " DA";
                totalRetailText.Text = (totalRetail * double.Parse(qtt.Text)).ToString("F2") + " DA";
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409

               
            }


<<<<<<< HEAD
            Comptoire.NewPrice = (!detail.Checked) ? double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ",")):
       double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ","));
            SaleInfo.NewPrice = (!detail.Checked) ? double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ",")) :
       double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ","));

        }

        private void reduction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iconButton3_Click(sender, e);

                e.SuppressKeyPress = true;


            }
        }
=======
            Comptoire.NewPrice = (!detail.Checked) ? double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text):
       double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text);
            SaleInfo.NewPrice = (!detail.Checked) ? double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text) :
       double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text);

        }

       
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409
    }
}