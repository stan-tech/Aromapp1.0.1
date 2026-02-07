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
    public partial class LogForm : DevExpress.XtraEditors.XtraForm
    {
        BackgroundWorker worker;
        int limit = 100, currentPage = 1;
        DataTable table;
        public LogForm()
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(duration.Text))
            {
                duration.Text = "Duration";
            }

            HistTable.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            HistTable.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(255, 64, 64, 64),
                Font = new System.Drawing.Font("Calibri", 9.25f)
            };

            HistTable.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(63, 81, 181),
                Font = new System.Drawing.Font("Calibri", 9.25f, FontStyle.Bold),
                ForeColor = Color.White
            };

            worker = new BackgroundWorker();
            table = new DataTable();
            worker.DoWork += LoadDataInBackground;
            worker.RunWorkerCompleted += LoadingCompleted;
        }

        private void LogForm_Shown(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 800);
            worker.RunWorkerAsync();
        }
        void LoadDataInBackground(object sender, DoWorkEventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                table = helper.LoadLogTable("", limit, currentPage);
            }
        }
        string condition = "";
        private void duration_SelectedIndexChanged(object sender, EventArgs e)
        {

            condition = "";

            switch (duration.SelectedIndex)
            {
                case 0:

                    condition = "10";
                    break;
                case 1:
                    condition = "30";
                    break;

            }

            using (DBHelper helper = new DBHelper())
            {
                HistTable.DataSource = helper.LoadLogTable(condition, limit, 1);

            }
        }

        void PasswoCorrect(object sender, EventArgs e)
        {
            bool all = condition == "";

            using (DBHelper helper = new DBHelper())
            {
                if (helper.DeleteFromLog(all, condition))
                {
                    HistTable.DataSource = helper.LoadLogTable(condition, limit, 1);

                }
                else
                {
                    MessageBoxer.showErrorMsg("Une erreur s'est produite");
                }

            }
        }
        private void delete_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("  Êtes vous sûr ?", ""
      , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Confirm confirm = new Confirm();
                confirm.Passed += PasswoCorrect;
                confirm.ShowDialog();
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                HistTable.DataSource = helper.LoadLogTable("", limit, 1);

            }
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("  Êtes vous sûr ?", ""
    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            condition = "";
            if (result == DialogResult.Yes)
            {
                Confirm confirm = new Confirm();
                confirm.Passed += PasswoCorrect;
                confirm.ShowDialog();
            }
        }

        private void duration_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(duration.Text))
            {
                duration.Text = "Duration";
            }
        }

      
        void LoadingCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HistTable.DataSource = table;
        }
    }
}