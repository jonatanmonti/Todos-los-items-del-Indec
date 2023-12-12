using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Todos_los_items_del_Indec
{
    class PDFTXTExtraction
    {
        Dictionary<string, string> descriptionDictionaryCuadro1 = new Dictionary<string, string>();
        Dictionary<string, string> descriptionDictionaryCuadro5 = new Dictionary<string, string>();
        Dictionary<string, string> descriptionDictionaryCuadro7 = new Dictionary<string, string>();
        Dictionary<string, string> descriptionDictionaryCuadro8 = new Dictionary<string, string>();

        SetdictionaryCuadro1();
        SetdictionaryCuadro5();
        SetdictionaryCuadro7();
        SetdictionaryCuadro8();

        List<ICuadro> listOfCuadros = new List<ICuadro>();
        public int cuadroNumber = 0; // en español poprque representa la palabra "cuadro"
        public DateTime periodToExtract;

        void Main()
        {
            Cuadro0 cuadro0Action = new Cuadro0();
            listOfCuadros.Add(cuadro0Action);
            Cuadro1 cuadro1Action = new Cuadro1();
            listOfCuadros.Add(cuadro1Action);
            Cuadro2 cuadro2Action = new Cuadro2();
            listOfCuadros.Add(cuadro2Action);
            Cuadro3 cuadro3Action = new Cuadro3();
            listOfCuadros.Add(cuadro3Action);
            Cuadro4 cuadro4Action = new Cuadro4();
            listOfCuadros.Add(cuadro4Action);
            Cuadro5 cuadro5Action = new Cuadro5();
            listOfCuadros.Add(cuadro5Action);
            Cuadro6 cuadro6Action = new Cuadro6();
            listOfCuadros.Add(cuadro6Action);
            Cuadro7 cuadro7Action = new Cuadro7();
            listOfCuadros.Add(cuadro7Action);
            Cuadro8 cuadro8Action = new Cuadro8();
            listOfCuadros.Add(cuadro8Action);
            Cuadro9 cuadro9Action = new Cuadro9();
            listOfCuadros.Add(cuadro9Action);
            Cuadro10 cuadro10Action = new Cuadro10();
            listOfCuadros.Add(cuadro10Action);
            Cuadro11 cuadro11Action = new Cuadro11();
            listOfCuadros.Add(cuadro11Action);
            Cuadro12 cuadro12Action = new Cuadro12();
            listOfCuadros.Add(cuadro12Action);
            Cuadro13 cuadro13Action = new Cuadro13();
            listOfCuadros.Add(cuadro13Action);

            ExtractValuesTxt();
        }

        void ExtractValuesTxt()
        {
            cuadroNumber = 0;
            try
            {
                string filePath = "ruta/del/archivo.txt";
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (ValidateNextCuadroIsContained(line))
                    {
                        cuadroNumber++;
                        continue;
                    }

                    if (ValidateCondition(line))
                    {
                        string[] stringSplitedBySpace = line.Split(' ');
                        if (stringSplitedBySpace.Length > 0)
                        {
                            string priceIndexId = GetIdRegisterInGrid();
                            string LastValue = stringSplitedBySpace[stringSplitedBySpace.Length - 1];

                            // jony aqui este valor y el priceIndex al cual se le debe insertar en-
                            // registro del ID correspondiente. del mes que se indico al inicio del programa.
                            // insertar en la grilla.

                            //PostNewPriceIndexValue(/*    xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx    */);
                        }
                        continue;
                    }
                    continue;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        bool ValidateNextCuadroIsContained(string line)
        {
            string nextCuadro = "cuadro " + (cuadroNumber + 1).ToString();
            return line.Contains(nextCuadro);
        }

        bool ValidateCondition(string line)
        {
            return listOfCuadros[cuadroNumber].ExecuteValidation(line);
        }

        public async Task PostNewPriceIndexValue(int priceIndexId, PriceIndex priceIndex, string priod, double value, int replacementIndexId, PriceIndex replacementIndex)
        {
            string apiUrl = "https://ppo.obraspublicas.gob.ar/REST/api/works/PriceIndex/PriceIndexValue";
            string apiKey = "abcdefg";

            using (HttpClient client = new HttpClient())
                client.DefaultRequestHeaders.Add("API-Key", apiKey);

            PriceIndexValue bodyRequest = new PriceIndexValue
            {
                /*  priceIndexId = //XXXXX,
                  priceIndex = //XXXXX
                  {
                      id = //XXXXX,
                      cpcCode = //XXXXX,
                      description = "//XXXXX",
                      values = //XXXXX
                  },
                  period = "//XXXXX",
                  value = //XXXXX,
                  replacementIndexId = //XXXXX,
                  replacementIndex = //XXXXX
                  {
                      id = //XXXXX,
                      cpcCode = //XXXXX,
                      description = "//XXXXX",
                      values = //XXXXX
                  }*/
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(bodyRequest), Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                Console.WriteLine($"Status Code: {response.StatusCode}");
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    PriceIndexValue responsePriceIndexValue = JsonSerializer.Deserialize<PriceIndexValue>(jsonResponse);

                    Console.WriteLine($"ID: {responsePriceIndexValue.id}");
                    Console.WriteLine($"PriceIndexID: {responsePriceIndexValue.priceIndexId}");
                    Console.WriteLine($"Period: {responsePriceIndexValue.period}");
                    Console.WriteLine($"Value: {responsePriceIndexValue.value}");
                    Console.WriteLine($"ReplacementIndexID: {responsePriceIndexValue.replacementIndexId}");
                }
                else
                {
                    Console.WriteLine($"Error en la solicitud. Código de estado: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void SetDictionaryCuadro1()
        {
            descriptionDictionaryCuadro1.Add("e)", "Productos químicos");
            descriptionDictionaryCuadro1.Add("i)", "Motores eléctricos y equipos de aire acondicionado");
            descriptionDictionaryCuadro1.Add("k)", "Asfaltos,combustibles y lubricantes");
            descriptionDictionaryCuadro1.Add("t)", "Medidores de caudal");
            descriptionDictionaryCuadro1.Add("w)", "Membrana impermeabilizante");
            descriptionDictionaryCuadro1.Add("j)", "Equipo-Amortización de equipo");
        }

        public void SetDictionaryCuadro5()
        {
            descriptionDictionaryCuadro5.Add("a)", "Mano de obra");
            descriptionDictionaryCuadro5.Add("b)", "Albañilería");
            descriptionDictionaryCuadro5.Add("d)", "Carpinterías");
            descriptionDictionaryCuadro5.Add("f)", "Andamios (2)");
            descriptionDictionaryCuadro5.Add("g)", "Artefactos de iluminación y cableado");
            descriptionDictionaryCuadro5.Add("h)", "Caños de PVC para instalaciones varias");
            descriptionDictionaryCuadro5.Add("p)", "Gastos generales");
            descriptionDictionaryCuadro5.Add("r)", "Artefactos para baño y grifería");
            descriptionDictionaryCuadro5.Add("s)", "Hormigón");
            descriptionDictionaryCuadro5.Add("u)", "Válvulas de bronce");
            descriptionDictionaryCuadro5.Add("v)", "Electrobombas");
        }

        public void SetDictionaryCuadro7()
        {
            descriptionDictionaryCuadro7.Add("NoCpcCode1", "Mano de obra");
            descriptionDictionaryCuadro7.Add("Mano de obra asalariada", "Mano de obra asalariada");
            descriptionDictionaryCuadro7.Add("(en albañilería y homi-", "Mano de obra directa (en albañilería y homigón armado)");
            descriptionDictionaryCuadro7.Add("Subcontratos de mano", "Subcontratos de mano de obra");
        }

        public void SetDictionaryCuadro8()
        {
            descriptionDictionaryCuadro8.Add("unique", "Yesería (incluye: mano de obra de subcontrato de yesería y sus materiales intervinientes para dicho ítem");
        }
    }
}

public interface ICuadro
{
    bool ExecuteValidation(string line);
    string GetIdRegisterInGrid();  // bool?
}

public class Cuadro0 : ICuadro { }

public class Cuadro1 : ICuadro
{
    public bool ExecuteValidation(string line)
    {
        return line.Trim().Length > 1 && char.IsLetter(line[0]) && line[1] == ')';
    }

    void SetIdRegisterInGrid()
    {
        // se utiliza la lista:  "descriptionDictionaryCuadro1" para mapear-
        // la descripcion con la lista y su ID ,para poder cargarlo en la grilla en su registro correspondiente.
    }
}

public class Cuadro2 : ICuadro
{
    public bool ExecuteValidation(string line)
    {
        return true; //set other logic;
    }
}

public class Cuadro3 : ICuadro
{
    public bool ExecuteValidation(string line)
    {
        return true; //set other logic;
    }
}

public class Cuadro4 : ICuadro
{
    string description1 = "Pisos y revestimientos";
    string description2 = "Aceros-Hierro aletado";
    string description3 = "Cemento";
    string description4 = "Arena";


    public bool ExecuteValidation(string line)
    {


        return true; //revisar retorno;
    }
}

public class Cuadro5 : ICuadro
{
    public bool ExecuteValidation(string line)
    {
        return line.Trim().Length > 1 && char.IsLetter(line[0]) && line[1] == ')';
    }

    void SetIdRegisterInGrid()
    {
        // se utiliza la lista:  "descriptionDictionaryCuadro5" para mapear con-
        // la descripcion en la lista y su obtener ID ,para poder cargarlo en la grilla en su registro correspondiente.
    }
}

public class Cuadro6 : ICuadro
{
    public bool ExecuteValidation(string line)
    {
        return true; //set other logic;
    }
}

public class Cuadro7 : ICuadro
{

    public bool ExecuteValidation(string line)
    {
        if (line.Contains("Mano de obra asalariada") || line.Contains("Mano de obra") || line.Contains("(en albañilería y homi")) ;
        {
            return true;
        }

        if (line.Contains("Subcontratos de mano"))
        {
            // devolver false pero el proximo registro es True si o si sin importar validaciones
            return false;
        }
    }

    SetIdRegisterInGrid()
    {
        // revisar si stringSplitedBySpace[0] es un string, y en caso de serlo , mapear con el modelo para ver si es un registro valido-
        // de haber coincidencia se busca el id y se inserta en la grilla.
    }
}

public class Cuadro8 : ICuadro
{
    public bool ExecuteValidation(string line)
    {
        return line.Contains("100,0");
    }

    string GetIdRegisterInGrid()
    {
        return "abc"; // el id del priceIndex del cuadro 8
    }
}

public class Cuadro9 : ICuadro
{
    public bool ExecuteValidation(string line)
    {
        return true; //set other logic;
    }
}

public class Cuadro10 : ICuadro
{
    public bool ExecuteValidation(string line)
    {
        return true; //set other logic;
    }
}

public class Cuadro11 : ICuadro
{
    public bool ExecuteValidation(string line)
    {
        return true; //set other logic;
    }
}

public class Cuadro12 : ICuadro
{
    public bool ExecuteValidation(string line)
    {
        return true; //set other logic;
    }
}

public class Cuadro13 : ICuadro
{
    public bool ExecuteValidation(string line)
    {
        return true; //set other logic;
    }
}