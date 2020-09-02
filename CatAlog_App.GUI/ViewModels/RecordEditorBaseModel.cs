using CatAlog_App.ConfigurationWorker.Model;
using CatAlog_App.Db.DtoModels;
using CatAlog_App.Db.Repositories;
using CatAlog_App.GUI.Infrastructure.Services;
using CatAlog_App.GUI.Models;
using System.Collections.Generic;
using System.Linq;

namespace CatAlog_App.GUI.ViewModels
{
    public class RecordEditorBaseModel : WindowsManager
    {
        #region SHARED_PAGE_DATA

        protected LoadRepository _repository;
        protected PropertyLibrary _configModel;
        protected ImageAdmin _fileAdmin;
        protected DataPackModel _packModel;
        protected object _currentPage;
        private string _displayType;

        public DataPackModel PackModel
        {
            get => _packModel;
            set => SetProperty(ref _packModel, value, "PackModel");
        }

        public object CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value, "CurrentPage");
        }

        public string DisplayType
        {
            get => _displayType;
            set => SetProperty(ref _displayType, value, "DisplayType");
        }

        protected RellayCommand _okCommand;
        protected RellayCommand _cancelCommand;

        public RellayCommand CancelCommand =>
            _cancelCommand = new RellayCommand((c) => Close());

        #endregion

        #region INITIALIZATION

        public RecordEditorBaseModel(LoadRepository repository, PropertyLibrary config)
        {
            _repository = repository;
            _configModel = config;
            _fileAdmin = new ImageAdmin();

            Countries = _repository.GetCountiesList();
            Genres = _repository.GetGenresList();
            Companies = _repository.GetCompaniesList();
            ReleaseAuthors = _repository.GetReleaseAuthorsList();
            Regisseurs = _repository.GetProducersList();
            Screenwriters = _repository.GetScreenwritersList();
            Actors = _repository.GetActorsList();

            SerialTypes = _repository.GetSerialTypeList();

            VideoQuality = _repository.GetVideoQualityList();
            VideoRelation = _repository.GetVideoRelationList();
            VideoResolutionWidth = _repository.GetVideoWidthList();
            VideoResolutionHeigth = _repository.GetVideoHeightList();
            VideoFormats = _repository.GetVideoFormatsList();

            AudioFormat = _repository.GetAudioFormatsList();
            AudioChannel = _repository.GetAudioChanelsList();
            AudioLanguage = _repository.GetAudioLanguagesList();
            AudioAuthor = _repository.GetAudioAuthorsList();

            SubtitleLanguage = _repository.GetSubtitleLanguagesList();
            SubtitleAuthor = _repository.GetSubtitleAuthorsList();
            SubtitleFormat = _repository.GetSubtitlesFormatList();
        }

        #endregion

        #region GENERAL_DATA

        #region TITLE_IMAGE_DATA

        private RellayCommand _addTitleImageCommand;
        private RellayCommand _removeTitleImageCommand;
        private RellayCommand _addTitleImageForUrlCommand;

        public RellayCommand AddTitleImageCommand
        {
            get
            {
                return _addTitleImageCommand ??
                    (_addTitleImageCommand = new RellayCommand(obj =>
                    {
                        string newTitlePath = OpenDialogManager.OpenFileDialog();
                        _packModel.MainData.TitleImage = newTitlePath ?? _packModel.MainData.TitleImage;
                    }));
            }
        }

        public RellayCommand RemoveTitleImageCommand
        {
            get
            {
                return _removeTitleImageCommand ??
                    (_removeTitleImageCommand = new RellayCommand(obj =>
                    {
                        _packModel.MainData.TitleImage = _configModel.GraphicDataFolderName;
                    }));
            }
        }

        public RellayCommand AddTitleImageForUrlCommand
        {
            get
            {
                return _addTitleImageForUrlCommand ??
                    (_addTitleImageForUrlCommand = new RellayCommand(obj =>
                    {
                        UriEnteringVCModel urlModelView = new UriEnteringVCModel();
                        urlModelView.OkHandler += ((sender, args) =>
                        {
                            UriEventArgs e = args as UriEventArgs;
                            _packModel.MainData.TitleImage = e.Uri.FirstOrDefault();
                        });
                        urlModelView.CloseHandler += (() => CurrentPage = null);
                        CurrentPage = urlModelView;
                    }));
            }
        }

        #endregion

        #region SCREENSHOTS_DATA

        protected ScreenshotDataModel _selectedScreenshot;

        public ScreenshotDataModel SelectedScreenshot
        {
            get => _selectedScreenshot;
            set => SetProperty(ref _selectedScreenshot, value, "SelectedScreenshot");
        }

        private RellayCommand _addScrinshotsForUrlCommand;
        private RellayCommand _addScreenshotsForFilesCommand;
        private RellayCommand _removieScreenshotCommand;
        private RellayCommand _clearScreenshotsCollectionCommand;

        public RellayCommand AddScrinshotsForUrlCommand
        {
            get
            {
                return _addScrinshotsForUrlCommand ??
                    (_addScrinshotsForUrlCommand = new RellayCommand(obj =>
                    {
                        UriEnteringVCModel _urlModelView = new UriEnteringVCModel();
                        _urlModelView.OkHandler += ((IChannelSender, args) =>
                        {
                            UriEventArgs e = args as UriEventArgs;
                            foreach (var item in e.Uri)
                            {
                                _packModel.MainData.Screenshots.Add(new ScreenshotDataModel()
                                {
                                    Path = item
                                });
                            }
                        });
                        _urlModelView.CloseHandler += (() => CurrentPage = null);
                        CurrentPage = _urlModelView;
                    }));
            }
        }

        public RellayCommand AddScreenshotsForFilesCommand
        {
            get
            {
                return _addScreenshotsForFilesCommand ??
                    (_addScreenshotsForFilesCommand = new RellayCommand(obj =>
                    {
                        var paths = OpenDialogManager.OpenFilesDialog();
                        if (paths != null)
                        {
                            foreach (var path in paths)
                            {
                                _packModel.MainData.Screenshots.Add(new ScreenshotDataModel()
                                {
                                    Path = path
                                });
                            }
                        }
                    }));
            }
        }

        public RellayCommand RemovieScreenshotCommand
        {
            get
            {
                return _removieScreenshotCommand ??
                    (_removieScreenshotCommand = new RellayCommand(obj =>
                    {
                        _packModel.MainData.Screenshots.Remove(_selectedScreenshot);
                    },
                        (obj) => _selectedScreenshot != null
                    ));
            }
        }

        public RellayCommand ClearScreenshotsCollectionCommand
        {
            get
            {
                return _clearScreenshotsCollectionCommand ??
                    (_clearScreenshotsCollectionCommand = new RellayCommand(obj =>
                    {
                        _packModel.MainData.Screenshots.Clear();
                    },
                        (obj) => _packModel.MainData.Screenshots != null && _packModel.MainData.Screenshots.Count != 0
                    ));
            }
        }

        #endregion

        #endregion

        #region ADDITIONALLY_DATA

        public List<DtoPairModel> Countries { get; }

        public List<DtoPairModel> Genres { get; }

        public List<DtoPairModel> Companies { get; }

        public List<string>       ReleaseAuthors { get; }

        public List<DtoPairModel> Regisseurs { get; }

        public List<DtoPairModel> Screenwriters { get; }

        public List<DtoPairModel> Actors { get; }

        #endregion

        #region SERIAL_DATA

        public List<string> SerialTypes { get; }

        private string _episodes;

        public string Episodes
        {
            get => _episodes;
            set => SetProperty(ref _episodes, value, "Episodes");
        }

        #endregion

        #region MEDIA_DATA

        #region VIDEO_DATA

        public List<string> VideoQuality { get; }

        public List<string> VideoRelation { get; }

        public List<ushort> VideoResolutionWidth { get; }

        public List<ushort> VideoResolutionHeigth { get; }

        public List<string> VideoFormats { get; }

        protected VideoDataModel _selectedVideoItem;

        public VideoDataModel SelectedVideoItem
        {
            get => _selectedVideoItem;
            set => _selectedVideoItem = value;
        }

        private RellayCommand _addNewVideoItemCommand;
        private RellayCommand _removieVideoItemCommand;
        private RellayCommand _clearVideoCollectionCommand;

        public RellayCommand AddNewVideoItemCommand
        {
            get
            {
                return _addNewVideoItemCommand ??
                    (_addNewVideoItemCommand = new RellayCommand(obj =>
                    {
                        VideoDataModel item = new VideoDataModel();
                        _packModel.MediaData.VideoData.Add(item);
                    }));
            }
        }

        public RellayCommand RemovieVideoItemCommand
        {
            get
            {
                return _removieVideoItemCommand ??
                    (_removieVideoItemCommand = new RellayCommand(obj =>
                    {
                        _packModel.MediaData.VideoData.Remove(_selectedVideoItem);
                    },
                        (obj) => _selectedVideoItem != null)
                    );
            }
        }

        public RellayCommand ClearVideoCollectionCommand
        {
            get
            {
                return _clearVideoCollectionCommand ??
                    (_clearVideoCollectionCommand = new RellayCommand(obj =>
                    {
                        _packModel.MediaData.VideoData.Clear();
                    },
                        (obj) => _packModel.MediaData.VideoData != null && _packModel.MediaData.VideoData.Count != 0)
                    );
            }
        }

        #endregion

        #region AUDIO_DATA

        public List<string> AudioFormat { get; }

        public List<string> AudioChannel { get; }

        public List<string> AudioLanguage { get; }

        public List<string> AudioAuthor { get; }

        protected AudioDataModel _selectedAudioItem;

        public AudioDataModel SelectedAudioItem
        {
            get => _selectedAudioItem;
            set => SetProperty(ref _selectedAudioItem, value, "SelectedAudioItem");
        }

        private RellayCommand _addNewAudioItemCommand;
        private RellayCommand _removieAudioItemCommand;
        private RellayCommand _clearAudioCollectionCommand;

        public RellayCommand AddNewAudioItemCommand
        {
            get
            {
                return _addNewAudioItemCommand ??
                    (_addNewAudioItemCommand = new RellayCommand(obj =>
                    {
                        AudioDataModel item = new AudioDataModel();
                        _packModel.MediaData.AudioData.Add(item);
                    }));
            }
        }

        public RellayCommand RemovieAudioItemCommand
        {
            get
            {
                return _removieAudioItemCommand ??
                    (_removieAudioItemCommand = new RellayCommand(obj =>
                    {
                        _packModel.MediaData.AudioData.Remove(_selectedAudioItem);
                    },
                        (obj) => _selectedAudioItem != null)
                    );
            }
        }

        public RellayCommand ClearAudioCollectionCommand
        {
            get
            {
                return _clearAudioCollectionCommand ??
                    (_clearAudioCollectionCommand = new RellayCommand(obj =>
                    {
                        _packModel.MediaData.AudioData.Clear();
                    },
                        (obj) => _packModel.MediaData.AudioData != null && _packModel.MediaData.AudioData.Count != 0)
                    );
            }
        }

        #endregion

        #region SUBTITLE_DATA

        public List<string> SubtitleLanguage { get; }

        public List<string> SubtitleAuthor { get; }

        public List<string> SubtitleFormat { get; }

        protected SubtitleDataModel _selectedSubtitleItem;

        public SubtitleDataModel SelectedSubtitleItem
        {
            get => _selectedSubtitleItem;
            set => SetProperty(ref _selectedSubtitleItem, value, "SelectedSubtitleItem");
        }

        private RellayCommand _addNewSubtitleItemCommand;
        private RellayCommand _removieSubtitleItemCommand;
        private RellayCommand _clearSubtitleCollectionCommand;


        public RellayCommand AddNewSubtitleItemCommand
        {
            get
            {
                return _addNewSubtitleItemCommand ??
                    (_addNewSubtitleItemCommand = new RellayCommand(obj =>
                    {
                        SubtitleDataModel item = new SubtitleDataModel();
                        _packModel.MediaData.SubtitleData.Add(item);
                    }));
            }
        }

        public RellayCommand RemovieSubtitleItemCommand
        {
            get
            {
                return _removieSubtitleItemCommand ??
                    (_removieSubtitleItemCommand = new RellayCommand(obj =>
                    {
                        _packModel.MediaData.SubtitleData.Remove(_selectedSubtitleItem);
                    },
                        (obj) => _selectedSubtitleItem != null)
                    );
            }
        }

        public RellayCommand ClearSubtitleCollectionCommand
        {
            get
            {
                return _clearSubtitleCollectionCommand ??
                    (_clearSubtitleCollectionCommand = new RellayCommand(obj =>
                    {
                        _packModel.MediaData.SubtitleData.Clear();
                    },
                        (obj) => _packModel.MediaData.SubtitleData != null && _packModel.MediaData.SubtitleData.Count != 0)
                    );
            }
        }

        #endregion

        #endregion                      
    }
}
