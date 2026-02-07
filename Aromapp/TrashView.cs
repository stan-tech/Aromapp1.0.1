using DevExpress.Data.Helpers;
using DocumentFormat.OpenXml.Drawing;
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
    public partial class TrashView : UserControl
    {
        public string Page{get;set;}
        TrashDBHelper db;

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

        private void TrashView_Load(object sender, EventArgs e)
        {

            using(db = new TrashDBHelper())
            {
                switch (Page)
                {
                    case "Produits":
                        trashGridView.DataSource = db.GetTrashProduits();
                        break;

                    case "Users":
                        trashGridView.DataSource = db.GetTrashUsers();
                        break;

                    case "Clients":
                        trashGridView.DataSource = db.GetTrashClients();
                        break;

                    case "Suppliers":
                        trashGridView.DataSource = db.GetTrashFournisseurs();
                        break;

                    case "Sales":
                        trashGridView.DataSource = db.GetTrashVentes();
                        break;

                    case "Purchases":
                        trashGridView.DataSource = db.GetTrashAchat();
                        break;

                    default:
                        trashGridView.DataSource = null;
                        break;
                }
            }
           
            AddTrashActionButtons(trashGridView);
            trashGridView.CellClick += trashGridView_CellClick;


        }

        private void AddTrashActionButtons(DataGridView grid)
        {
            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (col.Name == "Delete" || col.Name == "Recover")
                {
                    grid.Columns.Remove(col);
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

            //grid.CellPainting -= Grid_CellPainting; // remove any previous handler
            //grid.CellPainting += Grid_CellPainting;
        }

        private void trashGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; 

            var selectedId = trashGridView.Rows[e.RowIndex].Cells["Réf"].Value.ToString();


            if (trashGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                db.PermanentlyDelete(Page, selectedId);
                trashGridView.Rows.RemoveAt(e.RowIndex);
            }
            else if (trashGridView.Columns[e.ColumnIndex].Name == "Recover")
            {
                db.RestoreFromTrash(Page, selectedId);
                trashGridView.Rows.RemoveAt(e.RowIndex);
            }
        }


        private void Grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var grid = (DataGridView)sender;


            if (e.RowIndex < 0 || ((DataGridView)sender).Rows[e.RowIndex].IsNewRow) return;


            if (grid.Columns[e.ColumnIndex].Name == "Delete" || grid.Columns[e.ColumnIndex].Name == "Recover")
            {
                e.Handled = true; 

                Color btnColor = grid.Columns[e.ColumnIndex].Name == "Delete"
                    ? Color.FromArgb(220, 53, 69)      
                    : Color.RoyalBlue;                 

                System.Drawing.Rectangle paddedBounds = new System.Drawing.Rectangle(
                    e.CellBounds.X + 4,    // left padding
                    e.CellBounds.Y + 2,    // top padding
                    e.CellBounds.Width - 8, // right padding
                    e.CellBounds.Height - 4 // bottom padding
                );

                using (var brush = new SolidBrush(btnColor))
                {
                    e.Graphics.FillRectangle(brush, paddedBounds);
                }

                // Draw text centered
                TextRenderer.DrawText(
                    e.Graphics,
                    e.FormattedValue.ToString(),
                    new Font("Calibri", 14.25f, FontStyle.Bold),
                    paddedBounds,
                    Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                // Draw light border
                e.Graphics.DrawRectangle(Pens.LightGray, paddedBounds);
            }


        }


    }

}
