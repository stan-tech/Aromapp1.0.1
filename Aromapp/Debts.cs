using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aromapp
{
    public partial class Debts : DevExpress.XtraEditors.XtraForm
    {
        BackgroundWorker worker;
        DataTable table;
        int limit = 100, currentPage = 1;
        string[] oldestDate = new string[2];
        NumberFormatInfo nfi = new NumberFormatInfo();
        bool settled = false;

        public bool ClientsDebt { get; set; }
        public Debts()
        {
            InitializeComponent();

            worker = new BackgroundWorker();

            nfi.NumberDecimalDigits = 2;
            worker.DoWork += LoadDataInBackground;
            worker.RunWorkerCompleted += LoadingCompleted;


            DebtsTable.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(255, 64, 64, 64),
                Font = new Font("Calibri", 9.25f)
            };
            DebtsTable.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(63, 81, 181),
                ForeColor = Color.White,
                Font = new Font("Calibri", 9.25f, FontStyle.Bold)
            };
        }

        void LoadDataInBackground(object sender, DoWorkEventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                if (ClientsDebt)
                {
                    table = helper.GetDebts(true, limit, currentPage);
                    oldestDate[0] = helper.GetOldestDebtDate(true)[0];
                    oldestDate[1] = helper.GetOldestDebtDate(true)[1];
                }
                else
                {
                    table = helper.GetDebts(false, limit, currentPage);
                    oldestDate[0] = helper.GetOldestDebtDate(false)[0];
                    oldestDate[1] = helper.GetOldestDebtDate(false)[1];
                }

            }

        }

        private void Debts_Shown(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }

        char durFormat = '\0';
        string monthsString = "0", yearsString = "0", daysString = "0";

        private void DebtsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (DebtsTable.Rows.Count <= 1 || DebtsTable.SelectedRows[0].Index == DebtsTable.Rows.Count-1) return;

            DateTime selectedDate = DateTime.Parse(DebtsTable.SelectedRows[0].
                Cells[1].Value.ToString());
            string duration = (string.IsNullOrEmpty((DateTime.Now.Date - selectedDate).ToString().Replace("00:00:00", ""))) ? "0" :
                (DateTime.Now.Date - selectedDate).ToString().Replace("00:00:00", "");

            if (duration.EndsWith("."))
            {
                duration = duration.Trim('.');

            }


            double months = double.Parse(duration.ToString(nfi));


            daysString = (months / 365 * 12 * 30).ToString("F2");
            monthsString = (months / 365 * 12).ToString("F2");
            yearsString = (months / 365).ToString("F2");



            switch (durFormat)
            {
                case 'd':
                    this.days.Checked = true;
                    dur.Text = daysString + " J";

                    break;
                case 'm':
                    this.months.Checked = true;
                    dur.Text = monthsString + " M";

                    break;
                case 'y':
                    this.years.Checked = true;
                    dur.Text = yearsString + " A";

                    break;

                default:
                    this.months.Checked = true;
                    dur.Text = monthsString + " M";
                    break;
            }


            clientName.Text = DebtsTable.SelectedRows[0].
                Cells[3].Value.ToString();
            AmountValue.Text = DebtsTable.SelectedRows[0].
                Cells[6].Value.ToString();



        }


        private void days_CheckedChanged(object sender, EventArgs e)
        {

            if (days.Checked == true)
            {
                months.Checked = false;
                years.Checked = false;
            }

            dur.Text = daysString + " J";


        }

        private void months_CheckedChanged(object sender, EventArgs e)
        {


            if (months.Checked == true)
            {
                days.Checked = false;
                years.Checked = false;
            }


            dur.Text = monthsString + " M";



        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = guna2DateTimePicker1.Value.Date;
            string day = date.Day.ToString("D2"), month = date.Month.ToString("D2");

            string dateString = day + "-" + month + "-" + date.Year.ToString();

            DebtsTable.Invoke((Action)(() => {

                using (DBHelper dBHelper = new DBHelper())
                {
                    DebtsTable.DataSource = dBHelper.searchDebts(dateString, limit, currentPage, 0);
                }

            }));
        }

        private void search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchText.Text))
            {
                HintUtils.ShowHint(searchText);

            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(searchText);
        }

        private void amount_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(amount.Text))
            {
                HintUtils.ShowHint(amount);

            }
        }

        private void amount_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(amount);
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchText.Text) && !searchText.Text.Equals(searchText.Tag))
            {
                DebtsTable.Invoke((Action)(() =>
                {

                    using (DBHelper dBHelper = new DBHelper())
                    {
                        DebtsTable.DataSource = dBHelper.searchDebts(searchText.Text, limit, currentPage, 1);
                    }

                }));
            }
            else
            {
                DebtsTable.Invoke((Action)(() =>
                {

                    using (DBHelper dBHelper = new DBHelper())
                    {
                        DebtsTable.DataSource = dBHelper.GetDebts(ClientsDebt, 100, 1); ;
                    }

                }));
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            DebtsTable.Invoke((Action)(() =>
            {

                using (DBHelper dBHelper = new DBHelper())
                {
                    DebtsTable.DataSource = dBHelper.GetDebts(ClientsDebt, limit, 1); ;
                }

            }));
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        private void searchText_IconRightClick(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                DebtsTable.DataSource = helper.searchClients(searchText.Text, true);
            }
        }

        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (DBHelper helper = new DBHelper())
                {
                    DebtsTable.DataSource = helper.searchClients(searchText.Text, true);
                }
                e.SuppressKeyPress = true;
            }
        }

        void PasswoCorrect(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                string BillID = DebtsTable.SelectedRows[0].Cells[0].Value.ToString();
                decimal PaidAmount = decimal.Parse(DebtsTable.SelectedRows[0].Cells[6].Value.ToString());

                if (!settled)
                {
                    if (ClientsDebt)
                    {
                        helper.UpdatePaidAmount(BillID, decimal.Parse(amount.Text), Confirm.SelectedUser.Name);

                    }
                    else
                    {
                        helper.UpdatePurchasePaidAmount(BillID, double.Parse(amount.Text), Confirm.SelectedUser.Name);

                    }
                }
                else
                {

                    if (ClientsDebt)
                    {
                        helper.UpdatePaidAmount(BillID, PaidAmount, Confirm.SelectedUser.Name);
                    }
                    else
                    {
                        helper.UpdatePurchasePaidAmount(BillID, Convert.ToDouble(PaidAmount), Confirm.SelectedUser.Name);

                    }
                    settled = false;


                }
                DebtsTable.DataSource = helper.GetDebts(ClientsDebt, limit, 1);


            }
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(amount.Text) &&
                amount.Text != amount.Tag.ToString())
            {
                Confirm confirm = new Confirm();
                confirm.Passed += PasswoCorrect;
                confirm.ShowDialog(); 
            }


        }

        private void amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBox.Show("Veuillez saisir uniquement des chiffres");

                e.Handled = true;
            }
        }

        private void amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iconButton2_Click(sender, e);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            settled = true;
            Confirm confirm = new Confirm();
            confirm.Passed += PasswoCorrect;
            confirm.ShowDialog();
        }

        private void Debts_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(670, 560);
            this.CenterToScreen();


        }

        private void oldest_Click(object sender, EventArgs e)
        {

        }

        private void years_CheckedChanged(object sender, EventArgs e)
        {

            if (years.Checked == true)
            {
                months.Checked = false;
                days.Checked = false;
            }
            dur.Text = yearsString + " A";


        }
        void LoadingCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DateTime date = DateTime.Now;
            if (oldestDate[0] != null)
            {
                date = DateTime.Parse(oldestDate[0]);

            }

            DebtsTable.DataSource = table;
            oldest.Text = date.ToString("dd/MM/yyyy");
            OldestclientName.Text = (oldestDate[1] != null) ? oldestDate[1] : "Nom";
            double debtTotal = 0;

            foreach (DataGridViewRow row in DebtsTable.Rows)
            {
                if (row.Index != DebtsTable.RowCount - 1)
                {
                    debtTotal += double.Parse(row.Cells[6].Value.ToString());

                }
            }

            debtsTotal.Text = debtTotal.ToString("F2") + " DA";
        }
    }
}