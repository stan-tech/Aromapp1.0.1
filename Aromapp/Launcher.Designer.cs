using System.Windows.Forms;

namespace Aromapp
{
    partial class Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.getStartedBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.StoreName = new Aromapp.HintTexBox();
            this.StoreActivity = new Aromapp.HintTexBox();
            this.Address = new Aromapp.HintTexBox();
            this.rc = new Aromapp.HintTexBox();
            this.nif = new Aromapp.HintTexBox();
            this.guna2GroupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.email = new Aromapp.HintTexBox();
            this.phone = new Aromapp.HintTexBox();
            this.fax = new Aromapp.HintTexBox();
            this.create = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.getStartedBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.getStartedBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.guna2GroupBox1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1218, 629);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // getStartedBox
            // 
            this.getStartedBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.getStartedBox.Controls.Add(this.tableLayoutPanel2);
            this.getStartedBox.Font = new System.Drawing.Font("Calibri", 9.25F, System.Drawing.FontStyle.Bold);
            this.getStartedBox.ForeColor = System.Drawing.Color.White;
            this.getStartedBox.Location = new System.Drawing.Point(16, 16);
            this.getStartedBox.Margin = new System.Windows.Forms.Padding(6);
            this.getStartedBox.Name = "getStartedBox";
            this.getStartedBox.Padding = new System.Windows.Forms.Padding(20);
            this.getStartedBox.Size = new System.Drawing.Size(587, 597);
            this.getStartedBox.TabIndex = 6;
            this.getStartedBox.TabStop = false;
            this.getStartedBox.Text = "Démarrer ici";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.StoreName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.StoreActivity, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.Address, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.rc, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.nif, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(20, 51);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(547, 526);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // StoreName
            // 
            this.StoreName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StoreName.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.StoreName.ForeColor = System.Drawing.Color.Gray;
            this.StoreName.Location = new System.Drawing.Point(3, 3);
            this.StoreName.Name = "StoreName";
            this.StoreName.Size = new System.Drawing.Size(541, 47);
            this.StoreName.TabIndex = 31;
            this.StoreName.Tag = "Nom du magasin...";
            this.StoreName.Text = "Nom du magasin...";
            this.StoreName.Click += new System.EventHandler(this.StoreName_Click);
            this.StoreName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StoreName_KeyDown);
            this.StoreName.Leave += new System.EventHandler(this.StoreName_Leave);
            // 
            // StoreActivity
            // 
            this.StoreActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StoreActivity.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.StoreActivity.ForeColor = System.Drawing.Color.Gray;
            this.StoreActivity.Location = new System.Drawing.Point(3, 108);
            this.StoreActivity.Name = "StoreActivity";
            this.StoreActivity.Size = new System.Drawing.Size(541, 47);
            this.StoreActivity.TabIndex = 31;
            this.StoreActivity.Tag = "Activité du magasin...";
            this.StoreActivity.Text = "Activité du magasin...";
            this.StoreActivity.Click += new System.EventHandler(this.StoreActivity_Click);
            this.StoreActivity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StoreActivity_KeyDown);
            this.StoreActivity.Leave += new System.EventHandler(this.StoreActivity_Leave);
            // 
            // Address
            // 
            this.Address.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Address.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.Address.ForeColor = System.Drawing.Color.Gray;
            this.Address.Location = new System.Drawing.Point(3, 213);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(541, 47);
            this.Address.TabIndex = 31;
            this.Address.Tag = "Adresse du magasin...";
            this.Address.Text = "Adresse du magasin...";
            this.Address.Click += new System.EventHandler(this.Address_Click);
            this.Address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Address_KeyDown);
            this.Address.Leave += new System.EventHandler(this.Address_Leave);
            // 
            // rc
            // 
            this.rc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rc.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.rc.ForeColor = System.Drawing.Color.Gray;
            this.rc.Location = new System.Drawing.Point(3, 318);
            this.rc.Name = "rc";
            this.rc.Size = new System.Drawing.Size(541, 47);
            this.rc.TabIndex = 31;
            this.rc.Tag = "Numéro du registre commercial...";
            this.rc.Text = "Numéro du registre commercial...";
            this.rc.Click += new System.EventHandler(this.rc_Click);
            this.rc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rc_KeyDown);
            this.rc.Leave += new System.EventHandler(this.rc_Leave);
            // 
            // nif
            // 
            this.nif.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nif.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.nif.ForeColor = System.Drawing.Color.Gray;
            this.nif.Location = new System.Drawing.Point(3, 423);
            this.nif.Name = "nif";
            this.nif.Size = new System.Drawing.Size(541, 47);
            this.nif.TabIndex = 31;
            this.nif.Tag = "NIF...";
            this.nif.Text = "NIF...";
            this.nif.Click += new System.EventHandler(this.nif_Click);
            this.nif.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nif_KeyDown);
            this.nif.Leave += new System.EventHandler(this.nif_Leave);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GroupBox1.Controls.Add(this.tableLayoutPanel3);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Calibri", 9.25F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(615, 16);
            this.guna2GroupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Padding = new System.Windows.Forms.Padding(20);
            this.guna2GroupBox1.Size = new System.Drawing.Size(587, 597);
            this.guna2GroupBox1.TabIndex = 6;
            this.guna2GroupBox1.TabStop = false;
            this.guna2GroupBox1.Text = "Contact";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.email, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.phone, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.fax, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(20, 51);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(547, 526);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // email
            // 
            this.email.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.email.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.email.ForeColor = System.Drawing.Color.Gray;
            this.email.Location = new System.Drawing.Point(3, 3);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(541, 47);
            this.email.TabIndex = 31;
            this.email.Tag = "Email...";
            this.email.Text = "Email...";
            this.email.Click += new System.EventHandler(this.email_Click);
            this.email.KeyDown += new System.Windows.Forms.KeyEventHandler(this.email_KeyDown);
            this.email.Leave += new System.EventHandler(this.email_Leave);
            // 
            // phone
            // 
            this.phone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.phone.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.phone.ForeColor = System.Drawing.Color.Gray;
            this.phone.Location = new System.Drawing.Point(3, 108);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(541, 47);
            this.phone.TabIndex = 31;
            this.phone.Tag = "Téléphone...";
            this.phone.Text = "Téléphone...";
            this.phone.Click += new System.EventHandler(this.phone_Click);
            this.phone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phone_KeyDown);
            this.phone.Leave += new System.EventHandler(this.phone_Leave);
            // 
            // fax
            // 
            this.fax.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fax.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.fax.ForeColor = System.Drawing.Color.Gray;
            this.fax.Location = new System.Drawing.Point(3, 213);
            this.fax.Name = "fax";
            this.fax.Size = new System.Drawing.Size(541, 47);
            this.fax.TabIndex = 31;
            this.fax.Tag = "FAX...";
            this.fax.Text = "FAX...";
            this.fax.Click += new System.EventHandler(this.fax_Click);
            this.fax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fax_KeyDown);
            this.fax.Leave += new System.EventHandler(this.fax_Leave);
            // 
            // create
            // 
            this.create.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.create.BackColor = System.Drawing.Color.PaleTurquoise;
            this.create.Font = new System.Drawing.Font("Calibri", 10.25F);
            this.create.ForeColor = System.Drawing.Color.Black;
            this.create.Location = new System.Drawing.Point(200, 655);
            this.create.Margin = new System.Windows.Forms.Padding(200, 20, 200, 25);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(824, 75);
            this.create.TabIndex = 34;
            this.create.Text = "Cérer mon magasin";
            this.create.UseVisualStyleBackColor = false;
            this.create.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(6, 761);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(20);
            this.groupBox1.Size = new System.Drawing.Size(1212, 273);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contact";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Consolas", 8F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(26, 162);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.label2.Size = new System.Drawing.Size(1036, 82);
            this.label2.TabIndex = 2;
            this.label2.Text = "Version : 1.0     | Contact du développeur : amen7511@gmail.com";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 8F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.label1.Size = new System.Drawing.Size(1024, 69);
            this.label1.TabIndex = 3;
            this.label1.Text = "Aromapp est une application de gestion de magasin développée par Stan-Tech.";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.create, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.11111F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.57407F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.31482F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1224, 1040);
            this.tableLayoutPanel4.TabIndex = 36;
            // 
            // Launcher
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 1080);
            this.Controls.Add(this.tableLayoutPanel4);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("Launcher.IconOptions.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Launcher";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Démarrer";
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.getStartedBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.guna2GroupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private GroupBox getStartedBox;
        private GroupBox guna2GroupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button create;
        private HintTexBox StoreName;
        private HintTexBox StoreActivity;
        private TableLayoutPanel tableLayoutPanel3;
        private HintTexBox email;
        private HintTexBox phone;
        private GroupBox groupBox1;
        private HintTexBox Address;
        private HintTexBox rc;
        private HintTexBox nif;
        private HintTexBox fax;
        private Label label2;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel4;
    }
}