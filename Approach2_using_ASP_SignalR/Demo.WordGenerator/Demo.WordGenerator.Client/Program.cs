using System;
using System.Threading.Tasks;
using Demo.WordGenerator.Client.Hubs;

namespace Demo.WordGenerator.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var hub = new WordGeneratorHub();
            var result = await hub.ConnectAsync();
            Console.WriteLine($"Connected - {result}");

            if (result)
            {
                await hub.AddWordAsync("Test1");
                await hub.AddWordAsync("Test2");
                await hub.AddWordAsync("Test3");
                await hub.AddWordAsync("Test4");
                await hub.AddWordAsync("Test5");
                await hub.AddWordAsync("Test6");
                await hub.AddWordAsync("Test7");
                await hub.AddWordAsync("Test8");
                await hub.AddWordAsync("Test9");
                await hub.AddWordAsync("Test10");

                await hub.StartAsync();
            }

            Console.ReadKey();
        }
    }
}
