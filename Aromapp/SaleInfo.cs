using DevExpress.XtraEditors;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using DevExpress.XtraEditors.Filtering.Templates;
using static DevExpress.XtraEditors.Mask.MaskSettings;
using ZXing;
using System.Text.RegularExpressions;
using System.Security.Cryptography;


namespace Aromapp
{
    public partial class SaleInfo : DevExpress.XtraEditors.XtraForm
    {

        public Sale sale { get; set; }
        static bool deletedProduct = false;
        public static double NewPrice { get; set; }

        public static bool DeletedProduct { get => deletedProduct; set => deletedProduct = value; }
        static bool deletedSale = false;
        public double OriginalTotal, NewTotal;

        public static decimal Total { get; set; }
        DBHelper helper = new DBHelper();

        public Client ClientProp { get; set; }
        private BackgroundWorker dataLoader;
        bool typeSelected = false,
             tableFull = false,
             searching = false;
        

        int limit = 100, currentPage = 1;

        public static bool detail = true;
        List<double> BuyingPrices = new List<double>();
        public static double quantity = 1;
        public static DataTable CartTable;
        public List<SaleLine> OldSaleLines = new List<SaleLine>();
        public List<SaleLine> NewSaleLines = new List<SaleLine>();
        public bool prodIsNew = false;
        DataTable cartTable;
        public SaleInfo(Sale sale, Client client)
        {
            this.sale = sale;
            newID = sale.N;
            Total = sale.TotalHT;
            ClientProp = client;
            dataLoader = new BackgroundWorker();
            InitializeComponent();
           

            dataLoader.DoWork += LoadProducts;
            dataLoader.RunWorkerCompleted += LoadProductsCompleted;
            CartTable = new DataTable();
            CartTable.Columns.AddRange(new DataColumn[9] { new DataColumn("N"), new DataColumn("Type"),new DataColumn("Réf"),new DataColumn("Désignation"),
                new DataColumn("Qté"), new DataColumn("Prix U"),new DataColumn("Marge"),
                new DataColumn("Montant HT"),new DataColumn("Remise") });
        }
        private void searchBox_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(searchBox);

        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            HintUtils.ShowHint(searchBox);

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
        public static string SaleRefString;

