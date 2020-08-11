using CatAlog_App.ConfigurationWorker.Model;
using CatAlog_App.Db.Repositories;
using CatAlog_App.GUI.Infrastructure.Services;
using CatAlog_App.GUI.Models;
using System.Text;

namespace CatAlog_App.GUI.ViewModels
{
    public class UpdaterRecordViewModel : RecordEditorBaseModel
    {
        #region SHARED_PAGE_DATA

        public RellayCommand OkCommand
        {
            get
            {
                return _okCommand ??
                    (_okCommand = new RellayCommand(obj =>
                    {
                        //if (_serialInfo != null && _serialInfo.Episodes.Count != 0)
                        //{
                        //    _serialInfo.Episodes = ParsingSeries();
                        //}

                        //DataPackModel gData = new DataPackModel();
                        //gData.MainData = _generalData;
                        //gData.AdditionallyData = _additionalInfo;
                        //gData.SerialData = _serialInfo;
                        //gData.MediaData = _mediaInfo;
                        //gData.MediaData.VideoData = _videoInfo;
                        //gData.MediaData.AudioData = _audioInfo;
                        //gData.MediaData.SubtitleData = _subtitleInfo;

                       // _repository.UpdateData.UpdateRecord(gData.GetModel(), _configModel.DbFolderPath);

                        CancelCommand.Execute(null);
                    }));
            }
        }

        #endregion
               
        #region INITIALIZATION

        public UpdaterRecordViewModel(DataPackModel generalData, LoadRepository repository, PropertyLibrary config) : base(repository, config)
        {
            DisplayType = "Update";
            _repository = repository;
            _generalData = generalData.MainData;
            _additionalInfo = generalData.AdditionallyData;
            _serialInfo = generalData.SerialData;
            _mediaInfo = generalData.MediaData;
            _videoInfo = generalData.MediaData.VideoData;
            _audioInfo = generalData.MediaData.AudioData;
            _subtitleInfo = generalData.MediaData.SubtitleData;

            GetSeriesString();
        }

        private void GetSeriesString()
        {
            if (_serialInfo != null && _serialInfo.Episodes != null)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var info in _serialInfo.Episodes)
                {
                    builder.Append($"{info.Number}. {info.Name}.\n");
                }
                _series = builder.ToString();
            }
        }

        #endregion
    }
}
