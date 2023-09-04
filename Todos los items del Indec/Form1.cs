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
            //lines = lines.ToList().Where(x => !string.IsNullOrEmpty(x)).ToArray();
            ReadLines = File.OpenText(textBoxTXTPath.Text);
            for (int i = 1; i < lines.Length; i++)
            {
                WalkLine(i);
                if (TXTPath.LineNumber == i)
                {

                    switch (items[0])
                    {
                        case "e)":
                            int a = items.Length - 1;
                            CurrentMonthForm(EItems.Productos_quimicos, 0, a);
                            break;
                        case "i)":
                            int ab = items.Length - 1;
                            CurrentMonthForm(EItems.Moteres_electricos_y_equipos_de_aire_acondicionado, 0, ab);
                            break;
                        case "k)":
                            int ac = items.Length - 1;
                            CurrentMonthForm(EItems.Asfaltos_combustibles_y_lubricantes, 0, ac);
                            break;
                        case "t)":
                            int ad = items.Length - 1;
                            CurrentMonthForm(EItems.Medidores_de_caudal, 0, ad);
                            break;
                        case "w)":
                            int ae = items.Length - 1;
                            CurrentMonthForm(EItems.Membrana_impermeabilizante, 0, ae);
                            break;
                        case "j)":
                            int af = items.Length - 1;
                            CurrentMonthForm(EItems.Equipo_amortizacion_de_equipo, 0, af);
                            break;
                    }

                    /*if (items[0] == "e)")
                    {
                        int a = items.Length - 1;
                        CurrentMonthForm(EItems.Productos_quimicos, 0, a);
                        
                    }
                    if (items[0] == "i)")
                    {
                        int a = items.Length - 1;
                        CurrentMonthForm(EItems.Moteres_electricos_y_equipos_de_aire_acondicionado, 0, a);
                    }
                    if (items[0] == "k)")
                    {
                        int a = items.Length - 1;
                        CurrentMonthForm(EItems.Asfaltos_combustibles_y_lubricantes, 0, a);
                    }
                    if (items[0] == "t)")
                    {
                        int a = items.Length - 1;
                        CurrentMonthForm(EItems.Medidores_de_caudal, 0, a);
                    }
                    if (items[0] == "w)")
                    {
                        int a = items.Length - 1;
                        CurrentMonthForm(EItems.Membrana_impermeabilizante, 0, a);
                    }
                    if (items[0] == "j)")
                    {
                        int a = items.Length - 1;
                        CurrentMonthForm(EItems.Equipo_amortizacion_de_equipo, 0, a);
                    }
                    if (items.Length > 2 && items[2] == "42120-1")
                    {
                        int a = lines.Length - 1;
                       CurrentMonthForm(EItems.Equipo_amortizacion_de_equipo, 0, a);
                    }*/
                    
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
