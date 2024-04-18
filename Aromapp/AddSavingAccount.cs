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
    public partial class AddSavingAccount : DevExpress.XtraEditors.XtraForm
    {

        public long Quantity { get; set; }
        public long Remise { get; set; }

        public event EventHandler Added;


        public AddSavingAccount()
        {
            InitializeComponent();


        }



        public AddSavingAccount(int quantity, int remise1)
        {
            Quantity = quantity;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

            if (name.Text.Length == 0)
            {
                MessageBox.Show("Entrez un nom s'il vous plait");
                Remise = 0;
            }
            else
            {
                AccountItemModel model = new AccountItemModel();
                model.Name = name.Text;
                model.Amount = amount.Text.Replace(",", ".");

                DialogResult result = MessageBox.Show("Souhaitez-vous décaisser ?", "Options"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (DBHelper helper = new DBHelper())
                    {
                        if (helper.Caisser("Décaisser", model.Name, model.Amount) > 0)
                        {

                            helper.AddAccount(model);

                        }
                        else
                        {
                            MessageBoxer.showErrorMsg("Une erreur s'est produite");
                        }

                    }
                }
                else
                {
                    using (DBHelper helper = new DBHelper())
                    {
                        helper.AddAccount(model);

                    }
                }


            }

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

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
            name.Focus();
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