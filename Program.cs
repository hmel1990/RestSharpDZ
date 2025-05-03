namespace RestSharpDZ
{

    internal class Program
    {
        static async Task Main(string[] args)
        {
            var moneyAPI = new MoneyAPI("https://bank.gov.ua/");
            var moneyRates = await moneyAPI.GetMoneyRatesAsync();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            foreach (var rate in moneyRates)
            {
                Console.WriteLine(rate);
            }
        }
    }
}
