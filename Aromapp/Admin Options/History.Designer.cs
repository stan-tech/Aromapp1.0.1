namespace Aromapp
{
    partial class History
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.delete = new Guna.UI2.WinForms.Guna2Button();
            this.iconButton5 = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.searchText = new Aromapp.HintTexBox();
            this.iconButton4 = new Guna.UI2.WinForms.Guna2Button();
            this.Transaction = new System.Windows.Forms.ComboBox();
            this.HistTable = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HistTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Transaction, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.HistTable, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1134, 1057);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.delete, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.iconButton5, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 952);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1128, 102);
            this.tableLayoutPanel6.TabIndex = 30;
            // 
            // delete
            // 
            this.delete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.delete.BorderRadius = 5;
            this.delete.FillColor = System.Drawing.Color.Red;
            this.delete.Font = new System.Drawing.Font("Calibri", 9.25F);
            this.delete.ForeColor = System.Drawing.Color.White;
            this.delete.Location = new System.Drawing.Point(3, 30);
            this.delete.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(556, 69);
            this.delete.TabIndex = 1;
            this.delete.Text = "Supprimer ";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // iconButton5
            // 
            this.iconButton5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton5.BorderRadius = 5;
            this.iconButton5.FillColor = System.Drawing.Color.RoyalBlue;
            this.iconButton5.Font = new System.Drawing.Font("Calibri", 9.25F);
            this.iconButton5.ForeColor = System.Drawing.Color.White;
            this.iconButton5.Location = new System.Drawing.Point(569, 30);
            this.iconButton5.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Size = new System.Drawing.Size(556, 69);
            this.iconButton5.TabIndex = 1;
            this.iconButton5.Text = "Nettoyer l\'historique";
            this.iconButton5.Click += new System.EventHandler(this.iconButton5_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.55363F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.04244F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.40917F));
            this.tableLayoutPanel4.Controls.Add(this.guna2DateTimePicker1, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.searchText, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.iconButton4, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1128, 99);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // guna2DateTimePicker1
            // 
            this.guna2DateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2DateTimePicker1.Checked = true;
            this.guna2DateTimePicker1.FillColor = System.Drawing.Color.LightSteelBlue;
            this.guna2DateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2DateTimePicker1.ForeColor = System.Drawing.Color.Black;
            this.guna2DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.guna2DateTimePicker1.Location = new System.Drawing.Point(786, 20);
            this.guna2DateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.guna2DateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            this.guna2DateTimePicker1.Size = new System.Drawing.Size(339, 50);
            this.guna2DateTimePicker1.TabIndex = 2;
            this.guna2DateTimePicker1.Value = new System.DateTime(2024, 2, 2, 14, 55, 7, 466);
            this.guna2DateTimePicker1.ValueChanged += new System.EventHandler(this.guna2DateTimePicker1_ValueChanged);
            // 
            // searchText
            // 
            this.searchText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchText.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.searchText.ForeColor = System.Drawing.Color.Gray;
            this.searchText.Location = new System.Drawing.Point(0, 20);
            this.searchText.Margin = new System.Windows.Forms.Padding(0, 20, 3, 3);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(488, 47);
            this.searchText.TabIndex = 0;
            this.searchText.Tag = "Rechercher...";
            this.searchText.Text = "Rechercher...";
            this.searchText.Click += new System.EventHandler(this.searchText_Click);
            this.searchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchText_KeyDown);
            this.searchText.Leave += new System.EventHandler(this.searchText_Leave);
            // 
            // iconButton4
            // 
            this.iconButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton4.BorderRadius = 5;
            this.iconButton4.Font = new System.Drawing.Font("Calibri", 10.25F);
            this.iconButton4.ForeColor = System.Drawing.Color.White;
            this.iconButton4.Location = new System.Drawing.Point(531, 20);
            this.iconButton4.Margin = new System.Windows.Forms.Padding(40, 20, 3, 25);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Size = new System.Drawing.Size(239, 54);
            this.iconButton4.TabIndex = 1;
            this.iconButton4.Text = "Actualiser";
            this.iconButton4.Click += new System.EventHandler(this.iconButton4_Click);
            // 
            // Transaction
            // 
            this.Transaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Transaction.Font = new System.Drawing.Font("Calibri", 9.125F);
            this.Transaction.FormattingEnabled = true;
            this.Transaction.Items.AddRange(new object[] {
            "Ventes",
            "Achats",
            "Ajout",
            "Dette"});
            this.Transaction.Location = new System.Drawing.Point(3, 163);
            this.Transaction.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.Transaction.Name = "Transaction";
            this.Transaction.Size = new System.Drawing.Size(275, 37);
            this.Transaction.TabIndex = 28;
            this.Transaction.SelectedIndexChanged += new System.EventHandler(this.Transaction_SelectedIndexChanged);
            this.Transaction.TextChanged += new System.EventHandler(this.Transaction_TextChanged);
            this.Transaction.Leave += new System.EventHandler(this.Transaction_Leave);
            // 
            // HistTable
            // 
            this.HistTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(203)))), ((int)(((byte)(232)))));
            this.HistTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.HistTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HistTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.HistTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.HistTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.HistTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.HistTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.HistTable.ColumnHeadersHeight = 60;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(220)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HistTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.HistTable.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.HistTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(201)))), ((int)(((byte)(231)))));
            this.HistTable.Location = new System.Drawing.Point(3, 213);
            this.HistTable.Name = "HistTable";
            this.HistTable.ReadOnly = true;
            this.HistTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 7.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HistTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.HistTable.RowHeadersVisible = false;
            this.HistTable.RowHeadersWidth = 82;
            this.HistTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HistTable.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.HistTable.RowTemplate.Height = 33;
            this.HistTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.HistTable.Size = new System.Drawing.Size(1128, 733);
            this.HistTable.TabIndex = 29;
            this.HistTable.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Indigo;
            this.HistTable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(203)))), ((int)(((byte)(232)))));
            this.HistTable.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.HistTable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.HistTable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.HistTable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.HistTable.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.HistTable.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(201)))), ((int)(((byte)(231)))));
            this.HistTable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.HistTable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.HistTable.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.HistTable.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.HistTable.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.HistTable.ThemeStyle.HeaderStyle.Height = 60;
            this.HistTable.ThemeStyle.ReadOnly = true;
            this.HistTable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(220)))), ((int)(((byte)(239)))));
            this.HistTable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.HistTable.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.HistTable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HistTable.ThemeStyle.RowsStyle.Height = 33;
            this.HistTable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.HistTable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.HistTable.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HistTable_Scroll);
            this.HistTable.SelectionChanged += new System.EventHandler(this.HistTable_SelectionChanged);
            this.HistTable.Leave += new System.EventHandler(this.HistTable_Leave);
            this.HistTable.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HistTable_MouseClick);
            // 
            // History
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 1097);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1178, 1161);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1178, 1161);
            this.Name = "History";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historique";
            this.Load += new System.EventHandler(this.History_Load);
            this.Shown += new System.EventHandler(this.History_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HistTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private HintTexBox searchText;
        private Guna.UI2.WinForms.Guna2Button iconButton4;
        private System.Windows.Forms.ComboBox Transaction;
        private Guna.UI2.WinForms.Guna2DataGridView HistTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private Guna.UI2.WinForms.Guna2Button delete;
        private Guna.UI2.WinForms.Guna2Button iconButton5;
    }
}