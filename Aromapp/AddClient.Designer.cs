namespace Aromapp
{
    partial class AddClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddClient));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.name = new Aromapp.HintTexBox();
            this.phone = new Aromapp.HintTexBox();
            this.address = new Aromapp.HintTexBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.debt = new Aromapp.HintTexBox();
            this.email = new Aromapp.HintTexBox();
            this.fax = new Aromapp.HintTexBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.iconButton1 = new Guna.UI2.WinForms.Guna2Button();
            this.iconButton3 = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.name, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.phone, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.address, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(180, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(639, 225);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.name.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.name.ForeColor = System.Drawing.Color.Gray;
            this.name.Location = new System.Drawing.Point(3, 3);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(633, 47);
            this.name.TabIndex = 29;
            this.name.Tag = "Nom...";
            this.name.Text = "Nom...";
            this.name.Click += new System.EventHandler(this.nameClick);
            this.name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.name_KeyDown);
            this.name.Leave += new System.EventHandler(this.nameLeave);
            // 
            // phone
            // 
            this.phone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.phone.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.phone.ForeColor = System.Drawing.Color.Gray;
            this.phone.Location = new System.Drawing.Point(3, 78);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(633, 47);
            this.phone.TabIndex = 29;
            this.phone.Tag = "Téléphone...";
            this.phone.Text = "Téléphone...";
            this.phone.Click += new System.EventHandler(this.phoneClick);
            this.phone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phone_KeyDown);
            this.phone.Leave += new System.EventHandler(this.phoneLeave);
            // 
            // address
            // 
            this.address.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.address.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.address.ForeColor = System.Drawing.Color.Gray;
            this.address.Location = new System.Drawing.Point(3, 153);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(633, 47);
            this.address.TabIndex = 29;
            this.address.Tag = "Adresse...";
            this.address.Text = "Adresse...";
            this.address.Click += new System.EventHandler(this.addressClick);
            this.address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.address_KeyDown);
            this.address.Leave += new System.EventHandler(this.addressLeave);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.debt, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.email, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.fax, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 240);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(839, 262);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // debt
            // 
            this.debt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.debt.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.debt.ForeColor = System.Drawing.Color.Gray;
            this.debt.Location = new System.Drawing.Point(20, 3);
            this.debt.Margin = new System.Windows.Forms.Padding(20, 3, 25, 3);
            this.debt.Name = "debt";
            this.debt.Size = new System.Drawing.Size(794, 47);
            this.debt.TabIndex = 29;
            this.debt.Tag = "Dettes...";
            this.debt.Text = "Dettes...";
            this.debt.Click += new System.EventHandler(this.debtsClick);
            this.debt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.debt_KeyDown);
            this.debt.Leave += new System.EventHandler(this.debtsLeave);
            // 
            // email
            // 
            this.email.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.email.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.email.ForeColor = System.Drawing.Color.Gray;
            this.email.Location = new System.Drawing.Point(20, 90);
            this.email.Margin = new System.Windows.Forms.Padding(20, 3, 25, 3);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(794, 47);
            this.email.TabIndex = 29;
            this.email.Tag = "Email...";
            this.email.Text = "Email...";
            this.email.Click += new System.EventHandler(this.emailClick);
            this.email.KeyDown += new System.Windows.Forms.KeyEventHandler(this.email_KeyDown);
            this.email.Leave += new System.EventHandler(this.emailLeave);
            // 
            // fax
            // 
            this.fax.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fax.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.fax.ForeColor = System.Drawing.Color.Gray;
            this.fax.Location = new System.Drawing.Point(20, 177);
            this.fax.Margin = new System.Windows.Forms.Padding(20, 3, 25, 3);
            this.fax.Name = "fax";
            this.fax.Size = new System.Drawing.Size(794, 47);
            this.fax.TabIndex = 29;
            this.fax.Tag = "FAX...";
            this.fax.Text = "FAX...";
            this.fax.Click += new System.EventHandler(this.faxClick);
            this.fax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fax_KeyDown);
            this.fax.Leave += new System.EventHandler(this.faxLeave);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.56673F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.43327F));
            this.tableLayoutPanel3.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(822, 231);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(20, 20, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.97218F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.02782F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(845, 611);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.iconButton1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.iconButton3, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 508);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(839, 100);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.BorderRadius = 5;
            this.iconButton1.FillColor = System.Drawing.Color.Red;
            this.iconButton1.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.Location = new System.Drawing.Point(3, 22);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(406, 75);
            this.iconButton1.TabIndex = 10;
            this.iconButton1.Text = "Annuler";
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // iconButton3
            // 
            this.iconButton3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton3.BorderRadius = 5;
            this.iconButton3.FillColor = System.Drawing.Color.RoyalBlue;
            this.iconButton3.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.iconButton3.ForeColor = System.Drawing.Color.White;
            this.iconButton3.Location = new System.Drawing.Point(429, 22);
            this.iconButton3.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(407, 75);
            this.iconButton3.TabIndex = 10;
            this.iconButton3.Text = "Ok";
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // AddClient
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 651);
            this.Controls.Add(this.tableLayoutPanel4);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddClient";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter un client";
            this.Load += new System.EventHandler(this.AddClient_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private HintTexBox name;
        private HintTexBox phone;
        private HintTexBox address;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private HintTexBox email;
        private HintTexBox fax;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private HintTexBox debt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private Guna.UI2.WinForms.Guna2Button iconButton1;
        private Guna.UI2.WinForms.Guna2Button iconButton3;
    }
}