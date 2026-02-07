using DevExpress.XtraBars.FluentDesignSystem;

namespace Aromapp
{
    partial class Trash
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
            this.TopTabs = new Guna.UI2.WinForms.Guna2TabControl();
            this.Products = new System.Windows.Forms.TabPage();
            this.Clients = new System.Windows.Forms.TabPage();
            this.Suppliers = new System.Windows.Forms.TabPage();
            this.Sales = new System.Windows.Forms.TabPage();
            this.Purchases = new System.Windows.Forms.TabPage();
            this.Users = new System.Windows.Forms.TabPage();
            this.fluentDesignFormContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.TrashHint = new DevExpress.XtraBars.BarStaticItem();
            this.barLinkContainerItem1 = new DevExpress.XtraBars.BarLinkContainerItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.TopTabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // TopTabs
            // 
            this.TopTabs.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TopTabs.Controls.Add(this.Products);
            this.TopTabs.Controls.Add(this.Clients);
            this.TopTabs.Controls.Add(this.Suppliers);
            this.TopTabs.Controls.Add(this.Sales);
            this.TopTabs.Controls.Add(this.Purchases);
            this.TopTabs.Controls.Add(this.Users);
            this.TopTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopTabs.ItemSize = new System.Drawing.Size(180, 50);
            this.TopTabs.Location = new System.Drawing.Point(0, 62);
            this.TopTabs.Margin = new System.Windows.Forms.Padding(0);
            this.TopTabs.Name = "TopTabs";
            this.TopTabs.Padding = new System.Drawing.Point(0, 0);
            this.TopTabs.SelectedIndex = 0;
            this.TopTabs.Size = new System.Drawing.Size(1644, 788);
            this.TopTabs.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.TopTabs.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.TopTabs.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.TopTabs.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.TopTabs.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.TopTabs.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.TopTabs.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(168)))));
            this.TopTabs.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.TopTabs.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.TopTabs.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.TopTabs.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.TopTabs.TabButtonSelectedState.FillColor = System.Drawing.Color.Black;
            this.TopTabs.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.TopTabs.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.TopTabs.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.TopTabs.TabButtonSize = new System.Drawing.Size(180, 50);
            this.TopTabs.TabButtonTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TopTabs.TabIndex = 2;
            this.TopTabs.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(168)))));
            this.TopTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.TopTabs_Selected);
            // 
            // Products
            // 
            this.Products.BackColor = System.Drawing.Color.Black;
            this.Products.Location = new System.Drawing.Point(184, 4);
            this.Products.Margin = new System.Windows.Forms.Padding(0);
            this.Products.Name = "Products";
            this.Products.Size = new System.Drawing.Size(1456, 780);
            this.Products.TabIndex = 0;
            this.Products.Text = "Produits";
            // 
            // Clients
            // 
            this.Clients.BackColor = System.Drawing.Color.Black;
            this.Clients.Location = new System.Drawing.Point(184, 4);
            this.Clients.Name = "Clients";
            this.Clients.Padding = new System.Windows.Forms.Padding(3);
            this.Clients.Size = new System.Drawing.Size(1456, 780);
            this.Clients.TabIndex = 1;
            this.Clients.Text = "Clients";
            // 
            // Suppliers
            // 
            this.Suppliers.BackColor = System.Drawing.Color.Black;
            this.Suppliers.Location = new System.Drawing.Point(184, 4);
            this.Suppliers.Margin = new System.Windows.Forms.Padding(0);
            this.Suppliers.Name = "Suppliers";
            this.Suppliers.Size = new System.Drawing.Size(1456, 780);
            this.Suppliers.TabIndex = 2;
            this.Suppliers.Text = "Fournisseurs";
            // 
            // Sales
            // 
            this.Sales.BackColor = System.Drawing.Color.Black;
            this.Sales.Location = new System.Drawing.Point(184, 4);
            this.Sales.Margin = new System.Windows.Forms.Padding(0);
            this.Sales.Name = "Sales";
            this.Sales.Size = new System.Drawing.Size(1456, 780);
            this.Sales.TabIndex = 3;
            this.Sales.Text = "Ventes";
            // 
            // Purchases
            // 
            this.Purchases.BackColor = System.Drawing.Color.Black;
            this.Purchases.Location = new System.Drawing.Point(184, 4);
            this.Purchases.Margin = new System.Windows.Forms.Padding(0);
            this.Purchases.Name = "Purchases";
            this.Purchases.Size = new System.Drawing.Size(1456, 780);
            this.Purchases.TabIndex = 4;
            this.Purchases.Text = "Achats";
            // 
            // Users
            // 
            this.Users.BackColor = System.Drawing.Color.Black;
            this.Users.Location = new System.Drawing.Point(184, 4);
            this.Users.Margin = new System.Windows.Forms.Padding(0);
            this.Users.Name = "Users";
            this.Users.Size = new System.Drawing.Size(1456, 780);
            this.Users.TabIndex = 5;
            this.Users.Text = "Utilisateurs";
            // 
            // fluentDesignFormContainer
            // 
            this.fluentDesignFormContainer.Appearance.BackColor = System.Drawing.Color.Black;
            this.fluentDesignFormContainer.Appearance.Options.UseBackColor = true;
            this.fluentDesignFormContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer.Location = new System.Drawing.Point(394, 62);
            this.fluentDesignFormContainer.Margin = new System.Windows.Forms.Padding(340241408, 243824640, 340241408, 243824640);
            this.fluentDesignFormContainer.Name = "fluentDesignFormContainer";
            this.fluentDesignFormContainer.Size = new System.Drawing.Size(780, 719);
            this.fluentDesignFormContainer.TabIndex = 0;
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.TrashHint,
            this.barLinkContainerItem1});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1644, 62);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.TrashHint);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barLinkContainerItem1);
            // 
            // TrashHint
            // 
            this.TrashHint.Caption = "Les éléments supprimés sont placés dans la corbeille pendant une durée maximale d" +
    "e 30 jours";
            this.TrashHint.Id = 1;
            this.TrashHint.Name = "TrashHint";
            // 
            // barLinkContainerItem1
            // 
            this.barLinkContainerItem1.Caption = "Changer";
            this.barLinkContainerItem1.Id = 1;
            this.barLinkContainerItem1.ItemAppearance.Hovered.BackColor = System.Drawing.Color.RoyalBlue;
            this.barLinkContainerItem1.ItemAppearance.Hovered.ForeColor = System.Drawing.Color.White;
            this.barLinkContainerItem1.ItemAppearance.Hovered.Options.UseBackColor = true;
            this.barLinkContainerItem1.ItemAppearance.Hovered.Options.UseForeColor = true;
            this.barLinkContainerItem1.ItemAppearance.Normal.BackColor = System.Drawing.Color.LightSteelBlue;
            this.barLinkContainerItem1.ItemAppearance.Normal.Options.UseBackColor = true;
            this.barLinkContainerItem1.Name = "barLinkContainerItem1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Changer";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // Trash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1644, 850);
            this.ControlContainer = this.fluentDesignFormContainer;
            this.Controls.Add(this.TopTabs);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.IconOptions.ShowIcon = false;
            this.Name = "Trash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Corbeille";
            this.Load += new System.EventHandler(this.Trash_Load);
            this.TopTabs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer;
        private Guna.UI2.WinForms.Guna2TabControl TopTabs;
        private System.Windows.Forms.TabPage Products;
        private System.Windows.Forms.TabPage Clients;
        private System.Windows.Forms.TabPage Suppliers;
        private System.Windows.Forms.TabPage Sales;
        private System.Windows.Forms.TabPage Purchases;
        private System.Windows.Forms.TabPage Users;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.BarStaticItem TrashHint;
        private DevExpress.XtraBars.BarLinkContainerItem barLinkContainerItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}