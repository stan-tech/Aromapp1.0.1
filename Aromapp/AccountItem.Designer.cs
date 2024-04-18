using FontAwesome.Sharp;

namespace Aromapp
{
    partial class AccountItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountItem));
            this.amount = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.roundedButton1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.roundedButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // amount
            // 
            this.amount.AutoSize = true;
            this.amount.Font = new System.Drawing.Font("Calibri", 9.25F);
            this.amount.Location = new System.Drawing.Point(170, 108);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(111, 31);
            this.amount.TabIndex = 2;
            this.amount.Text = "22000,00";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Calibri", 12.25F, System.Drawing.FontStyle.Bold);
            this.name.Location = new System.Drawing.Point(166, 21);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(99, 40);
            this.name.TabIndex = 3;
            this.name.Text = "Name";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(445, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 182);
            this.button1.TabIndex = 19;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // roundedButton1
            // 
            this.roundedButton1.Image = global::Aromapp.Properties.Resources.PB;
            this.roundedButton1.Location = new System.Drawing.Point(14, 21);
            this.roundedButton1.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(120, 120);
            this.roundedButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roundedButton1.TabIndex = 18;
            this.roundedButton1.TabStop = false;
            // 
            // AccountItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.name);
            this.Controls.Add(this.amount);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "AccountItem";
            this.Size = new System.Drawing.Size(531, 182);
            this.Load += new System.EventHandler(this.AccountItem_Load);
            this.MouseEnter += new System.EventHandler(this.AccountItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.AccountItem_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.roundedButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label amount;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.PictureBox roundedButton1;
        private System.Windows.Forms.Button button1;
    }
}
