using DevExpress.XtraEditors;
using Guna.UI2.WinForms;
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
using System.Windows.Forms.DataVisualization.Charting;
using System.Text.RegularExpressions;
using static DevExpress.Utils.MVVM.Internal.ILReader;
using static DevExpress.Utils.Svg.CommonSvgImages;
using System.Data.SQLite;
using System.Threading;
using DevExpress.Utils.Behaviors;
using DevExpress.XtraBars.Docking.Helpers;

namespace Aromapp
{
    public partial class Products : DevExpress.XtraEditors.XtraUserControl
    {

        BackgroundWorker worker = new BackgroundWorker();
        BackgroundWorker TTVPWorker;
        BackgroundWorker VPJWorker;
        List<string> prodIDs = new List<string>();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        bool searching = false, tableFull = false;
        public static int EtiqNumber { get; set; }

      

        public Products()
        {
            InitializeComponent();
            this.Load += Produits_Shown;
            types.SelectedIndex = 0;
            timer.Interval = 100;
            timer.Tick += TimerTick;

            ProductsTable.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            ProductsTable.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(255, 64, 64, 64),
                Font = new System.Drawing.Font("Calibri", 9.25f)
            };

            ProductsTable.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(63, 81, 181),
                Font = new System.Drawing.Font("Calibri", 9.25f, FontStyle.Bold)
            };

