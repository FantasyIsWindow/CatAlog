using System.Collections.Generic;

namespace CatAlog_App.Db.DtoModels
{
    public class DtoSerialData
    {
        public int Id { get; set; }

        public List<DtoEpisode> Episodes { get; set; }

        public int? SeasonNumber { get; set; }

        public string Type { get; set; }

        public int? CountSpecials { get; set; }

        public string Note { get; set; }
    }

    public class DtoEpisode
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }
    }
}
