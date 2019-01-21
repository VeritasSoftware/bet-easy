using System.Collections.Generic;
using System.IO;

namespace dotnet_code_challenge
{
    using Models;
    using System.Linq;

    public class HorsePrice
    {
        public string HorseName { get; set; }

        public double Price { get; set; }
    }

    public interface IManagerService
    {
        IEnumerable<HorsePrice> GetCaulfieldInfo();

        IEnumerable<HorsePrice> GetWolferhamptonInfo();
    }

    public class ManagerService : IManagerService
    {
        IConfigService configService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configService">The injected config service</param>
        public ManagerService(IConfigService configService)
        {
            this.configService = configService;
        }

        /// <summary>
        /// Get Caulfield Info
        /// </summary>
        /// <returns><see cref="IEnumerable{HorsePrice}"/></returns>
        public IEnumerable<HorsePrice> GetCaulfieldInfo()
        {
            string fileName = configService.Settings["Caulfield"].Path;

            string xmlString = File.ReadAllText(fileName);

            var meeting = xmlString.ParseXML<Meeting>();                        

            //LINQ query to get horse names by ascending price
            var result = meeting.Races.Race.Horses.Horse.Join(
                                    meeting.Races.Race.Prices.Price.Horses.Horse,
                                    h => h.Number, h => h._Number,
                                    (h, h1) => new HorsePrice { HorseName = h.Name, Price = double.Parse(h1.Price) })
                                .OrderBy(h => h.Price);

            return result;
        }

        /// <summary>
        /// Get Wolferhampton Info
        /// </summary>
        /// <returns><see cref="IEnumerable{HorsePrice}"/></returns>
        public IEnumerable<HorsePrice> GetWolferhamptonInfo()
        {
            string fileName = configService.Settings["Wolferhampton"].Path;

            string jsonString = File.ReadAllText(fileName);

            var meeting = jsonString.ParseJSON<WolferhamptonMeeting>();

            var selections = meeting.RawData.Markets.SelectMany(x => x.Selections);

            //LINQ query to get horse names by ascending price
            var result = selections.Select(s => new HorsePrice { HorseName = s.Tags.name, Price = s.Price })
                                   .OrderBy(h => h.Price);            

            return result;
        }
    }
}
