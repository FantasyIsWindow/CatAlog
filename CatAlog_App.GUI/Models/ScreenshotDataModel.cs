using CatAlog_App.Db.DtoModels;
using CatAlog_App.GUI.Infrastructure.Services;

namespace CatAlog_App.GUI.Models
{
    public class ScreenshotDataModel : ModelBase
    {
        private DtoScreenshotModel _screenshotModel;

        public ScreenshotDataModel(DtoScreenshotModel screenshotModel)
        {
            _screenshotModel = screenshotModel;
        }

        public ScreenshotDataModel()
        {
            _screenshotModel = new DtoScreenshotModel();
        }

        public uint Id
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
