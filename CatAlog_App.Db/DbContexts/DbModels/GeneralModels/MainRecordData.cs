using CatAlog_App.Db.DbContexts.DbModels.VideoModels;
using System.Collections.Generic;

namespace CatAlog_App.Db.DbContexts.DbModels.GeneralModels
{
    public class MainRecordData
    {
        public uint Id { get; set; }

        public string TitleImage { get; set; }

        public uint CategoryId { get; set; }
        public Category Category { get; set; }

        public NameData Name { get; set; }

        public string Duration { get; set; }

        public string ReleaseDate { get; set; }

        public string Description { get; set; }

        public float? Rating { get; set; }

        public IEnumerable<Screenshot> Screenshots { get; set; }

        public AdditionallyData AdditionallyData { get; set; }

        public SerialData SerialData { get; set; }

        public Media Media { get; set; }
    }
}
