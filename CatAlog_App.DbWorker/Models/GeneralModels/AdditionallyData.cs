using CatAlog_App.DbWorker.Models.Relationship;
using CatAlog_App.DbWorker.Models.VideoModels;
using System.Collections.Generic;

namespace CatAlog_App.DbWorker.Models.GeneralModels
{
    public class AdditionallyData 
    {
        public int Id { get; set; }

        public string ReleaseAuthor { get; set; }

        public string Note { get; set; }
        
        public int MainRecordDataId { get; set; }
        public MainRecordData MainRecordData { get; set; }

        public IEnumerable<AdditionallyData_Company> AdditionallyData_Companies { get; set; }

        public IEnumerable<AdditionallyData_Country> AdditionallyData_Countries { get; set; }

        public IEnumerable<AdditionallyData_Genre> AdditionallyData_Genres { get; set; }

        public IEnumerable<AdditionallyData_Producer> AdditionallyData_Producers { get; set; }

        public IEnumerable<AdditionallyData_Screenwriter> AdditionallyData_Screenwriters { get; set; }

        public IEnumerable<AdditionallyData_Actor> AdditionallyData_Actors { get; set; }

        public SerialData SerialData { get; set; }
    }
}
