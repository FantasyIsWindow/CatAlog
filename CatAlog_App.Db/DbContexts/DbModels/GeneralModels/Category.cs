using System.Collections.Generic;

namespace CatAlog_App.Db.DbContexts.DbModels.GeneralModels
{
    public class Category
    {
        public uint Id { get; set; }

        public string Type { get; set; }

        public uint TemplateId { get; set; }
        public Template Template { get; set; }

        public IEnumerable<MainRecordData> MainRecordsData { get; set; }
    }
}
