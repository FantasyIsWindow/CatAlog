using CatAlog_App.DbWorker.Models.GeneralModels;

namespace CatAlog_App.DbWorker.Models.Relationship
{
    public class AdditionallyData_Company
    {
        public int AdditionallyInfoId { get; set; }

        public AdditionallyData AdditionallyData { get; set; }


        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
