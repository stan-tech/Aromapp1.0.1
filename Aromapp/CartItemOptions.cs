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
    public partial class CartItemOptions : DevExpress.XtraEditors.XtraForm
    {
        DataGridViewRow selectedRow;
        public event EventHandler QuantChanged;
        public event EventHandler Product_Deleted;



        Product prod;

        public DataGridViewRow SelectedRow
        {
            get { return selectedRow; }

        }

        public Product Product
        {
            get { return prod; }

        }
        public CartItemOptions(Product prod, DataGridViewRow selectedRow)
        {
            this.prod = prod;
            this.selectedRow = selectedRow;
            InitializeComponent();
            this.qtt.Text = prod.Quantity.ToString();
            qtt.Focus();

        }

        private void Modifier_Click(object sender, EventArgs e)
        {

            prod.Quantity = double.Parse(qtt.Text.Replace(".", ","));
            selectedRow.Cells[2].Value = double.Parse(qtt.Text.Replace(".", ","));
            OnRefreshRequested(e);

            this.Close();

        }
        public virtual void OnRefreshRequested(EventArgs e)
        {

            EventHandler eh = QuantChanged;

            if (eh != null)
            {

                eh(this, e);
            }
        }
        public virtual void OnRefresh(EventArgs e)
        {

            EventHandler eh = Product_Deleted;

            if (eh != null)
            {

                eh(this, e);
            }
        }

        private void supprimer_Click(object sender, EventArgs e)
        {
            OnRefresh(e);
            Comptoire.CartTable.Rows.RemoveAt(prod.Index);
            this.Close();
        }

        private void qtt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBox.Show("Veuillez saisir uniquement des chiffres");

                e.Handled = true;
            }
        }
    }
}