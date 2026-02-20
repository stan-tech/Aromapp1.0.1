using DevExpress.XtraEditors;
using Guna.UI2.WinForms;
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
    public partial class EditSupplierForm : DevExpress.XtraEditors.XtraForm
    {
        BackgroundWorker worker = new BackgroundWorker();
        Supplier supplier;
        public string ID { get; set; }

        string column = "\0", value = "\0";

        public EditSupplierForm(string id)
        {
            ID = id;

            InitializeComponent();

            worker.RunWorkerCompleted += worker_workCompleted;
            worker.DoWork += worker_Work;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        public void AssignValue()
        {
            name.Text = supplier.Nom;
            phone.Text = supplier.Tel;
            adr.Text = supplier.Adresse;
            act.Text = supplier.Activite;
            email.Text = supplier.Email;
            fax.Text = supplier.Fax;
            nis.Text = supplier.NIS;
            nif.Text = supplier.NIF;
            datePicker.Value = DateTime.Parse(supplier.DateAjout);
        }
        void worker_workCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AssignValue();



        }
        void worker_Work(object sender, DoWorkEventArgs e)
        {
            supplier = DBHelper.GetSupplier(ID);
        }

        private void EditSupplierForm_Shown(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            datePicker.Value = DateTime.Parse(supplier.DateAjout);
        }




        private void iconButton3_Click(object sender, EventArgs e)
        {

            DateTime dateValue = datePicker.Value.Date;
            string day = dateValue.Day.ToString("D2"), month = dateValue.Month.ToString("D2");

            string dateString = dateValue.Year.ToString() + "-" + month + "-" + day;

            using (DBHelper helper = new DBHelper())
            {
                supplier = helper.EditSupplier(supplier.C_fr, "dateajout", dateString);

            }
            AssignValue();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            column = comboBox1.SelectedItem.ToString().Trim();

            switch (column)
            {
                case "Address":
                    amount_Click(this, e);
                    amount.Text = adr.Text;
                    break;
                case "Activité":
                    amount_Click(this, e);
                    amount.Text = act.Text;
                    break;
                case "Nom":
                    amount_Click(this, e);
                    amount.Text = name.Text; break;
                case "Email":
                    amount_Click(this, e);
                    amount.Text = email.Text; break;
                case "Telephone":
                    amount_Click(this, e);
                    amount.Text = phone.Text; break;
                case "Fax":
                    amount_Click(this, e);
                    amount.Text = fax.Text; break;
                case "NIS":
                    amount_Click(this, e);
                    amount.Text = nis.Text; break;
                case "NIF":
                    amount_Click(this, e);
                    amount.Text = nif.Text; break;
            }


        }

        private void amount_KeyDown(object sender, KeyEventArgs e)
        {
            value = amount.Text;

            if (e.KeyCode == Keys.Enter)
            {

                if (!(string.IsNullOrEmpty(column) || string.IsNullOrEmpty(value)
                    || value == amount.Tag.ToString()))
                {
                    using (DBHelper helper = new DBHelper())
                    {
                        supplier = helper.EditSupplier(supplier.C_fr, column, value);

                    }
                    AssignValue();

                }
                else
                {
                    MessageBoxer.showGeneralMsg("Choisissez la valeur à modifier");
                }
            }
        }

        private void amount_Leave(object sender, EventArgs e)
        {
            if (amount.Text.Trim() == "")
            {
                HintUtils.ShowHint(amount);

            }
        }

        private void amount_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(amount);

        }

 

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditSupplierForm_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(545, 492);
            datePicker.Value = DateTime.Now;

            this.CenterToScreen();
        }

        private void amount_IconRightClick(object sender, EventArgs e)
        {

            value = amount.Text;

            if (!(string.IsNullOrEmpty(column) || string.IsNullOrEmpty(value)
                || value == amount.Tag.ToString()))
            {
                using (DBHelper helper = new DBHelper())
                {
                    supplier = helper.EditSupplier(supplier.C_fr, column, value);

                }
                AssignValue();

            }
            else
            {
                MessageBoxer.showGeneralMsg("Choisissez la valeur à modifier");
            }
        }
    }
}