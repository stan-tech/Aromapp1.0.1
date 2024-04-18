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
    public partial class LoyalClients : DevExpress.XtraEditors.XtraForm
    {
        BackgroundWorker worker;
        DataTable table;
        public LoyalClients()
        {
            InitializeComponent();

            this.Load += LoyalClients_Load;


            ClientsTable.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(255, 64, 64, 64),
                Font = new Font("Calibri", 9.25f)
            };
            ClientsTable.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(63, 81, 181),
                Font = new Font("Calibri", 9.25f, FontStyle.Bold),
                ForeColor = Color.White
            };

            worker = new BackgroundWorker();
            table = new DataTable();
            worker.DoWork += loadClients;
            worker.RunWorkerCompleted += loadClientsCompleted;
        }

       
        void loadClients(object sender, DoWorkEventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {

                table = helper.GetLoyalClients();
            }
        }
        void loadClientsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ClientsTable.DataSource = table;

        }
        void LoyalClients_Load(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }

        private void LoyalClients_Load_1(object sender, EventArgs e)
        {

        }
    }
}