﻿using CatAlog_App.DbWorker.DbContexts.DbModels.GeneralModels;

namespace CatAlog_App.DbWorker.DbContexts.DbModels.Relationship
{
    public class AdditionallyData_Producer
    {
        public int AdditionallyInfoId { get; set; }

        public AdditionallyData AdditionallyData { get; set; }


        public int ProducerId { get; set; }

        public Producer Producer { get; set; }
    }
}