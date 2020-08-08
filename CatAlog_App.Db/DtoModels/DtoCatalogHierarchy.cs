using System.Collections.Generic;

namespace CatAlog_App.Db.DtoModels
{
    public class DtoCatalogHierarchy
    {
        public string TemplateName { get; set; }

        public List<DtoCategory> Categories { get; set; }
    }

    public class DtoCategory
    {
        public string CategoryName { get; set; }

        public ushort Count { get; set; }
    }
}
