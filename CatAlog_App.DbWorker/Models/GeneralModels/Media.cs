using CatAlog_App.DbWorker.Models.VideoModels;
using System.Collections.Generic;

namespace CatAlog_App.DbWorker.Models.GeneralModels
{
    public class Media
    {
        public int Id { get; set; }

        public float? Size { get; set; }

        public int MainRecordDataId { get; set; }
        public MainRecordData MainRecordData { get; set; }

        public IEnumerable<AudioData> AudioData { get; set; }

        public IEnumerable<SubtitleData> SubtitleData { get; set; }

        public IEnumerable<VideoData> VideoData { get; set; }
    }
}
