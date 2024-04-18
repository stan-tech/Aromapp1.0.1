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
    public partial class Spend : DevExpress.XtraEditors.XtraForm
    {
        public Confirm GetConfirm { get; set; }

        public static bool cancel = true;

        public Spend()
        {
            InitializeComponent();


        }

        private void supprimer_Click(object sender, EventArgs e)
        {
            cancel = false;

            AddPurchase.spend = false;
            this.Close();

        }

        private void returnStock_Click(object sender, EventArgs e)
        {
            cancel = false;

            AddPurchase.spend = true;
            this.Close();


        }
     
    }
}