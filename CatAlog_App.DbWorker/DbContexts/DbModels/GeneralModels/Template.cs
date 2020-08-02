using System.Collections.Generic;

namespace CatAlog_App.DbWorker.DbContexts.DbModels.GeneralModels
{
    public class Template
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
 