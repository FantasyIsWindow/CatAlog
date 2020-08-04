using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CatAlog_App.GUI.Models
{
    //class SerialDataModel : ModelBase
    //{
    //    private DtoSerialDataModel _serialModel;

    //    private ObservableCollection<EpisodeViewModel> _series;

    //    public SerialDataModel(DtoSerialDataModel serialModel)
    //    {
    //        _serialModel = serialModel;
    //        _series = new ObservableCollection<EpisodeViewModel>();
    //        _serialModel.Episodes.ForEach(e => _series.Add(new EpisodeViewModel(e)));
    //    }

    //    public SerialDataModel()
    //    {
    //        _serialModel = new DtoSerialDataModel();
    //        _series = new ObservableCollection<EpisodeViewModel>();
    //    }

    //    public int Id
    //    {
    //        get => _serialModel.Id;
    //        set
    //        {
    //            _serialModel.Id = value;
    //            OnPropertyChanged("Id");
    //        }
    //    }

    //    public ObservableCollection<EpisodeViewModel> Series
    //    {
    //        get => _series;
    //        set => _series = value;
    //    }

    //    public int? SeasonNumber
    //    {
    //        get => _serialModel.SeasonNumber;
    //        set
    //        {
    //            _serialModel.SeasonNumber = value;
    //            OnPropertyChanged("SeasonNumber");
    //        }
    //    }

    //    public string Type
    //    {
    //        get => _serialModel.Type;
    //        set
    //        {
    //            _serialModel.Type = value;
    //            OnPropertyChanged("Type");
    //        }
    //    }

    //    public int? CountSpecials
    //    {
    //        get => _serialModel.CountSpecials;
    //        set
    //        {
    //            _serialModel.CountSpecials = value;
    //            OnPropertyChanged("CountSpecials");
    //        }
    //    }

    //    public string Note
    //    {
    //        get => _serialModel.Note;
    //        set
    //        {
    //            _serialModel.Note = value;
    //            OnPropertyChanged("Note");
    //        }
    //    }

    //    internal DtoSerialDataModel GetModel()
    //    {
    //        _serialModel.Episodes = new List<DtoEpisodesModel>();
    //        foreach (var item in Series)
    //        {
    //            _serialModel.Episodes.Add(new DtoEpisodesModel() { Id = item.Id, Number = item.Number, Name = item.Name });
    //        }
    //        return _serialModel;
    //    }
    //}

    //internal class EpisodeViewModel : ModelBase
    //{
    //    internal DtoEpisodesModel _episodeModel;

    //    public EpisodeViewModel(DtoEpisodesModel episodeModel)
    //    {
    //        _episodeModel = episodeModel;
    //    }

    //    public EpisodeViewModel()
    //    {
    //        _episodeModel = new DtoEpisodesModel();
    //    }

    //    public int Id
    //    {
    //        get => _episodeModel.Id;
    //        set
    //        {
    //            _episodeModel.Id = value;
    //            OnPropertyChanged("Id");
    //        }
    //    }

    //    public string Number
    //    {
    //        get => _episodeModel.Number;
    //        set
    //        {
    //            _episodeModel.Number = value;
    //            OnPropertyChanged("Number");
    //        }
    //    }

    //    public string Name
    //    {
    //        get => _episodeModel.Name;
    //        set
    //        {
    //            _episodeModel.Name = value;
    //            OnPropertyChanged("Name");
    //        }
    //    }

    //    internal DtoEpisodesModel GetModel() => _episodeModel;
    //}
}
