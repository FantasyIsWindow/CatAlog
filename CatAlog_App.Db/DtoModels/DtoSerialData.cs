using System.Collections.Generic;

namespace CatAlog_App.Db.DtoModels
{
    public class DtoSerialData
    {
        public uint Id { get; set; }

        public List<DtoEpisode> Episodes { get; set; }

        public byte? SeasonNumber { get; set; }

        public string Type { get; set; }

        public byte? CountSpecials { get; set; }

        public string Note { get; set; }
    }

    public class DtoEpisode
    {
        public uint Id { get; set; }

        public ushort Number { get; set; }

        public string Name { get; set; }
    }
}
