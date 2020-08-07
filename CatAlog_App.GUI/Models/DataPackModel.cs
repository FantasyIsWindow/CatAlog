using CatAlog_App.Db.DtoModels;

namespace CatAlog_App.GUI.Models
{
    public class DataPackModel
    {
        public MainDataModel MainData { get; set; }

        public AdditionalDataModel AdditionallyData { get; set; }

        public SerialDataModel SerialData { get; set; }

        public MediaDataModel MediaData { get; set; }

        public DataPackModel(DtoFullVideoData model)
        {
            MainData = new MainDataModel(model.DtoMainData);
            AdditionallyData = new AdditionalDataModel(model.DtoAdditionallyData);
            MediaData = new MediaDataModel(model.DtoMediaData);
            if (model.DtoSerialData != null)
            {
                SerialData = new SerialDataModel(model.DtoSerialData);
            }
        }

        public DataPackModel()
        { }

        public DtoFullVideoData GetModel()
        {
            DtoFullVideoData returnedModel = new DtoFullVideoData()
            {
                DtoMainData = MainData.GetModel(),
                DtoAdditionallyData = AdditionallyData.GetModel(),
                DtoSerialData = SerialData.GetModel(),
                DtoMediaData = MediaData.GetModel()
            };

            return returnedModel;
        }
    }
}
