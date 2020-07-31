using CatAlog_App.DbWorker.Models.GeneralModels;

namespace CatAlog_App.DbWorker.Models.VideoModels
{
    public class AudioData
    {
        public int Id { get; set; }

        public int MediaId { get; set; }
        public Media Media { get; set; }


        public string AudioFormat { get; set; }

        public string Language { get; set; }

        public string Channel { get; set; }

        public float? Frequency { get; set; }

        public float? Bitrate { get; set; }

        public string Author { get; set; }

        public string Note { get; set; }
    }
}
