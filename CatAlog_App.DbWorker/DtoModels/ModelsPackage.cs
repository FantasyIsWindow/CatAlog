using System.Collections.Generic;

namespace CatAlog_App.DbWorker.DtoModels
{
    public class ModelsPackage
    {
        public int Id { get; set; }

        public DtoMainRecordModel MainData { get; set; }

        public DtoAdditionalDataModel AdditionalyData { get; set; }

        public DtoMediaModel MediaData { get; set; }

        public List<DtoVideoDataModel> VideoData { get; set; }

        public List<DtoAudioDataModel> AudioData { get; set; }

        public List<DtoSubtitleDataModel> SubtitleData { get; set; }
    }
}
