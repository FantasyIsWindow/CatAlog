using CatAlog_App.DbWorker.Models.GeneralModels;

namespace CatAlog_App.DbWorker.Models.Relationship
{
    public class AdditionallyData_Screenwriter
    {
        public int AdditionallyInfoId { get; set; }

        public AdditionallyData AdditionallyData { get; set; }


        public int ScreenwriterId { get; set; }

        public Screenwriter Screenwriter { get; set; }
    }
}
