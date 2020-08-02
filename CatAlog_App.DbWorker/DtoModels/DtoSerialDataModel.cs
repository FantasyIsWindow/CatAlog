using System.Collections.Generic;

namespace CatAlog_App.DbWorker.DtoModels
{
    public class DtoSerialDataModel
    {
        public int Id { get; set; }

        public List<DtoEpisodesModel> Episodes { get; set; }

        public int? SeasonNumber { get; set; }

        public string Type { get; set; }

        public int? CountSpecials { get; set; }

        public string Note { get; set; }
    }

    public class DtoEpisodesModel
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }
    }
}
