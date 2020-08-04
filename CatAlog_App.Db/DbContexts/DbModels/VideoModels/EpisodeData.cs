﻿namespace CatAlog_App.Db.DbContexts.DbModels.VideoModels
{
    public class EpisodeData
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public int SerialDataId { get; set; }
        public SerialData SerialData { get; set; }
    }
}