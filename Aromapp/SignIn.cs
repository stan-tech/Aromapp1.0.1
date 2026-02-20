using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace Aromapp
{
    public partial class SignIn : DevExpress.XtraEditors.XtraForm
    {
        List<string> prodIDs = new List<string>();
        public static User SelectedUser;

        List<User> users;
        public SignIn()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(5000);

            InitializeComponent();

            t.Abort();

        }

        void StartForm()
        {
            Application.Run(new SplashScreen());

        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                users = helper.GetUsers();

            }
            PassWord.Focus();
            PassWord.Select();
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

        private void Ok_Click(object sender, EventArgs e)
        {
            if (PassWord.Text == SelectedUser.Password)
            {
                using (DBHelper helper = new DBHelper())
                {
                    helper.LogIn(SelectedUser.ID, true);
                    Properties.Settings.Default.LoggedInUserID = SelectedUser.ID;
                    Properties.Settings.Default.LoggedInUserName = SelectedUser.Name;
                    Properties.Settings.Default.IsUserAdmin = SelectedUser.IsAdmin;

                    if (!SelectedUser.IsAdmin)
                    {
                        Properties.Settings.Default.ShowProdPurp=false;
                        Properties.Settings.Default.ShowPurp=false;
                        Properties.Settings.Default.ShowStockPurp=false;

                        Properties.Settings.Default.Save();
                        Properties.Settings.Default.Reload();

                    }

                    Properties.Settings.Default.Save();
                }



                Application.Restart();

            }
            else
            {
                MessageBoxer.showErrorMsg("Mot de passe invalide");
            }
        }

        private void Users_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedUser = users[UsersCombo.SelectedIndex];

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
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
            if(e.KeyCode == Keys.Enter)
            {
                Ok_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }
    }
}