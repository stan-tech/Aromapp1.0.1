namespace Aromapp
{
    partial class RemoveProduct
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
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.supprimer = new Guna.UI2.WinForms.Guna2Button();
            this.returnStock = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(67, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.label1.Size = new System.Drawing.Size(645, 120);
            this.label1.TabIndex = 27;
            this.label1.Text = "Souhaitez-vous retourner le produits au stock ou le supprimer sans retour ?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.08992F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.91008F));
            this.tableLayoutPanel2.Controls.Add(this.supprimer, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.returnStock, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 146);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(777, 123);
            this.tableLayoutPanel2.TabIndex = 28;
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
            this.supprimer.Location = new System.Drawing.Point(10, 20);
            this.supprimer.Margin = new System.Windows.Forms.Padding(10);
            this.supprimer.Name = "supprimer";
            this.supprimer.Size = new System.Drawing.Size(376, 83);
            this.supprimer.TabIndex = 25;
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
            this.returnStock.Location = new System.Drawing.Point(406, 20);
            this.returnStock.Margin = new System.Windows.Forms.Padding(10);
            this.returnStock.Name = "returnStock";
            this.returnStock.Size = new System.Drawing.Size(361, 83);
            this.returnStock.TabIndex = 25;
            this.returnStock.Text = "Retourner au stock";
            this.returnStock.Click += new System.EventHandler(this.Modifier_Click);
            // 
            // RemoveProduct
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 269);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.label1);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemoveProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supprimer le produits";
            this.Load += new System.EventHandler(this.RemoveProduct_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2Button supprimer;
        private Guna.UI2.WinForms.Guna2Button returnStock;
    }
}