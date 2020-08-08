using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;

namespace CatAlog_App.Db.DbContexts.DbModels.VideoModels
{
    public class SubtitleData
    {
        public uint Id { get; set; }

        public uint MediaId { get; set; }
        public Media Media { get; set; }

        public string Language { get; set; }

        public string Author { get; set; }

        public string SubtitleFormat { get; set; }

        public string Note { get; set; }
    }
}
