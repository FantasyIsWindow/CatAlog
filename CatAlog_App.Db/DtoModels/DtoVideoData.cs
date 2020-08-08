namespace CatAlog_App.Db.DtoModels
{
    public class DtoVideoData
    {
        public uint Id { get; set; }

        public string VideoQuality { get; set; }

        public float? Bitrate { get; set; }

        public string Relation { get; set; }

        public ushort ResolutionHeigth { get; set; }

        public ushort ResolutionWidth { get; set; }

        public float? FrameRate { get; set; }

        public string VideoFormat { get; set; }

        public string Note { get; set; }
    }
}