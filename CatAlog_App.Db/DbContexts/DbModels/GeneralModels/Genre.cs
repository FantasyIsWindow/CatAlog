using CatAlog_App.Db.DbContexts.DbModels.Relationship;
using System.Collections.Generic;

namespace CatAlog_App.Db.DbContexts.DbModels.GeneralModels
{
    public class Genre
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<AdditionallyData_Genre> AdditionallyData_Genre { get; set; }
    }
}
