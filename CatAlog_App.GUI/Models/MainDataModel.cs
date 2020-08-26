using CatAlog_App.Db.DtoModels;
using CatAlog_App.GUI.Infrastructure.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CatAlog_App.GUI.Models
{
    public class MainDataModel : ModelBase
    {
        private DtoMainRecordModel _mainModel;

        private NameDataModel _name;

        private ObservableCollection<ScreenshotDataModel> _screenshots;

        public MainDataModel(DtoMainRecordModel mainModel)
        {
            _mainModel = mainModel;
            _name = new NameDataModel(_mainModel.Name);
            _screenshots = new ObservableCollection<ScreenshotDataModel>();
            _mainModel.Screenshots.ForEach(e => _screenshots.Add(new ScreenshotDataModel(e)));
        }

        public MainDataModel()
        {
            _mainModel = new DtoMainRecordModel();
            _name = new NameDataModel();
            _screenshots = new ObservableCollection<ScreenshotDataModel>();
        }

        public uint Id
        {
            get => _mainModel.Id;
            set
            {
                _mainModel.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string TitleImage
        {
            get => _mainModel.TitleImage;
            set
            {
                _mainModel.TitleImage = value;
                OnPropertyChanged("TitleImage");
            }
        }

        public string Template
        {
            get => _mainModel.Template;
            set
            {
                _mainModel.Template = value;
                OnPropertyChanged("Template");
            }
        }

        public string Category
        {
            get => _mainModel.Category;
            set
            {
                _mainModel.Category = value;
                OnPropertyChanged("Category");
            }
        }

        public NameDataModel Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Duration
        {
            get => _mainModel.Duration;
            set
            {
                _mainModel.Duration = value;
                OnPropertyChanged("Duration");
            }
        }

        public string ReleaseDate
        {
            get => _mainModel.ReleaseDate;
            set
            {
                _mainModel.ReleaseDate = value;
                OnPropertyChanged("ReleaseDate");
            }
        }

        public string Description
        {
            get => _mainModel.Description;
            set
            {
                _mainModel.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public float? Rating
        {
            get => _mainModel.Rating;
            set
            {
                _mainModel.Rating = value;
                OnPropertyChanged("Rating");
            }
        }

        public ObservableCollection<ScreenshotDataModel> Screenshots
        {
            get => _screenshots;
            set => _screenshots = value;
        }

        internal DtoMainRecordModel GetModel()
        {
            _mainModel.Name = Name.GetModel();
            _mainModel.Screenshots = new List<DtoScreenshotModel>();
            foreach (var screenshot in Screenshots)
            {
                _mainModel.Screenshots.Add(new DtoScreenshotModel() { Id = screenshot.Id, Path = screenshot.Path });
            }
            return _mainModel;
        }
    }
}