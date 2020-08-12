using CatAlog_App.Db.DtoModels;
using CatAlog_App.GUI.Infrastructure.Services;

namespace CatAlog_App.GUI.Models
{
    public class NameDataModel : ModelBase
    {
        private DtoNameModel _nameModel;

        public NameDataModel(DtoNameModel nameModel)
        {
            _nameModel = nameModel;
        }

        public NameDataModel()
        {
            _nameModel = new DtoNameModel();
        }

        public uint Id
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
}