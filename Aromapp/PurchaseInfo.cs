using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using Guna.UI2.WinForms;
using Humanizer;
using iTextSharp.text.pdf.draw;
using iTextSharp.text.pdf;
using iTextSharp.text;
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
using System.Text.RegularExpressions;

namespace Aromapp
{
    public partial class PurchaseInfo : DevExpress.XtraEditors.XtraForm
    {
        string ProductID;

        public Sale Sale { get; }
        public Supplier Supplier { get; }
        public static bool DeletedProduct { get; set; }
        public static decimal Total { get; set; }
        public static bool DeletedSale { get; set; }

        public PurchaseInfo(Sale sale, Supplier supplier)
        {
            InitializeComponent();


            PurchaseLines.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(255, 64, 64, 64),
                Font = new System.Drawing.Font("Calibri", 9.25f)
            };
            PurchaseLines.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(63, 81, 181),
                Font = new System.Drawing.Font("Calibri", 9.25f, FontStyle.Bold)
            };
            PurchaseLines.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = System.Drawing.Color.FromArgb(63, 81, 181),
                Font = new System.Drawing.Font("Calibri", 9.25f, FontStyle.Bold),
                ForeColor = Color.White
            };

            Sale = sale;
            Supplier = supplier;
        }



        private void BillLines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductID = PurchaseLines.SelectedRows[0].Cells[2].Value.ToString();

            Product prod;

            using (DBHelper helper = new DBHelper())
            {

                   prod = helper.selectProductByID(ProductID);
                
            }     
            
            if (!string.IsNullOrEmpty(prod.Name))
            {
                prodName.Text = prod.Name;

            }
            if (!string.IsNullOrEmpty(prod.Type))
            {
                prodType.Text = prod.Type;

            }

            if (!string.IsNullOrEmpty(prod.PriceG.ToString()))
            {
                PriceG.Text = prod.PriceG.ToString();

            }
            if (!string.IsNullOrEmpty(prod.PriceD.ToString()))
            {
                PriceD.Text = prod.PriceD.ToString();
            }
            if (!string.IsNullOrEmpty(prod.Quantity.ToString()))
            {
                QtD.Text = prod.Quantity.ToString();
            }


            if (!string.IsNullOrEmpty(PurchaseLines.SelectedRows[0].Cells[4].Value.ToString()))
            {
                Qt.Text = PurchaseLines.SelectedRows[0].Cells[4].Value.ToString();
            }

            subTotal.Text = PurchaseLines.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void PurchaseInfo_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(945, 498);
            this.CenterToScreen();

            using (DBHelper helper = new DBHelper())
            {
                PurchaseLines.DataSource = helper.selectPurchaseLines(Sale.N);

            }
            saleRef.Text = Sale.N;
            saleTotal.Text = Sale.TotalHT.ToString();

            saleType.Text = Sale.Type;
            saleDate.Text = Sale.Date.Replace("00:00:00", "");
            subTotal.Text = "0";

            label3.Text = label3.Text.Replace("Bon", Sale.Type);
        }

        void Removed(object sender, FormClosingEventArgs e)
        {

            if (DeletedProduct)
            {
                using (DBHelper helper = new DBHelper())
                {
                    PurchaseLines.DataSource = helper.selectPurchaseLines(Sale.N);

                }         
                saleTotal.Text = Total.ToString();

            }
            if (DeletedSale)
            {
                this.Close();
            }

        }
        private void RetirerProd_Click(object sender, EventArgs e)
        {
            decimal qt = 0;
            string prodID = PurchaseLines.SelectedRows[0].Cells[2].Value.ToString();

            if (!string.IsNullOrEmpty(PurchaseLines.SelectedRows[0].Cells[4].Value.ToString()))
            {

                qt = decimal.Parse(PurchaseLines.SelectedRows[0].Cells[4].Value.ToString());
            }
            if (PurchaseLines.SelectedRows.Count > 0)
            {
                RemoveFromPurchases removeProduct = new RemoveFromPurchases(prodID, qt, saleRef.Text.Trim());
                removeProduct.FormClosing += Removed;


                removeProduct.ShowDialog();
            }
            else
            {
                MessageBoxer.showGeneralMsg("Sélectionnez d'abord une ligne");
            }
        }

        void PasswoCorrectDelete(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                if (helper.DeletePurchase(saleRef.Text) > 0)
                {
                    Achats.DeletedPurchase = true;
                    this.Close();

                }
                else
                {
                    MessageBoxer.showErrorMsg("Une erreur se produitse");
                }
            }
        }
        private void supprimer_Click(object sender, EventArgs e)
        {
             PasswoCorrectDelete(sender,e);

        }

        private void imprimmer_Click(object sender, EventArgs e)
        {
            Bill bill = new Bill();
            bill.N = Sale.N;
            bill.DateA = DateTime.Parse(Sale.Date);
            bill.TotalTTC = (double)Sale.TotalHT;
            bill.TauxTVA = 0;
            bill.MontantRegler = (double)Sale.MontantRegler;
            bill.MontantRest = (double)Sale.MontantRest;


            GeneratePdf(PurchaseLines, bill);

        }

        FileStream fileStream;
        public void GeneratePdf(Guna2DataGridView grid,
      Bill bill)
        {
            PdfPTable table = new PdfPTable(5);

            Information Storeinfo = DBHelper.GetStoreInformation();
            string pattern = @"\p{IsArabic}";

            PdfPCell pdfPCell = null;
            Chunk glue = new Chunk(new VerticalPositionMark());

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


            document.Add(Chunk.NEWLINE);

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

            iTextSharp.text.Paragraph lineSeparator = new iTextSharp.text.Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator
                    (0.0F, 100.0F, BaseColor.BLACK,
                    Element.ALIGN_LEFT, 1)));

            document.Add(lineSeparator);


            Phrase storeNamePhrase = new Phrase("Achat N°: " + bill.N, FS);
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
            float startX = x + 10; // X-coordinate for the start of text
            float startY = y - 10;

            if (Regex.IsMatch(Supplier.Nom, pattern))
            {
                ColumnText columnText = new ColumnText(cb);
                columnText.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                columnText.SetSimpleColumn(startX + Supplier.Nom.Length * 5, startY + 100, Supplier.Nom.Length, 4);
                columnText.AddElement(new Phrase(Supplier.Nom,
                    new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL,
                    BaseColor.BLACK)));
                columnText.Go();

            }
            else
            {
                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(Supplier.Nom, FS), startX, startY + 80, 0);

            }
            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("\n"), startX, startY + 80, 0);

            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Tel: " + Supplier.Tel, SmallFS), startX, startY + 60, 0);
            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("\n"), startX, startY + 60, 0);


            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Adresse: " + Supplier.Adresse, SmallFS), startX, startY + 40, 0);



            document.Add(lineSeparator);

            document.Add(Chunk.NEWLINE);

            document.Add(new Phrase("Le: " + bill.DateA, FS));



            #region Write table

            /*[N],[Type],[C_PR] as Réf,[Nomproduit] as Désignation ,[Quantité] as Qté,[PrixHT] as 'Prix U' " +
                            ",[Marge],MontantHT as 'Montant HT',[Remise]*/

            /* Réf
             PR0030
             Désignation
             Qté
             Prix U
             CHANEL 5
             Total lignes: 1
             20
             12
             Montant HT*/


            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (i == 2 ||
                    i == 3 ||
                    i == 4 ||
                    i == 5 ||
                    i == 7)
                {

                    pdfPCell = new PdfPCell(new Phrase(grid.Columns[i].HeaderText,
                        FontFactory.GetFont("Calibri", 10, iTextSharp.text.Font.BOLD,
               BaseColor.BLACK)));
                    pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    pdfPCell.Padding = 5;

                    table.AddCell(pdfPCell);
                }


            }

            foreach (DataGridViewRow row in grid.Rows)
            {

                if (row.Index != grid.RowCount - 1)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (i == 2 ||
                        i == 3 ||
                        i == 4 ||
                        i == 5 ||
                        i == 7)
                        {

                            if (row.Cells[i].Value != null)
                            {
                                pdfPCell = new PdfPCell(new Phrase(row.Cells[i].Value.ToString(), SmallFS));

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
            }

            #endregion





            document.Add(table);

            document.Add(new iTextSharp.text.Paragraph("\n"));

            document.Add(new iTextSharp.text.Paragraph("Total lignes: " + (grid.RowCount - 1).ToString()));

            document.Add(Chunk.NEWLINE);

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



            string text = "La facture présente";

            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(text + " est à la somme de: ", SmallFS), document.Left, phraseY + 40, 0);
            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("\n"), document.Left, phraseY + 40, 0);

            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(Convert.ToInt32(bill.TotalTTC).ToWords(
                new System.Globalization.CultureInfo("fr-FR")).ToUpper() + " Dinars algériens"), document.Left, phraseY + 20, 0);


            document.Close();

            System.Diagnostics.Process.Start(fileStream.Name);







        }
    }
}