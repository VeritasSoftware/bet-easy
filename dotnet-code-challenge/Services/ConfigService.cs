using Microsoft.Extensions.Configuration;
using System.IO;

namespace dotnet_code_challenge
{
    public interface IConfigService
    {
        AppSettings Settings { get; set; }
    }

    /// <summary>
    /// Config Service: Read data file paths from appsettings.json
    /// </summary>
    public class ConfigService : IConfigService
    {
        public AppSettings Settings { get; set; }

        public ConfigService()
        {
            var builder = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            this.ReadConfig(configuration);
        }

        private void ReadConfig(IConfiguration configuration)
        {
            this.Settings = new AppSettings();
            configuration.Bind("Settings", this.Settings);
        }
    }
}
