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
    public partial class ScarceProducts : DevExpress.XtraEditors.XtraForm
    {

        BackgroundWorker worker;
        DataTable table;


        public ScarceProducts()
        {
            InitializeComponent();
            this.Load += ScarceLoad;

            ScarceTable.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            ScarceTable.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(255, 64, 64, 64),
                Font = new Font("Calibri", 12.25f),
                Padding = new System.Windows.Forms.Padding(8)
            };
            ScarceTable.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(63, 81, 181),
                Font = new Font("Calibri", 12.25f, FontStyle.Bold),
                ForeColor = Color.White,
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            };



            worker = new BackgroundWorker();
            table = new DataTable();
            worker.DoWork += loadProducts;
            worker.RunWorkerCompleted += loadProductsCompleted;
        }

       
        void ScarceLoad(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }
        void loadProducts(object sender, DoWorkEventArgs e)
        {
            table = new DataTable();

            using (DBHelper helper = new DBHelper())
            {
                table = helper.LoadScarceProducts();
            }
        }
        void loadProductsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ScarceTable.DataSource = table;
        }

        private void ScarceProducts_Load(object sender, EventArgs e)
        {

        }
    }
}