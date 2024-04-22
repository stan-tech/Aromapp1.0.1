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
    public partial class etiquette : DevExpress.XtraEditors.XtraForm
    {
        public event EventHandler Canceled;
        public event EventHandler Print;

        public etiquette()
        {
            InitializeComponent();
        }

        private void Imprimer_Click(object sender, EventArgs e)
        {
            Products.EtiqNumber = int.Parse(qtt.Text);
            OnPrint(e);
        }

        public void OnCanceled(EventArgs e)
        {
            if (e != null)
            {

                EventHandler eh = Canceled;

                if (eh != null)
                {

                    eh(this, e);
                }
            }
        }
        public void OnPrint(EventArgs e)
        {
            if (e != null)
            {

                EventHandler eh = Print;

                if (eh != null)
                {

                    eh(this, e);
                }
            }
        }

        private void annuler_Click(object sender, EventArgs e)
        {
            OnCanceled(e);
        }
    }
}