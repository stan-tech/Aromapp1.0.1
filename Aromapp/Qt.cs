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
        public long Remise { get; set; }
        public event EventHandler Added;

        //public event EventHandler Added;

        public Qt()
        {
            InitializeComponent();


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
            if (qtt.Text.Length == 0)
            {
                MessageBox.Show("Entrez un numero s'il vous plait");
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
            qtt.Select();
        }

        private void annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void detail_Click(object sender, EventArgs e)
        {
            gros.Checked = false;
        }

        private void gros_Click(object sender, EventArgs e)
        {
            detail.Checked = false;
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
    }
}