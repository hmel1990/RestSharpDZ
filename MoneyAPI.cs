using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace RestSharpDZ
{
    public class MoneyAPI
    {
        private readonly RestClient client;
        public readonly List<string> moneyList = new List<string> {"USD", "EUR", "GBP"};

        public MoneyAPI(string baseUrl)
        {
            client = new RestClient(baseUrl);
        }

        public async Task<List<MoneyJSON>?> GetMoneyRatesAsync()
        {
            var moneyRate = new List<MoneyJSON>();
            var today = DateTime.Now.ToString("yyyyMMdd");
                       
            foreach (var money in moneyList)
            {
                var request = new RestRequest("NBUStatService/v1/statdirectory/exchange", Method.Get);
                request.AddParameter("valcode", money);

                request.AddParameter("date", today);

                request.AddParameter("json", string.Empty);
                
                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    try
                    {
                        var moneyResponse = JsonConvert.DeserializeObject<List<MoneyJSON>>(response.Content ?? "");
                        if (moneyResponse != null)
                        {
                            moneyRate.AddRange(moneyResponse);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка парсинга JSON: {ex.Message}", Color.Red);
                        Console.WriteLine("Ответ сервера:");
                        Console.WriteLine(response.Content);
                    }
                }
                else
                {
                    Console.WriteLine($"Ошибка запроса: {response.StatusCode} - {response.StatusDescription}", Color.Red);
                    Console.WriteLine("Ответ сервера:");
                    Console.WriteLine(response.Content);
                }
            }

            return moneyRate;
        }


    }
}

