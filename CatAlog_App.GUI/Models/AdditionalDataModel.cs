using CatAlog_App.Db.DtoModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CatAlog_App.GUI.Models
{
    public class AdditionalDataModel : ModelBase
    {
        private DtoAdditionalDataModel _additionallyModel;

        private ObservableCollection<PairModel> _companies;

        private ObservableCollection<PairModel> _countries;

        private ObservableCollection<PairModel> _genres;

        private ObservableCollection<PairModel> _producers;

        private ObservableCollection<PairModel> _screenwriters;

        private ObservableCollection<PairModel> _actors;

        public AdditionalDataModel(DtoAdditionalDataModel additionallyModel)
        {
            _additionallyModel = additionallyModel;

            _companies = new ObservableCollection<PairModel>();
            _additionallyModel.Companies.ForEach(e => _companies.Add(new PairModel(e)));

            _countries = new ObservableCollection<PairModel>();
            _additionallyModel.Countries.ForEach(e => _countries.Add(new PairModel(e)));

            _genres = new ObservableCollection<PairModel>();
            _additionallyModel.Genres.ForEach(e => _genres.Add(new PairModel(e)));

            _producers = new ObservableCollection<PairModel>();
            _additionallyModel.Producers.ForEach(e => _producers.Add(new PairModel(e)));

            _screenwriters = new ObservableCollection<PairModel>();
            _additionallyModel.Screenwriters.ForEach(e => _screenwriters.Add(new PairModel(e)));

            _actors = new ObservableCollection<PairModel>();
            _additionallyModel.Actors.ForEach(e => _actors.Add(new PairModel(e)));
        }

        public AdditionalDataModel()
        {
            _additionallyModel = new DtoAdditionalDataModel();
        }

        public uint Id
        {
            get => _additionallyModel.Id;
            set
            {
                _additionallyModel.Id = value;
                OnPropertyChanged("id");
            }
        }

        public string ReleaseAuthor
        {
            get => _additionallyModel.ReleaseAuthor;
            set
            {
                _additionallyModel.ReleaseAuthor = value;
                OnPropertyChanged("ReleaseAuthor");
            }
        }

        public string Note
        {
            get => _additionallyModel.Note;
            set
            {
                _additionallyModel.Note = value;
                OnPropertyChanged("Note");
            }
        }

        public ObservableCollection<PairModel> Companies
        {
            get => _companies;
            set => _companies = value;
        }

        public ObservableCollection<PairModel> Countries
        {
            get => _countries;
            set => _countries = value;
        }

        public ObservableCollection<PairModel> Genres
        {
            get => _genres;
            set => _genres = value;
        }

        public ObservableCollection<PairModel> Producers
        {
            get => _producers;
            set => _producers = value;
        }

        public ObservableCollection<PairModel> Screenwriters
        {
            get => _screenwriters;
            set => _screenwriters = value;
        }

        public ObservableCollection<PairModel> Actors
        {
            get => _actors;
            set => _actors = value;
        }

        internal DtoAdditionalDataModel GetModel()
        {
            _additionallyModel.Companies = Convert(Companies);
            _additionallyModel.Countries = Convert(Countries);
            _additionallyModel.Genres = Convert(Genres);
            _additionallyModel.Producers = Convert(Producers);
            _additionallyModel.Screenwriters = Convert(Screenwriters);
            _additionallyModel.Actors = Convert(Actors);
            return _additionallyModel;
        }

        private List<DtoPairModel> Convert(ObservableCollection<PairModel> col)
        {
            List<DtoPairModel> filledCol = new List<DtoPairModel>();
            foreach (var item in col)
            {
                filledCol.Add(new DtoPairModel() { Id = item.Id, Name = item.Name });
            }
            return filledCol;
        }
    }
}
