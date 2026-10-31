namespace Aromapp
{
    partial class ChangePriceOrRemove
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
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProductPriceTxt = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.qtt = new Guna.UI2.WinForms.Guna2TextBox();
            this.newPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.totalText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.OkBtn = new Guna.UI2.WinForms.Guna2Button();
            this.annuler = new Guna.UI2.WinForms.Guna2Button();
            this.supprimer = new Guna.UI2.WinForms.Guna2Button();
            this.returnStock = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.08696F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.91304F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(667, 200);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 279F));
            this.tableLayoutPanel4.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.qtt, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.newPrice, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.Padding = new System.Windows.Forms.Padding(13, 6, 13, 0);
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(663, 108);
            this.tableLayoutPanel4.TabIndex = 28;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ProductPriceTxt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(373, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 47);
            this.panel1.TabIndex = 30;
            // 
            // ProductPriceTxt
            // 
            this.ProductPriceTxt.Font = new System.Drawing.Font("Calibri", 9.25F);
            this.ProductPriceTxt.ForeColor = System.Drawing.Color.White;
            this.ProductPriceTxt.Location = new System.Drawing.Point(71, 12);
            this.ProductPriceTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProductPriceTxt.Name = "ProductPriceTxt";
            this.ProductPriceTxt.Size = new System.Drawing.Size(137, 28);
            this.ProductPriceTxt.TabIndex = 27;
            this.ProductPriceTxt.Text = "00,00";
            this.ProductPriceTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("Calibri", 10.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.GreenYellow;
            this.label3.Location = new System.Drawing.Point(2, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 28);
            this.label3.TabIndex = 27;
            this.label3.Text = "Prix:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.qtt.Location = new System.Drawing.Point(18, 11);
            this.qtt.Margin = new System.Windows.Forms.Padding(5);
            this.qtt.MaximumSize = new System.Drawing.Size(300, 0);
            this.qtt.Name = "qtt";
            this.qtt.PlaceholderText = "";
            this.qtt.SelectedText = "";
            this.qtt.Size = new System.Drawing.Size(300, 41);
            this.qtt.TabIndex = 3;
            this.qtt.Tag = "Montant payé...";
            this.qtt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.qtt.TextChanged += new System.EventHandler(this.qtt_TextChanged);
            this.qtt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.qtt_KeyPress);
            // 
            // newPrice
            // 
            this.newPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.newPrice.DefaultText = "Nouveau prix...";
            this.newPrice.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.newPrice.ForeColor = System.Drawing.Color.Gray;
            this.newPrice.Location = new System.Drawing.Point(18, 62);
            this.newPrice.Margin = new System.Windows.Forms.Padding(5);
            this.newPrice.MaximumSize = new System.Drawing.Size(300, 0);
            this.newPrice.Name = "newPrice";
            this.newPrice.PlaceholderText = "";
            this.newPrice.SelectedText = "";
            this.newPrice.Size = new System.Drawing.Size(300, 41);
            this.newPrice.TabIndex = 3;
            this.newPrice.Tag = "Nouveau prix...";
            this.newPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.newPrice.TextChanged += new System.EventHandler(this.newPrice_TextChanged);
            this.newPrice.Enter += new System.EventHandler(this.newPrice_Click);
            this.newPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.qtt_KeyPress);
            this.newPrice.Leave += new System.EventHandler(this.newPrice_Leave);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.totalText);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(373, 59);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(275, 47);
            this.panel3.TabIndex = 29;
            // 
            // totalText
            // 
            this.totalText.Font = new System.Drawing.Font("Calibri", 9.25F);
            this.totalText.ForeColor = System.Drawing.Color.White;
            this.totalText.Location = new System.Drawing.Point(71, 12);
            this.totalText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalText.Name = "totalText";
            this.totalText.Size = new System.Drawing.Size(137, 28);
            this.totalText.TabIndex = 27;
            this.totalText.Text = "00,00";
            this.totalText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Calibri", 10.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.GreenYellow;
            this.label2.Location = new System.Drawing.Point(2, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 28);
            this.label2.TabIndex = 27;
            this.label2.Text = "Total:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.49201F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.02487F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.74805F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.86159F));
            this.tableLayoutPanel3.Controls.Add(this.OkBtn, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.annuler, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.supprimer, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.returnStock, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 114);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(663, 84);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // OkBtn
            // 
            this.OkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OkBtn.BorderRadius = 5;
            this.OkBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.OkBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.OkBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.OkBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.OkBtn.FillColor = System.Drawing.Color.Green;
            this.OkBtn.Font = new System.Drawing.Font("Calibri", 10.25F);
            this.OkBtn.ForeColor = System.Drawing.Color.White;
            this.OkBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.OkBtn.ImageSize = new System.Drawing.Size(10, 10);
            this.OkBtn.Location = new System.Drawing.Point(512, 17);
            this.OkBtn.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(134, 50);
            this.OkBtn.TabIndex = 30;
            this.OkBtn.Text = "Ok";
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
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
            this.annuler.Location = new System.Drawing.Point(17, 17);
            this.annuler.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.annuler.Name = "annuler";
            this.annuler.Size = new System.Drawing.Size(124, 50);
            this.annuler.TabIndex = 27;
            this.annuler.Text = "Annuler";
            this.annuler.Click += new System.EventHandler(this.annuler_Click);
            // 
            // supprimer
            // 
            this.supprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supprimer.BorderRadius = 5;
            this.supprimer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.supprimer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.supprimer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.supprimer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.supprimer.FillColor = System.Drawing.Color.Red;
            this.supprimer.Font = new System.Drawing.Font("Calibri", 10.25F);
            this.supprimer.ForeColor = System.Drawing.Color.White;
            this.supprimer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.supprimer.ImageSize = new System.Drawing.Size(10, 10);
            this.supprimer.Location = new System.Drawing.Point(155, 17);
            this.supprimer.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.supprimer.Name = "supprimer";
            this.supprimer.Size = new System.Drawing.Size(127, 50);
            this.supprimer.TabIndex = 28;
            this.supprimer.Text = "Supprimer";
            this.supprimer.Click += new System.EventHandler(this.supprimer_Click);
            // 
            // returnStock
            // 
            this.returnStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.returnStock.BorderRadius = 5;
            this.returnStock.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.returnStock.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.returnStock.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.returnStock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.returnStock.FillColor = System.Drawing.Color.RoyalBlue;
            this.returnStock.Font = new System.Drawing.Font("Calibri", 10.25F);
            this.returnStock.ForeColor = System.Drawing.Color.White;
            this.returnStock.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.returnStock.ImageSize = new System.Drawing.Size(10, 10);
            this.returnStock.Location = new System.Drawing.Point(296, 17);
            this.returnStock.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.returnStock.Name = "returnStock";
            this.returnStock.Size = new System.Drawing.Size(202, 50);
            this.returnStock.TabIndex = 29;
            this.returnStock.Text = "Retourner au stock";
            this.returnStock.Click += new System.EventHandler(this.returnToStock_Click);
            // 
            // ChangePriceOrRemove
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 200);
            this.Controls.Add(this.tableLayoutPanel2);
            this.IconOptions.ShowIcon = false;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePriceOrRemove";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quantité";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ChangePriceOrRemove_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2TextBox qtt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Guna.UI2.WinForms.Guna2Button annuler;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Guna.UI2.WinForms.Guna2TextBox newPrice;
        private Guna.UI2.WinForms.Guna2Button supprimer;
        private Guna.UI2.WinForms.Guna2Button returnStock;
        private Guna.UI2.WinForms.Guna2Button OkBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label totalText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ProductPriceTxt;
        private System.Windows.Forms.Label label3;
    }
}