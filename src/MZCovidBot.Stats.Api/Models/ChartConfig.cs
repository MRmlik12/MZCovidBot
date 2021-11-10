using System.Collections.Generic;

namespace MZCovidBot.Stats.Api.Models
{
    public class ChartConfig
    {
        public string Type { get; set; }
        public ChartData Data { get; set; }
        
        public class ChartData
        {
            public List<string> Labels { get; set; }
            public List<DataSet> DataSets { get; set; }
            
            public class DataSet
            {
                public string Label { get; set; }
                public List<long> Data { get; set; }
            }
        }
    }
}