using CatAlog_App.Db.DbContexts.DbModels.Relationship;
using System.Collections.Generic;

namespace CatAlog_App.Db.DbContexts.DbModels.GeneralModels
{
    public class Screenwriter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<AdditionallyData_Screenwriter> AdditionallyData_Screenwriter { get; set; }
    }
}
