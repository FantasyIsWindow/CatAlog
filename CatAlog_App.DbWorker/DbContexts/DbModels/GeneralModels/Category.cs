using System.Collections.Generic;

namespace CatAlog_App.DbWorker.DbContexts.DbModels.GeneralModels
{
    public class Category
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public int Count { get; set; }

        public int TemplateId { get; set; }
        public Template Template { get; set; }

        public IEnumerable<MainRecordData> MainRecordsData { get; set; }
    }
}
