using CatAlog_App.ConfigurationWorker.Model;
using CatAlog_App.Db.Repositories;
using CatAlog_App.GUI.Infrastructure.Services;
using CatAlog_App.GUI.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace CatAlog_App.GUI.ViewModels
{
    public class UpdaterRecordViewModel : RecordEditorBaseModel
    {
        private readonly string _folderPath;
        private readonly string _titlePathCopy;
        private ObservableCollection<ScreenshotDataModel> _screenshotsCopy;
        
        public List<string> Categories { get; }

        public UpdaterRecordViewModel(DataPackModel generalData, 
                                      LoadRepository repository, 
                                      PropertyLibrary config) : base(repository, config)
        {
            DisplayType = "Update";
            _packModel = generalData;
            _folderPath = CreatePathToImagesFolder();
            _titlePathCopy = _packModel.MainData.TitleImage;
            Categories = repository.GetCategories();
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
                            FileManager.RenameFolder(_folderPath, newFolderPath);

                            _packModel.MainData.TitleImage = GetNewTitlePath(newFolderPath);
                            ReplacePathToScreenshots(newFolderPath, _packModel.MainData.Screenshots);
                        }

                        updateRepository.UpdateRecord(_packModel.GetModel());
                        CancelCommand.Execute(null);
                    }));
            }
        }

        /// <summary>
        /// Building the path of the saved file
        /// </summary>
        /// <returns>New path</returns>
        private string CreatePathToImagesFolder()
        {
            char[] separators = new char[] { ':', ':' };
            var recordName = _packModel.MainData.Name.FirstName.Split(separators);
            return Path.Combine(_configModel.DbFolderPath, 
                                _configModel.GraphicDataFolderName,
                                _packModel.MainData.Template,
                                _packModel.MainData.Category,
                                recordName[0]);
        }

        /// <summary>
        /// Updating the title image
        /// </summary>
        /// <param name="path">Path to folder</param>
        private void TitleUpdate(string path)
        {
            if (_titlePathCopy != _packModel.MainData.TitleImage)
            {
                _packModel.MainData.TitleImage = 
                    _fileAdmin.SaveTitleImage(_packModel.MainData.TitleImage, path, _configModel.TitleImageName);
            }
        }

        /// <summary>
        /// Updating screenshots of an entry
        /// </summary>
        /// <param name="path"></param>
        private void ScreenshotsUpdate(string path)
        {
            var newScreenshots = new ObservableCollection<ScreenshotDataModel>();
            for (int i = 0; i < _packModel.MainData.Screenshots.Count; i++)
            {
                var tempItem = _screenshotsCopy.FirstOrDefault(s => 
                    s.Path == _packModel.MainData.Screenshots[i].Path);

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

            _fileAdmin.SaveScreenshots(newScreenshots, path);
        }

        /// <summary>
        /// Building the path to the title image
        /// </summary>
        /// <param name="path">New folder path</param>
        /// <returns>New path to title image</returns>
        private string GetNewTitlePath(string path)
        {
            string currentPath = Path.GetFileName(_packModel.MainData.TitleImage);
            string newPathToTitle = Path.Combine(path, currentPath);
            return newPathToTitle;
        }

        /// <summary>
        /// Updating information about the location of screenshots
        /// </summary>
        /// <param name="newPath">Path to new folder</param>
        /// <param name="screenshots">Collection of processed screenshots</param>
        private void ReplacePathToScreenshots(string newPath, 
                                              ObservableCollection<ScreenshotDataModel> screenshots)
        {
            for (int i = 0; i < screenshots.Count; i++)
            {
                string currentPath = Path.GetFileName(screenshots[i].Path);
                screenshots[i].Path = Path.Combine(newPath, currentPath);
            }
        }
    }
}
