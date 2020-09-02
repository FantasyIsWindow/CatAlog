using CatAlog_App.ConfigurationWorker.Model;
using CatAlog_App.Db.Repositories;
using CatAlog_App.GUI.Infrastructure.Constants;
using CatAlog_App.GUI.Infrastructure.Services;
using CatAlog_App.GUI.Models;
using System;
using System.IO;

namespace CatAlog_App.GUI.ViewModels
{
    public class CreateEvent : EventArgs
    {
        public uint Id { get; set; }
    }

    public class CreatorRecordViewModel : RecordEditorBaseModel
    {
        public event EventHandler OkHandler;

        public CreatorRecordViewModel(string template, string category, LoadRepository repository, PropertyLibrary config) : base(repository, config)
        {
            DisplayType = "Edit";
            _packModel = new DataPackModel();
            _packModel.MainData.Template = template;
            _packModel.MainData.Category = category;
            _packModel.MainData.TitleImage = OtherConstants.TitleImageDummy;
        }

        public RellayCommand OkCommand
        {
            get
            {
                return _okCommand ??
                    (_okCommand = new RellayCommand(obj =>
                    {
                        CreateInfrastructureAndSaveMedia();
                        SaveRepository _saveDb = new SaveRepository();
                        uint id = _saveDb.SaveNewRecord(_packModel.GetModel());

                        if (OkHandler != null)
                        {
                            CreateEvent args = new CreateEvent() { Id = id };
                            OkHandler.Invoke(null, args);
                        }
                        CancelCommand.Execute(null);
                    }));
            }
        }

        /// <summary>
        /// Create folder infrastructure and save new image files
        /// </summary>
        private void CreateInfrastructureAndSaveMedia()
        {
            string path = Path.Combine(_configModel.DbFolderPath, 
                                       _configModel.GraphicDataFolderName, 
                                       _packModel.MainData.Template, 
                                       _packModel.MainData.Category, 
                                       _packModel.MainData.Name.FirstName);
            FileManager.CreateNewFolder(path);
            _packModel.MainData.TitleImage = _fileAdmin.SaveTitleImage(_packModel.MainData.TitleImage, path, _configModel.TitleImageName);
            _fileAdmin.SaveScreenshots(_packModel.MainData.Screenshots, path);
        }
    }
}
