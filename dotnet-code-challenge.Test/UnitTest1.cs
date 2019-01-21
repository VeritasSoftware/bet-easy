using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Xunit;

namespace dotnet_code_challenge.Test
{
    using dotnet_code_challenge;

    public class UnitTest1
    {
        private ServiceProvider serviceProvider;

        static ServiceProvider AddDependencyInjection()
        {
            //Setup Dependency Injection
            return new ServiceCollection()
                            .AddSingleton<IConfigService, ConfigService>()
                            .AddScoped<IManagerService, ManagerService>()
                         .BuildServiceProvider();
        }

        public UnitTest1()
        {
            this.serviceProvider = AddDependencyInjection();
        }

        [Fact]
        public void Test_Caulfield_Pass()
        {
            var manager = this.serviceProvider.GetRequiredService<IManagerService>();

            var results = manager.GetCaulfieldInfo();

            Assert.True(results.Count() == 2);

            var firstHorse = results.First();
            var lastHorse = results.Last();

            Assert.True(firstHorse.HorseName == "Advancing" && firstHorse.Price == 4.2);
            Assert.True(lastHorse.HorseName == "Coronel" && lastHorse.Price == 12);
        }

        [Fact]
        public void Test_Wolferhampton_Pass()
        {
            var manager = this.serviceProvider.GetRequiredService<IManagerService>();

            var results = manager.GetWolferhamptonInfo();

            Assert.True(results.Count() == 2);

            var firstHorse = results.First();
            var lastHorse = results.Last();

            Assert.True(firstHorse.HorseName == "Fikhaar" && firstHorse.Price == 4.4);
            Assert.True(lastHorse.HorseName == "Toolatetodelegate" && lastHorse.Price == 10);
        }
    }
}
