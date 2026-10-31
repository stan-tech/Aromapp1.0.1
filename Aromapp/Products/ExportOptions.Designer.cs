namespace Aromapp
{
    partial class ExportOptions
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.annuler = new Guna.UI2.WinForms.Guna2Button();
            this.Okbtn = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.DateTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DateFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.annuler, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Okbtn, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 102);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(585, 70);
            this.tableLayoutPanel3.TabIndex = 27;
            // 
            // annuler
            // 
            this.annuler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.annuler.BorderRadius = 5;
            this.annuler.FillColor = System.Drawing.Color.Red;
            this.annuler.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.annuler.ForeColor = System.Drawing.Color.White;
            this.annuler.Location = new System.Drawing.Point(12, 13);
            this.annuler.Margin = new System.Windows.Forms.Padding(2, 2, 7, 2);
            this.annuler.Name = "annuler";
            this.annuler.Size = new System.Drawing.Size(273, 44);
            this.annuler.TabIndex = 0;
            this.annuler.Text = "Annuler";
            this.annuler.Click += new System.EventHandler(this.annuler_Click);
            // 
            // Okbtn
            // 
            this.Okbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Okbtn.BorderRadius = 5;
            this.Okbtn.FillColor = System.Drawing.Color.RoyalBlue;
            this.Okbtn.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.Okbtn.ForeColor = System.Drawing.Color.White;
            this.Okbtn.Location = new System.Drawing.Point(299, 13);
            this.Okbtn.Margin = new System.Windows.Forms.Padding(7, 2, 2, 2);
            this.Okbtn.Name = "Okbtn";
            this.Okbtn.Size = new System.Drawing.Size(274, 44);
            this.Okbtn.TabIndex = 0;
            this.Okbtn.Text = "Exporter";
            this.Okbtn.Click += new System.EventHandler(this.Okbtn_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.89655F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.10345F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(589, 174);
            this.tableLayoutPanel2.TabIndex = 28;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.DateTo, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.DateFrom, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(583, 93);
            this.tableLayoutPanel4.TabIndex = 28;
            // 
            // DateTo
            // 
            this.DateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTo.Checked = true;
            this.DateTo.FillColor = System.Drawing.Color.White;
            this.DateTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DateTo.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.DateTo.Location = new System.Drawing.Point(300, 49);
            this.DateTo.Margin = new System.Windows.Forms.Padding(9, 3, 3, 9);
            this.DateTo.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DateTo.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DateTo.Name = "DateTo";
            this.DateTo.Size = new System.Drawing.Size(280, 35);
            this.DateTo.TabIndex = 27;
            this.DateTo.Value = new System.DateTime(2026, 10, 24, 12, 27, 18, 748);
            this.DateTo.ValueChanged += new System.EventHandler(this.DateTo_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(300, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(9, 0, 4, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 24);
            this.label3.TabIndex = 25;
            this.label3.Text = "Fin";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "Debut";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DateFrom
            // 
            this.DateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DateFrom.Checked = true;
            this.DateFrom.FillColor = System.Drawing.Color.White;
            this.DateFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.DateFrom.Location = new System.Drawing.Point(3, 49);
            this.DateFrom.Margin = new System.Windows.Forms.Padding(3, 3, 9, 9);
            this.DateFrom.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DateFrom.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Size = new System.Drawing.Size(279, 35);
            this.DateFrom.TabIndex = 26;
            this.DateFrom.Value = new System.DateTime(2026, 10, 24, 12, 27, 18, 748);
            this.DateFrom.ValueChanged += new System.EventHandler(this.DateFrom_ValueChanged);
            // 
            // ExportOptions
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 174);
            this.Controls.Add(this.tableLayoutPanel2);
            this.IconOptions.ShowIcon = false;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options d\'exportation";
            this.Load += new System.EventHandler(this.ExportOptions_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Guna.UI2.WinForms.Guna2Button annuler;
        private Guna.UI2.WinForms.Guna2Button Okbtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateFrom;
    }
}