using CatAlog_App.DbWorker.Models.GeneralModels;
using System.Collections.Generic;

namespace CatAlog_App.DbWorker.Models.VideoModels
{
    public class SerialData
    {
        public int Id { get; set; }

        public int AdditionallyDataId { get; set; }
        public AdditionallyData AdditionallyData { get; set; }

        public IEnumerable<EpisodeData> Series { get; set; }

        public int? SeasonNumber { get; set; }

        public string Type { get; set; }

        public int? CountSpecials { get; set; }

        public string Note { get; set; }
    }
}
