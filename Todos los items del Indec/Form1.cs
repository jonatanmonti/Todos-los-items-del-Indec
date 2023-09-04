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

            string[] lines = File.ReadAllLines(textBoxTXTPath.Text);
            ReadLines = File.OpenText(textBoxTXTPath.Text);

            for (int i = 1; i<lines.Length; i++)
            {
                WalkLine(i);
            }

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
