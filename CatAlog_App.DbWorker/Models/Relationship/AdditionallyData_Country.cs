using CatAlog_App.DbWorker.Models.GeneralModels;

namespace CatAlog_App.DbWorker.Models.Relationship
{
    public class AdditionallyData_Country
    {
        public int AdditionallyInfoId { get; set; }

        public AdditionallyData AdditionallyData { get; set; }


        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}
