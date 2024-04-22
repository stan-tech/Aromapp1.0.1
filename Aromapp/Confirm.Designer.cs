namespace Aromapp
{
    partial class Confirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Confirm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UsersCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Factures = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.iconButton5 = new Guna.UI2.WinForms.Guna2Button();
            this.Ok = new Guna.UI2.WinForms.Guna2Button();
            this.PassWord = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(291, 32);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(137, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(410, 104);
            this.label3.TabIndex = 49;
            this.label3.Text = "La modification sera executée sous le nom de:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(274, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 39);
            this.label2.TabIndex = 50;
            this.label2.Text = "Utilisateur";
            // 
            // UsersCombo
            // 
            this.UsersCombo.Font = new System.Drawing.Font("Calibri", 10.125F);
            this.UsersCombo.FormattingEnabled = true;
            this.UsersCombo.Items.AddRange(new object[] {
            "Nom",
            "Telephone",
            "Address",
            "Activité",
            "Email",
            "Fax",
            "NIS",
            "NIF"});
            this.UsersCombo.Location = new System.Drawing.Point(139, 375);
            this.UsersCombo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.UsersCombo.Name = "UsersCombo";
            this.UsersCombo.Size = new System.Drawing.Size(409, 41);
            this.UsersCombo.TabIndex = 51;
            this.UsersCombo.SelectedIndexChanged += new System.EventHandler(this.Users_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(260, 433);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 39);
            this.label1.TabIndex = 50;
            this.label1.Text = "Mot de passe";
            // 
            // Factures
            // 
            this.Factures.BackColor = System.Drawing.Color.Black;
            this.Factures.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Factures.CheckedState.BorderRadius = 2;
            this.Factures.CheckedState.BorderThickness = 0;
            this.Factures.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Factures.Location = new System.Drawing.Point(218, 544);
            this.Factures.Name = "Factures";
            this.Factures.Size = new System.Drawing.Size(30, 30);
            this.Factures.TabIndex = 53;
            this.Factures.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.Factures.UncheckedState.BorderRadius = 2;
            this.Factures.UncheckedState.BorderThickness = 0;
            this.Factures.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.Factures.Click += new System.EventHandler(this.PassWord_IconRightClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(260, 546);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 29);
            this.label4.TabIndex = 50;
            this.label4.Text = "Afficher le mot de passe";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.iconButton5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Ok, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 616);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(15, 18, 15, 18);
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(688, 120);
            this.tableLayoutPanel3.TabIndex = 54;
            // 
            // iconButton5
            // 
            this.iconButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton5.BorderRadius = 5;
            this.iconButton5.FillColor = System.Drawing.Color.Red;
            this.iconButton5.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.iconButton5.ForeColor = System.Drawing.Color.White;
            this.iconButton5.Location = new System.Drawing.Point(18, 21);
            this.iconButton5.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Size = new System.Drawing.Size(316, 78);
            this.iconButton5.TabIndex = 0;
            this.iconButton5.Text = "Annuler";
            this.iconButton5.Click += new System.EventHandler(this.iconButton5_Click);
            // 
            // Ok
            // 
            this.Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok.BorderRadius = 5;
            this.Ok.BorderThickness = 1;
            this.Ok.FillColor = System.Drawing.Color.Gray;
            this.Ok.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.Ok.ForeColor = System.Drawing.Color.White;
            this.Ok.Location = new System.Drawing.Point(354, 21);
            this.Ok.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(316, 78);
            this.Ok.TabIndex = 0;
            this.Ok.Text = "Confirmer";
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // PassWord
            // 
            this.PassWord.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.PassWord.Location = new System.Drawing.Point(140, 481);
            this.PassWord.Name = "PassWord";
            this.PassWord.PasswordChar = '●';
            this.PassWord.Size = new System.Drawing.Size(410, 47);
            this.PassWord.TabIndex = 55;
            this.PassWord.UseSystemPasswordChar = true;
            this.PassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PassWord_KeyDown);
            // 
            // Confirm
            // 
            this.Appearance.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 736);
            this.Controls.Add(this.PassWord);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.Factures);
            this.Controls.Add(this.UsersCombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Confirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmer";
            this.Load += new System.EventHandler(this.Confirm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox UsersCombo;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CustomCheckBox Factures;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Guna.UI2.WinForms.Guna2Button iconButton5;
        private Guna.UI2.WinForms.Guna2Button Ok;
        private System.Windows.Forms.TextBox PassWord;
    }
}