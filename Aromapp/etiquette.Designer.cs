namespace Aromapp
{
    partial class etiquette
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.annuler = new Guna.UI2.WinForms.Guna2Button();
            this.Imprimer = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.qtt = new Guna.UI2.WinForms.Guna2TextBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.08992F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.91008F));
            this.tableLayoutPanel2.Controls.Add(this.annuler, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Imprimer, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 215);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(805, 123);
            this.tableLayoutPanel2.TabIndex = 30;
            // 
            // annuler
            // 
            this.annuler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.annuler.BorderRadius = 5;
            this.annuler.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.annuler.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.annuler.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.annuler.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.annuler.FillColor = System.Drawing.Color.Red;
            this.annuler.Font = new System.Drawing.Font("Calibri", 10.25F);
            this.annuler.ForeColor = System.Drawing.Color.White;
            this.annuler.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.annuler.ImageSize = new System.Drawing.Size(10, 10);
            this.annuler.Location = new System.Drawing.Point(10, 20);
            this.annuler.Margin = new System.Windows.Forms.Padding(10);
            this.annuler.Name = "annuler";
            this.annuler.Size = new System.Drawing.Size(391, 83);
            this.annuler.TabIndex = 25;
            this.annuler.Text = "Annuler";
            this.annuler.Click += new System.EventHandler(this.annuler_Click);
            // 
            // Imprimer
            // 
            this.Imprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Imprimer.BorderRadius = 5;
            this.Imprimer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Imprimer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Imprimer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Imprimer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Imprimer.FillColor = System.Drawing.Color.RoyalBlue;
            this.Imprimer.Font = new System.Drawing.Font("Calibri", 10.25F);
            this.Imprimer.ForeColor = System.Drawing.Color.White;
            this.Imprimer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Imprimer.ImageSize = new System.Drawing.Size(10, 10);
            this.Imprimer.Location = new System.Drawing.Point(421, 20);
            this.Imprimer.Margin = new System.Windows.Forms.Padding(10);
            this.Imprimer.Name = "Imprimer";
            this.Imprimer.Size = new System.Drawing.Size(374, 83);
            this.Imprimer.TabIndex = 25;
            this.Imprimer.Text = "Imprimer";
            this.Imprimer.Click += new System.EventHandler(this.Imprimer_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(77, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.label1.Size = new System.Drawing.Size(645, 91);
            this.label1.TabIndex = 29;
            this.label1.Text = "Entrez le nombre des étiquettes que vous souhaitez imprimer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // qtt
            // 
            this.qtt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qtt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.qtt.DefaultText = "1";
            this.qtt.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.qtt.ForeColor = System.Drawing.Color.Black;
            this.qtt.Location = new System.Drawing.Point(147, 125);
            this.qtt.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.qtt.Name = "qtt";
            this.qtt.PasswordChar = '\0';
            this.qtt.PlaceholderText = "";
            this.qtt.SelectedText = "";
            this.qtt.Size = new System.Drawing.Size(538, 59);
            this.qtt.TabIndex = 31;
            this.qtt.Tag = "Montant payé...";
            this.qtt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // etiquette
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 338);
            this.Controls.Add(this.qtt);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.label1);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(809, 402);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(809, 402);
            this.Name = "etiquette";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimer des étiquettes";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2Button annuler;
        private Guna.UI2.WinForms.Guna2Button Imprimer;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox qtt;
    }
}