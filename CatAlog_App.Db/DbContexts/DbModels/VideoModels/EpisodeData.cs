namespace CatAlog_App.Db.DbContexts.DbModels.VideoModels
{
    public class EpisodeData
    {
        public uint Id { get; set; }

        public ushort Number { get; set; }

        public string Name { get; set; }

        public uint SerialDataId { get; set; }
        public SerialData SerialData { get; set; }
    }
}
