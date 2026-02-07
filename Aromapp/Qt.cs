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
        public static double OptionalPrice { get; set; }
        public static double Remise { get; set; }

        public event EventHandler Added;
        public double totalBulk { get; set; }
        public double totalRetail { get; set; }

        //public event EventHandler Added;

        public Qt()
        {
            InitializeComponent();
            OptionalPrice = totalRetail;
            Remise = 0;
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
            string s = newPrice.Text;


            if (qtt.Text.Length == 0)
            {
                MessageBox.Show("Entrez un numéro s'il vous plait");
                OptionalPrice = 0;
            }
            else
            {
                Comptoire.quantity = double.Parse(qtt.Text.ToString().Replace(".",","));
                
                SaleInfo.quantity = double.Parse(qtt.Text.Replace(".", ","));

                 Comptoire.detail = detail.Checked;


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

            qtt.Select();

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
            Comptoire.NewPrice = double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ","));
            SaleInfo.NewPrice = double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ","));





        }

        private void gros_Click(object sender, EventArgs e)
        {
            detail.Checked = false;
            Comptoire.NewPrice = double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ","));
            SaleInfo.NewPrice = double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ","));




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
            HintUtils.HideHint(newPrice);

        }

        private void reduc_Leave(object sender, EventArgs e)
        {
            HintUtils.ShowHint(newPrice);

        }

        private void qtt_KeyDown1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                iconButton3_Click(sender, e);
                e.SuppressKeyPress = true;
                this.Close();


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

            if (!string.IsNullOrEmpty(qtt.Text)&& qtt.Text != qtt.Tag.ToString())
            {


                totalBulkText.Text = !priceModified?(totalBulk * double.Parse(qtt.Text.Replace(".",","))).ToString("F2") + " DA"
                    : (OptionalPrice * double.Parse(qtt.Text.Replace(".", ","))).ToString("F2") + " DA";
                totalRetailText.Text = !priceModified ? (totalRetail * double.Parse(qtt.Text.Replace(".", ","))).ToString("F2") + " DA"
                    : (OptionalPrice * double.Parse(qtt.Text.Replace(".", ","))).ToString("F2") + " DA";

                Comptoire.NewPrice = (!detail.Checked) ? double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ",")) :
double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ","));

                SaleInfo.NewPrice = (!detail.Checked) ? double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ",")) :
         double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text.Replace(".", ","));


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

          
          
            if (!string.IsNullOrEmpty(newPrice.Text) && newPrice.Text != newPrice.Tag.ToString())
            {
                OptionalPrice = double.Parse(newPrice.Text);

                double newRtail = OptionalPrice;


                totalBulkText.Text = (newRtail * double.Parse(qtt.Text.Replace(".", ","))).ToString("F2") + " DA";
                totalRetailText.Text = (newRtail * double.Parse(qtt.Text.Replace(".", ","))).ToString("F2") + " DA";


            }
            else
            {
                OptionalPrice = (detail.Checked) ? totalRetail : totalBulk;
                totalBulkText.Text = (totalBulk * double.Parse(qtt.Text.Replace(".", ","))).ToString("F2") + " DA";
                totalRetailText.Text = (totalRetail * double.Parse(qtt.Text.Replace(".", ","))).ToString("F2") + " DA";


               
            }


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

    }
}