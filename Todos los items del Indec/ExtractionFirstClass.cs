using System;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Todos_los_items_del_Indec
{
    public class SemesterDbPriceINdexValue
    {
        //Consulta para traer los valores del semestre anterior al mes brindado del objeto solicitado.
        public int periodToConsult;
        //A cambiar
        int month = 02;
        int year = 2023;


        async Task PostApiPriceIndexValueSearch()
        {


            string apiUrl = "https://ppo.obraspublicas.gob.ar/REST/api/works/PriceIndex/PriceIndexValue/search";
            string apiKey = "abcdefg";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("API-Key", apiKey);
                List<string> previousMonths = GetPreviousMonths(month, year);
    

                string priceIndexValueSolicitudeList = ConvertToStringPriceIndexValueSolicitudeList(previousMonths);

                StringContent content = new StringContent(JsonConvert.SerializeObject(priceIndexValueSolicitudeList), Encoding.UTF8, "application/json");
                try
                {
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        List<PriceIndexValue> priceIndexValueDeserializedArray = JsonSerializer.Deserialize<List<PriceIndexValue>>(jsonResponse);

                        ShowInGridValuesOfSemester(priceIndexValueDeserializedArray);
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

            List<string> GetPreviousMonths(int month, int year)
            {
                List<string> previousMonths = new List<string>();

                for (int i = 0; i < 6; i++)
                {
                    DateTime previousDate = new DateTime(year, month, 1).AddMonths(-i);
                    // Formatear la fecha como "mes/año" y agregar a la lista
                    previousMonths.Add(previousDate.ToString("MM/yyyy"));
                }
                return previousMonths;
            }

            List<PriceIndexValueSolicitude> ConvertToStringPriceIndexValueSolicitudeList(List<string> previousMonths)
            {
                List<PriceIndexValueSolicitude> priceIndexValuesSolicitude = new List<PriceIndexValueSolicitude>();

                foreach (var month in previousMonths)
                {
                    PriceIndexValueSolicitude indexValue = new PriceIndexValueSolicitude
                    {
                        period = month
                    };
                    priceIndexValuesSolicitude.Add(indexValue);
                }
                return priceIndexValuesSolicitude;
            }

            //aqui Mockearemos

            void ShowInGridValuesOfSemester(List<PriceIndexValue> priceIndexValueDeserializedArray)
            {
                foreach (var priceIndexValue in priceIndexValueDeserializedArray)
                {
                    int priceIndexId = priceIndexValue.priceIndex.id;
                    string period = priceIndexValue.period; //  enero 2023
                    double value = priceIndexValue.value;    //  1500

                    // Jony, aqui buscar en la grilla el campo que se debe impactar y alli mostrar el valor de      "double value = priceIndexValue.value;"
                }
            }
        }
    }

    public class PriceIndexValueSolicitude
    {
        public string period { get; set; } //date-time
    }

    public class PriceIndexValue
    {

        public int id { get; set; }
        public int priceIndexId { get; set; }
        public PriceIndex priceIndex { get; set; }
        public string period { get; set; } //date-time
        public double value { get; set; }
        public int replacementIndexId { get; set; }
        public PriceIndex replacementIndex { get; set; }
    }

    public class PriceIndex
    {
        public int id { get; set; }
        public int cpcCode { get; set; }
        public string description { get; set; }
        public PriceIndexValue values { get; set; }
    }
}