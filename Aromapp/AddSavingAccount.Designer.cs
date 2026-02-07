namespace Aromapp
{
    partial class AddSavingAccount
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.amount = new Aromapp.HintTexBox();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new Aromapp.HintTexBox();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 237);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(15, 18, 15, 18);
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(656, 112);
            this.tableLayoutPanel3.TabIndex = 29;
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
            this.annuler.Location = new System.Drawing.Point(18, 21);
            this.annuler.Name = "annuler";
            this.annuler.Size = new System.Drawing.Size(307, 70);
            this.annuler.TabIndex = 0;
            this.annuler.Text = "Annuler";
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
            this.Okbtn.Location = new System.Drawing.Point(338, 21);
            this.Okbtn.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.Okbtn.Name = "Okbtn";
            this.Okbtn.Size = new System.Drawing.Size(300, 70);
            this.Okbtn.TabIndex = 0;
            this.Okbtn.Text = "OK";
            this.Okbtn.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.31788F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.68212F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.amount, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.name, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(604, 172);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 39);
            this.label1.TabIndex = 22;
            this.label1.Text = "Nom";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // amount
            // 
            this.amount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.amount.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.amount.ForeColor = System.Drawing.Color.Black;
            this.amount.Location = new System.Drawing.Point(168, 122);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(433, 47);
            this.amount.TabIndex = 25;
            this.amount.Tag = "Montant payé...";
            this.amount.Text = "1";
            this.amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 39);
            this.label2.TabIndex = 23;
            this.label2.Text = "Montant";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.name.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.name.ForeColor = System.Drawing.Color.Black;
            this.name.Location = new System.Drawing.Point(168, 36);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(433, 47);
            this.name.TabIndex = 24;
            this.name.Tag = "Montant payé...";
            this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AddSavingAccount
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 349);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(660, 413);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(660, 413);
            this.Name = "AddSavingAccount";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter un compte";
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Guna.UI2.WinForms.Guna2Button annuler;
        private Guna.UI2.WinForms.Guna2Button Okbtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private HintTexBox amount;
        private System.Windows.Forms.Label label2;
        private HintTexBox name;
    }
}