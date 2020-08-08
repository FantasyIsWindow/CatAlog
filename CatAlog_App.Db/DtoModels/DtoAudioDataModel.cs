namespace CatAlog_App.Db.DtoModels
{
    public class DtoAudioDataModel
    {
        public uint Id { get; set; }

        public string AudioFormat { get; set; }

        public string Language { get; set; }

        public string Channel { get; set; }

        public float? Frequency { get; set; }

        public float? Bitrate { get; set; }

        public string Author { get; set; }

        public string Note { get; set; }
    }
}
