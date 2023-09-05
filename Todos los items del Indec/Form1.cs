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
using System.Linq.Expressions;
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

            try
            {
                PDFPath.GetPath();
                textBoxPDFPath.Text = PDFPath.FilePath;

                if (!string.IsNullOrWhiteSpace(textBoxPDFPath.Text))
                {
                    bttnFirstPage.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No selecciono ningun archivo!!!!");
                }
            }
            catch
            {
                MessageBox.Show("Tenes que seleccionar el archivo correcto!!!");
                //throw new Exception(message:"Tenes que seleccionar el archivo correcto!!");
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
            if(items.Length > 5)
            {
                if (items[IdItem] == referencia && contador == NumContador)
                {
                    int a = items.Length - 1;
                    CurrentMonthForm(name, 0, a);
                    contador++;
                }
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

            dataGridView1.ColumnCount = 3; 
            dataGridView1.Columns[0].HeaderText = "Insumos";
            dataGridView1.Columns[1].HeaderText = "mes anterior";
            dataGridView1.Columns[2].HeaderText = "mes actual";

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
                    //
                    //Box 1
                    //
                    WalkBox(0, "e)", 0, EItems.Productos_químicos);
                    WalkBox(0, "i)", 1, EItems.Moteres_eléctricos_y_equipos_de_aire_acondicionado);
                    WalkBox(0, "k)", 2, EItems.Asfaltos_combustibles_y_lubricantes);
                    WalkBox(0, "t)", 3, EItems.Medidores_de_caudal);
                    WalkBox(0, "w)", 4, EItems.Membrana_impermeabilizante);
                    WalkBox(0, "j)", 5, EItems.Equipo_amortización_de_equipo);

                    //
                    //Box 2
                    //First Page box 2

                    WalkBox(1, "42120-1", 6, EItems.Aberturas_de_aluminio);
                    WalkBox(2, "42120-2", 7, EItems.Aberturas_de_chapa_de_hierro);
                    WalkBox(1, "37910-1", 8, EItems.Abrasivos);
                    WalkBox(1, "42921-4", 9, EItems.Abrazaderas);
                    WalkBox(1, "44251-1", 10, EItems.Accesorio_para_máquinas_herramientas);
                    WalkBox(1, "42922-1", 11, EItems.Accesorios_para_herramientas);
                    WalkBox(1, "33380-1", 12, EItems.Aceites_lubricantes);
                    WalkBox(1, "49229-1", 13, EItems.Acoplados);
                    WalkBox(1, "46420-1", 14, EItems.Acumuladores_eléctricos);
                    WalkBox(2, "41263-1", 15, EItems.Alambres_de_acero);
                    WalkBox(2, "41241-1", 16, EItems.Alambres_de_hierro);
                    WalkBox(2, "44216-1", 17, EItems.Amoladoras);
                    WalkBox(2, "15400-1", 18, EItems.Arcillas);
                    WalkBox(1, "15310-1", 19, EItems.Arenas);
                    WalkBox(2, "37210-1", 20, EItems.Artefactos_sanitarios);
                    WalkBox(2, "37540-2", 21, EItems.Artículos_pretensados);
                    WalkBox(1, "49113-1", 22, EItems.Automóviles);
                    WalkBox(1, "36270-1", 23, EItems.Autopartes_de_goma);
                    WalkBox(1, "46539-1", 24, EItems.Balastos);
                    WalkBox(1, "37370-1", 25, EItems.Baldosas_cerámicas);
                    WalkBox(1, "35110-4", 26, EItems.Barnices_y_protectores_para_madera);
                    WalkBox(2, "41261-1", 27, EItems.Barras_de_hierro_y_acero);
                    WalkBox(1, "36490-6", 28, EItems.Bolsas_de_plástico);
                    WalkBox(1, "42944-1", 29, EItems.Bulones);
                    WalkBox(1, "42320-1", 30, EItems.Calderas_de_gas_y_fuel_oil);
                    WalkBox(1, "37420-1", 31, EItems.Cales);
                    WalkBox(2, "49115-2", 32, EItems.Camiones_y_sus_chasis);
                    WalkBox(2, "36320-3", 33, EItems.Caños_y_tubos_de_polietileno);
                    WalkBox(2, "36320-2", 34, EItems.Caños_y_tubos_de_polipropileno);
                    WalkBox(1, "36320-1", 35, EItems.Caños_y_tubos_de_PVC);
                    WalkBox(1, "46220-1", 36, EItems.Capacitores_electrolíticos);
                    WalkBox(2, "34800-1", 37, EItems.Cauchos_sintéticos);
                    WalkBox(1, "37440-1", 38, EItems.Cemento_portland);
                    WalkBox(1, "42992-1", 39, EItems.Cerraduras);
                    WalkBox(1, "42999-2", 40, EItems.Chapas_metálicas);
                    WalkBox(2, "42944-2", 41, EItems.Clavos);
                    WalkBox(1, "43230-1", 42, EItems.Compresores_y_sus_repuestos);

                    //
                    //
                    //Second page box 2

                    WalkBox(1, "46340-1", 43, EItems.Conductores_eléctricos);
                    WalkBox(2, "36270-2", 44, EItems.Correas_de_goma_con_refuerzo_textil);
                    WalkBox(1, "42190-2", 45, EItems.Cortinas_de_aluminio);
                    WalkBox(2, "36990-2", 46, EItems.Cortinas_de_enrollar_de_PVC);
                    WalkBox(2, "31600-1", 47, EItems.Cortinas_de_madera);
                    WalkBox(1, "32600-1", 48, EItems.Cuadernos_y_blocks);
                    WalkBox(2, "36111-3", 49, EItems.Cubiertas_agrícolas);
                    WalkBox(2, "36111-2", 50, EItems.Cubiertas_convencionales);
                    WalkBox(2, "36111-1", 51, EItems.Cubiertas_radiales);
                    WalkBox(1, "42921-1", 52, EItems.Cucharas_de_albañil);
                    WalkBox(2, "34800-2", 53, EItems.Dispresiones_de_caucho_pegamentos);
                    WalkBox(1, "49129-1", 54, EItems.Elásticos_para_autos);
                    WalkBox(1, "43220-1", 55, EItems.Electrobombas);
                    WalkBox(1, "35110-1", 56, EItems.Enduído_para_paredes);
                    WalkBox(1, "17100-1", 57, EItems.Energía_eléctrica);
                    WalkBox(1, "49129-3", 58, EItems.Equipos_de_transmisión);
                    WalkBox(1, "35110-2", 59, EItems.Esmaltes_sintéticos);
                    WalkBox(1, "37129-1", 60, EItems.Fibras_minerales);
                    WalkBox(1, "36490-4", 61, EItems.Film_de_polietileno);
                    WalkBox(1, "33370-1", 62, EItems.Fuel_oil);
                    WalkBox(1, "12020-1", 63, EItems.Gas);
                    WalkBox(1, "33360-1", 64, EItems.Gas_oil);
                    WalkBox(1, "33410-1", 65, EItems.Gases_de_refinería_butano_propano);
                    WalkBox(2, "42911-1", 66, EItems.Grifería);
                    WalkBox(2, "46113-1", 67, EItems.Grupos_electrógenos);
                    WalkBox(1, "42921-2", 68, EItems.Herramientas_de_mano);
                    WalkBox(1, "37990-1", 69, EItems.Hidrógufos);
                    WalkBox(1, "41242-1", 70, EItems.Hierros_redondos);
                    WalkBox(1, "37510-1", 71, EItems.Hormigón);
                    WalkBox(1, "44440-1", 72, EItems.Hormigoneras);
                    WalkBox(1, "35110-5", 73, EItems.Impermeabilizantes);
                    WalkBox(1, "46212-1", 74, EItems.Interruptores_eléctricos);
                    WalkBox(2, "33340-1", 75, EItems.Kerosene);
                    WalkBox(1, "37350-1", 76, EItems.Ladrillos_huecos);
                    WalkBox(1, "37320-1", 77, EItems.Ladrillos_refractarios);
                    WalkBox(1, "41532-11", 78, EItems.Lingotes_de_aluminio_y_sus_aleaciones);
                    WalkBox(1, "41532-1", 79, EItems.Lingotes_y_perfiles_de_aluminio_y_sus_aleaciones);
                    WalkBox(1, "31430-1", 80, EItems.Maderas_aglomeradas);
                    WalkBox(1, "31100-1", 81, EItems.Maderas_aserradas);

                    //
                    //
                    //Third page box 2



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
