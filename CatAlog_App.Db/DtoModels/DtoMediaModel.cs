using System.Collections.Generic;

namespace CatAlog_App.Db.DtoModels
{
    public class DtoMediaModel
    {
        public uint Id { get; set; }

        public float? Size { get; set; }

        public List<DtoVideoData> VideoData { get; set; }

        public List<DtoAudioData> AudioData { get; set; }

        public List<DtoSubtitleData> SubtitleData { get; set; }
    }
}
