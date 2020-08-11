using CatAlog_App.ConfigurationWorker;
using CatAlog_App.ConfigurationWorker.Model;
using CatAlog_App.GUI.Infrastructure.Services;
using System.IO;
using System.Linq;

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

        private RellayCommand _addNewPath;

        public RellayCommand AddNewPath
        {
            get
            {
                return _addNewPath ??
                    (_addNewPath = new RellayCommand(obj =>
                    {
                        string FullPath = OpenDialogManager.OpenFolderDialog();

                        if (!string.IsNullOrEmpty(FullPath) && FullPath.EndsWith(".db"))
                        {
                            string[] tempArr = FullPath.Split('\\');
                            string name = tempArr.LastOrDefault();

                            Settings.DbFileName = name.Replace(".db", "");
                            Settings.DbFolderPath = FullPath.Replace(tempArr.LastOrDefault(), "");
                        }
                        else
                        {
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
                        string imageFolderName = Settings.GraphicDataFolderName.Split('\\').LastOrDefault();

                        Settings.DbFolderPath = Path.Combine(Settings.DbFolderPath, Settings.DbFileName + ".db");
                        Settings.GraphicDataFolderName = Path.Combine(Settings.DbFolderPath, imageFolderName);
                        OkHandler?.Invoke();
                    },
                        (obj) => !string.IsNullOrEmpty(Settings.DbFileName) &&
                                 !string.IsNullOrEmpty(Settings.DbFolderPath)
                    ));
            }
        }
    }
}
