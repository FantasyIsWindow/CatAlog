using CatAlog_App.Db.DtoModels;

namespace CatAlog_App.GUI.Models
{
    public class SubtitleDataModel : ModelBase
    {
        internal DtoSubtitleData _subtitleModel;

        internal short _number;

        public SubtitleDataModel(DtoSubtitleData subtitleModel)
        {
            _subtitleModel = subtitleModel;
        }

        public SubtitleDataModel()
        {
            _subtitleModel = new DtoSubtitleData();
        }

        public int Id
        {
            get => _subtitleModel.Id;
            set
            {
                _subtitleModel.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public short Number
        {
            get => _number;
            set => SetProperty(ref _number, value, "Number");
        }

        public string Language
        {
            get => _subtitleModel.Language;
            set
            {
                _subtitleModel.Language = value;
                OnPropertyChanged("Language");
            }
        }

        public string Author
        {
            get => _subtitleModel.Author;
            set
            {
                _subtitleModel.Author = value;
                OnPropertyChanged("Author");
            }
        }

        public string SubtitleFormat
        {
            get => _subtitleModel.SubtitleFormat;
            set
            {
                _subtitleModel.SubtitleFormat = value;
                OnPropertyChanged("SubtitleFormat");
            }
        }

        public string Note
        {
            get => _subtitleModel.Note;
            set
            {
                _subtitleModel.Note = value;
                OnPropertyChanged("Note");
            }
        }

        internal DtoSubtitleData GetModel() => _subtitleModel;
    }
}
