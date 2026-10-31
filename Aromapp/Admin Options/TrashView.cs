using DevExpress.Data.Helpers;
using DevExpress.Xpo.DB.Helpers;
using DocumentFormat.OpenXml.Drawing;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Humanizer.On;

namespace Aromapp
{
    public partial class TrashView : UserControl
    {
        public string Page{get;set;}
        TrashDBHelper db;
        DateTime From, To;

        public void OnTrashViewLoad(object sender, EventArgs e)
        {
            From = FromDP.Value = DateTime.Now.AddDays( - Properties.Settings.Default.RetentionPeriod);
            To = ToDP.Value = DateTime.Now;
                       
        }

        void TextBox_Click(object sender, EventArgs e)
        {
            //HintUtils.HideHint(searchText);
        }
        void TextBox_Leave(object sender, EventArgs e)
        {
            //HintUtils.ShowHint(searchText);
        }

        public TrashView(string page)
        {
            InitializeComponent();
            trashGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            trashGridView.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = System.Drawing.Color.White,
                SelectionBackColor = System.Drawing.Color.FromArgb(255, 64, 64, 64),
                Font = new System.Drawing.Font("Calibri", 9.25f, FontStyle.Regular),
                Padding = new System.Windows.Forms.Padding(6), 
                ForeColor = System.Drawing.Color.Black,

                
                

            };
            trashGridView.RowsDefaultCellStyle = trashGridView.AlternatingRowsDefaultCellStyle;

            trashGridView.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = System.Drawing.Color.FromArgb(63, 81, 181),
                Font = new System.Drawing.Font("Calibri", 9.25f, FontStyle.Bold)
            };
            trashGridView.RowTemplate.Height = 35;

