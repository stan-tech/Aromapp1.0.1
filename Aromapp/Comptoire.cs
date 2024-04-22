using DevExpress.XtraBars.Docking.Helpers;
using DevExpress.XtraBars.ViewInfo;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using Guna.UI2.WinForms;
using Humanizer;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using iTextSharp.text.pdf.qrcode;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Aromapp.Ventes;
using static DevExpress.Utils.MVVM.Internal.ILReader;
using static DevExpress.Utils.Svg.CommonSvgImages;

namespace Aromapp
{
    public partial class Comptoire : DevExpress.XtraEditors.XtraUserControl
    {
        private BackgroundWorker dataLoader;
        DataTable table = new DataTable();
        List<double> BuyingPrices = new List<double>();

        public static bool detail = true;
        bool searching = false;
        bool typeSelected = false;
        bool tableFull = false;
        int searchLimit = 100, searchCurrentPage = 1;
        public event EventHandler QTChanged;
        int x = 0;
        Product product;
        CartItemOptions options;
        System.Windows.Forms.Timer timer;
        InvoiceOrTicket invoiceOr;
        int limit = 100, currentPage = 1;
        public static double quantity = 1;
        int SizeX = 0;
        public static DataTable CartTable = new DataTable
                ();
        ToolTip toolTip1 = new ToolTip ();

        public Comptoire()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.iconButton2, "Ctrl+B pour un Bon, Ctrl+F pour une Facture");
            this.toolTip1.SetToolTip(this.effacerbtn, "Ctrl+E");

