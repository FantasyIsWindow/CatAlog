using CatAlog_App.Db.DbContexts.DbModels.Relationship;
using System.Collections.Generic;

namespace CatAlog_App.Db.DbContexts.DbModels.GeneralModels
{
    public class Producer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<AdditionallyData_Producer> AdditionallyData_Producer { get; set; }
    }
}
