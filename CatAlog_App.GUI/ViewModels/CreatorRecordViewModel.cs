using CatAlog_App.ConfigurationWorker.Model;
using CatAlog_App.Db.Repositories;
using CatAlog_App.GUI.Infrastructure.Constants;
using CatAlog_App.GUI.Infrastructure.Services;
using CatAlog_App.GUI.Models;
using System.IO;
using static CatAlog_App.GUI.ViewModels.ViewControlsBaseModel;

namespace CatAlog_App.GUI.ViewModels
{
    public class CreatorRecordViewModel : RecordEditorBaseModel
    {
        public event NotifyDelegate OkHandler;

        #region SHARED_PAGE_DATA

        public RellayCommand OkCommand
        {
            get
            {
                return _okCommand ??
                    (_okCommand = new RellayCommand(obj =>
                    {
                        string newFolderPath = Path.Combine(_configModel.GraphicDataFolderName, _packModel.MainData.Template, _packModel.MainData.Category, _packModel.MainData.Name.FirstName);

                        _fileAdmin.CreateNewFolder(newFolderPath);
                        _packModel.MainData.TitleImage = _fileAdmin.SaveTitleImage(_packModel.MainData.TitleImage, newFolderPath, _configModel.TitleImageName);
                        _fileAdmin.SaveScreenshots(_packModel.MainData.Screenshots, newFolderPath);
                        SaveRepository _saveDb = new SaveRepository();
                        _saveDb.SaveNewRecord(_packModel.GetModel());
                        OkHandler?.Invoke();
                        CancelCommand.Execute(null);
                    }));
            }
        }

        #endregion

        #region INITIALIZATION

        public CreatorRecordViewModel(string template, string category, LoadRepository repository, PropertyLibrary config) : base(repository, config)
        {
            DisplayType = "Edit";
            _packModel = new DataPackModel();
            _packModel.MainData.Template = template;
            _packModel.MainData.Category = category;
            _packModel.MainData.TitleImage = OtherConstants.TitleImageDummy;
        }

        #endregion

        private void SaveDummyRecord()
        {
            DataPackModel model = new DataPackModel()
            {
                MainData = new MainDataModel()
                {

                },
                AdditionallyData = new AdditionalDataModel()
                {

                },
                SerialData = new SerialDataModel()
                {

                },
                MediaData = new MediaDataModel()
                {

                }
            };
        }
    }
}