        private void SaleInfo_Load(object sender, EventArgs e)
        {
            
            this.ClientSize = new System.Drawing.Size(1045, 698);
       
            this.CenterToScreen();

            BillLines.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            BillLines.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(255, 64, 64, 64),
                Font = new System.Drawing.Font("Calibri", 9.25f)
            };
            BillLines.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(63, 81, 181),
                Font = new System.Drawing.Font("Calibri", 9.25f, FontStyle.Bold),
                ForeColor = Color.White
            };
            prods.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            prods.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(255, 64, 64, 64),
                Font = new System.Drawing.Font("Calibri", 9.25f)
            };
            prods.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(63, 81, 181),
                Font = new System.Drawing.Font("Calibri", 9.25f, FontStyle.Bold),
                ForeColor = Color.White
            };

            cart.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            cart.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(255, 64, 64, 64),
                Font = new System.Drawing.Font("Calibri", 9.25f)
            };
            cart.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(63, 81, 181),
                Font = new System.Drawing.Font("Calibri", 9.25f, FontStyle.Bold),
                ForeColor = Color.White
            };

            guna2TabControl1.TabButtonSize= new Size ((int) (guna2TabControl1.Width / 2)-2, guna2TabControl1.TabButtonSize.Height);
            
            BillLines.DataSource = helper.selectBillLines(sale.N);
            saleRef.Text = sale.N;
            saleTotal.Text = sale.TotalHT.ToString("F2") + " DA";
            saleType.Text = sale.Type;
            saleDate.Text = sale.Date.Replace("00:00:00", "");
            subTotal.Text = "0";
            nettotalText.Text = saleTotal.Text;
            SaleRefString = saleRef.Text;
            label3.Text = label3.Text.Replace("Bon", sale.Type);

            cartTable = ((DataTable)BillLines.DataSource).Copy();
            foreach (var item in cartTable.Rows)
            {
                CartTable.Rows.Add(item);
            }
            foreach (DataRow line in cartTable.Rows)
            {

                SaleLine sale = new SaleLine();
                sale.N = saleRef.Text;
                sale.C_CL = ClientProp.C_CL;
                sale.Nomproduit = line[3].ToString();
                sale.Quantité = double.Parse(line[4].ToString());
                sale.PrixHT = double.Parse(line[5].ToString());
                sale.Marge = double.Parse(line[6].ToString());
                sale.Remise = double.Parse(line[8].ToString());
                sale.C_PR = line[2].ToString();
                sale.Type = line[1].ToString();
                sale.DateA = DateTime.Now.Date;
                sale.MontantHT = double.Parse(line[7].ToString());
                OriginalTotal += sale.PrixHT * sale.Quantité;
                OldSaleLines.Add(sale);

            }
            NewTotal = OriginalTotal;



        }

        string ProductID;
        DataTable table;

        private void BillLines_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            ProductID = BillLines.SelectedRows[0].Cells[2].Value.ToString();

            Product prod = helper.selectProductByID(ProductID);
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


            if (!string.IsNullOrEmpty(BillLines.SelectedRows[0].Cells[4].Value.ToString()))
            {
                Qt.Text = BillLines.SelectedRows[0].Cells[4].Value.ToString();
            }

            subTotal.Text = BillLines.SelectedRows[0].Cells[7].Value.ToString();
        }

        public void LoadProducts(object sener,EventArgs e)
        {
             table = new DataTable();


            using (DBHelper helper = new DBHelper())
            {
                table = helper.selectAllProducts(limit, currentPage);

            }

        }
        public void LoadProductsCompleted(object sener, EventArgs e)
        {
            prods.Invoke((Action)(() => { prods.DataSource = table; }));

            CartTable = ((DataTable)cart.DataSource).Copy();
        }

        string column = null;
        /*        void PasswoCorrect(object sender, EventArgs e)
                {
                    double total = 0;




                    DBHelper helper = new DBHelper();

                    DataTable table = helper.selectBillLines(Sale.N);
                    BillLines.DataSource = table;

                    foreach (DataGridViewRow row in BillLines.Rows)
                    {
                        if (row.Index != BillLines.RowCount - 1)
                        {
                            total += double.Parse(row.Cells[4].Value.ToString()) * double.Parse(row.Cells[5].Value.ToString());

                        }
                    }
                    saleTotal.Text = total.ToString();



                }
        */
        /*        private void iconButton2_Click(object sender, EventArgs e)
                {
                    if (column!=null)
                    {
                        if(double.Parse(val.Text) < double.Parse(Qt.Text))
                        {

                            Confirm confirm = new Confirm();
                            confirm.Passed += PasswoCorrect;

                            confirm.ShowDialog();
                        }
                        else 
                        {

                            if (double.Parse(val.Text) < double.Parse(QtD.Text))
                            {

                                Confirm confirm = new Confirm();
                                confirm.Passed += PasswoCorrect;

                                confirm.ShowDialog();
                            }
                            else
                            {
                                MessageBoxer.showErrorMsg("Vous ne pouvez pas dépasser la quantité disponible");

                            }
                        }

                    }
                    else
                    {
                        MessageBoxer.showGeneralMsg("Choisissez la valeur à modifier");
                    }
                }
        */




        void PasswoCorrectDelete(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                foreach (SaleLine line in OldSaleLines)
                {
                    helper.RemoveProductFromBill(0,line.C_PR, line.N, true, (decimal)line.Quantité, true);
                }
            }

            using (DBHelper helper = new DBHelper())
            {


                if (helper.DeleteBill(saleRef.Text) > 0)
                {
                    Ventes.DeletedBill = true;
                    this.Close();

                }
                else
                {
                    MessageBoxer.showErrorMsg("Une erreur s'est produite");
                }
            }
        }
        private void supprimer_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ê".ToUpper() + "tes-vous êtes sûr", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                PasswoCorrectDelete(sender, e);

            }

        }

        private void SupprimerProd_Click(object sender, EventArgs e)
        {
            decimal qt = 0;
            string prodID = BillLines.SelectedRows[0].Cells[2].Value.ToString();

            if (!string.IsNullOrEmpty(BillLines.SelectedRows[0].Cells[4].Value.ToString()))
            {

                qt = decimal.Parse(BillLines.SelectedRows[0].Cells[4].Value.ToString());
            }
            if (BillLines.SelectedRows.Count > 0)
            {
                RemoveProduct removeProduct = new RemoveProduct(prodID, qt, saleRef.Text.Trim());
                removeProduct.modif = false;
                removeProduct.modifNew = false;
                removeProduct.Removed += Removed;


                removeProduct.ShowDialog();
            }
            else
            {
                MessageBoxer.showGeneralMsg("Sélectionnez d'abord une ligne");
            }



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

            writer.ViewerPreferences = PdfWriter.PageLayoutTwoColumnLeft;

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


            Phrase storeNamePhrase = (bill.Type == "Facture") ? new Phrase("Facture N°: " + newID, FS) :
                new Phrase("Bon N°: " + newID, FS);
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

            if (Regex.IsMatch(ClientProp.Nom, pattern))
            {
                ColumnText columnText = new ColumnText(cb);
                columnText.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                columnText.SetSimpleColumn(startX + ClientProp.Nom.Length * 5, startY + 100, ClientProp.Nom.Length, 4);
                columnText.AddElement(new Phrase(ClientProp.Nom,
                    new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL,
                    BaseColor.BLACK)));
                columnText.Go();

            }
            else
            {
                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(ClientProp.Nom, FS), startX, startY + 80, 0);

            }
            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("\n"), startX, startY + 80, 0);

            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Tel: " + ClientProp.Tel, SmallFS), startX, startY + 60, 0);
            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("\n"), startX, startY + 60, 0);


            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Adresse: " + ClientProp.Adresse, SmallFS), startX, startY + 40, 0);



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
            float NumLignePos = writer.GetVerticalPosition(true);

            document.Add(Chunk.NEWLINE);

            var remainingPageSpace = NumLignePos - document.BottomMargin;

            float phraseHeight = SmallFS.GetCalculatedBaseFont(true).
                GetFontDescriptor(BaseFont.AWT_MAXADVANCE, SmallFS.Size);

            float phraseY = document.BottomMargin + phraseHeight;

            if (table.Rows.Count <= 17 && remainingPageSpace > 100)
            {
                phraseY = NumLignePos - 100;

                PdfContentByte conb = writer.DirectContent;


                conb.RoundRectangle(document.Right - 150, phraseY + 10, 150, 100, 20);
                conb.Stroke();

                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Taux TVA: \t" + bill.TauxTVA.ToString("F2") + " DA", SmallFS), document.Right - 140, phraseY + 90, 0);
                string versement = (NewTotal == OriginalTotal) ? bill.MontantRegler.ToString("F2") : NewTotal.ToString("F2");
                string total = (NewTotal == OriginalTotal) ? OriginalTotal.ToString("F2") : NewTotal.ToString("F2");


                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Total TTC: \t" + total + " DA", SmallFS), document.Right - 140, phraseY + 70, 0);

                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Versement: \t" + versement + " DA", SmallFS), document.Right - 140, phraseY + 50, 0);

                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Reste: \t" + bill.MontantRest.ToString("F2") + " DA", SmallFS), document.Right - 140, phraseY + 30, 0);


            }
            else if (writer.PageNumber > 1 && table.Rows.Count % 17 >= 0)
            {


                if (table.TotalHeight >= 500)
                {
                    phraseY = NumLignePos - 120;

                }

                PdfContentByte conb = writer.DirectContent;


                conb.RoundRectangle(document.Right - 150, phraseY + 10, 150, 100, 20);
                conb.Stroke();

                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Taux TVA: \t" + bill.TauxTVA.ToString("F2") + " DA", SmallFS), document.Right - 140, phraseY + 90, 0);
                string versement = (NewTotal == OriginalTotal) ? bill.MontantRegler.ToString("F2") : NewTotal.ToString("F2");
                string total = (NewTotal == OriginalTotal) ? OriginalTotal.ToString("F2") : NewTotal.ToString("F2");


                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Total TTC: \t" + total + " DA", SmallFS), document.Right - 140, phraseY + 70, 0);

                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Versement: \t" + versement + " DA", SmallFS), document.Right - 140, phraseY + 50, 0);

                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Reste: \t" + bill.MontantRest.ToString("F2") + " DA", SmallFS), document.Right - 140, phraseY + 30, 0);

            }
            else
            {
                document.NewPage();
                phraseY = document.PageSize.Height - document.TopMargin - phraseHeight*10;
                PdfContentByte conb = writer.DirectContent;


                conb.RoundRectangle(document.Right - 150, phraseY + 10, 150, 100, 20);
                conb.Stroke();

                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Taux TVA: \t" + bill.TauxTVA.ToString("F2") + " DA", SmallFS), document.Right - 140, phraseY + 90, 0);
                string versement = (NewTotal == OriginalTotal) ? bill.MontantRegler.ToString("F2") : NewTotal.ToString("F2");
                string total = (NewTotal == OriginalTotal) ? OriginalTotal.ToString("F2") : NewTotal.ToString("F2");


                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Total TTC: \t" + total + " DA", SmallFS), document.Right - 140, phraseY + 70, 0);

                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Versement: \t" + versement + " DA", SmallFS), document.Right - 140, phraseY + 50, 0);

                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Reste: \t" + bill.MontantRest.ToString("F2") + " DA", SmallFS), document.Right - 140, phraseY + 30, 0);
            }




            string text = (bill.Type == "Facture") ? "La facture présente" : "Le bon pérsent";

            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(text + " est à la somme de: ", SmallFS), document.Left, phraseY + 40, 0);
            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("\n"), document.Left, phraseY + 40, 0);

            string TotalString = Convert.ToInt32(Math.Round(double.Parse(nettotalText.Text.Replace("DA", "")), 0)).ToWords(
                 new System.Globalization.CultureInfo("fr-FR")).ToUpper()+ " Dinars algériens";

            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(TotalString, 
                FontFactory.GetFont("Calibri", 8, iTextSharp.text.Font.NORMAL,
            BaseColor.BLACK)),document.Left, phraseY + 20, 0);
            
            document.Close();
            System.Diagnostics.Process.Start(fileStream.Name);







        }

        private void SaleInfo_SizeChanged(object sender, EventArgs e)
        {
            guna2TabControl1.TabButtonSize = new Size((int)(guna2TabControl1.Width / 2) - 2, guna2TabControl1.TabButtonSize.Height);

        }
        Qt qtForm;
        private void prods_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            NewPrice = detail ? double.Parse(prods.SelectedRows[0].Cells[6].Value.ToString()) :
     NewPrice = double.Parse(prods.SelectedRows[0].Cells[7].Value.ToString());

            qtForm = new Qt();

            qtForm.totalBulk = double.Parse(prods.SelectedRows[0].Cells[7].Value.ToString());
            qtForm.totalRetail = double.Parse(prods.SelectedRows[0].Cells[6].Value.ToString());

            qtForm.Added += AddProduct;
            qtForm.ShowDialog();

        }
    
        void AddProduct(object sender, EventArgs e)
        {
            double buyinPrice;


            string reference = prods.SelectedRows[0].Cells[0].Value.ToString(),
                type = prods.SelectedRows[0].Cells[4].Value.ToString();


            string nomproduits = prods.SelectedRows[0].Cells[2].Value.ToString();

       
            buyinPrice = double.Parse(prods.SelectedRows[0].Cells[5].Value.ToString());

            BuyingPrices.Add(buyinPrice);

            produits l_Ventes = new produits(nomproduits, quantity, NewPrice, 10, 0);

            l_Ventes.Marge = (NewPrice - buyinPrice) * quantity;
            l_Ventes.MontantHT = NewPrice* quantity;

            nettotalText.Text = (double.Parse(nettotalText.Text.Replace(" DA", "")) + quantity * NewPrice).ToString("F2")+" DA";

            quantity = 1;

            SaleLine sale = new SaleLine();
            sale.N = (applied)?newID:saleRef.Text;
            sale.C_CL = ClientProp.C_CL;
            sale.Nomproduit = nomproduits;
            sale.Quantité = l_Ventes.Quantité;
            sale.PrixHT = NewPrice;
            sale.Marge = l_Ventes.Marge;
            sale.Remise = 0;
            sale.C_PR = reference;
            sale.Type = type;
            sale.DateA = DateTime.Now.Date;
            sale.MontantHT = l_Ventes.MontantHT;

            NewTotal += sale.PrixHT * sale.Quantité;
            NewSaleLines.Add(sale);


            CartTable.Rows.Add(saleRef.Text, type, reference, l_Ventes.Nomproduits, double.Parse(l_Ventes.Quantité.ToString().Replace(".", ",")),
                NewPrice, l_Ventes.Marge, l_Ventes.MontantHT,
                Aromapp.Qt.OptionalPrice);


            cart.DataSource = CartTable;

            applied = false;

            qtForm.Close();

        }

        bool applied = false;
        bool exe = false;
        string newID;

        public void UpdateBillStatus(bool executed)
        {
            applied = true;
            DataTable newTable = ((DataTable)cart.DataSource).Copy();
            List<SaleLine> saleLines = new List<SaleLine>();


            using (DBHelper helper = new DBHelper())
            {
                foreach (SaleLine line in OldSaleLines)
                {
                    if (line != null)
                    {
                        helper.RemoveProductFromBill(line.MontantHT, line.C_PR, line.N, true, (decimal)line.Quantité, true);

                    }

                }
            }

            double benefice = 0;

            foreach (DataRow line in newTable.Rows)
            {

                try
                {
                    SaleLine sale = new SaleLine();
                    sale.N = saleRef.Text;
                    sale.C_CL = ClientProp.C_CL;
                    sale.Nomproduit = line[3].ToString();
                    sale.Quantité = double.Parse(line[4].ToString());
                    sale.PrixHT = double.Parse(line[5].ToString());
                    sale.Marge = double.Parse(line[6].ToString());
                    sale.Remise = 0;
                    sale.C_PR = line[2].ToString();
                    sale.Type = line[1].ToString();
                    sale.DateA = DateTime.Now.Date;
                    sale.MontantHT = double.Parse(line[7].ToString());
                    benefice += sale.Marge;
                    saleLines.Add(sale);
                }
                catch (DeletedRowInaccessibleException)
                {

                }
            }
            sale.MontantRegler = decimal.Parse(nettotalText.Text.Replace(" DA", ""));

            using (DBHelper helper = new DBHelper())
            {

                if (helper.UpdateBill(benefice, saleRef.Text, double.Parse(nettotalText.Text.Replace(".", ",")
                    .Replace(" DA", "")), executed, out newID) > 0)
                {
                    foreach (SaleLine line in saleLines)
                    {
                        line.N = newID;
                        helper.AddSaleLines(line);
                        helper.InsertIntoStockHistory(line, line.C_CL);
                    }
                    saleRef.Text = newID;
                    try
                    {
                        if (executed)
                        {
                            helper.InsertIntoLog("La vente " + newID + " avec le total de : "+ nettotalText.Text + " a été éffectuée");

                            helper.Earn(double.Parse(nettotalText.Text.Replace(".", ",").Replace(" DA", "")), new User(Properties.Settings.
                                                            Default.LoggedInUserName, Properties.Settings.
                                                            Default.LoggedInUserID), saleLines[0].DateA.ToString("yyyy-MM-dd"),
                                                            (!string.IsNullOrEmpty(saleLines[0].NomClient))?
                                                            saleLines[0].NomClient:"Non disponible",
                                                            saleLines[0].N, "Vente", 0); 
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {

                    }
                }
            }

            OldSaleLines = saleLines;
            BillLines.DataSource = helper.selectBillLines(sale.N);
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SaveBtn.Enabled = false;
                UpdateBillStatus(true);
                MessageBoxer.showGeneralMsg("Vente effectuée");

                prods.DataSource = helper.selectAllProducts(limit, 1);
                BillLines.DataSource = helper.selectBillLines(newID);
                cartTable = ((DataTable)cart.DataSource).Copy();
                cart.DataSource = cartTable; ;
                OldSaleLines.Clear();
                foreach (DataRow line in cartTable.Rows)
                {

                    SaleLine sale = new SaleLine();
                    sale.N = saleRef.Text;
                    sale.C_CL = ClientProp.C_CL;
                    sale.Nomproduit = line[3].ToString();
                    sale.Quantité = double.Parse(line[4].ToString());
                    sale.PrixHT = double.Parse(line[5].ToString());
                    sale.Marge = double.Parse(line[6].ToString());
                    sale.Remise = double.Parse(line[8].ToString());
                    sale.C_PR = line[2].ToString();
                    sale.Type = line[1].ToString();
                    sale.DateA = DateTime.Now.Date;
                    sale.MontantHT = double.Parse(line[7].ToString());
                    OriginalTotal += sale.PrixHT * sale.Quantité;
                    OldSaleLines.Add(sale);

                }
                guna2TabControl1.SelectedIndex = 0;

                double total = 0;
                foreach (SaleLine saleLine in OldSaleLines)
                {
                    total += saleLine.MontantHT;
                }
                saleTotal.Text = total.ToString("F2") + " DA";
                saleRef.Text = newID;
            }
            catch (Exception)
            {

            }


        }

        private void cart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ProductID = cart.SelectedRows[0].Cells[2].Value.ToString();
            decimal qtt = (decimal)double.Parse(cart.SelectedRows[0].Cells[4].Value.ToString());
            int idx = cart.SelectedRows[0].Index;

            if (cart.SelectedRows.Count > 0)
            {
                RemoveProduct removeProduct = new RemoveProduct(ProductID, qtt, saleRef.Text.Trim());

                try
                {
                    if (OldSaleLines[idx] != null && OldSaleLines[idx].C_PR == ProductID)
                    {
                        
                            removeProduct.modif = true;
                            removeProduct.modifNew = false;
                            prodIsNew = false; 
                        


                    }

                    else
                    {

                        if (applied)
                        {
                            removeProduct.modif = true;
                            removeProduct.modifNew = false;
                            prodIsNew = true;
                        }
                        else
                        {
                            removeProduct.modif = false;
                            removeProduct.modifNew = true;
                            prodIsNew = true;
                        }


                    }
                    

                    if(OldSaleLines[idx] != null && OldSaleLines[idx].N.Contains("T"))
                    {
                        removeProduct.modif = false;
                        removeProduct.modifNew = true;
                        prodIsNew = true;
                    }

                }
                catch (Exception)
                {

                    removeProduct.modif = false;
                    removeProduct.modifNew = true;
                    prodIsNew = true;

                }
                
                


                removeProduct.Removed += RemovedFromCart;



                removeProduct.ShowDialog();
            }
            else
            {
                MessageBoxer.showGeneralMsg("Sélectionnez d'abord une ligne");
            }
        }
        void Removed(object sender, EventArgs e)
        {
            if (DeletedBill)
            {
                this.Close();
            }

            if (DeletedProduct)
            {
                BillLines.DataSource = helper.selectBillLines(sale.N);

                saleTotal.Text = Total.ToString("F2") + " DA";

            }

           
        }
        void RemovedFromCart(object sender, EventArgs e)
        {

            if (DeletedProduct)
            {
                applied = false;

                nettotalText.Text = (double.Parse(nettotalText.Text.Replace(" DA", "")) - 
                    double.Parse(cart.SelectedRows[0].Cells[7].Value.ToString())).ToString("F2") + " DA";
                int index = cart.SelectedRows[0].Index;

                try
                {
                    CartTable.Rows.RemoveAt(index);
                }
                catch (Exception)
                {

                }


                if (!prodIsNew)
                {
                    OldSaleLines[index] = null;
                }
                NewTotal=double.Parse(nettotalText.Text.Replace(" DA",""));

                 saleTotal.Text = Total.ToString("F2") + " DA";

                cart.DataSource = CartTable;


            }
            
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            UpdateBillStatus(false);
            MessageBoxer.showGeneralMsg("Vente sauvegardée");


        }

        private void SupprimerProd_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (applied)
            {
                decimal qt = 0;
                string prodID = BillLines.SelectedRows[0].Cells[2].Value.ToString();

                if (!string.IsNullOrEmpty(BillLines.SelectedRows[0].Cells[4].Value.ToString()))
                {

                    qt = decimal.Parse(BillLines.SelectedRows[0].Cells[4].Value.ToString());
                }
                if (BillLines.SelectedRows.Count > 0)
                {
                    if (BillLines.Rows.Count-1 == 1)
                    {
                        DialogResult result = MessageBox.Show("La vente va être supprimée. Veuillez cliquer sur oui pour continuer ou aller vers modification", "",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            RemoveProduct removeProduct = new RemoveProduct(prodID, qt, saleRef.Text.Trim());
                            removeProduct.modif = false;
                            removeProduct.modifNew = false;
                            removeProduct.Removed += Removed;


                            removeProduct.ShowDialog();
                        }
                    }
                    else
                    {
                        RemoveProduct removeProduct = new RemoveProduct(prodID, qt, saleRef.Text.Trim());
                        removeProduct.modif = false;
                        removeProduct.modifNew = false;
                        removeProduct.Removed += Removed;


                        removeProduct.ShowDialog();
                    }

                   
                    
                }
                else
                {
                    MessageBoxer.showGeneralMsg("Sélectionnez d'abord une ligne");
                } 
            }
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)

            {
                SelectedTable = "emballage";
            }
            else
            {
                SelectedTable = "produits";
            }
        }

        public static bool DeletedBill { get; set; }
        private void iconButton1_Click(object sender, EventArgs e)
        {

            if ((guna2TabControl1.SelectedTab.Name != "Modification" || applied ))
            {
                Bill bill = new Bill();

                bill.Type = sale.Type;
                bill.TotalRemise = (double)sale.RemiseTotal;
                bill.TotalTTC =(applied)?double.Parse(saleTotal.Text.Replace(" DA","")):(double)sale.TotalHT;
                bill.MontantRegler = (applied) ? double.Parse(saleTotal.Text.Replace(" DA", "")) :(double)sale.MontantRegler;
                bill.MontantRest =  (applied) ? 0: (double)(sale.MontantRest);
                bill.DateA = DateTime.Parse(sale.Date);
                bill.N = (exe)?newID: sale.N;



                GeneratePdf(BillLines.Rows.Count>1?BillLines:cart, bill);
            }
            else 
            {
                MessageBoxer.showGeneralMsg("Veuillez appliquer votre modification avant d'imprimer le rapport");
            }

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    

private void guna2TabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if(e.TabPage.Name != "Actuelle")
            {
                if (!SaleRefString.Contains("T"))
                {
                    SaveBtn.Enabled = false;
                }
                applied = saleRef.Text.Contains("T")?false:true;
                dataLoader.RunWorkerAsync();
                DataTable cartTable = (DataTable)BillLines.DataSource;
                cart.DataSource =cartTable;

            }
        }
    }
}