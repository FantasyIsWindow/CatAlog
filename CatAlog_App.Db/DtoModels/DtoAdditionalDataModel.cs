using System.Collections.Generic;

namespace CatAlog_App.Db.DtoModels
{
    public class DtoAdditionalDataModel
    {
        public uint Id { get; set; }

        public string ReleaseAuthor { get; set; }

        public string Note { get; set; }

        public List<DtoPairModel> Companies { get; set; }

        public List<DtoPairModel> Countries { get; set; }

        public List<DtoPairModel> Genres { get; set; }

        public List<DtoPairModel> Producers { get; set; }

        public List<DtoPairModel> Screenwriters { get; set; }

        public List<DtoPairModel> Actors { get; set; }
    }
}
