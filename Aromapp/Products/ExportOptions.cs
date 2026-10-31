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
    public partial class ExportOptions : DevExpress.XtraEditors.XtraForm
    {
        public event EventHandler Done;
        public DateTime dateFrom { get; set;  }
        public DateTime dateTo { get; set;  }

        public ExportOptions()
        {
            InitializeComponent();
        }

        private void Okbtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public virtual void OnDone(EventArgs e)
        {
            EventHandler eh = Done;
            if (eh != null)
            {
                eh(this, e);

            }
        }

        private void annuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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

        private void ExportOptions_Load(object sender, EventArgs e)
        {
            DateFrom.Value= DateTime.Now.AddDays(-1);
            DateTo.Value = DateTime.Now;

        }

        private void DateFrom_ValueChanged(object sender, EventArgs e)
        {
            dateFrom = (DateTime)DateFrom.Value;
        }

        private void DateTo_ValueChanged(object sender, EventArgs e)
        {
            dateTo = (DateTime)DateTo.Value;
        }

    }
}