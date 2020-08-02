using System.Collections.Generic;

namespace CatAlog_App.DbWorker.DtoModels
{
    public class DtoCatalogShemaModel
    {
        public string Name { get; set; }

        public List<DtoCategoryModel> Categories { get; set; }
    }

    public class DtoCategoryModel
    {
        public string Type { get; set; }

        public int Count { get; set; }
    }
}
