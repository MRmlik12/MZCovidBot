using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MZCovidBot.Stats.Api.Models
{
    public class LatestCovidStats
    { 
        public long Infected { get; set; }
        public long Deceased { get; set; }
        public long Recovered { get; set; }
        public long DailyInfected { get; set; }
        public long DailyTested { get; set; }
        public long DailyPositiveTests { get; set; }
        public long DailyDeceased { get; set; }
        public long DailyRecovered { get; set; }
        public long DailyQuarantine { get; set; }
        public string TxtDate { get; set; }
        public DateTimeOffset LastUpdatedAtApify { get; set; }
        public DateTimeOffset LastUpdatedAtSource { get; set; }
        public string Country { get; set; }
        public Uri SourceUrl { get; set; }
        public Uri HistoryData { get; set; }
        public Uri ReadMe { get; set; }
    }
}