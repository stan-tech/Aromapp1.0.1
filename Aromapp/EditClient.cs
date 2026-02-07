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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Aromapp
{
    public partial class EditClient : DevExpress.XtraEditors.XtraForm
    {
        BackgroundWorker worker = new BackgroundWorker();
        Client client;
        public string ID { get; set; }

        string column = "\0", value = "\0";
        public EditClient(string id)
        {
            ID = id;

            InitializeComponent();

            worker.RunWorkerCompleted += worker_workCompleted;
            worker.DoWork += worker_Work;
        }
        public void AssignValue()
        {
            name.Text = client.Nom;
            phone.Text = client.Tel;
            adr.Text = client.Adresse;
            act.Text = client.Activite;
            email.Text = client.Email;
            fax.Text = client.Fax;
            nis.Text = client.NIS;
            nif.Text = client.NIF;
            datePicker.Value = DateTime.Parse(client.DatAjout);
        }

    
        void worker_workCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AssignValue();

        }

        private void EditClient_Shown(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            datePicker.Value = DateTime.Parse(client.DatAjout);

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
                        client = helper.EditClient(client.C_CL, column, value);

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
             HintUtils.ShowHint(amount);

        }

        private void amount_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(amount);

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

        private void amount_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            value = amount.Text;
            DateTime dateValue = datePicker.Value.Date;
            string day = dateValue.Day.ToString("D2"), month = dateValue.Month.ToString("D2");

            string dateString = dateValue.Year.ToString() + "-" + month + "-" + day;

            using (DBHelper helper = new DBHelper())
            {
                client = helper.EditClient(client.C_CL, "dateajout", dateString);

            }

            if (!(string.IsNullOrEmpty(column) || string.IsNullOrEmpty(value)
                    || value == amount.Tag.ToString()))
            {
                using (DBHelper helper = new DBHelper())
                {
                    client = helper.EditClient(client.C_CL, column, value);

                }

            }
            else
            {
                MessageBoxer.showGeneralMsg("Choisissez la valeur à modifier");
            }
            AssignValue();
        }

        private void EditClient_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(545, 492);
            this.CenterToScreen();
        }

        void worker_Work(object sender, DoWorkEventArgs e)
        {
            client = DBHelper.GetClient(ID);
        }
    }
}