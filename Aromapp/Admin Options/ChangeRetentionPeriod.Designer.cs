namespace Aromapp
{
    partial class ChangeRetentionPeriod
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
            this.qtt = new Aromapp.HintTexBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.supprimer = new Guna.UI2.WinForms.Guna2Button();
            this.Modifier = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.97268F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.02732F));
            this.tableLayoutPanel2.Controls.Add(this.qtt, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(15, 18, 15, 18);
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(669, 151);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // qtt
            // 
            this.qtt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qtt.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.qtt.ForeColor = System.Drawing.Color.Black;
            this.qtt.Location = new System.Drawing.Point(241, 53);
            this.qtt.Margin = new System.Windows.Forms.Padding(3, 35, 3, 3);
            this.qtt.Name = "qtt";
            this.qtt.Size = new System.Drawing.Size(410, 47);
            this.qtt.TabIndex = 2;
            this.qtt.Tag = "0";
            this.qtt.Text = "0";
            this.qtt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 40, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Durée";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.supprimer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Modifier, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 151);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(15, 18, 15, 18);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(669, 112);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // supprimer
            // 
            this.supprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supprimer.BorderRadius = 5;
            this.supprimer.FillColor = System.Drawing.Color.Red;
            this.supprimer.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.supprimer.ForeColor = System.Drawing.Color.White;
            this.supprimer.Location = new System.Drawing.Point(18, 21);
            this.supprimer.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.supprimer.Name = "supprimer";
            this.supprimer.Size = new System.Drawing.Size(306, 70);
            this.supprimer.TabIndex = 0;
            this.supprimer.Text = "Annuler";
            this.supprimer.Click += new System.EventHandler(this.supprimer_Click);
            // 
            // Modifier
            // 
            this.Modifier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Modifier.BorderRadius = 5;
            this.Modifier.FillColor = System.Drawing.Color.RoyalBlue;
            this.Modifier.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.Modifier.ForeColor = System.Drawing.Color.White;
            this.Modifier.Location = new System.Drawing.Point(337, 21);
            this.Modifier.Name = "Modifier";
            this.Modifier.Size = new System.Drawing.Size(314, 70);
            this.Modifier.TabIndex = 0;
            this.Modifier.Text = "Modifier";
            this.Modifier.Click += new System.EventHandler(this.Modifier_Click);
            // 
            // ChangeRetentionPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(669, 263);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ChangeRetentionPeriod";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Changer la durée de la retention";
            this.Load += new System.EventHandler(this.ChangeRetentionPeriod_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private HintTexBox qtt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button supprimer;
        private Guna.UI2.WinForms.Guna2Button Modifier;
    }
}