using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;

namespace CatAlog_App.Db.DbContexts.DbModels.Relationship
{
    public class AdditionallyData_Genre
    {
        public int Id { get; set; }

        public int AdditionallyDataId { get; set; }

        public AdditionallyData AdditionallyData { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}
