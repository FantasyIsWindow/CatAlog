using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;
using System.Collections.Generic;

namespace CatAlog_App.Db.DbContexts.DbModels.VideoModels
{
    public class SerialData
    {
        public int Id { get; set; }

        public int MainRecordDataId { get; set; }
        public MainRecordData MainRecordData { get; set; }

        public IEnumerable<EpisodeData> Episodes { get; set; }

        public int? SeasonNumber { get; set; }

        public string Type { get; set; }

        public int? CountSpecials { get; set; }

        public string Note { get; set; }
    }
}
