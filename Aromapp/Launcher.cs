using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aromapp
{
    public partial class Launcher : DevExpress.XtraEditors.XtraForm
    {
        public Launcher()
        {
            InitializeComponent();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            Information info = new Information();
            info.Nom = (StoreName.Text != StoreName.Tag.ToString()) ? StoreName.Text : null;
            info.Tel = (phone.Text != phone.Tag.ToString()) ? phone.Text : null;
            info.Email = (email.Text != email.Tag.ToString()) ? email.Text : null;
            info.Fax = (fax.Text != fax.Tag.ToString()) ? fax.Text : null;
            info.RC = (rc.Text != rc.Tag.ToString()) ? rc.Text : null;
            info.NIF = (nif.Text != nif.Tag.ToString()) ? nif.Text : null;
            info.Adresse = (Address.Text != Address.Tag.ToString()) ? Address.Text : null;
            info.Activite = (StoreActivity.Text != StoreActivity.Tag.ToString()) ? StoreActivity.Text : null;
            info.CodeBarre = r.Next(100, 999).ToString() + r.Next(10, 99).ToString("D10");
            info.QR = "";
            info.Logo = "";


            Type type = info.GetType();

            PropertyInfo[] propertyInfo = type.GetProperties();

            foreach (PropertyInfo property in propertyInfo)
            {
                object v = property.GetValue(info);

                if (v == null)
                {
                    MessageBoxer.showGeneralMsg("Veuillez remplir toutes les informations");
                    return;
                }
                else
                {
                    continue;
                }
            }

            using (DBHelper helper = new DBHelper())
            {
                helper.AddStoreInfo(info);
            }

            Application.Restart();
        }

        private void StoreName_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(StoreName);
        }

        private void StoreName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(StoreName.Text))
            {
                HintUtils.ShowHint(StoreName);
            }
        }

        private void StoreActivity_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(StoreActivity);

        }

        private void StoreActivity_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(StoreActivity.Text))
            {
                HintUtils.ShowHint(StoreActivity);
            }
        }

        private void Address_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(Address);

        }

        private void Address_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Address.Text))
            {
                HintUtils.ShowHint(Address);
            }
        }

        private void rc_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(rc);

        }

        private void rc_Leave(object sender, EventArgs e)
        {

        }

        private void nif_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nif.Text))
            {
                HintUtils.ShowHint(nif);
            }
        }

        private void nif_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(nif);

        }

        private void email_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(email.Text))
            {
                HintUtils.ShowHint(email);
            }
        }

        private void email_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(email);

        }

        private void phone_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(phone.Text))
            {
                HintUtils.ShowHint(phone);
            }
        }

        private void phone_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(phone);

        }

        private void fax_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fax.Text))
            {
                HintUtils.ShowHint(fax);
            }
        }

        private void fax_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(fax);

        }

        private void StoreName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StoreActivity_Click(this, e);
                StoreActivity.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void StoreActivity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Address_Click(this, e);
                Address.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void Address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rc_Click(this, e);
                rc.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void rc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nif_Click(this, e);
                nif.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void nif_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                email_Click(this, e);
                email.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                phone_Click(this, e);
                phone.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void phone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fax_Click(this, e);
                fax.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void fax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iconButton2_Click(this, e);
                e.SuppressKeyPress = true;
            }
        }

        private void Launcher_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(545, 498);
            this.MaximumSize = new System.Drawing.Size(545,498);
            this.MinimumSize = new System.Drawing.Size(545, 498);

            this.CenterToScreen();
        }
    }
}