            SizeX = this.Size.Width;
            timer = new System.Windows.Forms.Timer();
            timer.Tick += timer_Tick;
            this.Load += Comptoire_Load;
            this.SizeChanged += Comp_SizeChanged;
            prods.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            prods.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = System.Drawing.Color.White,
                SelectionBackColor = System.Drawing.Color.FromArgb(255, 64, 64, 64),
                Font = new System.Drawing.Font("Calibri", 9.25f)
            };
            cart.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            cart.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = System.Drawing.Color.White,
                SelectionBackColor = System.Drawing.Color.FromArgb(255, 64, 64, 64),
                Font = new System.Drawing.Font("Calibri", 9.25f)
            };
            cart.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = System.Drawing.Color.FromArgb(63, 81, 181),
                Font = new System.Drawing.Font("Calibri", 9.25f, FontStyle.Bold)
            };
            prods.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = System.Drawing.Color.FromArgb(63, 81, 181),
                Font = new System.Drawing.Font("Calibri", 9.25f, FontStyle.Bold)
            };
            dataLoader = new BackgroundWorker();

            DoubleBuffered = true;

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            x++;
            if (x >= 1)
            {
                timer.Stop();
                iconButton4_Click(sender, e);
            }
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {

            double debt = 0;
            DBHelper helper = new DBHelper();

                if (keys == (Keys.Control | Keys.F))
                {
                    if (cart.Rows.Count > 0)
                    {
                        try
                        {
                                if (!helper.CheckDebt(selectedClient.C_CL, out debt))
                                {
                            iconButton2_Click(new object(), EventArgs.Empty);

                                }
                                else
                                {
                                    DialogResult result = MessageBox.Show("Ce client a une dette de: " +
                                   debt.ToString() + " DA, souhaitez vous continuer ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                    if (result == DialogResult.Yes)
                                    {
                                iconButton2_Click(new object(), EventArgs.Empty);

                                    }
    
                                }

                         }
                        catch (Exception)
                        {

                        }
                    }
                    else
                    {
                        MessageBoxer.showGeneralMsg("Le panier est vide");

                    }
                }
             
                
            if (keys == (Keys.Control | Keys.E))
            {
                if (cart.Rows.Count > 0)
                {
                    try
                    {
                        effacerbtn_Click(new object(), EventArgs.Empty);

                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    MessageBoxer.showGeneralMsg("Le panier est vide");

                }

            }


            return base.ProcessCmdKey(ref message, keys);

        }
        private void custPhone_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(custPhone);

        }

        private void custPhone_Leave(object sender, EventArgs e)
        {
            HintUtils.ShowHint(custPhone);
        }

        private void custAddress_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(custAddress);

        }

        private void custAddress_Leave(object sender, EventArgs e)
        {
            HintUtils.ShowHint(custAddress);
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(searchBox);

        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            HintUtils.ShowHint(searchBox);

        }

        private void amount_TextChanged(object sender, EventArgs e)
        {

        }

        private void amount_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(amount);

        }

        private void reduction_Leave(object sender, EventArgs e)
        {
            HintUtils.ShowHint(reduction);

        }

        private void reduction_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(reduction);

        }

        private void amount_Leave(object sender, EventArgs e)
        {
            HintUtils.ShowHint(amount);
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        void Comptoire_Load(object sender, EventArgs e)
        {
            if (tva.Text == "")
            {
                tva.Text = "TVA";
            }

            if (comboBox1.Text == "")
            {
                comboBox1.Text = "Types";
            }

            timer.Start();

            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                comboBox1.Text = "Types";
            }


            CartTable.Columns.AddRange(new DataColumn[8] { new DataColumn("Réf"),new DataColumn("Désignation"),
                new DataColumn("Qté"), new DataColumn("Prix U"), new DataColumn("Type"),new DataColumn("Marge"),
                new DataColumn("Remise") ,new DataColumn("Montant HT")});
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "")
            {
                comboBox1.Text = "Types";
            }
        }

        private void cart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cart.RowCount > 0)
            {

                int quantity = int.Parse(cart.SelectedRows[0].Cells[2].Value.ToString());
                decimal prix = decimal.Parse(cart.SelectedRows[0].Cells[3].Value.ToString());
                subtotalText.Text = (prix * quantity).ToString();
            }
            else
            {
                MessageBox.Show("Le pannier est vide", "", MessageBoxButtons.OK);

            }
        }

        private void cart_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (cart.RowCount > 0)
            {
                product = new Product();
                product.Name = cart.SelectedRows[0].Cells[1].Value.ToString();
                product.Quantity = double.Parse(cart.SelectedRows[0].Cells[2].Value.ToString());
                product.PriceG = double.Parse(cart.SelectedRows[0].Cells[3].Value.ToString());
                product.Index = cart.SelectedRows[0].Index;
                options = new CartItemOptions(product, cart.SelectedRows[0]);
                options.QuantChanged += RowModified;
                options.Product_Deleted += Product_Deleted;
                options.ShowDialog();
            }
            else
            {
                MessageBox.Show("Le pannier est vide", "", MessageBoxButtons.OK);

            }
        }
        public void RowModified(object sender, EventArgs e)
        {
            if (cart.Rows.Count == 0)
            {
                subtotalText.Text = "0";
                nettotalText.Text = "0";
            }
            else
            {
                double quantity = Int32.Parse(options.Product.Quantity.ToString());
                double prix = double.Parse(options.Product.PriceG.ToString());
                subtotalText.Text = (prix * quantity).ToString();
                cart.SelectedRows[0].Cells[2].Value = quantity;
                cart.SelectedRows[0].Cells[7].Value = quantity * prix;

                float total = 0;
                int sub_quantity = 0;
                double sub_prix = 0;

                try
                {
                    foreach (DataGridViewRow row in cart.Rows)
                    {
                        sub_quantity = int.Parse(row.Cells[2].Value.ToString());
                        sub_prix = double.Parse(row.Cells[3].Value.ToString());

                        total += (float)(sub_quantity * sub_prix);
                    }
                }
                catch
                {

                }

                nettotalText.Text = total.ToString();
            }


            cart.DataSource = CartTable;

        }

        void Product_Deleted(object sender, EventArgs e)
        {
            double total = double.Parse(nettotalText.Text);
            double deletedTotal = double.Parse(cart.SelectedRows[0].Cells[7].Value.ToString());
            int LinesN = int.Parse(n_lignes.Text);
            LinesN--;
            total -= deletedTotal;

            nettotalText.Text = total.ToString();
            n_lignes.Text = LinesN.ToString();

        }

        private void effacerbtn_Click(object sender, EventArgs e)
        {
            if (CartTable.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Cette action est irréversible, cliquez sur oui pour continuer", "Vous êtes sûr ?", MessageBoxButtons.YesNo);


                if (result == DialogResult.Yes)
                {
                    subtotalText.Text = "0";
                    nettotalText.Text = "0";
                    n_lignes.Text = "0";
                    CartTable.Rows.Clear();
                }
            }
            else
            {
                MessageBoxer.showGeneralMsg("Le panier est vide");

            }
        }


        void AddProduct(object sender, EventArgs e)
        {
            double buyinPrice;


            string reference = prods.SelectedRows[0].Cells[0].Value.ToString(),
                type = prods.SelectedRows[0].Cells[3].Value.ToString();

            tva.SelectedIndex = 0;

            string nomproduits = prods.SelectedRows[0].Cells[1].Value.ToString();

           
            buyinPrice = double.Parse(prods.SelectedRows[0].Cells[4].Value.ToString());

            BuyingPrices.Add(buyinPrice);

            produits l_Ventes = new produits(nomproduits, quantity, NewPrice, 10, 0);

            l_Ventes.Marge = (NewPrice - buyinPrice) * quantity;
            l_Ventes.MontantHT = NewPrice * quantity;

            nettotalText.Text = (int.Parse(nettotalText.Text) + quantity * NewPrice).ToString();
            subtotalText.Text = (quantity * NewPrice).ToString();

            quantity = 1;

            CartTable.Rows.Add(reference, l_Ventes.Nomproduits, l_Ventes.Quantité, NewPrice.ToString(), type,
                l_Ventes.Marge, Qt.Remise, l_Ventes.MontantHT); 

            cart.DataSource = CartTable;
            n_lignes.Text = cart.RowCount.ToString();
        }

        private void prods_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
                NewPrice = detail? double.Parse(prods.SelectedRows[0].Cells[5].Value.ToString()):
                     NewPrice = double.Parse(prods.SelectedRows[0].Cells[6].Value.ToString());
         

            Qt qt = new Qt();

            qt.totalBulk = double.Parse(prods.SelectedRows[0].Cells[6].Value.ToString());
            qt.totalRetail = double.Parse(prods.SelectedRows[0].Cells[5].Value.ToString());

            qt.Added += AddProduct;
            qt.ShowDialog();

        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        string SelectedTable = "produits";

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                if (searchBox.Text != searchBox.Tag.ToString() && !string.IsNullOrEmpty(searchBox.Text.Trim()))
                {
                    searching = true;
                    prods.DataSource = helper.searchPOS(SelectedTable,searchBox.Text, 100, 1);
                }
                else
                {
                    searching = false;

                }
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeSelected = true;
            searching = true;


            using (DBHelper helper = new DBHelper())
            {
                prods.DataSource = helper.GetProductByType(comboBox1.SelectedItem.ToString().Trim(), searchLimit, searchCurrentPage);

            }

            if(comboBox1.SelectedIndex==3|| comboBox1.SelectedIndex == 4)
            {
                SelectedTable = "emballage";
            }
            else
            {
                SelectedTable = "produits";
            }

        }
        AutoCompleteStringCollection collection;
        List<Client> customers;
        Client selectedClient = new Client();

        private void OnAutoCompleteTextClicked(Client selected)
        {
            custAddress_Click(this, new EventArgs());
            custAddress.Text = selected.Adresse;
            custPhone_Click(this, new EventArgs());

            custPhone.Text = selected.Tel;
        }

        List<SaleLine> soldProducts;
        public Bill GenerateTemporarySale(string type , List<double> BuyingPrices)
        {
            double amountPaid, total;
            Bill bill = new Bill();
            string billID = (type == "Facture") ? DBHelper.generateID("FA", Tables.ventes) : DBHelper.generateID("BL", Tables.ventes);
            ;

            soldProducts =
                new List<SaleLine>();


            string clientID = (selectedClient.C_CL == null) ? "Non disponible" : selectedClient.C_CL;
            int i = 0;
            foreach (DataGridViewRow row in cart.Rows)
            {
                SaleLine sale = new SaleLine();
                sale.C_CL = (clientID == "Non disponible") ? "X" : clientID;
                sale.Nomproduit = row.Cells[1].Value.ToString();
                sale.Quantité = double.Parse(row.Cells[2].Value.ToString());
                sale.PrixHT = double.Parse(row.Cells[3].Value.ToString());
                sale.Marge = double.Parse(row.Cells[5].Value.ToString());
                sale.Remise = double.Parse(row.Cells[6].Value.ToString());
                if (i < BuyingPrices.Count)
                {
                    sale.BuyingPrice = BuyingPrices[i];

                }
                sale.C_PR = row.Cells[0].Value.ToString();
                sale.Type = row.Cells[4].Value.ToString();
                sale.DateA = DateTime.Now.Date;
                sale.MontantHT = double.Parse(row.Cells[7].Value.ToString());

                soldProducts.Add(sale);

                i++;


            }


            total = double.Parse(nettotalText.Text);

            if (amount.Text ==
                amount.Tag.ToString() ||
                string.IsNullOrEmpty(amount.Text))
            {
                amountPaid = total;
            }
            else
            {
                amountPaid = double.Parse(amount.Text.Replace(".", ","));
            }


            string reductionString = (reduction.Text == reduction.Tag.ToString() || string.IsNullOrEmpty(reduction.Text)) ? "0" : reduction.Text.Replace(".", ",");

            bill.TotalTTC = total;
            bill.MontantRest = total - amountPaid;
            bill.Type = type;
            bill.MontantRegler = amountPaid;
            bill.TotalRemise = double.Parse(reductionString);
            bill.N_Ligne = soldProducts.Count;
            bill.Regler = (total == amountPaid) ? "Réglé" : "Non Réglé";
            bill.TauxTVA = float.Parse(tva.SelectedItem.ToString());
            bill.ClientObj = selectedClient;
            bill.ClientObj.Adresse = (custAddress.Text == custAddress.Tag.ToString()) ? "Non disponible" : custAddress.Text;
            bill.ClientObj.Nom = (custName.Text == custName.Tag.ToString()) ? "Non disponible" : custName.Text;
            bill.ClientObj.Tel = (custPhone.Text == custPhone.Tag.ToString()) ? "Non disponible" : custPhone.Text;

            bill.N = billID;


            return bill;

        }

        string InvoicePath = "", ticketPath="";
      

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool DeleteFile(string lpFileName);

        public void SaleAdded(object sender, EventArgs e)
        {
               
            if (invoiceOr.canceled)
            {

                string[] paths = new string[] { InvoicePath,ticketPath };
                foreach(string path in paths)
                {
                    DeleteFile(path);

                }
            }
            else if (invoiceOr.Type == "Facture")
            {
                DeleteFile(ticketPath);

            }
            else
            {
                DeleteFile(InvoicePath);


            }

            CartTable.Rows.Clear();

            nettotalText.Text = "0";
            subtotalText.Text = "0";
            n_lignes.Text = "0";
           
            selectedClient = new Client();
            ClearTexts();
            BuyingPrices.Clear();
            invoiceOr.Close();
        }

        public void ConfirmSale()
        {

            Bill invoice = GenerateTemporarySale("Facture", BuyingPrices);
            Bill ticket = GenerateTemporarySale("Bon", BuyingPrices);
            string invoicePath = GeneratePdf(cart, invoice);
            fileStream.Close();

            Thread.Sleep(1000);
            string ticketPath = GeneratePdf(cart, ticket);
            fileStream.Close();



            this.ticketPath = ticketPath;
            this.InvoicePath = invoicePath;

            invoiceOr = new InvoiceOrTicket(this.InvoicePath, this.ticketPath);
            invoiceOr.SaleAdded += SaleAdded;
            invoiceOr.InvoiceBill = invoice;
            invoiceOr.TicketBill = ticket;
            invoiceOr.soldProducts = soldProducts;
            invoiceOr.reductionString = (reduction.Text == reduction.Tag.ToString() || string.IsNullOrEmpty(reduction.Text)) ? "0" : reduction.Text.Replace(".", ",");
            if (amount.Text ==
                           amount.Tag.ToString() ||
                           string.IsNullOrEmpty(amount.Text))
            {
                invoiceOr.amountPaid = invoice.TotalTTC;
            }
            else
            {
                invoiceOr.amountPaid = double.Parse(amount.Text.Replace(".", ","));
            }

            invoiceOr.ShowDialog();
        }
        public void iconButton2_Click(object sender, EventArgs e)
        {
            double debt;


            if (CartTable.Rows.Count > 0)
            {
                using (DBHelper helper = new DBHelper())
                {
                    if (!helper.CheckDebt(selectedClient.C_CL, out debt))
                    {
                        ConfirmSale();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Ce client a une dette de: " +
                       debt.ToString() + " DA, souhaitez vous continuer ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            ConfirmSale();
                        }

                    }
                } 
            }
            else
            {
                MessageBoxer.showGeneralMsg("Le panier est vide");

            }




        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            searchCurrentPage = 1;
            currentPage = 1;
            typeSelected = false;
            tableFull = false;
            searching = false;
            using (DBHelper helper = new DBHelper())
            {
                table = helper.selectAllProducts(limit, currentPage);

            }
            prods.Invoke((Action)(() => { prods.DataSource = table; }));
            comboBox1.Text = "Types";
            SelectedTable = "produits";
        }

        private void tva_TextChanged(object sender, EventArgs e)
        {
            if (tva.Text == "")
            {
                tva.Text = "TVA";
            }
        }
        public virtual void 
            
            
            
            
            TChanged(EventArgs e)
        {

            EventHandler eh = QTChanged;
            if (eh != null)
            {
                eh(this, e);


            }
        }
        public void ClearTexts()
        {
            custName.ForeColor = Color.Gray;
            custName.Text = custName.Tag.ToString();
            custAddress.ForeColor = Color.Gray;
            custAddress.Text = custAddress.Tag.ToString();
            custPhone.ForeColor = Color.Gray;
            custPhone.Text = custPhone.Tag.ToString();
            reduction.ForeColor = Color.Gray;
            reduction.Text = reduction.Tag.ToString();

            HintUtils.ShowHint(custAddress);
            HintUtils.ShowHint(custPhone);
            HintUtils.ShowHint(amount);
            HintUtils.ShowHint(reduction);
        }


       /* public Bill AddSaleWithType(string type, List<double> BuyingPrices)
        {
            double amountPaid, total;
            Bill bill = new Bill();
            string billID = "";

            List<SaleLine> soldProducts =
                new List<SaleLine>();


            string clientID = (selectedClient.C_CL == null) ? "Non disponible" : selectedClient.C_CL;
            int i = 0;
            foreach (DataGridViewRow row in cart.Rows)
            {
                SaleLine sale = new SaleLine();
                sale.C_CL = (clientID == "Non disponible") ? "X" : clientID;
                sale.Nomproduit = row.Cells[1].Value.ToString();
                sale.Quantité = double.Parse(row.Cells[2].Value.ToString());
                sale.PrixHT = double.Parse(row.Cells[3].Value.ToString());
                sale.Marge = double.Parse(row.Cells[5].Value.ToString());
                sale.Remise = double.Parse(row.Cells[6].Value.ToString());
                if (i < BuyingPrices.Count)
                {
                    sale.BuyingPrice = BuyingPrices[i];

                }
                sale.C_PR = row.Cells[0].Value.ToString();
                sale.Type = row.Cells[4].Value.ToString();
                sale.DateA = DateTime.Now.Date;
                sale.MontantHT = double.Parse(row.Cells[7].Value.ToString());

                soldProducts.Add(sale);

                i++;


            }


            total = double.Parse(nettotalText.Text);

            if (amount.Text ==
                amount.Tag.ToString() ||
                string.IsNullOrEmpty(amount.Text))
            {
                amountPaid = total;
            }
            else
            {
                amountPaid = double.Parse(amount.Text.Replace(".", ","));
            }


            string reductionString = (reduction.Text == reduction.Tag.ToString() || string.IsNullOrEmpty(reduction.Text)) ? "0" : reduction.Text.Replace(".", ",");

            using (DBHelper helper = new DBHelper())
            {
                if (helper.AddSale(soldProducts, total, selectedClient.Nom,
                    amountPaid, float.Parse(tva.SelectedItem.ToString()),
                    type, out billID, double.Parse(reductionString)) > 0 true)

                {
                    bill.TotalTTC = total;
                    bill.MontantRest = total - amountPaid;
                    bill.Type = type;
                    bill.MontantRegler = amountPaid;
                    bill.TotalRemise = double.Parse(reductionString);
                    bill.N_Ligne = soldProducts.Count;
                    bill.Regler = (total == amountPaid) ? "Réglé" : "Non Réglé";
                    bill.TauxTVA = float.Parse(tva.SelectedItem.ToString());
                    bill.ClientObj = selectedClient;
                    bill.ClientObj.Adresse = (custAddress.Text == custAddress.Tag.ToString()) ? "Non disponible" : custAddress.Text;
                    bill.ClientObj.Nom = (custName.Text == custName.Tag.ToString()) ? "Non disponible" : custName.Text;
                    bill.ClientObj.Tel = (custPhone.Text == custPhone.Tag.ToString()) ? "Non disponible" : custPhone.Text;

                    bill.N = billID;


                    return bill;
                }
                else
                {
                    return null;
                }
            }


        }

        void FactureClick(object sender, EventArgs e)
        {
            Bill bill = AddSaleWithType("Facture", BuyingPrices);

            OnQTChanged(e);
            iconButton4_Click(sender, e);

            if (bill != null)
            {
                GeneratePdf(cart, bill);
                CartTable.Rows.Clear();

                nettotalText.Text = "0";
                subtotalText.Text = "0";
                n_lignes.Text = "0";
                selectedClient = new Client();
                ClearTexts();
                BuyingPrices.Clear();
                invoiceOr.Hide();

            }

        }
        void BonClick(object sender, EventArgs e)
        {
            Bill bill = AddSaleWithType("Bon", BuyingPrices);
            OnQTChanged(e);
            iconButton4_Click(sender, e);

            if (bill != null)
            {
                GeneratePdf(cart, bill);
                CartTable.Rows.Clear();

                nettotalText.Text = "0";
                subtotalText.Text = "0";
                n_lignes.Text = "0";
                selectedClient = new Client();
                ClearTexts();
                BuyingPrices.Clear();
                invoiceOr.Hide();
            }



        }*/

        private void custName_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (custName.Text == custName.Tag.ToString())
                {
                    custName.ForeColor = Color.Black;
                    custName.Text = "";
                }
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }

        private void custName_Leave(object sender, EventArgs e)
        {

            
            try
            {
                if (custName.Text == "")
                {
                    custName.ForeColor = Color.Gray;
                    custName.Text = custName.Tag.ToString();
                }

            }
            catch (ArgumentOutOfRangeException ex)
            {

                Console.WriteLine("ArgumentOutOfRangeException caught: " + ex.Message);
            }

        }

