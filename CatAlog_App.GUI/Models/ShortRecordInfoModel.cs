using CatAlog_App.Db.DtoModels;

namespace CatAlog_App.GUI.Models
{
    public class ShortRecordInfoModel : ModelBase
    {
        private DtoShortRecordInfo _model;

        public ShortRecordInfoModel(DtoShortRecordInfo model)
        {
            _model = model;
        }

        public int Id
        {
            get => _model.Id;
        }

        public string FirstName
        {
            get => _model.FirstName;
        }

        public string SecondName
        {
            get => _model.SecondName;
        }

        public string TitleImage
        {
            get => _model.TitleImage;
        }

        public string ReleaseDate
        {
            get => _model.ReleaseDate;
        }

        public float? Rating
        {
            get => _model.Rating;
        }
    }
}
