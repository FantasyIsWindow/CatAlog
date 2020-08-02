using CatAlog_App.DbWorker.DbContexts.DbModels.Relationship;
using System.Collections.Generic;

namespace CatAlog_App.DbWorker.DbContexts.DbModels.GeneralModels
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<AdditionallyData_Genre> AdditionallyInfo_Genre { get; set; }
    }
}
