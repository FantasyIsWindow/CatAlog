using CatAlog_App.DbWorker.Models.GeneralModels;

namespace CatAlog_App.DbWorker.Models.Relationship
{
    public class AdditionallyData_Genre
    {
        public int AdditionallyInfoId { get; set; }

        public AdditionallyData AdditionallyData { get; set; }


        public int GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}
