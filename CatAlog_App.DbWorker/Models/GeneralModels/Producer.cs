using CatAlog_App.DbWorker.Models.Relationship;
using System.Collections.Generic;

namespace CatAlog_App.DbWorker.Models.GeneralModels
{
    public class Producer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<AdditionallyData_Producer> AdditionallyInfo_Producer { get; set; }
    }
}
