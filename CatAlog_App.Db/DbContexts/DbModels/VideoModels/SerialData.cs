using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;
using System.Collections.Generic;

namespace CatAlog_App.Db.DbContexts.DbModels.VideoModels
{
    public class SerialData
    {
        public uint Id { get; set; }

        public uint MainRecordDataId { get; set; }
        public MainRecordData MainRecordData { get; set; }

        public IEnumerable<EpisodeData> Episodes { get; set; }

        public byte? SeasonNumber { get; set; }

        public string Type { get; set; }

        public byte? CountSpecials { get; set; }

        public string Note { get; set; }
    }
}
