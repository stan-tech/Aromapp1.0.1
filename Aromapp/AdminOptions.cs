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
    public partial class AdminOptions : DevExpress.XtraEditors.XtraUserControl
    {

        BackgroundWorker worker;
        Information info;
        List<User> users;
        User SelectedUser;


        string SelectedColumn;
     
        public AdminOptions()
        {
            InitializeComponent();
            this.Load += AdminOptions_Shown;
            worker = new BackgroundWorker();
            worker.DoWork += LoadInfo;
            worker.RunWorkerCompleted += LoadInfoCompleted;

            PassWord.ForeColor = Color.Black;
            NewPass.ForeColor = Color.Black;

            if (string.IsNullOrEmpty(UserCombo.Text))
            {
                UserCombo.Text = "Utilisateurs";
            }
            if (string.IsNullOrEmpty(ColumnCombo.Text))
            {
                ColumnCombo.Text = "Informations";
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
        void LoadInfo(object sender, DoWorkEventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                users = helper.GetUsers();

            }

            info = DBHelper.GetStoreInformation();

        }

        public void UpdateInfo()
        {
            NameText.Text = info.Nom;
            PhoneText.Text = info.Tel;
            Email.Text = info.Email;
            AddrText.Text = info.Adresse;
            act.Text = info.Activite;
            rc.Text = info.RC;
            fax.Text = info.Fax;
            NIF.Text = info.NIF;

        }
        void LoadInfoCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            UpdateInfo();

            UserCombo.Items.Clear();

            foreach (User user in users)
            {
                UserCombo.Items.Add(user.Name);
            }




        }

        private void AdminOptions_Shown(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }

        private void UserCombo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserCombo.Text))
            {
                UserCombo.Text = "Utilisateurs";
            }
        }

        private void ColumnCombo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ColumnCombo.Text))
            {
                ColumnCombo.Text = "Informations";
            }
        }

        private void UserCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedUser = users[UserCombo.SelectedIndex];
        }


        private void modifMDP_Click(object sender, EventArgs e)
        {

            if (SelectedUser != null && !string.IsNullOrEmpty(PassWord.Text)
            && !string.IsNullOrEmpty(NewPass.Text) 
            )
            {
                if (PassWord.Text == SelectedUser.Password)
                {

                    using (DBHelper helper = new DBHelper())
                    {
                        if (helper.UpdatePassword(SelectedUser.ID, NewPass.Text))
                        {
                            MessageBoxer.showGeneralMsg("Mot de passe changé avec succés");

                            PassWord.PasswordChar = '\0';
                            PassWord.UseSystemPasswordChar = false;
                            NewPass.PasswordChar = '\0';
                            NewPass.UseSystemPasswordChar = false;
                           
                        }
                    }

                }
                else
                {
                    MessageBoxer.showErrorMsg("Mot de passe incorrect");
                    PassWord.Focus();

                }
            }
            else
            {
                if (SelectedUser == null)
                {
                    MessageBoxer.showGeneralMsg("Selectionnez un utilisateur d'abord");

                }
                else
                {
                    MessageBoxer.showGeneralMsg("Entrez un mot de passe");

                }

            }


        }

        void RefreshInfo(object sender, FormClosingEventArgs e)
        {
            RefreshList();
        }

        public void RefreshList()
        {
            using (DBHelper helper = new DBHelper())
            {
                users.Clear();

                users = helper.GetUsers();
                UserCombo.Items.Clear();
                UserCombo.Text = "Utilisateurs";

                foreach (User user in users)
                {
                    UserCombo.Items.Add(user.Name);
                }

              
            }
        }
        private void AddUser_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser(false);
            addUser.FormClosing += RefreshInfo;
            addUser.ShowDialog();
        }

        void PasswoCorrect(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                if (helper.DeleteUser(SelectedUser.ID))
                {
                    helper.Dispose();

                    RefreshList();

                    if (users.Count == 0)
                    {
                        Application.Exit();

                    }
                }
                else
                {
                    MessageBoxer.showErrorMsg("Une erreur s'est produits");
                }
            }
        }
        private void DeleteUser_Click(object sender, EventArgs e)
        {
            if (SelectedUser != null)
            {
                DialogResult result = MessageBox.Show("  Êtes vous sûr ?", string.Empty,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Confirm confirm = new Confirm();
                    confirm.Passed += PasswoCorrect;
                    confirm.ShowDialog();
                }
            }
            else
            {
                MessageBoxer.showGeneralMsg("Selectionnez un utilisateur d'abord");

            }
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

        private void valueBox_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(valueBox);
        }

        private void valueBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(valueBox.Text))
            {
                HintUtils.ShowHint(valueBox);
            }
        }

        private void NewPass_IconRightClick(object sender, EventArgs e)
        {
            if (NewPass.UseSystemPasswordChar)
            {
                NewPass.UseSystemPasswordChar = false;
                NewPass.PasswordChar = '\0';

              

            }
            else
            {
                NewPass.UseSystemPasswordChar = true;
                NewPass.PasswordChar = '●';

               
            }


        }

        private void ColumnCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (ColumnCombo.SelectedIndex)
            {
                case 0:

                    valueBox_Click(sender, e);
                    valueBox.Text = info.Nom;
                    SelectedColumn = "Nom";
                    break;
                case 1:
                    valueBox_Click(sender, e);
                    valueBox.Text = info.Adresse;
                    SelectedColumn = "Adresse";

                    break;

                case 2:
                    valueBox_Click(sender, e);
                    valueBox.Text = info.Activite;
                    SelectedColumn = "Activite";

                    break;

                case 3:
                    valueBox_Click(sender, e);
                    valueBox.Text = info.Tel;
                    SelectedColumn = "Tel";

                    break;
                case 4:
                    valueBox_Click(sender, e);
                    valueBox.Text = info.Email;
                    SelectedColumn = "Email";

                    break;
                case 5:
                    valueBox_Click(sender, e);
                    valueBox.Text = info.RC;
                    SelectedColumn = "RC";

                    break;
                case 6:
                    valueBox_Click(sender, e);
                    valueBox.Text = info.NIF;
                    SelectedColumn = "NIF";
                    break;
            }


        }

        private void modifINF_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(valueBox.Text) &&
                valueBox.Text != valueBox.Tag.ToString())
            {

                if (SelectedColumn != null)
                {
                    using (DBHelper helper = new DBHelper())
                    {
                        if (helper.UpdateStoreInfo(SelectedColumn, valueBox.Text))
                        {
                            info = DBHelper.GetStoreInformation();
                            UpdateInfo();
                        }
                    }
                }
                else
                {
                    MessageBoxer.showGeneralMsg("Choisissez quoi à modifier");

                }

            }
            else
            {
                MessageBoxer.showGeneralMsg("Entrez une valeur");
            }
        }

        private void valueBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                modifINF_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        void InvPasswoCorrect(object sender, EventArgs e)
        {



            using (DBHelper helper = new DBHelper())
            {
                if (helper.DeleteBill("all") > 0)
                {

                    if (helper.DeleteFromStock("all") > 0)
                    {

                        if (helper.DeleteProducts(new List<string>() { "all" }) > 0)
                        {

                            if (helper.DeletePurchase("all") > 0)
                            {

                                MessageBoxer.showGeneralMsg("L'inventaire a été supprimé");

                            }
                            else
                            {
                                MessageBoxer.showErrorMsg("Une erreur s'est produite");
                            }


                        }
                        else
                        {
                            MessageBoxer.showErrorMsg("Une erreur s'est produite");
                        }

                    }
                    else
                    {
                        MessageBoxer.showErrorMsg("Une erreur s'est produite");
                    }

                }
                else
                {
                    MessageBoxer.showErrorMsg("Une erreur s'est produite");
                }
            }

        }
        private void supprimer_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("  Êtes vous sûr ?", string.Empty,
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Confirm confirm = new Confirm();
                confirm.Passed += InvPasswoCorrect;
                confirm.ShowDialog();
            }
        }

        void BillPasswoCorrect(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {

                if (helper.DeleteBill("all") > 0)
                {
                    MessageBoxer.showGeneralMsg("Les rapports de vente ont été supprimés");

                }
            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Confirm confirm = new Confirm();
            confirm.Passed += BillPasswoCorrect;
            confirm.ShowDialog();

        }

        void PurchasePasswoCorrect(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {

                if (helper.DeletePurchase("all") > 0)
                {
                    MessageBoxer.showGeneralMsg("Les rapports d'achat ont été supprimés");

                }
            }
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            Confirm confirm = new Confirm();
            confirm.Passed += PurchasePasswoCorrect;
            confirm.ShowDialog();
        }
    }
}