/*        private void custName_TextChanged(object sender, EventArgs e)
        {

            if (custName.Text != custName.Tag.ToString())
            {
                using (DBHelper helper = new DBHelper())
                {
                    collection = helper.GetCustomerNames(custName.Text, out customers);

                }

                try
                {

                    custName.BeginInvoke((Action)(() =>
                    {

                        *//* custName.AutoCompleteCustomSource = collection;
                         custName.AutoCompleteMode = AutoCompleteMode.Suggest;
                         custName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                         *//*
                        custName.Items.Clear();
                        List<string> collectionList = collection.Cast<string>().ToList();

                        foreach (string s in collectionList)
                        {
                            custName.Items.Add(s);

                        }

                        if (custName.Items.Contains(custName.Text))
                        {
                            custName.DroppedDown = true;
                        }

                        custName.Select(comboBox1.Text.Length, 0);


                    }));


                    foreach (Client option in customers)
                    {
                        if (option.Nom.Equals(custName.Text))
                        {
                            selectedClient = option;
                            OnAutoCompleteTextClicked(selectedClient);
                            break;
                        }
                    }


                }
                catch (Exception ex)
                {

                    System.Windows.Forms.MessageBox.Show("An error occurred: " + ex.Message);
                }
            
              
            }



        }
*/
        FileStream fileStream;
        BindingSource bindingSource;

        public void AddTable(int currentPage)
        {
            BindingSource bindingSource = new BindingSource();
            using (DBHelper helper = new DBHelper())
            {
                table = helper.selectAllProducts(limit, currentPage);

            }
            bindingSource.DataSource = table;
            prods.DataSource = bindingSource;
        }
        private void prods_Scroll(object sender, ScrollEventArgs e)
        {
            int totalHeight = 0;

            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
            {
                foreach (DataGridViewRow row in prods.Rows)
                    totalHeight += row.Height;

                if (!searching)
                {

                    if (prods.VerticalScrollingOffset == 0 && e.NewValue < e.OldValue)
                    {
                        if (currentPage > 1)
                        {
                            currentPage--;
                            AddTable(currentPage);
                            tableFull = false;

                        }
                        else
                        {
                            AddTable(1);
                        }
                    }

                    if (totalHeight - prods.Height < prods.VerticalScrollingOffset)
                    {
                        if (currentPage == 1)
                        {
                            AddTable(currentPage);

                        }
                        else if (currentPage != 1 && !tableFull)
                        {
                            AddTable(currentPage);

                            if (table.Rows.Count < limit)
                            {
                                tableFull = true;
                            }

                        }

                        if (!tableFull)
                        {
                            currentPage++;

                        }

                    }


                }

            }
        }

        private void custName_TextChanged(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                collection = helper.GetCustomerNames(custName.Text, out customers);

            }  
            
            try
            {
                if (string.IsNullOrEmpty(custName.Text))
                {
                    custName.BeginInvoke((Action)(() => {

                        custName.AutoCompleteCustomSource = collection;
                        custName.AutoCompleteMode = AutoCompleteMode.Suggest;
                        custName.AutoCompleteSource = AutoCompleteSource.CustomSource;


                    }));
                }

                foreach (Client option in customers)
                {
                    if (option.Nom.Equals(custName.Text))
                    {
                        selectedClient = option;
                        OnAutoCompleteTextClicked(selectedClient);
                        break;
                    }
                }


            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void custName_Click(object sender, EventArgs e)
        {
            if (custName.Text == (string)custName.Tag)
            {
                custName.Text = "";
                custName.ForeColor = Color.Black;
            }
        }

       

        public string GeneratePdf(Guna2DataGridView grid,
       Bill bill)
        {
            PdfPTable table = new PdfPTable(5);
            Information Storeinfo = DBHelper.GetStoreInformation();
            string pattern = @"\p{IsArabic}";


            PdfPCell pdfPCell = null;
            int pageCount = 1;
            iTextSharp.text.Chunk glue = new iTextSharp.text.Chunk(new VerticalPositionMark());

            Document document = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
            document.SetMargins(20f, 20f, 20f, 20f);

            string id = DateTime.Now.ToString().Trim().Replace("/", "-").Replace(":", "_");

            string path = Environment.GetFolderPath(
                         Environment.SpecialFolder.DesktopDirectory) + "\\BA_Ventes";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += "\\fichier_BA" + id + ".pdf";


            fileStream = new FileStream(path, FileMode.OpenOrCreate);
            PdfWriter writer;

            iTextSharp.text.Font FS = FontFactory.GetFont("Calibri", 12, iTextSharp.text.Font.BOLD,
                  BaseColor.BLACK);

            iTextSharp.text.Font SmallFS = FontFactory.GetFont("Calibri", 10, iTextSharp.text.Font.NORMAL,
            BaseColor.BLACK);
            writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, fileStream);
            document.Open();
            string fontPath = Environment.CurrentDirectory + "\\arabicFont.ttf";
            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            PdfPTable titlePhrase = new PdfPTable(1);
            Phrase titleYeah = new Phrase(" بيت العود و العطور الفاخرة",
                new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));

            Phrase subtitleYeah = new Phrase(Storeinfo.Activite, FontFactory.GetFont("Calibri", 10, iTextSharp.text.Font.BOLD,
            BaseColor.BLACK));

            PdfPCell cell = new PdfPCell(titleYeah);
            PdfPCell subCell = new PdfPCell(subtitleYeah);
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BorderWidthBottom = 0f;
            cell.BorderWidthLeft = 0f;
            cell.BorderWidthTop = 0f;
            cell.BorderWidthRight = 0f;
            subCell.BorderWidthBottom = 0f;
            subCell.BorderWidthLeft = 0f;
            subCell.BorderWidthTop = 0f;
            subCell.BorderWidthRight = 0f;

            titlePhrase.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            titlePhrase.HorizontalAlignment = Element.ALIGN_CENTER;
            titlePhrase.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            subCell.HorizontalAlignment = Element.ALIGN_CENTER;

            subCell.PaddingBottom = 5;

            titlePhrase.AddCell(cell);
            titlePhrase.AddCell(subCell);

            document.Add(titlePhrase);


            document.Add(iTextSharp.text.Chunk.NEWLINE);

            iTextSharp.text.Image picture = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "\\Logo.png");

            picture.ScaleToFit(80f, 80f);
            picture.Alignment = Element.ALIGN_LEFT;
            picture.SpacingAfter = 1;

            document.Add(picture);

            table.WidthPercentage = 100;
            table.HorizontalAlignment = Element.ALIGN_LEFT;




            document.Add(new Phrase("Address: " + Storeinfo.Adresse, SmallFS));
            document.Add(Chunk.NEWLINE);
            document.Add(new Phrase("NRC: " + Storeinfo.RC, SmallFS));
            document.Add(Chunk.NEWLINE);

            document.Add(new Phrase("Tel: " + Storeinfo.Tel, SmallFS));
            document.Add(Chunk.NEWLINE);
            document.Add(new Phrase("Email: " + Storeinfo.Email, SmallFS));
            document.Add(Chunk.NEWLINE);
            document.Add(new Phrase("NIF: " + Storeinfo.NIF, SmallFS));
            document.Add(Chunk.NEWLINE);

            Paragraph lineSeparator = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator
                    (0.0F, 100.0F, BaseColor.BLACK,
                    Element.ALIGN_LEFT, 1)));

            document.Add(lineSeparator);


            Phrase storeNamePhrase = (bill.Type == "Facture") ? new Phrase("Facture N°: " + bill.N, FS) :
                new Phrase("Bon N°: " + bill.N, FS);
            Paragraph p = new Paragraph(storeNamePhrase);
            p.Alignment = Element.ALIGN_CENTER;

            document.Add(p);

            PdfContentByte cb = writer.DirectContent;

            float x = 380;
            float y = 670;
            float width = 200;
            float height = 100;
            float radius = 20;

            cb.RoundRectangle(x, y, width, height, radius);
            cb.Stroke();


            ColumnText ct = new ColumnText(cb);
            float startX = x + 10; 
            float startY = y - 10;

            if (Regex.IsMatch(bill.ClientObj.Nom, pattern))
            {
                ColumnText columnText = new ColumnText(cb);
                columnText.RunDirection = PdfWriter.RUN_DIRECTION_RTL; 
                columnText.SetSimpleColumn(startX+ bill.ClientObj.Nom.Length*5, startY + 100, bill.ClientObj.Nom.Length, 4); 
                columnText.AddElement(new Phrase(bill.ClientObj.Nom,
                    new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL,
                    BaseColor.BLACK)));
                columnText.Go();

            }
            else
            {
                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(bill.ClientObj.Nom, FS), startX, startY + 80, 0);

            }



            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("\n"), startX, startY + 80, 0);

            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Tel: " + bill.ClientObj.Tel, SmallFS), startX, startY + 60, 0);
            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("\n"), startX, startY + 60, 0);


            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Adresse: " + bill.ClientObj.Adresse, SmallFS), startX, startY + 40, 0);



            document.Add(lineSeparator);

            document.Add(Chunk.NEWLINE);

            document.Add(new Phrase("Le: " + DateTime.Now, FS));



            #region Write table


            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (i == 0 ||
                i == 1 ||
                    i == 2 ||
                    i == 3 ||
                    i == 7)
                {

                    pdfPCell = new PdfPCell(new Phrase(grid.Columns[i].HeaderText, FontFactory.GetFont("Calibri", 10, iTextSharp.text.Font.BOLD,
               BaseColor.BLACK)));
                    pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    pdfPCell.Padding = 5;

                    table.AddCell(pdfPCell);
                }


            }

            foreach (DataGridViewRow row in grid.Rows)
            {

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (i == 0 ||
                          i == 1 ||
                            i == 2 ||
                            i == 3 ||
                    i == 7)
                    {

                        if (row.Cells[i].Value != null)
                        {
                            if (Regex.IsMatch(row.Cells[i].Value.ToString(), pattern))
                            {
                                


                                Phrase ph = new Phrase(row.Cells[i].Value.ToString(),
                                     new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));

                                pdfPCell = new PdfPCell(ph);
                                pdfPCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                            }
                            else
                            {
                                pdfPCell = new PdfPCell(new Phrase(row.Cells[i].Value.ToString(), SmallFS));

                            }


                        }
                        else
                        {

                            pdfPCell = new PdfPCell(new Phrase("Non disponible", SmallFS));

                        }
                        pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPCell.Padding = 5;

                        table.AddCell(pdfPCell);
                    }


                }
            }

            #endregion





            document.Add(table);



            document.Add(new iTextSharp.text.Paragraph("\n"));

            document.Add(new iTextSharp.text.Paragraph("Total lignes: " + bill.N_Ligne));
            document.Add(Chunk.NEWLINE);

            pageCount = document.PageNumber + 1;

            if (table.Rows.Count > 16 * pageCount)
            {
                document.NewPage();

            }


            float phraseHeight = SmallFS.GetCalculatedBaseFont(true).
                GetFontDescriptor(BaseFont.AWT_MAXADVANCE, SmallFS.Size);

            float phraseY = document.BottomMargin + phraseHeight;

            PdfContentByte conb = writer.DirectContent;


            conb.RoundRectangle(document.Right - 150, phraseY + 10, 150, 100, 20);
            conb.Stroke();


            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Taux TVA: \t" + bill.TauxTVA.ToString("F2") + " DA", SmallFS), document.Right - 140, phraseY + 90, 0);

            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Total TTC: \t" + bill.TotalTTC.ToString("F2") + " DA", SmallFS), document.Right - 140, phraseY + 70, 0);

            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Versement: \t" + bill.MontantRegler.ToString("F2") + " DA", SmallFS), document.Right - 140, phraseY + 50, 0);

            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Reste: \t" + bill.MontantRest.ToString("F2") + " DA", SmallFS), document.Right - 140, phraseY + 30, 0);



            string text = (bill.Type == "Facture") ? "La facture présente" : "Le bon pérsent";

            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(text + " est à la somme de: ", SmallFS), document.Left, phraseY + 40, 0);
            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("\n"), document.Left, phraseY + 40, 0);

            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(Convert.ToInt32(bill.TotalTTC).ToWords(
                new System.Globalization.CultureInfo("fr-FR")).ToUpper() + " Dinars Algériens"), document.Left, phraseY + 20, 0);

            document.Close();

            return fileStream.Name; 







        }
        void Comp_SizeChanged(object sender, EventArgs e)
        {
            if (this.Size.Width > SizeX)
            {
                prods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                prods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            }
        }
        public static double NewPrice { get; set; }
    }
}
