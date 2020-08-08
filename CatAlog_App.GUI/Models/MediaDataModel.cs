using CatAlog_App.Db.DtoModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CatAlog_App.GUI.Models
{
    public class MediaDataModel : ModelBase
    {
        private DtoMediaModel _mediaModel;

        private ObservableCollection<VideoDataModel> _videoData;

        private ObservableCollection<AudioDataModel> _audioData;

       private ObservableCollection<SubtitleDataModel> _subtitleData;

        public MediaDataModel(DtoMediaModel mediaModel)
        {
            _mediaModel = mediaModel;

            byte number = 0;
            _videoData = new ObservableCollection<VideoDataModel>();
            mediaModel.VideoData.ForEach(v => _videoData.Add(new VideoDataModel(v) { Number = ++number }));

            number = 0;
            _audioData = new ObservableCollection<AudioDataModel>();
            mediaModel.AudioData.ForEach(a => _audioData.Add(new AudioDataModel(a) { Number = ++number }));

            number = 0;
            _subtitleData = new ObservableCollection<SubtitleDataModel>();
            mediaModel.SubtitleData.ForEach(s => _subtitleData.Add(new SubtitleDataModel(s) { Number = ++number }));
        }

        public MediaDataModel()
        {
            _mediaModel = new DtoMediaModel();
        }

        public uint Id
        {
            get => _mediaModel.Id;
            set
            {
                _mediaModel.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public float? Size
        {
            get => _mediaModel.Size;
            set
            {
                _mediaModel.Size = value;
                OnPropertyChanged("Size");
            }
        }

        public ObservableCollection<VideoDataModel> VideoData
        {
            get => _videoData;
            set => _videoData = value;
        }

        public ObservableCollection<AudioDataModel> AudioData
        {
            get => _audioData;
            set => _audioData = value;
        }

        public ObservableCollection<SubtitleDataModel> SubtitleData
        {
            get => _subtitleData;
            set => _subtitleData = value;
        }

        internal DtoMediaModel GetModel()
        {
            _mediaModel.VideoData = new List<DtoVideoData>();
            _mediaModel.AudioData = new List<DtoAudioData>();
            _mediaModel.SubtitleData = new List<DtoSubtitleData>();

            foreach (var data in _videoData)
            {
                _mediaModel.VideoData.Add(data.GetModel());
            }

            foreach (var data in _audioData)
            {
                _mediaModel.AudioData.Add(data.GetModel());
            }

            foreach (var data in _subtitleData)
            {
                _mediaModel.SubtitleData.Add(data.GetModel());
            }
            return _mediaModel;
        }
    }
}
