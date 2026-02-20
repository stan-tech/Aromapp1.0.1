namespace Aromapp
{
    partial class TrashView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.trashGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.IntervalRestoreButton = new Guna.UI2.WinForms.Guna2Button();
            this.IntervalDeleteButton = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ToDP = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.FromDP = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.deleteAll = new Guna.UI2.WinForms.Guna2Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.RefreshBtn = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.searchText = new Aromapp.HintTexBox();
            ((System.ComponentModel.ISupportInitialize)(this.trashGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // trashGridView
            // 
            this.trashGridView.AllowUserToAddRows = false;
            this.trashGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(203)))), ((int)(((byte)(232)))));
            this.trashGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.trashGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trashGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.trashGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.trashGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.trashGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.trashGridView.ColumnHeadersHeight = 60;
            this.tableLayoutPanel1.SetColumnSpan(this.trashGridView, 2);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(220)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.trashGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.trashGridView.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.trashGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(201)))), ((int)(((byte)(231)))));
            this.trashGridView.Location = new System.Drawing.Point(30, 128);
            this.trashGridView.Margin = new System.Windows.Forms.Padding(30);
            this.trashGridView.Name = "trashGridView";
            this.trashGridView.ReadOnly = true;
            this.trashGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 7.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.trashGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.trashGridView.RowHeadersVisible = false;
            this.trashGridView.RowHeadersWidth = 82;
            this.trashGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.trashGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.trashGridView.RowTemplate.Height = 53;
            this.trashGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.trashGridView.Size = new System.Drawing.Size(1555, 647);
            this.trashGridView.TabIndex = 3;
            this.trashGridView.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Indigo;
            this.trashGridView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(203)))), ((int)(((byte)(232)))));
            this.trashGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.trashGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.trashGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.trashGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.trashGridView.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.trashGridView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(201)))), ((int)(((byte)(231)))));
            this.trashGridView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.trashGridView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.trashGridView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.trashGridView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.trashGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.trashGridView.ThemeStyle.HeaderStyle.Height = 60;
            this.trashGridView.ThemeStyle.ReadOnly = true;
            this.trashGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(220)))), ((int)(((byte)(239)))));
            this.trashGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.trashGridView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.trashGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.trashGridView.ThemeStyle.RowsStyle.Height = 53;
            this.trashGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.trashGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.trashGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.17391F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.82609F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1615, 899);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.23694F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.75791F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.00515F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.IntervalRestoreButton, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.IntervalDeleteButton, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel3, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1609, 92);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // IntervalRestoreButton
            // 
            this.IntervalRestoreButton.BorderRadius = 5;
            this.IntervalRestoreButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.IntervalRestoreButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.IntervalRestoreButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.IntervalRestoreButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.IntervalRestoreButton.FillColor = System.Drawing.Color.RoyalBlue;
            this.IntervalRestoreButton.Font = new System.Drawing.Font("Calibri", 22.25F);
            this.IntervalRestoreButton.ForeColor = System.Drawing.Color.White;
            this.IntervalRestoreButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.IntervalRestoreButton.ImageOffset = new System.Drawing.Point(15, 0);
            this.IntervalRestoreButton.ImageSize = new System.Drawing.Size(30, 30);
            this.IntervalRestoreButton.Location = new System.Drawing.Point(1502, 23);
            this.IntervalRestoreButton.Margin = new System.Windows.Forms.Padding(20, 23, 20, 5);
            this.IntervalRestoreButton.Name = "IntervalRestoreButton";
            this.IntervalRestoreButton.Size = new System.Drawing.Size(82, 64);
            this.IntervalRestoreButton.TabIndex = 43;
            this.IntervalRestoreButton.Text = "↻";
            this.IntervalRestoreButton.TextOffset = new System.Drawing.Point(0, -5);
            this.IntervalRestoreButton.Click += new System.EventHandler(this.IntervalRestoreButton_Click);
            // 
            // IntervalDeleteButton
            // 
            this.IntervalDeleteButton.BorderRadius = 5;
            this.IntervalDeleteButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.IntervalDeleteButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.IntervalDeleteButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.IntervalDeleteButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.IntervalDeleteButton.FillColor = System.Drawing.Color.Red;
            this.IntervalDeleteButton.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.IntervalDeleteButton.ForeColor = System.Drawing.Color.White;
            this.IntervalDeleteButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.IntervalDeleteButton.ImageOffset = new System.Drawing.Point(7, 0);
            this.IntervalDeleteButton.ImageSize = new System.Drawing.Size(40, 40);
            this.IntervalDeleteButton.Location = new System.Drawing.Point(1379, 23);
            this.IntervalDeleteButton.Margin = new System.Windows.Forms.Padding(20, 23, 20, 5);
            this.IntervalDeleteButton.Name = "IntervalDeleteButton";
            this.IntervalDeleteButton.Size = new System.Drawing.Size(74, 64);
            this.IntervalDeleteButton.TabIndex = 42;
            this.IntervalDeleteButton.Text = "🗑";
            this.IntervalDeleteButton.Click += new System.EventHandler(this.IntervalDeleteButton_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.54875F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.45126F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.ToDP, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(995, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(361, 86);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 56);
            this.label1.TabIndex = 25;
            this.label1.Text = " À";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ToDP
            // 
            this.ToDP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToDP.Checked = true;
            this.ToDP.FillColor = System.Drawing.Color.LightSteelBlue;
            this.ToDP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ToDP.ForeColor = System.Drawing.Color.Black;
            this.ToDP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ToDP.Location = new System.Drawing.Point(66, 22);
            this.ToDP.Margin = new System.Windows.Forms.Padding(3, 22, 3, 3);
            this.ToDP.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.ToDP.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ToDP.Name = "ToDP";
            this.ToDP.Size = new System.Drawing.Size(292, 61);
            this.ToDP.TabIndex = 4;
            this.ToDP.Value = new System.DateTime(2024, 2, 2, 14, 55, 7, 466);
            this.ToDP.ValueChanged += new System.EventHandler(this.FromDP_ValueChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.29933F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.70067F));
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.FromDP, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(577, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(412, 86);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 56);
            this.label4.TabIndex = 25;
            this.label4.Text = "De";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FromDP
            // 
            this.FromDP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FromDP.Checked = true;
            this.FromDP.FillColor = System.Drawing.Color.LightSteelBlue;
            this.FromDP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FromDP.ForeColor = System.Drawing.Color.Black;
            this.FromDP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FromDP.Location = new System.Drawing.Point(66, 22);
            this.FromDP.Margin = new System.Windows.Forms.Padding(3, 22, 3, 3);
            this.FromDP.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.FromDP.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.FromDP.Name = "FromDP";
            this.FromDP.Size = new System.Drawing.Size(343, 61);
            this.FromDP.TabIndex = 4;
            this.FromDP.Value = new System.DateTime(2024, 2, 2, 14, 55, 7, 466);
            this.FromDP.ValueChanged += new System.EventHandler(this.FromDP_ValueChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.deleteAll, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 808);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.Padding = new System.Windows.Forms.Padding(8);
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1609, 88);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // deleteAll
            // 
            this.deleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteAll.BorderRadius = 5;
            this.deleteAll.FillColor = System.Drawing.Color.Red;
            this.deleteAll.Font = new System.Drawing.Font("Calibri", 9.25F);
            this.deleteAll.ForeColor = System.Drawing.Color.White;
            this.deleteAll.Location = new System.Drawing.Point(11, 11);
            this.deleteAll.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.deleteAll.Name = "deleteAll";
            this.deleteAll.Size = new System.Drawing.Size(1585, 66);
            this.deleteAll.TabIndex = 2;
            this.deleteAll.Text = "Vider toute la corbeille";
            this.deleteAll.Click += new System.EventHandler(this.deleteAll_Click);
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshBtn.BorderRadius = 5;
            this.RefreshBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.RefreshBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.RefreshBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.RefreshBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.RefreshBtn.FillColor = System.Drawing.Color.RoyalBlue;
            this.RefreshBtn.Font = new System.Drawing.Font("Calibri", 10.25F);
            this.RefreshBtn.ForeColor = System.Drawing.Color.White;
            this.RefreshBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.RefreshBtn.ImageOffset = new System.Drawing.Point(15, 0);
            this.RefreshBtn.ImageSize = new System.Drawing.Size(30, 30);
            this.RefreshBtn.Location = new System.Drawing.Point(374, 28);
            this.RefreshBtn.Margin = new System.Windows.Forms.Padding(20, 23, 20, 5);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(180, 59);
            this.RefreshBtn.TabIndex = 44;
            this.RefreshBtn.Text = "Actualiser";
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.79578F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.20422F));
            this.tableLayoutPanel6.Controls.Add(this.RefreshBtn, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.searchText, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(574, 92);
            this.tableLayoutPanel6.TabIndex = 45;
            // 
            // searchText
            // 
            this.searchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchText.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.searchText.ForeColor = System.Drawing.Color.Gray;
            this.searchText.Location = new System.Drawing.Point(20, 37);
            this.searchText.Margin = new System.Windows.Forms.Padding(20, 25, 40, 8);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(294, 47);
            this.searchText.TabIndex = 0;
            this.searchText.Tag = "Rechercher...";
            this.searchText.Text = "Rechercher...";
            this.searchText.Click += new System.EventHandler(this.TextBox_Click);
            this.searchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchText_KeyDown);
            this.searchText.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // TrashView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TrashView";
            this.Size = new System.Drawing.Size(1615, 899);
            this.Load += new System.EventHandler(this.OnTrashViewLoad);
            ((System.ComponentModel.ISupportInitialize)(this.trashGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView trashGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private HintTexBox searchText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2DateTimePicker FromDP;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker ToDP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Button deleteAll;
        private Guna.UI2.WinForms.Guna2Button IntervalRestoreButton;
        private Guna.UI2.WinForms.Guna2Button IntervalDeleteButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private Guna.UI2.WinForms.Guna2Button RefreshBtn;
    }
}
