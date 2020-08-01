using System.Collections.Generic;

namespace CatAlog_App.DbWorker.Models.GeneralModels
{
    public class MainRecordData
    {
        public int Id { get; set; }

        public string TitleImage { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int NameId { get; set; }
        public NameData Name { get; set; }

        public string Duration { get; set; }

        public string ReleaseDate { get; set; }

        public string Description { get; set; }

        public float? Rating { get; set; }

        public IEnumerable<Screenshot> Screenshots { get; set; }

        public AdditionallyData AdditionallyData { get; set; }

        public Media Media { get; set; }        
    }
}
