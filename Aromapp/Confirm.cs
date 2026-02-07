using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace Aromapp
{
    public partial class Confirm : DevExpress.XtraEditors.XtraForm
    {
        List<string> prodIDs = new List<string>();
        public event EventHandler Passed;
        public static User SelectedUser;

        List<User> users;
        public Confirm()
        {
            InitializeComponent();

        }

        private void Confirm_Load(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                users = helper.GetUsers();

            }
            UsersCombo.Items.Clear();

            foreach (User user in users)
            {
                UsersCombo.Items.Add(user.Name);
            }
            if (users.Count > 0)
            {
                UsersCombo.SelectedIndex = 0;

            }


        }


        public virtual void PasswordEntered(object sender, EventArgs e)
        {
            EventHandler eventHandler = Passed;

            if (e != null)
            {
                eventHandler(this, e);

            }
        }

        private void Ok_Click(object sender, EventArgs e)
        {

            if (PassWord.Text == SelectedUser.Password && SelectedUser.IsAdmin)
            {
                PasswordEntered(sender, e);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBoxer.showErrorMsg("Mot de passe invalide ou absence de permission");
            }
        }

        private void Users_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedUser = users[UsersCombo.SelectedIndex];

        }


        private void iconButton5_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            this.Close();
        }


        private void PassWord_IconRightClick(object sender, EventArgs e)
        {
            if (PassWord.UseSystemPasswordChar)
            {
                PassWord.PasswordChar = '\0';
                PassWord.UseSystemPasswordChar = false;

                     
            }
            else
            {
                PassWord.PasswordChar = '●';
                PassWord.UseSystemPasswordChar = true;

            }
        }

        private void PassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Ok_Click(sender, e);
                e.SuppressKeyPress = true;

            }
        }
    }
}