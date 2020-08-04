using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;

namespace CatAlog_App.Db.DbContexts.DbModels.Relationship
{
    public class AdditionallyData_Company
    {
        public int Id { get; set; }

        public int AdditionallyDataId { get; set; }

        public AdditionallyData AdditionallyData { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
