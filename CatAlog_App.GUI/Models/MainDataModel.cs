using CatAlog_App.DbWorker.DtoModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CatAlog_App.GUI.Models
{
    public class MainDataModel : ModelBase
    {
        private DtoMainRecordModel _mainModel;

        private NameModel _name;

        private ObservableCollection<ScreenshotModel> _screenshots;

        public MainDataModel(DtoMainRecordModel mainModel)
        {
            _mainModel = mainModel;
            _name = new NameModel(_mainModel.Name);
            _screenshots = new ObservableCollection<ScreenshotModel>();
            _mainModel.Screenshots.ForEach(e => _screenshots.Add(new ScreenshotModel(e)));
        }

        public MainDataModel()
        {
            _mainModel = new DtoMainRecordModel();
        }

        public int Id
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

        public NameModel Name
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

        public ObservableCollection<ScreenshotModel> Screenshots
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

    public class NameModel : ModelBase
    {
        private DtoNameModel _nameModel;

        public NameModel(DtoNameModel nameModel)
        {
            _nameModel = nameModel;
        }

        public NameModel()
        {
            _nameModel = new DtoNameModel();
        }

        public int Id
        {
            get => _nameModel.Id;
            set
            {
                _nameModel.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string FirstName
        {
            get => _nameModel.FirstName;
            set
            {
                _nameModel.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string SecondName
        {
            get => _nameModel.SecondName;
            set
            {
                _nameModel.SecondName = value;
                OnPropertyChanged("SecondName");
            }
        }

        public string ThirdName
        {
            get => _nameModel.ThirdName;
            set
            {
                _nameModel.ThirdName = value;
                OnPropertyChanged("ThirdName");
            }
        }

        public string FourthName
        {
            get => _nameModel.FourthName;
            set
            {
                _nameModel.FourthName = value;
                OnPropertyChanged("FourthName");
            }
        }

        internal DtoNameModel GetModel() => _nameModel;
    }

    public class ScreenshotModel : ModelBase
    {
        private DtoScreenshotModel _screenshotModel;

        public ScreenshotModel(DtoScreenshotModel screenshotModel)
        {
            _screenshotModel = screenshotModel;
        }

        public ScreenshotModel()
        {
            _screenshotModel = new DtoScreenshotModel();
        }

        public int Id
        {
            get => _screenshotModel.Id;
            set
            {
                _screenshotModel.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Path
        {
            get => _screenshotModel.Path;
            set
            {
                _screenshotModel.Path = value;
                OnPropertyChanged("Path");
            }
        }

        internal DtoScreenshotModel GetModel() => _screenshotModel;
    }
}
