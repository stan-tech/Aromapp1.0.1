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
    public partial class AddSupplier : DevExpress.XtraEditors.XtraForm
    {
        public AddSupplier()
        {
            InitializeComponent();
            name.Click += nameClick;
            phone.Click += phoneClick;
            activity.Click += activityClick;
            address.Click += addressClick;
            email.Click += emailClick;
            fax.Click += faxClick;
            nif.Click += nifClick;
            nis.Click += nisClick;
            debts.Click += debtsClick;
            name.Leave += nameLeave;
            phone.Leave += phoneLeave;
            activity.Leave += activityLeave;
            address.Leave += addressLeave;
            email.Leave += emailLeave;
            fax.Leave += faxLeave;
            nif.Leave += nifLeave;
            nis.Leave += nisLeave;
            debts.Leave += debtsLeave;
        }

    
        void faxClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(fax);
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                phoneClick(sender, e);
                phone.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void phone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addressClick(sender, e);
                address.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                activityClick(sender, e);
                activity.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void debt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                emailClick(sender, e);
                email.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                faxClick(sender, e);
                fax.Focus();
                e.SuppressKeyPress = true;

            }
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {

            /*string c_FR, string nom, string activite, string adresse,
    string tel, string fax, string email, string nis, string nif, string dateAjout*/

            string[] str = new string[] { name.Text, activity.Text,address.Text, phone.Text, fax.Text,
                email.Text, nis.Text, nif.Text };
            if (!(phone.Text == phone.Tag.ToString()
                || string.IsNullOrEmpty(phone.Text)))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (string.IsNullOrEmpty(str[i]) ||
                        str[i] == name.Tag.ToString()
                        || str[i] == name.Tag.ToString()
                        || str[i] == phone.Tag.ToString()
                        || str[i] == address.Tag.ToString()
                        || str[i] == email.Tag.ToString()
                        || str[i] == fax.Tag.ToString()
                        || str[i] == nif.Tag.ToString()
                        || str[i] == nis.Tag.ToString()
                        || str[i] == activity.Tag.ToString())

                    {
                        str[i] = "Non disponible";
                    }
                }


                using (DBHelper helper = new DBHelper())
                {
                    string c_fr = DBHelper.generateID("FR", Tables.Fourniseur);

                    Supplier supplier = new Supplier(c_fr, str[0], str[1], str[2]
                        , str[3], str[4], str[5], str[6], str[7], DateTime.Now.Date.ToString().Replace("00:00:00", "")
                        .Replace("/", "-").Trim());

                    supplier.Debts = (!(string.IsNullOrEmpty(debts.Text) || debts.Text == debts.Tag.ToString()))
                        ? double.Parse(debts.Text.ToString().Replace(".", ",")) : 0;

                    if (!helper.InsertSupplier(supplier))
                    {
                        MessageBoxer.showErrorMsg("Une erreur s'est produite");
                    }
                    else
                    {
                        MessageBoxer.showGeneralMsg("Fournisseur ajouté");
                    }
                }
            }
            else
            {
                MessageBoxer.showGeneralMsg("Veuillez remplir au moins le nom");
            }
        }
        void nameClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(name);
        }
        void phoneClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(phone);
        }
        void activityClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(activity);
        }
        void addressClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(address);
        }
        void emailClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(email);
        }
        void nifClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(nif);
        }
        void nisClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(nis);
        }
        void debtsClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(debts);
        }
        void nameLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(name.Text))
            {
                HintUtils.ShowHint(name);
            }
        }
        void phoneLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(phone.Text))
            {
                HintUtils.ShowHint(phone);
            }
        }
        void activityLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(activity.Text))
            {
                HintUtils.ShowHint(activity);
            }
        }
        void addressLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(address.Text))
            {
                HintUtils.ShowHint(address);
            }
        }
        void emailLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(email.Text))
            {
                HintUtils.ShowHint(email);
            }
        }
        void faxLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fax.Text))
            {
                HintUtils.ShowHint(fax);
            }
        }
        void nifLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nif.Text))
            {
                HintUtils.ShowHint(nif);
            }
        }
        void nisLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nis.Text))
            {
                HintUtils.ShowHint(nis);
            }
        }
        void debtsLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(debts.Text))
            {
                HintUtils.ShowHint(debts);
            }
        }

     

        private void fax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                debtsClick(sender, e);
                debts.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void debts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nisClick(sender, e);
                nis.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void nif_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iconButton3_Click(sender, e);
                e.SuppressKeyPress = true;

            }
        }

        private void phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBoxer.showGeneralMsg("Veuillez saisir uniquement des chiffres");

                e.Handled = true;
            }
        }

        private void debts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBoxer.showGeneralMsg("Veuillez saisir uniquement des chiffres");

                e.Handled = true;
            }
        }

        private void fax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBoxer.showGeneralMsg("Veuillez saisir uniquement des chiffres");

                e.Handled = true;
            }
        }

        private void nis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nifClick(sender, e);
                nif.Focus();
                e.SuppressKeyPress = true;

            }
        }

      
    }
}