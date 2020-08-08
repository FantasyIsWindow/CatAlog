using CatAlog_App.Db.DbContexts.DbModels.VideoModels;
using System.Collections.Generic;

namespace CatAlog_App.Db.DbContexts.DbModels.GeneralModels
{
    public class Media
    {
        public uint Id { get; set; }

        public float? Size { get; set; }

        public uint MainRecordDataId { get; set; }
        public MainRecordData MainRecordData { get; set; }

        public IEnumerable<VideoData> VideoData { get; set; }

        public IEnumerable<AudioData> AudioData { get; set; }

        public IEnumerable<SubtitleData> SubtitleData { get; set; }
    }
}
