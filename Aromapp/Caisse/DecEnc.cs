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
    public partial class DecEnc : DevExpress.XtraEditors.XtraForm
    {
        public event EventHandler Done;

        public DecEnc()
        {
            InitializeComponent();
        }

        private void Okbtn_Click(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                if (helper.Caisser(this.Text, name.Text, amount.Text) > 0)
                {
                    OnDone(e);
                    this.Hide();
                }
                else
                {
                    MessageBoxer.showErrorMsg("Une erreur s'est produite");
                }
            }
        }
        public virtual void OnDone(EventArgs e)
        {
            EventHandler eh = Done;
            if (eh != null)
            {
                eh(this, e);


            }
        }

        private void annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBox.Show("Veuillez saisir uniquement des chiffres");

                e.Handled = true;
            }
        }
    }
}