using CatAlog_App.DbWorker.Models.Relationship;
using System.Collections.Generic;

namespace CatAlog_App.DbWorker.Models.GeneralModels
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<AdditionallyData_Country> AdditionallyData_Country { get; set; }
    }
}
