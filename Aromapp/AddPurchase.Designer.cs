using Guna.UI2.WinForms;

namespace Aromapp
{
    partial class AddPurchase
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.retirer = new Guna.UI2.WinForms.Guna2Button();
            this.Ajouter = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.avendre = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.StockAlert = new Aromapp.HintTexBox();
            this.Unit = new System.Windows.Forms.ComboBox();
            this.Typpe = new System.Windows.Forms.ComboBox();
            this.QT = new Aromapp.HintTexBox();
            this.priceSG = new Aromapp.HintTexBox();
            this.priceSD = new Aromapp.HintTexBox();
            this.prodName = new Guna.UI2.WinForms.Guna2TextBox();
            this.listBox1 = new System.Windows.Forms.ComboBox();
            this.prodRef = new Aromapp.HintTexBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.priceP = new Aromapp.HintTexBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.effacerbtn = new Guna.UI2.WinForms.Guna2Button();
            this.tva = new System.Windows.Forms.ComboBox();
            this.Amount = new Guna.UI2.WinForms.Guna2TextBox();
            this.suppName = new Guna.UI2.WinForms.Guna2TextBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.subtotalText = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nettotalText = new System.Windows.Forms.Label();
            this.cart = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Valider = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);

            this.Amount = new Guna.UI2.WinForms.Guna2TextBox();
            this.suppName = new Guna.UI2.WinForms.Guna2TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cart)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.retirer, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.Ajouter, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.Unit, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.Typpe, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.QT, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.priceSG, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.priceSD, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.prodName, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.prodRef, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.priceP, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.603194F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.877414F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.788945F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.951424F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.025126F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.030151F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.862647F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.872697F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.946399F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.90604F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.12081F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.0976F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(453, 1318);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // retirer
            // 
            this.retirer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.retirer.BackColor = System.Drawing.Color.Transparent;
            this.retirer.BorderRadius = 5;
            this.retirer.FillColor = System.Drawing.Color.Red;
            this.retirer.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.retirer.ForeColor = System.Drawing.Color.White;
            this.retirer.Location = new System.Drawing.Point(23, 1212);
            this.retirer.Margin = new System.Windows.Forms.Padding(3, 10, 3, 30);
            this.retirer.Name = "retirer";
            this.retirer.Size = new System.Drawing.Size(407, 76);
            this.retirer.TabIndex = 8;
            this.retirer.Text = "Retirer";
            this.retirer.Click += new System.EventHandler(this.retirer_Click);
            // 
            // Ajouter
            // 
            this.Ajouter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Ajouter.BackColor = System.Drawing.Color.Transparent;
            this.Ajouter.BorderRadius = 5;
            this.Ajouter.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.Ajouter.ForeColor = System.Drawing.Color.White;
            this.Ajouter.Location = new System.Drawing.Point(23, 1084);
            this.Ajouter.Margin = new System.Windows.Forms.Padding(3, 40, 3, 20);
            this.Ajouter.Name = "Ajouter";
            this.Ajouter.Size = new System.Drawing.Size(407, 76);
            this.Ajouter.TabIndex = 8;
            this.Ajouter.Text = "Ajouter";
            this.toolTip1.SetToolTip(this.Ajouter, "Ctrl+N");
            this.Ajouter.Click += new System.EventHandler(this.Ajouter_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.avendre);
            this.panel1.Controls.Add(this.StockAlert);
            this.panel1.Location = new System.Drawing.Point(23, 803);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 193);
            this.panel1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Calibri", 10.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(57, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 50);
            this.label1.TabIndex = 17;
            this.label1.Text = "A vendre";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // avendre
            // 
            this.avendre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.avendre.Checked = true;
            this.avendre.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.avendre.CheckedState.BorderRadius = 2;
            this.avendre.CheckedState.BorderThickness = 0;
            this.avendre.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.avendre.Location = new System.Drawing.Point(8, 122);
            this.avendre.Name = "avendre";
            this.avendre.Size = new System.Drawing.Size(40, 40);
            this.avendre.TabIndex = 16;
            this.avendre.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.avendre.UncheckedState.BorderRadius = 2;
            this.avendre.UncheckedState.BorderThickness = 0;
            this.avendre.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // StockAlert
            // 
            this.StockAlert.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StockAlert.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.StockAlert.ForeColor = System.Drawing.Color.Gray;
            this.StockAlert.Location = new System.Drawing.Point(8, 25);
            this.StockAlert.Margin = new System.Windows.Forms.Padding(3, 35, 3, 3);
            this.StockAlert.Name = "StockAlert";
            this.StockAlert.Size = new System.Drawing.Size(396, 47);
            this.StockAlert.TabIndex = 28;
            this.StockAlert.Tag = "Alerte de stock...";
            this.StockAlert.Text = "Alerte de stock...";
            this.toolTip1.SetToolTip(this.StockAlert, "Alerte de stock...");
            // 
            // Unit
            // 
            this.Unit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Unit.Font = new System.Drawing.Font("Calibri", 12.125F);
            this.Unit.FormattingEnabled = true;
            this.Unit.Items.AddRange(new object[] {
            "U",
            "L",
            "G",
            "KG",
            "M"});
            this.Unit.Location = new System.Drawing.Point(23, 681);
            this.Unit.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.Unit.Name = "Unit";
            this.Unit.Size = new System.Drawing.Size(407, 47);
            this.Unit.TabIndex = 29;
            this.Unit.SelectedIndexChanged += new System.EventHandler(this.Unit_SelectedIndexChanged);
            this.Unit.TextChanged += new System.EventHandler(this.Unit_TextChanged);
            // 
            // Typpe
            // 
            this.Typpe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Typpe.Font = new System.Drawing.Font("Calibri", 12.125F);
            this.Typpe.FormattingEnabled = true;
            this.Typpe.Items.AddRange(new object[] {
            "Homme",
            "Femme",
            "Unisexe",
            "Emabllage",
            "Sachet"});
            this.Typpe.Location = new System.Drawing.Point(23, 611);
            this.Typpe.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.Typpe.Name = "Typpe";
            this.Typpe.Size = new System.Drawing.Size(407, 47);
            this.Typpe.TabIndex = 29;
            this.Typpe.SelectedIndexChanged += new System.EventHandler(this.Type_SelectedIndexChanged);
            this.Typpe.TextChanged += new System.EventHandler(this.Type_TextChanged);
            // 
            // QT
            // 
            this.QT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QT.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.QT.ForeColor = System.Drawing.Color.Gray;
            this.QT.Location = new System.Drawing.Point(23, 543);
            this.QT.Margin = new System.Windows.Forms.Padding(3, 35, 3, 3);
            this.QT.Name = "QT";
            this.QT.Size = new System.Drawing.Size(407, 47);
            this.QT.TabIndex = 28;
            this.QT.Tag = "Quantité...";
            this.QT.Text = "Quantité...";
            this.toolTip1.SetToolTip(this.QT, "Quantité...");
            this.QT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceP_KeyPress);
            // 
            // priceSG
            // 
            this.priceSG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.priceSG.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.priceSG.ForeColor = System.Drawing.Color.Gray;
            this.priceSG.Location = new System.Drawing.Point(23, 474);
            this.priceSG.Margin = new System.Windows.Forms.Padding(3, 35, 3, 3);
            this.priceSG.Name = "priceSG";
            this.priceSG.Size = new System.Drawing.Size(407, 47);
            this.priceSG.TabIndex = 28;
            this.priceSG.Tag = "Prix de vente en gros...";
            this.priceSG.Text = "Prix de vente en gros...";
            this.toolTip1.SetToolTip(this.priceSG, "Prix de vente en gros...");
            this.priceSG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.priceSG_KeyDown);
            this.priceSG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceP_KeyPress);
            // 
            // priceSD
            // 
            this.priceSD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.priceSD.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.priceSD.ForeColor = System.Drawing.Color.Gray;
            this.priceSD.Location = new System.Drawing.Point(23, 403);
            this.priceSD.Margin = new System.Windows.Forms.Padding(3, 35, 3, 3);
            this.priceSD.Name = "priceSD";
            this.priceSD.Size = new System.Drawing.Size(407, 47);
            this.priceSD.TabIndex = 28;
            this.priceSD.Tag = "Prix de vente en detail...";
            this.priceSD.Text = "Prix de vente en detail...";
            this.toolTip1.SetToolTip(this.priceSD, "Prix de vente en detail...");
            this.priceSD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.priceSD_KeyDown);
            this.priceSD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceP_KeyPress);
            // 
            // prodName
            // 
            this.prodName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prodName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.prodName.DefaultText = "Nom de produits...";
            this.prodName.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.prodName.ForeColor = System.Drawing.Color.Gray;
            this.prodName.Location = new System.Drawing.Point(23, 252);
            this.prodName.Margin = new System.Windows.Forms.Padding(3, 25, 3, 3);
            this.prodName.Name = "prodName";
            this.prodName.PasswordChar = '\0';
            this.prodName.PlaceholderText = "";
            this.prodName.SelectedText = "";
            this.prodName.Size = new System.Drawing.Size(407, 54);
            this.prodName.TabIndex = 28;
            this.prodName.Tag = "Nom de produits...";
            this.toolTip1.SetToolTip(this.prodName, "Nom de produits...");
            this.prodName.TextChanged += new System.EventHandler(this.prodName_TextChanged);
            this.prodName.Click += new System.EventHandler(this.prodClick);
            this.prodName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.prodName_KeyDown);
            this.prodName.Leave += new System.EventHandler(this.prodLeave);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Font = new System.Drawing.Font("Calibri", 12.125F);
            this.listBox1.ForeColor = System.Drawing.Color.Black;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(23, 170);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 35, 3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(407, 47);
            this.listBox1.TabIndex = 27;
            this.listBox1.Tag = "";
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DataSourceChanged += new System.EventHandler(this.listBox1_DataSourceChanged);
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.prodRef_MouseClick);
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1MouseDown);
            // 
            // prodRef
            // 
            this.prodRef.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prodRef.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.prodRef.ForeColor = System.Drawing.Color.Gray;
            this.prodRef.Location = new System.Drawing.Point(23, 101);
            this.prodRef.Margin = new System.Windows.Forms.Padding(3, 35, 3, 3);
            this.prodRef.Name = "prodRef";
            this.prodRef.Size = new System.Drawing.Size(407, 47);
            this.prodRef.TabIndex = 28;
            this.prodRef.Tag = "Référence de produits...";
            this.prodRef.Text = "Référence de produits...";
            this.toolTip1.SetToolTip(this.prodRef, "Référence de produits...");
            this.prodRef.Click += new System.EventHandler(this.prodRef_Click);
            this.prodRef.TextChanged += new System.EventHandler(this.prodRef_TextChanged);
            this.prodRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.prodRef_KeyDown);
            this.prodRef.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.prodRef_KeyPress);
            this.prodRef.Leave += new System.EventHandler(this.prodRefLeave);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Font = new System.Drawing.Font("Calibri", 12.125F);
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Parfum",
            "Emballage/Sachet"});
            this.comboBox1.Location = new System.Drawing.Point(23, 35);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 35, 3, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(407, 47);
            this.comboBox1.TabIndex = 30;
            this.comboBox1.Tag = "";
            this.comboBox1.Text = "Catégories";
            this.toolTip1.SetToolTip(this.comboBox1, "Catégories");
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // priceP
            // 
            this.priceP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.priceP.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.priceP.ForeColor = System.Drawing.Color.Gray;
            this.priceP.Location = new System.Drawing.Point(23, 334);
            this.priceP.Margin = new System.Windows.Forms.Padding(3, 25, 3, 3);
            this.priceP.Name = "priceP";
            this.priceP.Size = new System.Drawing.Size(407, 47);
            this.priceP.TabIndex = 28;
            this.priceP.Tag = "Prix...";
            this.priceP.Text = "Prix...";
            this.toolTip1.SetToolTip(this.priceP, "Prix...");
            this.priceP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.priceP_KeyDown);
            this.priceP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceP_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.tableLayoutPanel6);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1040, 552);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Résumé du commande";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.tableLayoutPanel8);
            this.groupBox5.Font = new System.Drawing.Font("Calibri", 9.25F, System.Drawing.FontStyle.Bold);
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(40, 239);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox5.Size = new System.Drawing.Size(964, 297);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Informations sur le paiement ";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.effacerbtn, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.tva, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.Amount, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.suppName, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(10, 41);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.Padding = new System.Windows.Forms.Padding(20, 23, 20, 23);
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.94118F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.05882F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(944, 246);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // effacerbtn
            // 
            this.effacerbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.effacerbtn.BorderRadius = 5;
            this.effacerbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.effacerbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.effacerbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.effacerbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.effacerbtn.FillColor = System.Drawing.Color.Red;
            this.effacerbtn.Font = new System.Drawing.Font("Calibri", 10.25F);
            this.effacerbtn.ForeColor = System.Drawing.Color.White;
            this.effacerbtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.effacerbtn.ImageSize = new System.Drawing.Size(10, 10);
            this.effacerbtn.Location = new System.Drawing.Point(475, 148);
            this.effacerbtn.Margin = new System.Windows.Forms.Padding(3, 20, 3, 10);
            this.effacerbtn.Name = "effacerbtn";
            this.effacerbtn.Size = new System.Drawing.Size(446, 65);
            this.effacerbtn.TabIndex = 28;
            this.effacerbtn.Text = "Vider le panier";
            this.effacerbtn.Click += new System.EventHandler(this.effacerbtn_Click);
            // 
            // tva
            // 
            this.tva.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tva.Font = new System.Drawing.Font("Calibri", 9.25F);
            this.tva.FormattingEnabled = true;
            this.tva.Items.AddRange(new object[] {
            "0",
            "9",
            "19"});
            this.tva.Location = new System.Drawing.Point(23, 164);
            this.tva.Margin = new System.Windows.Forms.Padding(3, 10, 3, 20);
            this.tva.Name = "tva";
            this.tva.Size = new System.Drawing.Size(446, 39);
            this.tva.TabIndex = 26;
            this.tva.TextChanged += new System.EventHandler(this.tva_TextChanged);
            this.tva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tva_KeyPress);
            // 
            // Amount
            // 
            this.Amount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Amount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Amount.DefaultText = "Montant payé...";
            this.Amount.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.Amount.ForeColor = System.Drawing.Color.Gray;
            this.Amount.Location = new System.Drawing.Point(475, 58);
            this.Amount.Margin = new System.Windows.Forms.Padding(3, 35, 3, 25);
            this.Amount.Name = "Amount";
            this.Amount.PasswordChar = '\0';
            this.Amount.PlaceholderText = "";
            this.Amount.SelectedText = "";
            this.Amount.Size = new System.Drawing.Size(446, 45);
            this.Amount.TabIndex = 29;
            this.Amount.Tag = "Montant payé...";
            this.toolTip1.SetToolTip(this.Amount, "Montant payé...");
            this.Amount.Click += new System.EventHandler(this.AmountClick);
            this.Amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceP_KeyPress);
            this.Amount.Leave += new System.EventHandler(this.AmountLeave);
            // 
            // suppName
            // 
            this.suppName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suppName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.suppName.DefaultText = "Nom de fournisseur...";
            this.suppName.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.suppName.ForeColor = System.Drawing.Color.Gray;
            this.suppName.Location = new System.Drawing.Point(23, 58);
            this.suppName.Margin = new System.Windows.Forms.Padding(3, 35, 3, 25);
            this.suppName.Name = "suppName";
            this.suppName.PasswordChar = '\0';
            this.suppName.PlaceholderText = "";
            this.suppName.SelectedText = "";
            this.suppName.Size = new System.Drawing.Size(446, 45);
            this.suppName.TabIndex = 28;
            this.suppName.Tag = "Nom de fournisseur...";
            this.toolTip1.SetToolTip(this.suppName, "Nom de fournisseur...");
            this.suppName.TextChanged += new System.EventHandler(this.suppName_TextChanged);
            this.suppName.Click += new System.EventHandler(this.suppNameClick);
            this.suppName.Leave += new System.EventHandler(this.suppNameLeave);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.groupBox4, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(40, 52);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(964, 167);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Black;
            this.groupBox3.Controls.Add(this.subtotalText);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 9.25F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(476, 161);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sous-total";
            // 
            // subtotalText
            // 
            this.subtotalText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subtotalText.AutoSize = true;
            this.subtotalText.BackColor = System.Drawing.Color.Transparent;
            this.subtotalText.Font = new System.Drawing.Font("Calibri", 16.125F, System.Drawing.FontStyle.Bold);
            this.subtotalText.ForeColor = System.Drawing.Color.OliveDrab;
            this.subtotalText.Location = new System.Drawing.Point(39, 81);
            this.subtotalText.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.subtotalText.Name = "subtotalText";
            this.subtotalText.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.subtotalText.Size = new System.Drawing.Size(55, 53);
            this.subtotalText.TabIndex = 2;
            this.subtotalText.Text = "0";
            this.subtotalText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.BackColor = System.Drawing.Color.Black;
            this.groupBox4.Controls.Add(this.nettotalText);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 9.25F, System.Drawing.FontStyle.Bold);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(485, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(476, 161);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Total net";
            // 
            // nettotalText
            // 
            this.nettotalText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nettotalText.AutoSize = true;
            this.nettotalText.BackColor = System.Drawing.Color.Transparent;
            this.nettotalText.Font = new System.Drawing.Font("Calibri", 16.125F, System.Drawing.FontStyle.Bold);
            this.nettotalText.ForeColor = System.Drawing.Color.White;
            this.nettotalText.Location = new System.Drawing.Point(44, 81);
            this.nettotalText.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.nettotalText.Name = "nettotalText";
            this.nettotalText.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.nettotalText.Size = new System.Drawing.Size(55, 53);
            this.nettotalText.TabIndex = 1;
            this.nettotalText.Text = "0";
            this.nettotalText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cart
            // 
            this.cart.AllowUserToAddRows = false;
            this.cart.AllowUserToDeleteRows = false;
            this.cart.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(203)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(203)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.cart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.cart.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.cart.ColumnHeadersHeight = 60;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(220)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cart.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.cart.ColumnHeadersHeight = 60;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(220)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cart.DefaultCellStyle = dataGridViewCellStyle13;
            this.cart.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(201)))), ((int)(((byte)(231)))));
            this.cart.Location = new System.Drawing.Point(13, 571);
            this.cart.Name = "cart";
            this.cart.ReadOnly = true;
            this.cart.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 7.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cart.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.cart.RowHeadersVisible = false;
            this.cart.RowHeadersWidth = 82;
            this.cart.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cart.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Calibri", 7.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cart.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.cart.RowHeadersVisible = false;
            this.cart.RowHeadersWidth = 82;
            this.cart.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Calibri", 9.25F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cart.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.cart.RowTemplate.Height = 33;
            this.cart.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cart.Size = new System.Drawing.Size(1040, 623);
            this.cart.TabIndex = 2;
            this.cart.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Indigo;
            this.cart.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(203)))), ((int)(((byte)(232)))));
            this.cart.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.cart.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.cart.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.cart.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.cart.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cart.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(201)))), ((int)(((byte)(231)))));
            this.cart.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.cart.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.cart.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cart.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.cart.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.cart.ThemeStyle.HeaderStyle.Height = 60;
            this.cart.ThemeStyle.ReadOnly = true;
            this.cart.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(220)))), ((int)(((byte)(239)))));
            this.cart.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.cart.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cart.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cart.ThemeStyle.RowsStyle.Height = 33;
            this.cart.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.cart.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.cart.SelectionChanged += new System.EventHandler(this.cart_SelectionChanged);
            // 
            // Valider
            // 
            this.Valider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Valider.BackColor = System.Drawing.Color.Transparent;
            this.Valider.BorderRadius = 5;
            this.Valider.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Valider.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Valider.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Valider.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Valider.FillColor = System.Drawing.Color.Green;
            this.Valider.Font = new System.Drawing.Font("Calibri", 10.25F);
            this.Valider.ForeColor = System.Drawing.Color.White;
            this.Valider.Location = new System.Drawing.Point(13, 1212);
            this.Valider.Margin = new System.Windows.Forms.Padding(3, 10, 3, 20);
            this.Valider.Name = "Valider";
            this.Valider.Size = new System.Drawing.Size(1040, 76);
            this.Valider.TabIndex = 9;
            this.Valider.Text = "Valider";
            this.toolTip1.SetToolTip(this.Valider, "Ctrl+B");
            this.Valider.Click += new System.EventHandler(this.Valider_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.Valider, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cart, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(467, 8);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.98922F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.45917F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.424909F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1066, 1318);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1541, 1334);
            this.tableLayoutPanel3.TabIndex = 11;
            // 

            // Amount
            // 
            this.Amount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Amount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Amount.DefaultText = "Montant payé...";
            this.Amount.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.Amount.ForeColor = System.Drawing.Color.Gray;
            this.Amount.Location = new System.Drawing.Point(475, 58);
            this.Amount.Margin = new System.Windows.Forms.Padding(3, 35, 3, 25);
            this.Amount.Name = "Amount";
            this.Amount.PasswordChar = '\0';
            this.Amount.PlaceholderText = "";
            this.Amount.SelectedText = "";
            this.Amount.Size = new System.Drawing.Size(446, 45);
            this.Amount.TabIndex = 29;
            this.Amount.Tag = "Montant payé...";
            this.toolTip1.SetToolTip(this.Amount, "Montant payé...");
            this.Amount.Click += new System.EventHandler(this.AmountClick);
            this.Amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceP_KeyPress);
            this.Amount.Leave += new System.EventHandler(this.AmountLeave);
            // 
            // suppName
            // 
            this.suppName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suppName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.suppName.DefaultText = "Nom de fournisseur...";
            this.suppName.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.suppName.ForeColor = System.Drawing.Color.Gray;
            this.suppName.Location = new System.Drawing.Point(23, 58);
            this.suppName.Margin = new System.Windows.Forms.Padding(3, 35, 3, 25);
            this.suppName.Name = "suppName";
            this.suppName.PasswordChar = '\0';
            this.suppName.PlaceholderText = "";
            this.suppName.SelectedText = "";
            this.suppName.Size = new System.Drawing.Size(446, 45);
            this.suppName.TabIndex = 28;
            this.suppName.Tag = "Nom de fournisseur...";
            this.toolTip1.SetToolTip(this.suppName, "Nom de fournisseur...");
            this.suppName.TextChanged += new System.EventHandler(this.suppName_TextChanged);
            this.suppName.Click += new System.EventHandler(this.suppNameClick);
            this.suppName.Leave += new System.EventHandler(this.suppNameLeave);
            // 
            // AddPurchase
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1541, 1334);
            this.Controls.Add(this.tableLayoutPanel3);
            this.DoubleBuffered = true;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1491, 1398);
            this.Name = "AddPurchase";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nouvel achat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddPurchase_FormClosing);
            this.Load += new System.EventHandler(this.AddPurchase_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cart)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna2TextBox prodName;
        private HintTexBox priceP;
        private HintTexBox priceSD;
        private HintTexBox priceSG;
        private HintTexBox QT;
        private System.Windows.Forms.ComboBox Typpe;
        private System.Windows.Forms.ComboBox Unit;
        private Guna.UI2.WinForms.Guna2CustomCheckBox avendre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button Ajouter;
        private Guna.UI2.WinForms.Guna2Button retirer;
        private System.Windows.Forms.GroupBox groupBox1;
        public Guna.UI2.WinForms.Guna2DataGridView cart;
        private Guna.UI2.WinForms.Guna2Button Valider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label subtotalText;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label nettotalText;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.ComboBox tva;
        private HintTexBox StockAlert;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox listBox1;
        private HintTexBox prodRef;
        private System.Windows.Forms.ToolTip toolTip1;
        private Guna.UI2.WinForms.Guna2Button effacerbtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private Guna2TextBox Amount;
        private Guna2TextBox suppName;
    }
}