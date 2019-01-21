using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_code_challenge
{
    class Program
    {        
        static ServiceProvider AddDependencyInjection()
        {
            //Setup Dependency Injection
            return new ServiceCollection()
                            .AddSingleton<IConfigService, ConfigService>()
                            .AddScoped<IManagerService, ManagerService>()
                         .BuildServiceProvider();
        }

        static void Print(IEnumerable<HorsePrice> horsePrices)
        {
            horsePrices.ToList().ForEach(horse =>
            {
                Console.WriteLine(horse.HorseName + "\t" + horse.Price);
            });
        }

        static void Main(string[] args)
        {
            try
            {
                var serviceProvider = AddDependencyInjection();

                Console.WriteLine("Hello World!");

                Console.WriteLine("Horse names in price ascending order...");
                Console.WriteLine(Environment.NewLine);

                Console.WriteLine("Caulfield...");
                Console.WriteLine(Environment.NewLine);

                var manager = serviceProvider.GetRequiredService<IManagerService>();

                var horsePrices = manager.GetCaulfieldInfo();

                Print(horsePrices);

                Console.WriteLine(Environment.NewLine);

                Console.WriteLine("Wolferhampton...");
                Console.WriteLine(Environment.NewLine);

                horsePrices = manager.GetWolferhamptonInfo();

                Print(horsePrices);

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }            
        }
    }
}
