using CatAlog_App.Db.DbContexts.DbModels.Relationship;
using System.Collections.Generic;

namespace CatAlog_App.Db.DbContexts.DbModels.GeneralModels
{
    public class Actor
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<AdditionallyData_Actor> AdditionallyData_Actor { get; set; }
    }
}
