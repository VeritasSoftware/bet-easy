using System.Collections.Generic;
using System.Linq;

namespace dotnet_code_challenge
{
    public class AppSettings
    {
        public List<DataSource> DataSources { get; set; }

        public DataSource this[string name]
        {
            get { return DataSources.Single(x => x.Name == name); }
        }
    }

    public class DataSource
    {
        public string Name { get; set; }

        public string Path { get; set; }
    }
}
