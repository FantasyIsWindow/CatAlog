namespace CatAlog_App.DbWorker.Models.VideoModels
{
    public class EpisodeData
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public int SerialDataID { get; set; }
        public SerialData SerialData { get; set; }
    }
}
