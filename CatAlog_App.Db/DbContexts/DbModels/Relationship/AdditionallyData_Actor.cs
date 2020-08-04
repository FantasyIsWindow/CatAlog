using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;

namespace CatAlog_App.Db.DbContexts.DbModels.Relationship
{
    public class AdditionallyData_Actor
    {
        public int Id { get; set; }

        public int AdditionallyDataId { get; set; }

        public AdditionallyData AdditionallyData { get; set; }


        public int ActorId { get; set; }

        public Actor Actor { get; set; }
    }
}
