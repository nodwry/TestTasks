using System.IO;
using System.Threading.Tasks;
using TestTasks.InternationalTradeTask;
using TestTasks.VowelCounting;
using TestTasks.WeatherFromAPI;

namespace TestTasks;

class Program
{
    static async Task Main()
    {
        //Below are examples of usage. However, it is not guaranteed that your implementation will be tested on those examples.            
        var stringProcessor = new StringProcessor();
        var str = File.ReadAllText("./StringExample.txt");
        stringProcessor.GetCharCount(str, ['l', 'r', 'm']);

        var commodityRepository = new CommodityRepository();
        commodityRepository.GetImportTariff("Natural honey");
        commodityRepository.GetExportTariff("Iron/steel scrap not sorted or graded");            

        var weatherManager = new WeatherManager();
        await weatherManager.CompareWeather("dubai,ae", "lviv,ua", 4);
    }
}