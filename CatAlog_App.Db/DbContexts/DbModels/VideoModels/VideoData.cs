using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;

namespace CatAlog_App.Db.DbContexts.DbModels.VideoModels
{
    public class VideoData
    {
        public int Id { get; set; }

        public int MediaId { get; set; }
        public Media Media { get; set; }

        public string VideoQuality { get; set; }

        public float? Bitrate { get; set; }

        public string Relation { get; set; }

        public int ResolutionHeigth { get; set; }

        public int ResolutionWidth { get; set; }

        public float? FrameRate { get; set; }

        public string VideoFormat { get; set; }

        public string Note { get; set; }
    }
}
