using CatAlog_App.DbWorker.DbContexts.DbModels.GeneralModels;

namespace CatAlog_App.DbWorker.DbContexts.DbModels.Relationship
{
    public class AdditionallyData_Company
    {
        public int AdditionallyInfoId { get; set; }

        public AdditionallyData AdditionallyData { get; set; }


        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
