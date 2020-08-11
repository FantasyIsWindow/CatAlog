using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CatAlog_App.ConfigurationWorker.Model
{
    public class PropertyLibrary : INotifyPropertyChanged
    {
        private string _dbFolderPath;

        private string _dbFileName;

        private string _graphicDataFolderName;

        public string DbFolderPath
        {
            get => _dbFolderPath; 
            set 
            {
                _dbFolderPath = value;
                OnPropertyChanged("DbFolderPath");
            }
        }

        public string DbFileName
        {
            get => _dbFileName; 
            set 
            { 
                _dbFileName = value;
                OnPropertyChanged("DbFileName");
            }
        }

        public string GraphicDataFolderName
        {
            get => _graphicDataFolderName; 
            set
            {
                _graphicDataFolderName = value;
                OnPropertyChanged("GraphicDataFolderName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "") => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
