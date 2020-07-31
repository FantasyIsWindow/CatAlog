using CatAlog_App.DbWorker.Models.GeneralModels;

namespace CatAlog_App.DbWorker.Models.Relationship
{
    public class AdditionallyData_Actor
    {
        public int AdditionallyInfoId { get; set; }

        public AdditionallyData AdditionallyData { get; set; }


        public int ActorId { get; set; }

        public Actor Actor { get; set; }
    }
}
