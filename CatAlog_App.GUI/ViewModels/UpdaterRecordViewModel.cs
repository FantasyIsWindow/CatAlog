using CatAlog_App.ConfigurationWorker.Model;
using CatAlog_App.Db.Repositories;
using CatAlog_App.GUI.Infrastructure.Services;
using CatAlog_App.GUI.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System;

namespace CatAlog_App.GUI.ViewModels
{
    public class UpdaterRecordViewModel : RecordEditorBaseModel
    {
        private readonly string _folderPath;
        private readonly string _titlePathCopy;
        private List<string> _categories;
        private ObservableCollection<ScreenshotDataModel> _screenshotsCopy;

        public List<string> Categories
        {
            get => _categories; 
            set => _categories = value; 
        }

        public UpdaterRecordViewModel(DataPackModel generalData, LoadRepository repository, PropertyLibrary config) : base(repository, config)
        {
            DisplayType = "Update";
            _packModel = generalData;
            _folderPath = CreatePathToImagesFolder();
            _titlePathCopy = _packModel.MainData.TitleImage;
            _categories = repository.GetCategories();
            _screenshotsCopy = new ObservableCollection<ScreenshotDataModel>();
            foreach (var item in _packModel.MainData.Screenshots)
            {
                _screenshotsCopy.Add(item);
            }
        }

        public RellayCommand OkCommand
        {
            get
            {
                return _okCommand ??
                    (_okCommand = new RellayCommand(obj =>
                    {
                        UpdateRepository updateRepository = new UpdateRepository();
                        
                        TitleUpdate(_folderPath);
                        ScreenshotsUpdate(_folderPath);

                        string newFolderPath = CreatePathToImagesFolder();
                        if (newFolderPath != _folderPath)
                        {
                            _fileAdmin.RenameFolder(_folderPath, newFolderPath);

                            _packModel.MainData.TitleImage = GetNewTitlePath(newFolderPath);
                            ReplacePathToScreenshots(newFolderPath, _packModel.MainData.Screenshots);
                        }

                        updateRepository.UpdateRecord(_packModel.GetModel());
                        CancelCommand.Execute(null);
                    }));
            }
        }

        private string CreatePathToImagesFolder()
        {
            char[] separators = new char[] { ':', ':' };
            var recordName = _packModel.MainData.Name.FirstName.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string newFolderPath = Path.Combine(_configModel.GraphicDataFolderName, _packModel.MainData.Template, _packModel.MainData.Category, recordName[0]);
            return newFolderPath;
        }

        private void TitleUpdate(string newFolderPath)
        {
            if (_titlePathCopy != _packModel.MainData.TitleImage)
            {
                _packModel.MainData.TitleImage = _fileAdmin.SaveTitleImage(_packModel.MainData.TitleImage, newFolderPath, _configModel.TitleImageName);
            }
        }

        private void ScreenshotsUpdate(string newFolderPath)
        {
            var newScreenshots = new ObservableCollection<ScreenshotDataModel>();
            for (int i = 0; i < _packModel.MainData.Screenshots.Count; i++)
            {
                var tempItem = _screenshotsCopy.FirstOrDefault(s => s.Path == _packModel.MainData.Screenshots[i].Path);
                if (tempItem != null)
                {
                    _screenshotsCopy.Remove(tempItem);
                }
                else
                {
                    newScreenshots.Add(_packModel.MainData.Screenshots[i]);
                }
            }
            if (_screenshotsCopy.Count != 0)
            {
                _fileAdmin.DeleteScreenshotFiles(_screenshotsCopy);
            }

            _fileAdmin.SaveScreenshots(newScreenshots, newFolderPath);
        }

        private string GetNewTitlePath(string newFolderPath)
        {
            string currentPath = Path.GetFileName(_packModel.MainData.TitleImage);
            string newPathToTitle = Path.Combine(newFolderPath, currentPath);
            return newPathToTitle;
        }

        private void ReplacePathToScreenshots(string newFolderPath, ObservableCollection<ScreenshotDataModel> screenshots)
        {
            for (int i = 0; i < screenshots.Count; i++)
            {
                string currentPath = Path.GetFileName(screenshots[i].Path);
                screenshots[i].Path = Path.Combine(newFolderPath, currentPath);
            }
        }
    }
}
