using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Todos_los_items_del_Indec
{
    public partial class Form1 : Form
    {

        public PDFPath PDFPath = new PDFPath();

        public TXTPath TXTPath = new TXTPath();

        string[] items;

        StreamReader ReadLines;

        public Form1()
        {
            InitializeComponent();
        }

        private void bttnPDFpath_Click(object sender, EventArgs e)
        {
            PDFPath.GetPath();
            textBoxPDFPath.Text = PDFPath.FilePath;

            if(!string.IsNullOrWhiteSpace(textBoxPDFPath.Text))
            {
                bttnFirstPage.Enabled = true;
            }
            else
            {
                MessageBox.Show("No selecciono ningun archivo!!!!");
            }
        }

        private void bttnFirstPage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(maskedFirstPage.Text))
            {
                PDFPath.FirstPage = int.Parse(maskedFirstPage.Text);
                bttnLastPage.Enabled = true;
                bttnFirstPage.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe Ingresar un valor!!!!");
            }
        }

        private void bttnLastPage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(maskedLastPage.Text))
            {
                PDFPath.LastPage = int.Parse(maskedLastPage.Text);
                bttnLastPage.Enabled= false;
                bttnTXT.Enabled = true;
            }
            else
            {
                MessageBox.Show("Debe Ingresar un valor!!!!");
            }
        }

        int contador = 0;

        public void WalkBox(int IdItem, string referencia, int NumContador, EItems name)
        {
            if (items[IdItem] == referencia && contador == NumContador && items.Length > 2)
            {
                int a = items.Length - 1;
                CurrentMonthForm(name, 0, a);
                contador++;
            }
        }

        private void bttnTXT_Click(object sender, EventArgs e)
        {
            TXTPath.ArchivePath = TXTPath.SaveFileTXT();
            textBoxTXTPath.Text = TXTPath.ArchivePath;
            bttnTXT.Enabled = false;

            var pdfDocument = new PdfDocument(new PdfReader(textBoxPDFPath.Text));
            var strategy = new LocationTextExtractionStrategy();
            PDFPath.Text = string.Empty;
            StreamWriter file = new StreamWriter(TXTPath.Archive, true);

            for(int i = 1; i<= pdfDocument.GetNumberOfPages(); i++)
            {
                if(PDFPath.FirstPage == i && PDFPath.LastPage >= i)
                {
                    var Page = pdfDocument.GetPage(PDFPath.FirstPage++);
                    PDFPath.Text = PdfTextExtractor.GetTextFromPage(Page);
                    file.Write(PDFPath.Text);
                    Debug.Write(PDFPath.Text);
                }
            }

            file.Close();
            file.Dispose();

            dataGridView1.ColumnCount = 3; //asigno el numero de columnas
            dataGridView1.Columns[0].HeaderText = "Insumos"; //agrego titulo a la columna 0
            dataGridView1.Columns[1].HeaderText = "mes anterior"; //aca se agrega en la columna 2 el mes anterior
            dataGridView1.Columns[2].HeaderText = "mes actual"; //aca se agrega en la columna 3 el mes actual

            string[] lines = File.ReadAllLines(textBoxTXTPath.Text);
            using(StreamWriter writer = new StreamWriter(TXTPath.ArchivePath))
            {
                foreach(string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        writer.WriteLine(line);
                    }
                }
            }

            ReadLines = File.OpenText(textBoxTXTPath.Text);
            
            for (int i = 1; i < lines.Length; i++)
            {
                WalkLine(i);
                if (TXTPath.LineNumber == i)
                {

                    //Cuadro 1
                    WalkBox(0, "e)", 0, EItems.Productos_quimicos);
                    WalkBox(0, "i)", 1, EItems.Moteres_electricos_y_equipos_de_aire_acondicionado);
                    WalkBox(0, "k)", 2, EItems.Asfaltos_combustibles_y_lubricantes);
                    WalkBox(0, "t)", 3, EItems.Medidores_de_caudal);
                    WalkBox(0, "w)", 4, EItems.Membrana_impermeabilizante);
                    WalkBox(0, "j)", 5, EItems.Equipo_amortizacion_de_equipo);

                    //
                    //cuadro 2
                    //primera pagina del cuadro 2

                    WalkBox(1, "42120-1", 6, EItems.Aberturas_de_aluminio);
                    WalkBox(2, "42120-2", 7, EItems.Aberturas_de_chapa_de_hierro);
                    

                }
            }

        }

        public void CurrentMonthForm(EItems Item, int PreviousMonthPosition, int CurrentMonthPosition)
        {
            dataGridView1.Rows.Add(Item, 0, items[CurrentMonthPosition]);
        }

        public void Parsear()
        {
            items = TXTPath.Line.Split(' '); //asignamos que el separador es el espacio vacio
            items = items.ToList().Where(x => !string.IsNullOrEmpty(x)).ToArray(); //esto sirve para indicar que todo espacio vacio extra no nos moleste
            int i = 0;
            Debug.WriteLine(TXTPath.Line); //aca esbrico en el debug cada linea del archivo de texto
            dataGridView1.AllowUserToAddRows = false;

            //while (i < items.Length)
            //{
            //    Debug.WriteLine("[" + items[i] + "]"); //aca escribo en el debug como se ve parseado mostrando las separaciones con corchetes
            //    i++;
            //}
            
        }

        public void WalkLine(int lineNumber)
        {
            while (!ReadLines.EndOfStream)
            {
                TXTPath.Line = ReadLines.ReadLine();

                if(++TXTPath.LineNumber == lineNumber)
                {
                    Parsear();
                    break;
                }
            }
        }

    }
}
