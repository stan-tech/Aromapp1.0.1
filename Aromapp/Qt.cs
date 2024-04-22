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
        public static double Remise { get; set; }

        public event EventHandler Added;
        public double totalBulk { get; set; }
        public double totalRetail { get; set; }

        //public event EventHandler Added;

        public Qt()
        {
            InitializeComponent();
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
            string s = reduction.Text;

            if (qtt.Text.Length == 0)
            {
                MessageBox.Show("Entrez un numéro s'il vous plait");
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

                }
                else
                {
                    Comptoire.detail = detail.Checked;
                    SaleInfo.detail = detail.Checked;

                    OnAdded(e);

                }
            }

            this.Close();
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
            Comptoire.NewPrice = double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text);
            SaleInfo.NewPrice = double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text);




        }

        private void gros_Click(object sender, EventArgs e)
        {
            detail.Checked = false;
            Comptoire.NewPrice = double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text);
            SaleInfo.NewPrice = double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text);



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
            HintUtils.HideHint(reduction);
        }

        private void reduc_Leave(object sender, EventArgs e)
        {
            HintUtils.ShowHint(reduction);
        }

        private void qtt_KeyDown1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                reduc_Click(sender, e);
                e.SuppressKeyPress = true;

            }  
        }

        private void qtt_TextChanged(object sender, EventArgs e)
        {
            if(reduction.Text== reduction.Tag.ToString() || string.IsNullOrEmpty(reduction.Text))
            {
                Remise = 0;

            }
            else
            {
                Remise = double.Parse(reduction.Text);

            }

            if (!string.IsNullOrEmpty(qtt.Text)&& qtt.Text != qtt.Tag.ToString())
            {

                double newRtail = totalRetail - Remise
                    , newtotal = totalBulk - Remise;


                totalBulkText.Text = (newtotal * double.Parse(qtt.Text)).ToString("F2") + " DA";
                totalRetailText.Text = (newRtail * double.Parse(qtt.Text)).ToString("F2") + " DA";

                Comptoire.NewPrice = (!detail.Checked) ? double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text) :
double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text);

                SaleInfo.NewPrice = (!detail.Checked) ? double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text) :
         double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text);


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

          
          
            if (!string.IsNullOrEmpty(reduction.Text) && reduction.Text != reduction.Tag.ToString())
            {
                Remise = double.Parse(reduction.Text);

                double newRtail = totalRetail - Remise
                   , newtotal = totalBulk - Remise;


                totalBulkText.Text = (newtotal * double.Parse(qtt.Text)).ToString("F2") + " DA";
                totalRetailText.Text = (newRtail * double.Parse(qtt.Text)).ToString("F2") + " DA";

            }
            else
            {
                Remise = 0;
                totalBulkText.Text = (totalBulk * double.Parse(qtt.Text)).ToString("F2") + " DA";
                totalRetailText.Text = (totalRetail * double.Parse(qtt.Text)).ToString("F2") + " DA";

               
            }


            Comptoire.NewPrice = (!detail.Checked) ? double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text):
       double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text);
            SaleInfo.NewPrice = (!detail.Checked) ? double.Parse(totalBulkText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text) :
       double.Parse(totalRetailText.Text.Replace("DA", "").Trim()) / double.Parse(qtt.Text);

        }

       
    }
}