            this.Page = page;
            this.Load += TrashView_Load;
        }

        public void LoadTable()
        {
            using (db = new TrashDBHelper())
            {
                switch (Page)
                {
                    case "Produits":
                        trashGridView.DataSource = db.GetTrashProduits(From, To);
                        break;

                    case "Users":
                        trashGridView.DataSource = db.GetTrashUsers(From, To);
                        break;

                    case "Clients":
                        trashGridView.DataSource = db.GetTrashClients(From, To);
                        break;

                    case "Suppliers":
                        trashGridView.DataSource = db.GetTrashFournisseurs(From, To);
                        break;

                    case "Sales":
                        trashGridView.DataSource = db.GetTrashVentes(From, To);
                        break;

                    case "Purchases":
                        trashGridView.DataSource = db.GetTrashAchat(From, To);
                        break;

                    default:
                        trashGridView.DataSource = null;
                        break;
                }
            }
        }

        private void TrashView_Load(object sender, EventArgs e)
        {
            LoadTable();
            trashGridView.CellClick += trashGridView_CellClick;
            trashGridView.DataBindingComplete += trashGridView_DataBindingComplete;

        }

        private void trashGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AddTrashActionButtons(trashGridView);
        }

        public string GetTableName()
        {
            string tableName = "";
            switch (Page)
            {
                case "Produits":
                    tableName = "trash_produits";
                    break;

                case "Users":
                    tableName = "trash_user";
                    break;

                case "Clients":
                    tableName = "trash_client";
                    break;

                case "Suppliers":
                    tableName = "trash_fourniseur";
                    break;

                case "Sales":
                    tableName = "trash_ventes";
                    break;

                case "Purchases":
                    tableName = "trash_achat";
                    break;

                default:
                    tableName = "";
                    break;
            }
            return tableName;
        }

        private async void AddTrashActionButtons(DataGridView grid)
        {
            for (int i =0; i< grid.Columns.Count; i++)
            {
                if (grid.Columns[i].Name == "Delete" || grid.Columns[i].Name == "Recover")
                {

                    grid.Columns.RemoveAt(i);
                    i = -1;
                }
            }

            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
            deleteBtn.Name = "Delete";
            deleteBtn.HeaderText = "Supprimer définitivement";
            deleteBtn.Text = "🗑";
            deleteBtn.UseColumnTextForButtonValue = true;
            deleteBtn.DefaultCellStyle = new DataGridViewCellStyle()
            {


                Font = new System.Drawing.Font("Calibri", 20.25f, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
            };
            deleteBtn.Width = 120;
            grid.Columns.Add(deleteBtn);

            DataGridViewButtonColumn recoverBtn = new DataGridViewButtonColumn();
            recoverBtn.Name = "Recover";
            recoverBtn.HeaderText = "Restaurer";
            recoverBtn.Text = "↻";
            
            recoverBtn.UseColumnTextForButtonValue = true;
            recoverBtn.Width = 100;
            recoverBtn.DefaultCellStyle = new DataGridViewCellStyle()
            {

                Font = new System.Drawing.Font("Calibri", 20.25f, FontStyle.Bold),
                Alignment=DataGridViewContentAlignment.MiddleCenter,
                

            };

            grid.Columns.Add(recoverBtn);


            deleteBtn.DisplayIndex = grid.Columns.Count - 2;
            recoverBtn.DisplayIndex = grid.Columns.Count - 1;

        }

        private void trashGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; 

            var selectedId = trashGridView.Rows[e.RowIndex].Cells["Réf"].Value.ToString();


            if (trashGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                if(MessageBox.Show("Continuer?", "Supprimer définitivement", MessageBoxButtons.YesNo)== DialogResult.Yes)
                {
                    db.PermanentlyDelete(Page, selectedId);
                    trashGridView.Rows.RemoveAt(e.RowIndex);
                }
               
            }
            else if (trashGridView.Columns[e.ColumnIndex].Name == "Recover")
            {
                db.RestoreFromTrash(Page, selectedId);
                trashGridView.Rows.RemoveAt(e.RowIndex);
            }
        }


   
        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                string search = searchText.Text;

                using (db = new TrashDBHelper())
                {
                    switch (Page)
                    {
                        case "Produits":
                            trashGridView.DataSource = db.GetTrashProduits(From, To, search);
                            break;

                        case "Users":
                            trashGridView.DataSource = db.GetTrashUsers(From, To, search);
                            break;

                        case "Clients":
                            trashGridView.DataSource = db.GetTrashClients(From, To, search);
                            break;

                        case "Suppliers":
                            trashGridView.DataSource = db.GetTrashFournisseurs(From, To, search);
                            break;

                        case "Sales":
                            trashGridView.DataSource = db.GetTrashVentes(From, To, search);
                            break;

                        case "Purchases":
                            trashGridView.DataSource = db.GetTrashAchat(From, To, search);
                            break;

                        default:
                            trashGridView.DataSource = null;
                            break;
                    }
                }

            }
        }

        private void ConfirmDeletion(object sender, EventArgs e)
        {
            using (TrashDBHelper helper = new TrashDBHelper())
            {
                if (helper.EmptyAllTrash())
                {
                    MessageBoxer.showGeneralMsg("La corbeille a été vidée");
                }


            }
            LoadTable();
        }

        private void deleteAll_Click(object sender, EventArgs e)
        {
            Confirm confirm = new Confirm();
            confirm.Passed += ConfirmDeletion;
            confirm.ShowDialog();

        }

        private void IntervalDeleteButton_Click(object sender, EventArgs e)
        {
            Confirm confirm = new Confirm();
            confirm.Passed += ConfirmIntervalDeletion;
            confirm.ShowDialog();
        }

        private void IntervalRestoreButton_Click(object sender, EventArgs e)
        {
            Confirm confirm = new Confirm();
            confirm.Passed += ConfirmIntervalRetrievement;
            confirm.ShowDialog();
        }

        private void ConfirmIntervalDeletion(object sender, EventArgs e)
        {
            string tableName = GetTableName();
            DateTime from = FromDP.Value, to = ToDP.Value;

         

            using (TrashDBHelper helper = new TrashDBHelper())
            {
                if (helper.PermenantlyDeleteByInterval(tableName,from,to))
                {
                    MessageBoxer.showGeneralMsg("La corbeille a été vidée des éléments de "+from+" à "+to);
                }
            }
            LoadTable();

        }

        private void FromDP_ValueChanged(object sender, EventArgs e)
        {
            From = FromDP.Value;
            To = ToDP.Value;

            LoadTable();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            FromDP.Value = DateTime.Now.AddDays(-Properties.Settings.Default.RetentionPeriod);
            ToDP.Value = DateTime.Now;
            searchText.Text = "";
            HintUtils.ShowHint(searchText);
        }

        private void ConfirmIntervalRetrievement(object sender, EventArgs e)
        {
            string tableName = GetTableName();
            DateTime from = FromDP.Value, to = ToDP.Value;

            
            using (TrashDBHelper helper = new TrashDBHelper())
            {
                if (helper.RetrieveByInterval(tableName,from,to))
                {
                    MessageBoxer.showGeneralMsg("La corbeille a été vidée des éléments de " + from + " à " + to);
                }
            }
            LoadTable();

        }


    }

}
