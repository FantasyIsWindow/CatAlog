using CatAlog_App.ConfigurationWorker;
using CatAlog_App.ConfigurationWorker.Model;
using CatAlog_App.GUI.Infrastructure.Services;
using System.IO;

namespace CatAlog_App.GUI.ViewModels
{
    public class NewDataBaseOptionsVCModel : ViewControlsBaseModel
    {
        /// <summary>
        /// Positive result of new data collection
        /// </summary>
        public event NotifyDelegate OkHandler;

        private SettingsManager _sManager;

        /// <summary>
        /// The object containing the configuration data
        /// </summary>
        public PropertyLibrary Settings
        {
            get => _sManager.Settings;
            set
            {
                _sManager.Settings = value;
                OnPropertyChanged("Settings");
            }
        }

        public NewDataBaseOptionsVCModel()
        {
            _sManager = new SettingsManager();
        }

        private RellayCommand _addNewPathCommand;

        public RellayCommand AddNewPathCommand
        {
            get
            {
                return _addNewPathCommand ??
                    (_addNewPathCommand = new RellayCommand(obj =>
                    {
                        string FullPath = OpenDialogManager.OpenFolderDialog(Settings.Extension);
                        bool isDbFile = Path.GetExtension(FullPath) == Settings.Extension;

                        if (!string.IsNullOrEmpty(FullPath) && isDbFile)
                        {
                            Settings.DbFileName = Path.GetFileNameWithoutExtension(FullPath);
                            Settings.DbFolderPath = Path.GetDirectoryName(FullPath);
                        }
                        else
                        {
                            Settings.DbFileName = "";
                            Settings.DbFolderPath = FullPath;
                        }
                    }));
            }
        }

        public RellayCommand OkCommand
        {
            get
            {
                return _okCommand ??
                    (_okCommand = new RellayCommand(obj =>
                    {                       
                        _sManager.SaveConfig();

                        OkHandler?.Invoke();
                        CloseCommand.Execute(null);
                    },
                        (obj) => !string.IsNullOrEmpty(Settings.DbFileName) && // Подумать о конвертере
                                 !string.IsNullOrEmpty(Settings.DbFolderPath)
                    ));
            }
        }
    }
}
