using System.Collections.Generic;

namespace CatAlog_App.Db.DbContexts.DbModels.GeneralModels
{
    public class Template
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
