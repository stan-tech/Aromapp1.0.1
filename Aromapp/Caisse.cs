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
using System.Windows.Media;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Aromapp
{
    public partial class Caisse : DevExpress.XtraEditors.XtraUserControl
    {
        DataTable items = new DataTable();
        BackgroundWorker worker1 = new BackgroundWorker(),
            worker2 = new BackgroundWorker(),
            worker = new BackgroundWorker(), worker3 = new BackgroundWorker();
        DBHelper helper = new DBHelper();
        int selection = -1;
        bool tableFull = false, searching = false;
        string TableContent = "";
        Size currentSize;
       string SelectedAccount = "";
        public Caisse()
        {
            InitializeComponent();

     
            regLines.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            regLines.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = System.Drawing.Color.White,
                SelectionBackColor = System.Drawing.Color.FromArgb(255, 64, 64, 64),
                Font = new Font("Calibri", 9.25f)
            };
            regLines.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = System.Drawing.Color.FromArgb(63, 81, 181),
                Font = new Font("Calibri", 9.25f, FontStyle.Bold)
            };
            Comptes.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            Comptes.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = System.Drawing.Color.White,
                SelectionBackColor = System.Drawing.Color.FromArgb(255, 64, 64, 64),
                Font = new Font("Calibri", 9.25f)
            };
            Comptes.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = System.Drawing.Color.FromArgb(63, 81, 181),
                Font = new Font("Calibri", 9.25f, FontStyle.Bold),
                
            };

            currentSize = this.Size;
            worker.RunWorkerCompleted += worker_workCompleted;
            worker.DoWork += worker_Work;




        }

        
        void DeleteClick(object sender, EventArgs e)
        {
         
            DialogResult result = MessageBox.Show("Êtes vous sûr ?", "Suppression", MessageBoxButtons.YesNoCancel);


            if (result == DialogResult.Yes)
            {
                using (DBHelper helper = new DBHelper())
                {
                    helper.RemoveAccount(SelectedAccount);
                }
            }


        }


        public void DisplayAccounts()
        {
            items = DBHelper.GetSavingAccounts();


     
        }
        

        public void ZakatWithdrawn(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                entries = helper.GetEntriesAndSpendings(out spendings);

            }

            entre.BeginInvoke(new Action(() =>
            {
                entre.Text = entries.ToString("F2");
                sortie.Text = spendings.ToString("F2");
            }));
        }

        void AccountAdded(object sender, EventArgs e)
        {
            DisplayAccounts();
            Comptes.DataSource = items;

            using (DBHelper helper = new DBHelper())
            {
                entries = helper.GetEntriesAndSpendings(out spendings);



            }

            entre.BeginInvoke(new Action(() =>
            {
                entre.Text = entries.ToString("F2");
                sortie.Text = spendings.ToString("F2");
            }));

            if (addSavingAccount != null)
            {
                addSavingAccount.Close();

            }
        }

        AddSavingAccount addSavingAccount;
        private void iconButton3_Click(object sender, EventArgs e)
        {
            addSavingAccount = new AddSavingAccount();
            addSavingAccount.Controls[0].Controls[1].Click += AccountAdded;
            addSavingAccount.ShowDialog();
        }

        private void amount_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(amount);
        }

        private void amount_Leave(object sender, EventArgs e)
        {
            if (amount.Text.Trim() == "")
            {
                HintUtils.ShowHint(amount);
            }
        }

        private void search_Leave(object sender, EventArgs e)
        {
            if (searchText.Text.Trim() == "")
            {
                HintUtils.ShowHint(searchText);
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(searchText);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

            if (!(amount.Text == "Valeur..." || string.IsNullOrEmpty(amount.Text)) && SelectedAccount != "")
            {
                using (DBHelper helper = new DBHelper())
                {
                    helper.EditAccount(double.Parse(amount.Text.Replace(".",",")), SelectedAccount);

                }
                DisplayAccounts();
                Comptes.DataSource = items;

            }
            else
            {
                MessageBoxer.showGeneralMsg("Sélectionnez un compte et saisissez une valeur pour le modifier.");
            }

        }
        void worker_workCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            regLines.Invoke((Action)(() => {

                regLines.DataSource = table;


            }));

            worker1.RunWorkerCompleted += worker1_workCompleted;
            worker1.DoWork += worker1_Work;
            worker1.RunWorkerAsync();



        }

        int limit = 100;
        int currentPage = 1;
        DataTable table = new DataTable();
        double[] entresort = new double[2];
        void worker_Work(object sender, DoWorkEventArgs e)
        {

            table = helper.selectRegisterLines(limit, currentPage);


        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {
            if (!(amount.Text == "Valeur..." || string.IsNullOrEmpty(amount.Text)) && SelectedAccount != "")
            {
                string[] AccountName = helper.GetSavingAccount(SelectedAccount);

                string newAmount = (double.Parse(AccountName[1]) + double.Parse(amount.Text.Replace(".", ","))).ToString();

                DialogResult result = MessageBox.Show("Souhaitez-vous décaisser ?", "Options"
                   , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (DBHelper helper = new DBHelper())
                    {
                        if (helper.Caisser("Décaisser", AccountName[0], amount.Text) > 0)
                        {


                            helper.EditAccount(double.Parse(newAmount), SelectedAccount);

                            AccountAdded(sender, e);


                        }
                        else
                        {
                            MessageBoxer.showErrorMsg("Une erreur s'est produite");
                        }

                    }
                }

                DisplayAccounts();
            }
            else
            {
                MessageBoxer.showGeneralMsg("Sélectionnez un compte et saisissez une valeur pour le modifier.");
            }
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {

            if (!(amount.Text == "Valeur..." || string.IsNullOrEmpty(amount.Text)) && SelectedAccount != "")
            {

                string[] AccountName = helper.GetSavingAccount(SelectedAccount);

                string newAmount = (double.Parse(AccountName[1]) - double.Parse(amount.Text)).ToString();


                DialogResult result = MessageBox.Show("Souhaitez-vous encaisser ?", "Options"
                                  , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (DBHelper helper = new DBHelper())
                    {

                        if (helper.Caisser("Encaisser", AccountName[0], amount.Text) > 0)
                        {

                            helper.EditAccount(double.Parse(newAmount), SelectedAccount);
                            AccountAdded(sender, e);

                        }
                        else
                        {
                            MessageBoxer.showErrorMsg("Une erreur s'est produite");
                        }

                    }
                }
                DisplayAccounts();

            }
            else
            {
                MessageBoxer.showGeneralMsg("Sélectionnez un compte et saisissez une valeur pour le modifier.");
            }
        }

        private void Factures_Click(object sender, EventArgs e)
        {

            Ventes.Checked = false;
            decaiss.Checked = false;
            encaiss.Checked = false;
            searching = true;
            rowSelected = false;

            TableContent = "achat";
            delete.Text = delete.Tag.ToString();

            if (Achats.Checked)
            {
                selection = 0;
                currentPage = 1;

                using (DBHelper helper = new DBHelper())
                {

                    DataTable data = helper.searchForOps("Achat", selection, limit, currentPage);
                    regLines.DataSource = data;
                }


            }
        }

        private void Ventes_Click(object sender, EventArgs e)
        {

            encaiss.Checked = false;
            decaiss.Checked = false;
            Achats.Checked = false;
            searching = true;
            rowSelected = false;

            TableContent = "vente";
            delete.Text = delete.Tag.ToString();


            if (Ventes.Checked)
            {
                selection = 0;
                currentPage = 1;

                using (DBHelper helper = new DBHelper())
                {

                    DataTable data = helper.searchForOps("Vente", selection, limit, currentPage);
                    regLines.DataSource = data;
                }


            }
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = guna2DateTimePicker1.Value.Date;
            string day = date.Day.ToString("D2"), month = date.Month.ToString("D2");

            string dateString = day + "-" + month + "-" + date.Year.ToString();
            selection = 2;
            using (DBHelper helper = new DBHelper())
            {

                DataTable data = helper.searchForOps(dateString, selection, limit, currentPage);
                regLines.DataSource = data;
            }
        }



        private void iconButton4_Click(object sender, EventArgs e)
        {
            table = helper.selectRegisterLines(limit, 1);

            encaiss.Checked = false;
            decaiss.Checked = false;
            Achats.Checked = false;
            Ventes.Checked = false;
            searching = false;
            TableContent = "";

            regLines.Invoke((Action)(() => {

                regLines.DataSource = helper.selectRegisterLines(limit, currentPage);


            }));

            using (DBHelper helper = new DBHelper())
            {
                entries = helper.GetEntriesAndSpendings(out spendings);
                today.Checked = true;
                Profit = helper.GetProfit("d",false);

            }

            entre.BeginInvoke(new Action(() => {
                entre.Text = entries.ToString("F2");
                sortie.Text = spendings.ToString("F2");
                benefToday.Text = ProfitToday.ToString("F2");
                benef.Text = Profit.ToString("F2");

            }));


            zakat.BeginInvoke(new Action(() => {

                using (DBHelper helper = new DBHelper())
                {
                    zakat.Text = helper.GetZakat().ToString("F2");
                    capitalTXT.Text = helper.GetCapital().ToString("F2");

                }
            }));
        }

        private void Caisse_Shown(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();

        }


        BindingSource bindingSource;
        public void AddTable(int currentPage)
        {
            bindingSource = new BindingSource();
            table = helper.selectRegisterLines(limit, currentPage);
            rowSelected = false;
            bindingSource.DataSource = table;
            regLines.DataSource = bindingSource;
        }
        private void regLines_Scroll(object sender, ScrollEventArgs e)
        {
            int totalHeight = 0;


            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
            {

                foreach (DataGridViewRow row in regLines.Rows)
                    totalHeight += row.Height;


                if (!searching)
                {

                    if (regLines.VerticalScrollingOffset == 0 && e.NewValue < e.OldValue)
                    {
                        if (currentPage > 1)
                        {
                            currentPage--;
                            AddTable(currentPage);
                            tableFull = false;


                        }
                        else
                        {
                            AddTable(1);
                        }
                    }

                    if (totalHeight - regLines.Height < regLines.VerticalScrollingOffset)
                    {
                        if (currentPage == 1)
                        {
                            AddTable(currentPage);

                        }
                        else if (currentPage != 1 && !tableFull)
                        {
                            AddTable(currentPage);

                            if (table.Rows.Count < limit)
                            {
                                tableFull = true;
                            }

                        }

                        if (!tableFull)
                        {
                            currentPage++;

                        }

                    }

                    delete.Text = delete.Tag.ToString();

                }
            }

        }
        void worker1_workCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            worker2.RunWorkerCompleted += worker2_workCompleted;
            worker2.DoWork += worker2_Work;
            worker2.RunWorkerAsync();
        }

        private void enc_Click(object sender, EventArgs e)
        {
            DecEnc decEnc = new DecEnc();
            decEnc.Done += Withdrawal;
            decEnc.Text = "Encaisser";
            decEnc.ShowDialog();
        }

        private void Withdrawal(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                entries = helper.GetEntriesAndSpendings(out spendings);

            }

            entre.BeginInvoke(new Action(() =>
            {
                entre.Text = entries.ToString("F2");
                sortie.Text = spendings.ToString("F2");
            }));

        }



        private void dec_Click(object sender, EventArgs e)
        {
            DecEnc decEnc = new DecEnc();
            decEnc.Done += Withdrawal;
            decEnc.Text = "Décaisser";
            decEnc.ShowDialog();
        }

        private void decaiss_Click(object sender, EventArgs e)
        {
            Achats.Checked = false;
            Ventes.Checked = false;
            encaiss.Checked = false;
            searching = true;
            rowSelected = false;

            TableContent = "dec";

            delete.Text = delete.Tag.ToString();

            if (decaiss.Checked)
            {
                selection = 0;
                currentPage = 1;

                using (DBHelper helper = new DBHelper())
                {

                    DataTable data = helper.selectMoney("DEC");
                    regLines.DataSource = data;
                }


            }
        }

        private void regLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            regLines.ClearSelection();
        }
        private void encaiss_Click(object sender, EventArgs e)
        {
            Ventes.Checked = false;
            decaiss.Checked = false;
            Achats.Checked = false;
            searching = true;
            rowSelected = false;

            TableContent = "enc";
            delete.Text = delete.Tag.ToString();

            if (encaiss.Checked)
            {
                selection = 0;
                currentPage = 1;

                using (DBHelper helper = new DBHelper())
                {

                    DataTable data = helper.selectMoney("ENC");
                    regLines.DataSource = data;
                }


            }
        }
        double entries, spendings;
        double ProfitToday, Profit;

        private void searchText_IconRightClick(object sender, EventArgs e)
        {

            using (DBHelper helper = new DBHelper())
            {

                DataTable data = helper.searchForOps(searchText.Text, selection, limit, currentPage);
                regLines.DataSource = data;
            }

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            string date = "";

            using (DBHelper helper = new DBHelper())
            {
                if (!helper.CheckZakat(out date))
                {
                    DialogResult result = MessageBox.Show("  Êtes vous sûr ?", ""
                               , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {

                        if (helper.Caisser("Décaisser", "Zakat", zakat.Text.Replace(",", ".")) > 0)
                        {

                            ZakatWithdrawn(sender, e);

                        }

                    }
                }
                else
                {
                    MessageBoxer.showGeneralMsg("Vous avez déjà retiré la zakat le : " + date + ", supprimez-la d'abord de la table des décaissement");
                }
            }

        }

        private void regLines_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        List<string> IDs;
        bool rowSelected = false;
        private void regLines_SelectionChanged(object sender, EventArgs e)
        {

            if (rowSelected && table.Rows.Count>0)
            {
                IDs = new List<string>();

                for (int i = 0; i < regLines.SelectedRows.Count; i++)
                {
                    if (regLines.SelectedRows[i].Cells[2].Value != null)
                    {
                        IDs.Add(regLines.SelectedRows[i].Cells[2].Value.ToString());

                    }
                }

                if (regLines.SelectedRows.Count > 1)
                {
                    delete.Text = "Supprimer  " + regLines.SelectedRows.Count.ToString();

                }
                else
                {
                    delete.Text = "Supprimer  " + regLines.SelectedRows[0].Cells[2].Value.ToString();

                }
            }


        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (delete.Text != delete.Tag.ToString())
            {
                DialogResult result = MessageBox.Show("  Êtes vous sûr ?", ""
             , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    rowSelected = false;

                    if (TableContent == "enc")
                    {
                        using (DBHelper helper = new DBHelper())
                        {
                            if (regLines.SelectedRows[0].Cells[0].Value != null)
                            {
                                string motif = regLines.SelectedRows[0].Cells[3].Value.ToString();
                                string amount = regLines.SelectedRows[0].Cells[4].Value.ToString();

                                if (helper.DeleteWithdrwalsAndDeposits("encaissement", "n_en", regLines.SelectedRows[0].Cells[0].
                                    Value.ToString(), motif, double.Parse(amount.Replace(".", ","))) > 0)
                                {
                                    encaiss.Checked = true;
                                    encaiss_Click(sender, e);

                                }
                            }
                        }

                    }
                    else if (TableContent == "dec")
                    {
                        using (DBHelper helper = new DBHelper())
                        {
                            if (regLines.SelectedRows[0].Cells[0].Value != null)
                            {
                                string motif = regLines.SelectedRows[0].Cells[3].Value.ToString();
                                string amount = regLines.SelectedRows[0].Cells[4].Value.ToString();
                                if (helper.DeleteWithdrwalsAndDeposits("decaissement", "n_dec", regLines.SelectedRows[0].Cells[0].
                                    Value.ToString(), motif, double.Parse(amount.Replace(".", ","))) > 0)


                                {
                                    decaiss.Checked = true;
                                    decaiss_Click(sender, e);

                                }
                            }
                        }
                    }
                    else
                    {
                        using (DBHelper helper = new DBHelper())
                        {
                            if (helper.DeleteFromRegistry(IDs) > 0)
                            {
                                table = helper.selectRegisterLines(limit, 1);

                                regLines.DataSource = table;
                                delete.Text = delete.Tag.ToString();
                            }
                            else
                            {
                                MessageBoxer.showErrorMsg("Une erreur s'est produite");
                            }
                        }
                    }

                }
            }
            else
            {
                MessageBoxer.showGeneralMsg("Aucune ligne séléctionnée");

            }
        }

        private void regLines_MouseClick(object sender, MouseEventArgs e)
        {
            rowSelected = true;
            regLines_SelectionChanged(sender, e);

            if (TableContent == "enc")
            {
                delete.Text = "Supprimer  " + regLines.SelectedRows[0].Cells[0].Value.ToString();

            }
            else if (TableContent == "dec")
            {
                delete.Text = "Supprimer  " + regLines.SelectedRows[0].Cells[0].Value.ToString();

            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void regLines_Leave(object sender, EventArgs e)
        {
            rowSelected = false;
        }

        private void Comptes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedAccount = Comptes.SelectedRows[0].Cells[0].Value.ToString(); 
        }

        private void Comptes_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                DeleteClick(sender, e); 
            }
        }

        private void regLines_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                delete_Click(sender, e);
            }
        }

        private void today_CheckedChanged(object sender, EventArgs e)
        {
            if (today.Checked == true)
            {
                thisWeek.Checked = false;
                thisMonth.Checked = false;
            }

            groupBox3.BeginInvoke((Action)(() => {
                groupBox3.Text = "Profits d'aujourd'hui:";
            }));

            setProfitText("d");



        }

        private void thisWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (thisWeek.Checked == true)
            {
                today.Checked = false;
                thisMonth.Checked = false;
            }

            groupBox3.BeginInvoke((Action)(() => {
                groupBox3.Text = "Profits de la semaine:";
            }));

            setProfitText("w");

        }

        private void thisMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (thisMonth.Checked == true)
            {
                today.Checked = false;
                thisWeek.Checked = false;
            }

            groupBox3.BeginInvoke((Action)(() => {
                groupBox3.Text = "Profits du mois:";
            }));


            setProfitText("m");
        }
        public void setProfitText(string duration)
        {

            using(DBHelper helper = new DBHelper())
            {
                ProfitToday = helper.GetProfit(duration, true);

                benef.BeginInvoke((Action)(() =>
                {
                    benefToday.Text = ProfitToday.ToString("F2");
                }));

            }
        }

    
        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selection = -1;

                using (DBHelper helper = new DBHelper())
                {

                    DataTable data = helper.searchForOps(searchText.Text, selection, limit, currentPage);
                    regLines.DataSource = data;
                }

                e.SuppressKeyPress = true;

            }
        }

        void GetMoney(object sender, DoWorkEventArgs e)
        {

            using (DBHelper helper = new DBHelper())
            {
                entries = helper.GetEntriesAndSpendings(out spendings);
                today_CheckedChanged(sender, e);
                Profit = helper.GetProfit("d",false);

            }
        }
        void GetMoneyCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            entre.BeginInvoke(new Action(() => {
                entre.Text = entries.ToString("F2");
                sortie.Text = spendings.ToString("F2");
                benefToday.Text = ProfitToday.ToString("F2");
                benef.Text = Profit.ToString("F2");
            }));


            zakat.BeginInvoke(new Action(() => {

                using (DBHelper helper = new DBHelper())
                {
                    zakat.Text = helper.GetZakat().ToString("F2");
                }
            }));



        }
        void worker2_workCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Comptes.Invoke((Action)(() => {

                Comptes.DataSource = items;

            }));



            worker3.DoWork += GetMoney;
            worker3.RunWorkerCompleted += GetMoneyCompleted;
            worker3.RunWorkerAsync();

        }
        void worker1_Work(object sender, DoWorkEventArgs e)
        {

            entre.Invoke((Action)(() => {

                entre.Text = entresort[0].ToString("F2");
                sortie.Text = entresort[1].ToString("F2");
                capitalTXT.Text = helper.GetCapital().ToString("F2");

            }));
        }
        void worker2_Work(object sender, DoWorkEventArgs e)
        {
            items = DBHelper.GetSavingAccounts();

        }
    }
}
