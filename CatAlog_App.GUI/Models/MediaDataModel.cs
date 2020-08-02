using CatAlog_App.DbWorker.DtoModels;

namespace CatAlog_App.GUI.Models
{
    public class MediaDataModel : ModelBase
    {
        private DtoMediaModel _mediaModel;

        public MediaDataModel(DtoMediaModel mediaModel)
        {
            _mediaModel = mediaModel;
        }

        public MediaDataModel()
        {
            _mediaModel = new DtoMediaModel();
        }

        public int Id
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

        internal DtoMediaModel GetModel() => _mediaModel;
    }
}