            if (string.IsNullOrWhiteSpace(Nouveautés.Text))
            {
                Nouveautés.Text = "Nouveautés";
            }
            if (string.IsNullOrWhiteSpace(types.Text))
            {
                types.Text = "Type";

            }
            worker.DoWork += loadData;
            worker.RunWorkerCompleted += loadingCompleted;

        }

        private void search_TextChanged(object sender, EventArgs e)
        {

        }

        public void SetupCharts()
        {
            searching = false;

            TVPP.Series.Clear();
            Series series;
            series = new Series("Total de ventes");
            TVPP.Series.Add(series);
            TVPP.ChartAreas[0].AxisY.Title = "Total en DZD";
            TVPP.ChartAreas[0].AxisX.Title = "Nom de produit";
            TVPP.ChartAreas[0].AxisY.Interval = 1000;
            TVPP.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            TVPP.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            TVPP.ChartAreas[0].AxisX.TitleForeColor = Color.White;
            TVPP.ChartAreas[0].AxisY.TitleForeColor = Color.White;
            TVPP.ChartAreas[0].BackColor = Color.Black;
            TVPP.Series["Total de ventes"].IsVisibleInLegend = false;
            TVPP.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
            TVPP.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;
            TVPP.BackColor = Color.Black;



            VPJ.Series.Clear();

            Series series1 = new Series();
            series1.IsVisibleInLegend = false;
            series1.ChartType = SeriesChartType.Line;
            series1.BorderWidth = 4;
            VPJ.Series.Add(series1);

            VPJ.ChartAreas[0].AxisY.Interval = 1000;

            VPJ.ChartAreas[0].AxisY.Title = "Total en DZD";
            VPJ.ChartAreas[0].AxisX.Title = "Date";
            VPJ.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            VPJ.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            VPJ.ChartAreas[0].AxisX.TitleForeColor = Color.White;
            VPJ.ChartAreas[0].AxisY.TitleForeColor = Color.White;
            VPJ.ChartAreas[0].BackColor = Color.Black;
            VPJ.BackColor = Color.Black;
            VPJ.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
            VPJ.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;

            TVPP.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            VPJ.ChartAreas[0].AxisX.LabelStyle.Angle = -90;

        }

        string[] names ;
        double[] totals;
        DataTable table = new DataTable();
        Dictionary<string, double> salesByDate;
        int limit = 100, currentPage = 1;
        private void Produits_Load(object sender, EventArgs e)
        {

        }

        void loadData(object sender, DoWorkEventArgs e)
        {



            using (DBHelper helper = new DBHelper())
            {

                table = helper.selectAllProducts(limit, currentPage);

            }

        }
        public double MaxTotal(Dictionary<string, double> total)
        {
            double max = 0;

            foreach (var t in total)
            {
                if (t.Value > max)
                {
                    max = t.Value;
                }
            }


            return max;
        }
        void loadingCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            ProductsTable.Invoke((Action)(() => {

                ProductsTable.DataSource = table;

            }));


            TTVPWorker = new BackgroundWorker();

            TTVPWorker.DoWork += TTVPWorkerloadData;
            TTVPWorker.RunWorkerCompleted += TTVPWorkerloadingCompleted;

            TTVPWorker.RunWorkerAsync();

        }

        public void ProductAdded(object sender, EventArgs e)
        {


        }
        private void Ajouter_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.OnProductAdded += ProductAdded;
            addProduct.ShowDialog();
        }

        private void Products_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Nouveautés_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Nouveautés.Text))
            {
                Nouveautés.Text = "Nouveautés";

            }
        }

        public void iconButton1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(System.Windows.Forms.Cursor.Position.X,
                System.Windows.Forms.Cursor.Position.Y);

        }
        FileStream fileStream;
        public void GeneratePdf(DataTable gridTable)
        {
            string fontPath = Environment.CurrentDirectory + "\\arabicFont.ttf";

            DataTable grid = gridTable;
            grid.Columns.RemoveAt(4);

            PdfPTable table = new PdfPTable(grid.Columns.Count - 1);
            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            string pattern = @"\p{IsArabic}";

            PdfPCell pdfPCell = null;
            Chunk glue = new Chunk(new VerticalPositionMark());

            Document document = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
            document.SetMargins(20f, 20f, 20f, 20f);

            string id = Guid.NewGuid().ToString();
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\fichier_BA" + id + ".pdf";
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Sauvegarder le fichier PDF";
                saveFileDialog.FileName = "fichier_BA" + id + ".pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;


                }
            }

            fileStream = new FileStream(path, FileMode.Create);
            PdfWriter writer;


            writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, fileStream); // sometime rise exception on first call


            document.Open();

            table.WidthPercentage = 100;
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            iTextSharp.text.Font FS = FontFactory.GetFont("Calibri", 12, iTextSharp.text.Font.BOLD,
            BaseColor.BLACK);

            Information Storeinfo = DBHelper.GetStoreInformation();

            iTextSharp.text.Font SmallFS = FontFactory.GetFont("Calibri", 10, iTextSharp.text.Font.NORMAL,
            BaseColor.BLACK);

            PdfPTable title = new PdfPTable(1);

            Phrase titleYeah = new Phrase(" بيت العود و العطور الفاخرة",
                new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
            PdfPCell Titlecell = new PdfPCell(titleYeah);

            Titlecell.HorizontalAlignment = Element.ALIGN_CENTER;
            Titlecell.BorderWidthBottom = 0f;
            Titlecell.BorderWidthLeft = 0f;
            Titlecell.BorderWidthTop = 0f;
            Titlecell.BorderWidthRight = 0f;


            title.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            title.HorizontalAlignment = Element.ALIGN_CENTER;
            title.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            title.AddCell(Titlecell);
            document.Add(title);

            iTextSharp.text.Image picture = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "\\Logo.png");

            picture.ScaleToFit(80f, 80f);
            picture.Alignment = Element.ALIGN_CENTER;
            picture.SpacingAfter = 1;

            document.Add(picture);

            document.Add(new Phrase("Adresse: " + Storeinfo.Adresse, SmallFS));
            document.Add(new iTextSharp.text.Paragraph("\n"));
            document.Add(new Phrase("Tel: " + Storeinfo.Tel, SmallFS));
            document.Add(new iTextSharp.text.Paragraph("\n"));
            document.Add(new Phrase("Email: " + Storeinfo.Email, SmallFS));
            document.Add(new iTextSharp.text.Paragraph("\n"));

            iTextSharp.text.Paragraph lineSeparator = new iTextSharp.text.Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator
                    (0.0F, 100.0F, BaseColor.BLACK,
                    Element.ALIGN_LEFT, 1)));

            document.Add(lineSeparator);

            document.Add(new iTextSharp.text.Paragraph(""));
       
            PdfPTable titlePhrase = new PdfPTable(1);

            Phrase storeNamePhrase = new Phrase("قائمة أسعار العطور بالجملة",
                new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
            Phrase storeNameSub = new Phrase("أقل كمية 100غ, سعر الكيلو غرام يختلف عن سعر 100غ \n\n الشحن متوفر إلى كل الولايات",
                new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
            Paragraph p = new Paragraph(storeNamePhrase);

            p.Alignment = Element.ALIGN_CENTER;

            PdfPCell cell = new PdfPCell(storeNamePhrase);
            PdfPCell cellSub = new PdfPCell(storeNameSub);

            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BorderWidthBottom = 0f;
            cell.BorderWidthLeft = 0f;
            cell.BorderWidthTop = 0f;
            cell.BorderWidthRight = 0f;
            cellSub.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSub.BorderWidthBottom = 0f;
            cellSub.BorderWidthLeft = 0f;
            cellSub.BorderWidthTop = 0f;
            cellSub.BorderWidthRight = 0f;

            titlePhrase.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            titlePhrase.HorizontalAlignment = Element.ALIGN_CENTER;
            titlePhrase.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            titlePhrase.AddCell(cell);
            titlePhrase.AddCell(cellSub);



            document.Add(titlePhrase);

            document.Add(lineSeparator);



            document.Add(new iTextSharp.text.Paragraph("\n"));

            //table.SetWidths(new float[] { 20f, 150f, 100f});

            #region Write table


         

            foreach (DataColumn header in grid.Columns)
            {

                if (grid.Columns.IndexOf(header) == 6)
                {
                    continue;
                }
                if (grid.Columns.IndexOf(header) == 4)
                {
                    header.ColumnName = "Prix 100 g/DA";
                }
<<<<<<< HEAD
                if (grid.Columns.IndexOf(header) == 5)
=======
                if (grid.Columns.IndexOf(header) == 4)
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409
                {
                    header.ColumnName = "Prix 1 KG/DA";
                }

                pdfPCell = new PdfPCell(new Phrase(header.ColumnName, FS));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.Padding = 6f;
                table.AddCell(pdfPCell);

            }

            FS = FontFactory.GetFont("Calibri", 10,
        BaseColor.BLACK);
            foreach (DataRow row in grid.Rows)
            {
                

                if (double.Parse(row[6].ToString()) <= 0)
                {
                    continue;
                }

                for (int i = 0; i<grid.Columns.Count; i++)
                {
                    if (i == 6)
                    {
                        continue;
                    }
                    if (row[i]!= null)
                    {

                        if (Regex.IsMatch(row[i].ToString(), pattern))
                        {

                            Phrase ph = new Phrase(row[i].ToString(),
                                new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));

                            
                            pdfPCell = new PdfPCell(ph);
                            pdfPCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                        }
                        else
                        {
                            pdfPCell = new PdfPCell(new Phrase(row[i].ToString(), FS));

                        }

                    }
                    else
                    {

                        pdfPCell = new PdfPCell(new Phrase("Non disponible", FS));

                    }
                    pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    pdfPCell.Padding = 6f;

                    table.AddCell(pdfPCell);

                }
            }

            #endregion


            document.Add(new iTextSharp.text.Paragraph(""));



            document.Add(table);

            document.Add(new iTextSharp.text.Paragraph("\n"));

            document.Add(new Phrase("Le: " + DateTime.Now, FS));

            document.Add(lineSeparator);

            document.Add(new iTextSharp.text.Paragraph("\n"));


            document.Close();







        }

        public void GenerateNamesPDF(Dictionary<string, string> names,bool onlyOne)
        {
            PdfPTable table = new PdfPTable(2);
            PdfPCell pdfPCell = null;
            string pattern = @"\p{IsArabic}";

            Chunk glue = new Chunk(new VerticalPositionMark());
            Document document = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
            document.SetMargins(20f, 20f, 20f, 20f);

            string id = Guid.NewGuid().ToString();
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\fichier_BA" + id + ".pdf";
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Save PDF File";
                saveFileDialog.FileName = "fichier_BA" + id + ".pdf"; // Default file name

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file name and save the PDF file
                    path = saveFileDialog.FileName;


                }
            }

            fileStream = new FileStream(path, FileMode.Create);
            PdfWriter writer;

            writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, fileStream); // sometime rise exception on first call

            document.Open();

            table.WidthPercentage = 100;
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            iTextSharp.text.Font FS = FontFactory.GetFont("Calibri", 11, iTextSharp.text.Font.BOLD,
            BaseColor.BLACK);

            if (onlyOne)
            {
                for (int i =1;i<=EtiqNumber;i++)
                {
                    Phrase phrase = new Phrase();
<<<<<<< HEAD
                    string key = ProductsTable.SelectedRows[0].Cells[3].Value.ToString();
=======
                    string key = ProductsTable.SelectedRows[0].Cells[0].Value.ToString();
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409
                    string value =ProductsTable.SelectedRows[0].Cells[1].Value.ToString();



                if (Regex.IsMatch(value, pattern))
                    {
                        string fontPath = Environment.CurrentDirectory + "\\arabicFont.ttf";

                        BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);


<<<<<<< HEAD
                        phrase.Add(new Chunk(value + "\n\n", font));
                        phrase.Add(new Chunk("(" + key + ")", FS));
=======
                        phrase.Add(new Chunk(value, font));
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409


                        pdfPCell = new PdfPCell(phrase);
                        pdfPCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;


                    }
                    else
                    {
<<<<<<< HEAD
                        phrase.Add(new Chunk(value + "\n\n", FS));
                        phrase.Add(new Chunk("("+key+")",FS));

=======
                        phrase.Add(new Chunk(value , FS));


>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409
                        pdfPCell = new PdfPCell(phrase);
                        pdfPCell.RunDirection = PdfWriter.RUN_DIRECTION_LTR;
                    }

                    pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
<<<<<<< HEAD
                    pdfPCell.PaddingBottom = 15f;
                    pdfPCell.PaddingTop= 15f;

                    if (i==EtiqNumber && i % 2 != 0)
                    {

                        table.AddCell(pdfPCell);
                        pdfPCell = new PdfPCell(new Phrase("", FS));

=======
                    pdfPCell.Padding = 15f;
                    if (i==EtiqNumber && i % 2 != 0)
                    {

                        table.AddCell(pdfPCell);
                        pdfPCell = new PdfPCell(new Phrase("", FS));

>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409
                        pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPCell.Padding = 10f;

                        table.AddCell(pdfPCell);

                        break;


                    }
                    else
                    {
                        table.AddCell(pdfPCell);

                    }
                }
            }
            else
            {
                foreach (var name in names)
                {
                    Phrase phrase = new Phrase();





                    if (Regex.IsMatch(name.Value.ToString(), pattern))
                    {
                        string fontPath = Environment.CurrentDirectory + "\\arabicFont.ttf";

                        BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);


                        phrase.Add(new Chunk(name.Value + "\n\n", font));
                        phrase.Add(new Chunk(name.Key));


                        pdfPCell = new PdfPCell(phrase);
                        pdfPCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;


                    }
                    else
                    {
                        phrase.Add(new Chunk(name.Value + "\n\n", FS));
                        phrase.Add(new Chunk(name.Key));


                        pdfPCell = new PdfPCell(phrase);
                        pdfPCell.RunDirection = PdfWriter.RUN_DIRECTION_LTR;
                    }

                    pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    pdfPCell.Padding = 15f;
                    if (name.Value == names.Values.Last() && names.Values.Count % 2 != 0)
                    {

                        table.AddCell(pdfPCell);
                        pdfPCell = new PdfPCell(new Phrase("", FS));

                        pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPCell.Padding = 10f;

                        table.AddCell(pdfPCell);

                        break;


                    }
                    else
                    {
                        table.AddCell(pdfPCell);

                    }
                }
            }
            

            document.Add(table);
            document.Close();


        }

        private void Nouveautés_SelectedIndexChanged(object sender, EventArgs e)
        {
            int duration = 0;
            searching = true;
            switch (Nouveautés.SelectedIndex)
            {
                case 0:
                    duration = 7;
                    break;
                case 1:
                    duration = 10;
                    break;
                case 2:
                    duration = 30;
                    break;
            }

            using (DBHelper helper = new DBHelper())
            {
                ProductsTable.DataSource = helper.GetNewestProducts(duration);

            }

        }

        private void Bon_Click(object sender, EventArgs e)
        {
            if (Bon.Checked == true)
            {
                ProductsTable.SelectAll();

            }
            else
            {
                ProductsTable.ClearSelection();

            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (ProductsTable.SelectedRows.Count > 0)
            {
                Dictionary<string, string> names = new Dictionary<string, string>();

                for (int i = ProductsTable.SelectedRows.Count - 1; i >= 0; i--)
                {

                    if (ProductsTable.SelectedRows[i].Cells[1].Value != null)
                    {
                        names.Add(ProductsTable.SelectedRows[i].Cells[0].Value.ToString(),
                            ProductsTable.SelectedRows[i].Cells[1].Value.ToString());
                    }
                    else
                    {

                        break;
                    }
                }
                GenerateNamesPDF(names,false);

            }
            else
            {

            }
        }

        private void types_SelectedIndexChanged(object sender, EventArgs e)
        {
            searching = true;
                     

            if (types.SelectedItem.ToString().Trim() == "Emballage"||
                types.SelectedItem.ToString().Trim() == "Sachet")
            {
                SelectedTable = "emballage";

                DataTable table = new DataTable();

                string q = "SELECT c_prd as Référence,[Nom],[Unit],[Type],[Prix_VenteHT] as " +
                    "'Prix en Detail',[PrixVGros] as 'Prix en Gros',prix_achat 'Prix d''achat', [Q_Stock] as 'Disponible'" +
                    "  FROM Emballage order by c_prd asc;";

                
                    using(SQLiteDataAdapter cmd = new SQLiteDataAdapter(q, DBHelper.connectionString))
                    {
                        cmd.Fill(table);

                    }
                

                ProductsTable.DataSource = table; 

                return;
            }
            SelectedTable = "produits";

            using (DBHelper helper = new DBHelper())
            {

                switch (types.SelectedIndex)
                {

                    case 0:
                        ProductsTable.DataSource = helper.GetProductByType("%%", 100, 1);
                        break;
                    default:
                        ProductsTable.DataSource = helper.GetProductByType(types.SelectedItem.ToString().Trim(), 100, 1);

                        break;
                }
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            try
            {
                SetupCharts();

            }
            catch (IndexOutOfRangeException)
            {

            }           
            searching = false;
            tableFull = false;
            currentPage = 1;

            types.Text = "Type";
            Nouveautés.Text = "Nouveautés";

            if (Bon.Checked)
            {
                Bon.Checked = false;
            }

            using (DBHelper helper = new DBHelper())
            {

                ProductsTable.DataSource = helper.selectAllProducts(limit, 1);

                names = helper.GetTopSoldProductsNames();
                totals = helper.GetTopSoldProductsTotals();

                salesByDate = helper.GetTopSoldProductsByDate();


            }

            if ((VPJ.ChartAreas[0].AxisY.Interval / MaxTotal(salesByDate)) < 10)
            {
                VPJ.ChartAreas[0].AxisY.Interval = VPJ.ChartAreas[0].AxisY.Interval * 10;
            }


            if (salesByDate != null && salesByDate.Count>0) 
               
                {
                    foreach (var val in salesByDate)
                    {
                        VPJ.Series[0].Points.AddXY(val.Key.Replace("00:00:00", ""), val.Value);

                    } 
                }

            if (totals!=null && totals.Length> 0)
            {
                foreach (var point in VPJ.Series[0].Points)
                {
                    point.Color = Color.LightSteelBlue;
                }
                if ((TVPP.ChartAreas[0].AxisY.Interval / totals[0]) < 10)
                {
                    TVPP.ChartAreas[0].AxisY.Interval = TVPP.ChartAreas[0].AxisY.Interval * 10;
                }

            }

            if (names != null)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    TVPP.Series["Total de ventes"].Points.AddXY(names[i], totals[i]);

                }

            }

            foreach (var point in TVPP.Series[0].Points)
            {
                point.Color = Color.LightSteelBlue;
            }

        }

        private void search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchText.Text))
            {
                HintUtils.ShowHint(searchText);
                searching = false;
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            HintUtils.HideHint(searchText);
        }

        private void search_KeyDown(object sender, KeyEventArgs e)
        {

            
                if (e.KeyCode == Keys.Enter)
                {
                    Search();
                    searching = true;

                e.SuppressKeyPress = true;

                  }



        }
        string SelectedTable = "produits";

        public void Search()
        {
            using (DBHelper helper = new DBHelper())
            {
                if (searchText.Text != searchText.Tag.ToString())
                {
                    ProductsTable.DataSource = helper.searchForProduct(SelectedTable,searchText.Text.ToLower());

                }
            }
        }
        private void search_IconRightClick(object sender, EventArgs e)
        {
            Search();
        }

        private void Products_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            contextMenuStrip2.Show(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y);

        }

        private void Produits_Shown(object sender, EventArgs e)
        {
            TVPP.Invoke((Action)(() => {

                SetupCharts();

            }));

            timer.Start();

        }
        void TTVPWorkerloadData(object sender, DoWorkEventArgs e)
        {

            using (DBHelper helper = new DBHelper())
            {
                names = helper.GetTopSoldProductsNames();
                totals = helper.GetTopSoldProductsTotals();
            }

        }
        void TTVPWorkerloadingCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (names!=null)
            {
                if ((TVPP.ChartAreas[0].AxisY.Interval / totals[0]) < 10)
                {
                    TVPP.ChartAreas[0].AxisY.Interval = TVPP.ChartAreas[0].AxisY.Interval * 10;
                }
                for (int i = 0; i < names.Length; i++)
                {
                    TVPP.Series["Total de ventes"].Points.AddXY(names[i], totals[i]);

                }

                foreach (var point in TVPP.Series[0].Points)
                {
                    point.Color = Color.LightSteelBlue;
                }

                VPJWorker = new BackgroundWorker();

                VPJWorker.DoWork += VPJWorkerloadData;
                VPJWorker.RunWorkerCompleted += VPJWorkerloadingCompleted;

                VPJWorker.RunWorkerAsync(); 
            }
        }
        void VPJWorkerloadData(object sender, DoWorkEventArgs e)
        {

            using (DBHelper helper = new DBHelper())
            {
                //TotalQuantité = helper.GetTopSoldProductsTotalQT();
                salesByDate = helper.GetTopSoldProductsByDate();
            }
        }
        void VPJWorkerloadingCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (salesByDate!=null)
            {
                if ((VPJ.ChartAreas[0].AxisY.Interval / MaxTotal(salesByDate)) < 10)
                {
                    VPJ.ChartAreas[0].AxisY.Interval = VPJ.ChartAreas[0].AxisY.Interval * 10;
                }


                foreach (var val in salesByDate)
                {
                    VPJ.Series[0].Points.AddXY(val.Key.Replace("00:00:00", ""), val.Value);

                }

                foreach (var point in VPJ.Series[0].Points)
                {
                    point.Color = Color.LightSteelBlue;
                } 
            }
        }

        int x = 1;

        private void Products_Scroll(object sender, ScrollEventArgs e)
        {
            int totalHeight = 0;

            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
            {
                foreach (DataGridViewRow row in ProductsTable.Rows)
                    totalHeight += row.Height;

                if (!searching)
                {

                    if (ProductsTable.VerticalScrollingOffset == 0 && e.NewValue < e.OldValue)
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

                    if (totalHeight - ProductsTable.Height < ProductsTable.VerticalScrollingOffset)
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

        private void REF_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ProductsTable.SelectedRows.Count; i++)
            {
                if (ProductsTable.SelectedRows[i].Cells[0].Value != null)
                {
                    prodIDs.Add(ProductsTable.SelectedRows[i].Cells[0].Value.ToString());

                }
            }

            if (prodIDs.Count >= 1)
            {
                DialogResult result = MessageBox.Show("  Êtes vous sûr ?", ""
                                      , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {


                    using (DBHelper helper = new DBHelper())
                    {
                        if (helper.DeleteProducts(prodIDs) > 0)
                        {
                            if (prodIDs.Count > 1)
                            {
                                MessageBoxer.showGeneralMsg("Produits supprimés");
                                prodIDs.Clear();
                                iconButton4_Click(sender, e);

                            }
                            else
                            {
                                MessageBoxer.showGeneralMsg("Produit supprimé");

                            }
                        }
                    }

                }
            }
            else
            {
                MessageBoxer.showGeneralMsg("Selectionnez au moins une ligne");

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void VPJ_Click(object sender, EventArgs e)
        {

        }

        private void ProductsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchText_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void TVPP_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tousLesProduitsToolStripMenuItem_Click(object sender, EventArgs e)
        {


            DataTable table;
            using (DBHelper helper = new DBHelper())
            {
                table = helper.selectAllProducts(10000, 1);

                GeneratePdf(table);

                MessageBox.Show("Fichier généré", "Terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           




        }

        private void seulementLaListeVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {

                DataTable table = ((DataTable)(ProductsTable.DataSource)).Copy();
                GeneratePdf(table); 
            }

        }

        private void detailsSurLeProduitToolStripMenuItem_Click(object sender, EventArgs e)
        {
                string id = ProductsTable.SelectedRows[0].Cells[0].Value.ToString(),
        name = ProductsTable.SelectedRows[0].Cells[1].Value.ToString(),
        priceP = ProductsTable.SelectedRows[0].Cells[7].Value.ToString(),
        priceSD = ProductsTable.SelectedRows[0].Cells[4].Value.ToString(),
        priceSG = ProductsTable.SelectedRows[0].Cells[5].Value.ToString(),
        q_stock = ProductsTable.SelectedRows[0].Cells[6].Value.ToString(),
        type = ProductsTable.SelectedRows[0].Cells[3].Value.ToString(),
        unit = ProductsTable.SelectedRows[0].Cells[2].Value.ToString();

                Product product = new Product()
                {
                    ID = id,
                    Name = name,
                    PriceD = double.Parse(priceSD),
                    PriceG = double.Parse(priceSG),
                    Quantity = double.Parse(q_stock),
                    Type = type,
                    Unit = unit,
                    PriceP = double.Parse(priceP)
                };

                ProdView prodView = new ProdView(product);
                prodView.ShowDialog();
        }

        void EtiquetteCanceled(object sender, EventArgs e)
        {
            Etiquette.Close();
        }
        void EtiquettePrint(object sender, EventArgs e)
        {
            Dictionary<string, string> names = new Dictionary<string, string>();

           
                names.Add(ProductsTable.SelectedRows[0].Cells[0].Value.ToString(),
                                            ProductsTable.SelectedRows[0].Cells[1].Value.ToString());
<<<<<<< HEAD

=======
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409
            
            GenerateNamesPDF(names,true);
            Etiquette.Close();


        }
        etiquette Etiquette;
        private void imprimerDesÉtiquettesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Etiquette = new etiquette();
            Etiquette.Canceled += EtiquetteCanceled;
            Etiquette.Print += EtiquettePrint;
            Etiquette.ShowDialog();
        }

        public void AddTable(int currentPage)
        {
            BindingSource bindingSource = new BindingSource();
            using (DBHelper helper = new DBHelper())
            {
                table = helper.selectAllProducts(limit, currentPage);

            }
            bindingSource.DataSource = table;
            ProductsTable.DataSource = bindingSource;
        }

        void TimerTick(object sender, EventArgs e)
        {
            x++;
            if (x == 5)
            {
                worker.RunWorkerAsync();
                timer.Stop();
            }
        }
    }
}
