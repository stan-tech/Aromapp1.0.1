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
    public partial class ChangeRetentionPeriod : Form
    {
        public ChangeRetentionPeriod()
        {
            InitializeComponent();
        }

        private void ChangeRetentionPeriod_Load(object sender, EventArgs e)
        {
            qtt.Text = Properties.Settings.Default.RetentionPeriod.ToString();

        }

        private void Modifier_Click(object sender, EventArgs e)
        {
            var confirm = new Confirm();
            confirm.Passed += PasswoCorrectDelete;
            confirm.ShowDialog();
        }



        private void PasswoCorrectDelete(object sender, EventArgs e)
        {
            Properties.Settings.Default.RetentionPeriod = int.Parse(qtt.Text);
            Properties.Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void supprimer_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }
    }
}
