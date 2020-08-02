namespace CatAlog_App.DbWorker.DtoModels
{
    public class DtoAudioDataModel
    {
        public int Id { get; set; }

        public string AudioFormat { get; set; }

        public string Language { get; set; }

        public string Channel { get; set; }

        public float? Frequency { get; set; }

        public float? Bitrate { get; set; }

        public string Author { get; set; }

        public string Note { get; set; }
    }
}
