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
    public partial class Lend : DevExpress.XtraEditors.XtraForm
    {
        public string C_cl { get; set; }

        public event EventHandler Done;
        public Lend(string c_cl)
        {
            this.C_cl = c_cl;
            InitializeComponent();
        }

        public void OnDone(EventArgs e)
        {
            if (e != null)
            {

                EventHandler eh = Done;

                if (eh != null)
                {

                    eh(this, e);
                }
            }
        }
        private void Okbtn_Click(object sender, EventArgs e)
        {
            double amount = double.Parse(this.amount.Text);

            using(DBHelper helper = new DBHelper())
            {
                helper.Lend(amount, C_cl, name.Text);

                MessageBoxer.showGeneralMsg("Effectuée");
                OnDone(e);
                this.Close();
            }

        }

        private void annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}