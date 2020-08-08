using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;

namespace CatAlog_App.Db.DbContexts.DbModels.Relationship
{
    public class AdditionallyData_Producer
    {
        public uint Id { get; set; }

        public uint AdditionallyDataId { get; set; }
        public AdditionallyData AdditionallyData { get; set; }

        public uint ProducerId { get; set; }
        public Producer Producer { get; set; }
    }
}
