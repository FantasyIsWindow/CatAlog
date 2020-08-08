using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;

namespace CatAlog_App.Db.DbContexts.DbModels.Relationship
{
    public class AdditionallyData_Company
    {
        public uint Id { get; set; }

        public uint AdditionallyDataId { get; set; }
        public AdditionallyData AdditionallyData { get; set; }

        public uint CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
