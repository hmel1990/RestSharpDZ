namespace RestSharpDZ
{

    internal class Program
    {
        static async Task Main(string[] args)
        {
            var moneyAPI = new MoneyAPI("https://bank.gov.ua/");
            var moneyRates = await moneyAPI.GetMoneyRatesAsync();
            int i = 0;
            foreach (var rate in moneyRates)
            {
                Console.WriteLine($" Курс {moneyAPI.moneyList[i]} на {rate} грн ");
                i++;
            }
        }
    }
}
