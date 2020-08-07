using CatAlog_App.Db.DtoModels;

namespace CatAlog_App.GUI.Models
{
    public class VideoDataModel : ModelBase
    {
        internal DtoVideoData _videoModel;

        private short _number;

        public VideoDataModel(DtoVideoData videoModel)
        {
            _videoModel = videoModel;
        }

        public VideoDataModel()
        {
            _videoModel = new DtoVideoData();
        }

        public int Id
        {
            get => _videoModel.Id;
            set
            {
                _videoModel.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public short Number
        {
            get => _number;
            set => SetProperty(ref _number, value, "Number");
        }

        public string VideoQuality
        {
            get => _videoModel.VideoQuality;
            set
            {
                _videoModel.VideoQuality = value;
                OnPropertyChanged("VideoQuality");
            }
        }

        public float? Bitrate
        {
            get => _videoModel.Bitrate;
            set
            {
                _videoModel.Bitrate = value;
                OnPropertyChanged("Bitrate");
            }
        }

        public string Relation
        {
            get => _videoModel.Relation;
            set
            {
                _videoModel.Relation = value;
                OnPropertyChanged("Relation");
            }
        }

        public int HeigthR
        {
            get => _videoModel.ResolutionHeigth;
            set
            {
                _videoModel.ResolutionHeigth = value;
                OnPropertyChanged("ResolutionHeigth");
            }
        }

        public int WidthR
        {
            get => _videoModel.ResolutionWidth;
            set
            {
                _videoModel.ResolutionWidth = value;
                OnPropertyChanged("ResolutionWidth");
            }
        }

        public float? FrameRate
        {
            get => _videoModel.FrameRate;
            set
            {
                _videoModel.FrameRate = value;
                OnPropertyChanged("FrameRate");
            }
        }

        public string VideoFormat
        {
            get => _videoModel.VideoFormat;
            set
            {
                _videoModel.VideoFormat = value;
                OnPropertyChanged("VideoFormat");
            }
        }

        public string Note
        {
            get => _videoModel.Note;
            set
            {
                _videoModel.Note = value;
                OnPropertyChanged("Note");
            }
        }

        internal DtoVideoData GetModel() => _videoModel;
    }
}
