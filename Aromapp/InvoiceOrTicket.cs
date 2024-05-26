using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using Guna.UI2.WinForms;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace Aromapp
{
    public partial class InvoiceOrTicket : DevExpress.XtraEditors.XtraForm
    {
        public string InvoicePath {  get; set; }
        public string ticketPath { get; set; }

        public string Type { get; set; }

        public Bill InvoiceBill { get; set; }
        public Bill TicketBill { get; set; }

        Bill SelectedBill;
        public double amountPaid { get; set; }

        public List<SaleLine> soldProducts { get; set; }
          
        public string reductionString { get; set; }


        public  bool canceled { get; set; }

        string clientID { get; set; }

        string billID;

        public event EventHandler SaleAdded;
        PdfViewer pdfViewer2;

        public InvoiceOrTicket(string Invoicepath, string TicketPath)
        {
            canceled = true;
            this.InvoicePath = Invoicepath;
            this.ticketPath = TicketPath;
            InitializeComponent();
            this.Load += InvoiceLoad;
        }
        public void InvoiceLoad(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 0;
            Type = "Facture";
            SelectedBill = InvoiceBill;
            this.WindowState = FormWindowState.Maximized;

            pdfViewer1.Document = PdfDocument.Load(InvoicePath);


        }


        private void guna2TabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if(e.TabPage.Name == "Bon")
            {

                
                pdfViewer2 = new PdfViewer();
                pdfViewer2.Dock = DockStyle.Fill;
                e.TabPage.Controls.Add(pdfViewer2);
                pdfViewer2.Document = PdfDocument.Load(ticketPath);
                Type = "Bon";
                SelectedBill = TicketBill;

            }
            else
            {
                
                pdfViewer1.Document = PdfDocument.Load(InvoicePath);
                Type = "Facture";
                SelectedBill = InvoiceBill;

            }
        }

        public void SaveClick(object sender, EventArgs e)
        {
            canceled = false;
            DialogResult result = MessageBox.Show("Êtes vous sûr ?", "Sauveguader", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using (DBHelper helper = new DBHelper())
                {
                    if (helper.SaveSale(soldProducts, SelectedBill.TotalTTC, SelectedBill.ClientObj.Nom,
                                SelectedBill.MontantRegler, float.Parse(SelectedBill.TauxTVA.ToString()),
                               Type, out billID, double.Parse(reductionString)) > 0)
                    {
                        MessageBoxer.showGeneralMsg("Vente sauvegardée");

                       
                        this.Close();
                    }
                    else
                    {
                        canceled = true;
                    }
                } 
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            canceled = false;

            DialogResult result = MessageBox.Show("Êtes vous sûr ?", "Valider", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using (DBHelper helper = new DBHelper())
                {
                    if (helper.AddSale(soldProducts, SelectedBill.TotalTTC, SelectedBill.ClientObj.Nom,
                               amountPaid, float.Parse(SelectedBill.TauxTVA.ToString()),
                               Type, out billID, double.Parse(reductionString)) > 0)
                    {

                        using (var printDialog = new PrintDialog())
                        {
                            if (printDialog.ShowDialog() == DialogResult.OK)
                            {
                                using (var document = PdfDocument.Load(Type == "Facture" ? InvoicePath : ticketPath))
                                {
                                    using (var printDocument = document.CreatePrintDocument())
                                    {
                                        printDocument.PrinterSettings = printDialog.PrinterSettings;
                                        printDocument.Print();
                                    }
                                }
                            }
                        }

                        this.Close();
                    }
                    else
                    {
                        canceled = true;
                    }
                }
            }
               
        }

        public void OnSaleAdded(EventArgs e)
        {
            EventHandler eh = SaleAdded;
            if (eh != null)
            {
                eh(this, e);


            }
        }

        
        private void delete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InvoiceOrTicket_FormClosed(object sender, FormClosedEventArgs e)
        {
            pdfViewer1.Document.Dispose();
            pdfViewer1.Document.Dispose();
            OnSaleAdded(e);
        }

        private void InvoiceOrTicket_SizeChanged(object sender, EventArgs e)
        {
            
                guna2TabControl1.TabButtonSize = new Size((int)((guna2TabControl1.Width / 2) - 2.2), guna2TabControl1.TabButtonSize.Height);

            
        }
    }
}