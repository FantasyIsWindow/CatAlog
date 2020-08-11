using CatAlog_App.Db.DtoModels;
using CatAlog_App.GUI.Infrastructure.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CatAlog_App.GUI.Models
{
    public class SerialDataModel : ModelBase
    {
        private DtoSerialData _serialModel;

        private ObservableCollection<EpisodeModel> _episodes;

        public SerialDataModel(DtoSerialData serialModel)
        {
            _serialModel = serialModel;
            if (_serialModel.Episodes != null)
            {
                _episodes = new ObservableCollection<EpisodeModel>();
                _serialModel.Episodes.ForEach(e => _episodes.Add(new EpisodeModel(e)));
            }
        }

        public SerialDataModel()
        {
            _serialModel = new DtoSerialData();
            _episodes = new ObservableCollection<EpisodeModel>();
        }

        public uint Id
        {
            get => _serialModel.Id;
            set
            {
                _serialModel.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public ObservableCollection<EpisodeModel> Episodes
        {
            get => _episodes;
            set => _episodes = value;
        }

        public byte? SeasonNumber
        {
            get => _serialModel.SeasonNumber;
            set
            {
                _serialModel.SeasonNumber = value;
                OnPropertyChanged("SeasonNumber");
            }
        }

        public string Type
        {
            get => _serialModel.Type;
            set
            {
                _serialModel.Type = value;
                OnPropertyChanged("Type");
            }
        }

        public byte? CountSpecials
        {
            get => _serialModel.CountSpecials;
            set
            {
                _serialModel.CountSpecials = value;
                OnPropertyChanged("CountSpecials");
            }
        }

        public string Note
        {
            get => _serialModel.Note;
            set
            {
                _serialModel.Note = value;
                OnPropertyChanged("Note");
            }
        }

        internal DtoSerialData GetModel()
        {
            _serialModel.Episodes = new List<DtoEpisode>();
            foreach (var item in Episodes)
            {
                _serialModel.Episodes.Add(new DtoEpisode() { Id = item.Id, Number = item.Number, Name = item.Name });
            }
            return _serialModel;
        }
    }

    public class EpisodeModel : ModelBase
    {
        internal DtoEpisode _episodeModel;

        public EpisodeModel(DtoEpisode episodeModel)
        {
            _episodeModel = episodeModel;
        }

        public EpisodeModel()
        {
            _episodeModel = new DtoEpisode();
        }

        public uint Id
        {
            get => _episodeModel.Id;
            set
            {
                _episodeModel.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Number
        {
            get => _episodeModel.Number;
            set
            {
                _episodeModel.Number = value;
                OnPropertyChanged("Number");
            }
        }

        public string Name
        {
            get => _episodeModel.Name;
            set
            {
                _episodeModel.Name = value;
                OnPropertyChanged("Name");
            }
        }

        internal DtoEpisode GetModel() => _episodeModel;
    }
}
