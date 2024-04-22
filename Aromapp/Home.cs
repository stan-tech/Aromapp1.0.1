using DevExpress.XtraBars;
using DevExpress.XtraEditors.TextEditController.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Aromapp
{
    public partial class Home : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        Ventes ventes = new Ventes();
        Comptoire comptoire = new Comptoire();
        Achats achats = new Achats();
        Caisse caisse = new Caisse();
        Clients clients = new Clients();
        Suppliers suppliers = new Suppliers();
        Products products = new Products();
        StockForm stock = new StockForm();
        AdminOptions options = new AdminOptions();
        string number = "0";
        public Home()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(5000);

            InitializeComponent();

            t.Abort();

            this.DoubleBuffered = true;
            using (DBHelper helper = new DBHelper())
            {
                helper.GetScarceProductsNumber(out number);

            }
            this.Shown += assign;
        }
        void StartForm()
        {
            Application.Run(new SplashScreen());

        }
        void QuantChanged(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                helper.GetScarceProductsNumber(out number);
            }
            assign(sender, e);
        }
        void assign(object sender, EventArgs e)
        {
            Scarce.Caption = Scarce.Tag.ToString()+" ("+number+")";
        }
        private void accordionControlElement11_Click(object sender, EventArgs e)
        {
            comptoire.Dock = DockStyle.Fill;
            comptoire.BringToFront();
            comptoire.QTChanged += QuantChanged;

            fluentDesignFormContainer.Controls.Clear();
            fluentDesignFormContainer.Controls.Add(comptoire);
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            ventes.Dock = DockStyle.Fill;
            ventes.BringToFront();
            fluentDesignFormContainer.Controls.Clear();
            fluentDesignFormContainer.Controls.Add(ventes);
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            achats.Dock = DockStyle.Fill;
            achats.BringToFront();
            achats.QTChanged += QuantChanged;
            fluentDesignFormContainer.Controls.Clear();
            fluentDesignFormContainer.Controls.Add(achats);
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            caisse.Dock = DockStyle.Fill;
            caisse.BringToFront();
            fluentDesignFormContainer.Controls.Clear();
            fluentDesignFormContainer.Controls.Add(caisse);
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            clients.Dock = DockStyle.Fill;
            clients.BringToFront();
            fluentDesignFormContainer.Controls.Clear();
            fluentDesignFormContainer.Controls.Add(clients);
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            suppliers.Dock = DockStyle.Fill;
            suppliers.BringToFront();
            fluentDesignFormContainer.Controls.Clear();
            fluentDesignFormContainer.Controls.Add(suppliers);
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            products.Dock = DockStyle.Fill;
            products.BringToFront();
            fluentDesignFormContainer.Controls.Clear();
            fluentDesignFormContainer.Controls.Add(products);
        }

        private void Home_Load(object sender, EventArgs e)
        {
            accordionControl1.Appearance.AccordionControl.Options.UseBackColor = false;
            accordionControl1.Size = new System.Drawing.Size(195,accordionControl1.Size.Height);

            label1.Location = new System.Drawing.Point(fluentDesignFormContainer.Width/2 - label1.Width/3,
                fluentDesignFormContainer.Height/2 - label1.Height);
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            stock.Dock = DockStyle.Fill;
            stock.BringToFront();
            fluentDesignFormContainer.Controls.Clear();
            fluentDesignFormContainer.Controls.Add(stock);
        }

        private void accordionControlElement9_Click(object sender, EventArgs e)
        {
            options.Dock = DockStyle.Fill;
            options.BringToFront();
            fluentDesignFormContainer.Controls.Clear();
            fluentDesignFormContainer.Controls.Add(options);
        }

        private void LogButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            LogForm logForm = new LogForm();
            logForm.ShowDialog();
        }

        private void Scarce_ItemClick(object sender, ItemClickEventArgs e)
        {
            ScarceProducts logForm = new ScarceProducts();
            logForm.FormClosing += QuantChanged;

            logForm.ShowDialog();

            /*    Dictionary<int, string> IDs = new Dictionary<int, string>();
                int Order = 1;
                using (SQLiteConnection connection = new SQLiteConnection(DBHelper.connectionString))
                {
                    string q = "select code from stock order by code asc;";

                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = q;

                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IDs.Add(Order, reader.GetString(0));
                                Order++;
                            }
                            reader.Close();
                        }
                    }

                    foreach (var id in IDs)
                    {
                        string query = "update stock set code = 'PR" + id.Key.ToString("D4") + "' where code = '" + id.Value + "' ;";
                        new SQLiteCommand(query, connection).ExecuteNonQuery();




                    }
                    connection.Close();


                }*/

        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Êtes vous sûr ?", "Déconnecter", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                new DBHelper().LogIn(Properties.Settings.Default.LoggedInUserID, false);
             
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
