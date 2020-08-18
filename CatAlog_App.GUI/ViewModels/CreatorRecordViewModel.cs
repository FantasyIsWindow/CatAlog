using CatAlog_App.ConfigurationWorker.Model;
using CatAlog_App.Db.Repositories;
using CatAlog_App.GUI.Infrastructure.Constants;
using CatAlog_App.GUI.Infrastructure.Services;
using CatAlog_App.GUI.Models;
using System.Collections.ObjectModel;
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
                        string newFolderPath = Path.Combine(_configModel.GraphicDataFolderName, _generalData.Template, _generalData.Category, _generalData.Name.FirstName);

                        _generalData.TitleImage = _fileAdmin.SaveTitleImage(_generalData.TitleImage, newFolderPath, _configModel.TitleImageName);
                        _fileAdmin.SaveScreenshots(_generalData.Screenshots, newFolderPath);

                        DataPackModel gData = new DataPackModel();
                        gData.MainData = _generalData;
                        gData.AdditionallyData = _additionalInfo;
                        _serialInfo.Episodes = EpisodesParser();
                        gData.SerialData = _serialInfo;
                        gData.MediaData = _mediaInfo;
                        gData.MediaData.VideoData = _videoInfo;
                        gData.MediaData.AudioData = _audioInfo;
                        gData.MediaData.SubtitleData = _subtitleInfo;

                        SaveRepository _saveDb = new SaveRepository();
                        _saveDb.SaveNewRecord(gData.GetModel());
                        OkHandler?.Invoke();
                        CancelCommand.Execute(null);
                    }));
            }
        }

        #endregion

        #region INITIALIZATION

        public CreatorRecordViewModel(string template, string recordType, LoadRepository repository, PropertyLibrary config) : base(repository, config)
        {
            DisplayType = "Editing";
            _generalData = new MainDataModel()
            {
                Template = template,
                Category = recordType,
                TitleImage = OtherConstants.TitleImageDummy
            };

            _additionalInfo = new AdditionalDataModel();
            _serialInfo = new SerialDataModel();
            _mediaInfo = new MediaDataModel();
            _videoInfo = new ObservableCollection<VideoDataModel>();
            _audioInfo = new ObservableCollection<AudioDataModel>();
            _subtitleInfo = new ObservableCollection<SubtitleDataModel>();
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
