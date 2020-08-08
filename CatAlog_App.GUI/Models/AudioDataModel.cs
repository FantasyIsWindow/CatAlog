using CatAlog_App.Db.DtoModels;

namespace CatAlog_App.GUI.Models
{
    public class AudioDataModel : ModelBase
    {
        private DtoAudioData _audioModel;

        private byte _number;

        public AudioDataModel(DtoAudioData audioModel)
        {
            _audioModel = audioModel;
        }

        public AudioDataModel()
        {
            _audioModel = new DtoAudioData();
        }

        public uint Id
        {
            get => _audioModel.Id;
            set
            {
                _audioModel.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public byte Number
        {
            get => _number;
            set => SetProperty(ref _number, value, "Number");
        }

        public string AudioFormat
        {
            get => _audioModel.AudioFormat;
            set
            {
                _audioModel.AudioFormat = value;
                OnPropertyChanged("AudioFormat");
            }
        }

        public string Language
        {
            get => _audioModel.Language;
            set
            {
                _audioModel.Language = value;
                OnPropertyChanged("Language");
            }
        }

        public string Channel
        {
            get => _audioModel.Channel;
            set
            {
                _audioModel.Channel = value;
                OnPropertyChanged("Channel");
            }
        }

        public float? Frequency
        {
            get => _audioModel.Frequency;
            set
            {
                _audioModel.Frequency = value;
                OnPropertyChanged("Frequency");
            }
        }

        public float? Bitrate
        {
            get => _audioModel.Bitrate;
            set
            {
                _audioModel.Bitrate = value;
                OnPropertyChanged("Bitrate");
            }
        }

        public string Author
        {
            get => _audioModel.Author;
            set
            {
                _audioModel.Author = value;
                OnPropertyChanged("Author");
            }
        }

        public string Note
        {
            get => _audioModel.Note;
            set
            {
                _audioModel.Note = value;
                OnPropertyChanged("Note");
            }
        }

        internal DtoAudioData GetModel() => _audioModel;
    }
}
