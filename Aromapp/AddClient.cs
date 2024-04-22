using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Aromapp
{
    public partial class AddClient : DevExpress.XtraEditors.XtraForm
    {
        public AddClient()
        {
            InitializeComponent();
            name.Click += nameClick;
            phone.Click += phoneClick;
            debt.Click += debtsClick;
            address.Click += addressClick;
            email.Click += emailClick;
            fax.Click += faxClick;
            name.Leave += nameLeave;
            phone.Leave += phoneLeave;
            debt.Leave += debtsLeave;
            address.Leave += addressLeave;
            email.Leave += emailLeave;
            fax.Leave += faxLeave;
        }
        void nameClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(name);
        }
        void phoneClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(phone);
        }
        void faxClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(fax);
        }
        void addressClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(address);
        }
        void emailClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(email);
        }
        void debtsClick(object sender, EventArgs e)
        {
            HintUtils.HideHint(debt);
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
        void debtsLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(debt.Text))
            {
                HintUtils.ShowHint(debt);
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
        private void AddClient_Load(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

            string[] str = new string[] { name.Text, phone.Text, address.Text, email.Text, fax.Text };

            if (!(name.Text == name.Tag.ToString()
                || string.IsNullOrEmpty(name.Text)))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (string.IsNullOrEmpty(str[i]) ||
                        str[i] == name.Tag.ToString()
                        || str[i] == name.Tag.ToString()
                        || str[i] == phone.Tag.ToString()
                        || str[i] == address.Tag.ToString()
                        || str[i] == email.Tag.ToString()
                        || str[i] == fax.Tag.ToString())
                    {
                        str[i] = "Non disponible";
                    }
                }
                using (DBHelper helper = new DBHelper())
                {
                    Client client = new Client(str[0], str[1], str[2]
                    , str[3], str[4]);

                    client.DatAjout = DateTime.Now.Date.ToShortDateString();
                    client.Debts = (!(string.IsNullOrEmpty(debt.Text) ||
                        debt.Text == debt.Tag.ToString())) ? double.Parse(debt.Text.ToString().Replace(".", ",")) : 0;

                    if (!helper.AddClient(client))
                    {
                        MessageBoxer.showErrorMsg("Une erreur s'est produite");
                    }
                    else
                    {
                        MessageBoxer.showGeneralMsg("Client ajouté");
                        this.Hide();
                    }
                }
            }
            else
            {
                MessageBoxer.showGeneralMsg("Veuillez remplir au moins le nom");
            }
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
                debtsClick(sender, e);
                debt.Focus();
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

        private void fax_KeyDown(object sender, KeyEventArgs e)
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

        private void debt_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}