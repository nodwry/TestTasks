using System;
using System.IO;
using System.Threading.Tasks;
using TestTasks.InternationalTradeTask;
using TestTasks.VowelCounting;
using TestTasks.WeatherFromAPI;

namespace TestTasks
{
    class Program
    {
        static async Task Main()
        {
            //Below are examples of usage. However, it is not guaranteed that your implementation will be tested on those examples.            
            var stringProcessor = new StringProcessor();
            string str = File.ReadAllText("/Users/elenakalistova/Desktop/repos/TestTasks/TestTasks/CharCounting/StringExample.txt");
            var charCount = stringProcessor.GetCharCount(str, new char[] { 'l', 'r', 'm' });

            var commodityRepository = new CommodityRepository();
            var result1 = commodityRepository.GetImportTariff("Natural honey");
            var result2 = commodityRepository.GetExportTariff("Iron/steel scrap not sorted or graded");            

            var weatherManager = new WeatherManager();
            var comparisonResult = await weatherManager.CompareWeather("dubai,ae", "lviv,ua", 4);
            Console.WriteLine(comparisonResult);
        }
    }
}
