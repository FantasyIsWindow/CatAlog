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

        protected ImageFileAdmin _fileAdmin;

        protected DataPackModel _packModel;

        protected object _currentPage;

        public object CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value, "CurrentPage");
        }

        private string _displayType;

        public string DisplayType
        {
            get => _displayType;
            set => SetProperty(ref _displayType, value, "DisplayType");
        }

        public DataPackModel PackModel
        {
            get => _packModel;
            set => SetProperty(ref _packModel, value, "PackModel");
        }

        protected RellayCommand _okCommand;

        protected RellayCommand _cancelCommand;

        public RellayCommand CancelCommand =>
            _cancelCommand = new RellayCommand((c) => Close());

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
                        UriEnteringVCModel _urlModelView = new UriEnteringVCModel();
                        _urlModelView.OkHandler += ((sender, args) =>
                        {
                            UriEventArgs e = args as UriEventArgs;
                            _packModel.MainData.TitleImage = e.Uri.FirstOrDefault();
                        });
                        _urlModelView.CloseHandler += (() => CurrentPage = null);
                        CurrentPage = _urlModelView;
                    }));
            }
        }

        #endregion

        #region SCREENSHOTS_DATA

        protected ScreenshotDataModel _selectedScreenshot;

        protected string _screenshotUrl;

        public ScreenshotDataModel SelectedScreenshot
        {
            get => _selectedScreenshot;
            set => SetProperty(ref _selectedScreenshot, value, "SelectedScreenshot");
        }

        public string ScreenshotUrl
        {
            get => _screenshotUrl;
            set => _screenshotUrl = value;
        }

        private RellayCommand _addScrinshotsForUrlCommand;

        private RellayCommand _addScreenshotsForFilesCommand;

        private RellayCommand _removieScreenshotCommand;

        private RellayCommand _clearScreenshotsCollectionCommand;

        private RellayCommand _enterScreenUrlCommand;


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

        public RellayCommand EnterScreenUrlCommand
        {
            get
            {
                return _enterScreenUrlCommand ??
                    (_enterScreenUrlCommand = new RellayCommand(obj =>
                    {
                        _packModel.MainData.Screenshots.Add(new ScreenshotDataModel()
                        {
                            Path = _screenshotUrl
                        });
                        ScreenshotUrl = null;
                    }));
            }
        }

        #endregion

        #endregion

        #region ADDITIONALLY_DATA

        protected List<DtoPairModel> _countries;

        protected List<DtoPairModel> _genres;

        protected List<DtoPairModel> _companies;

        protected List<string> _releaseAuthors;

        protected List<DtoPairModel> _regisseurs;

        protected List<DtoPairModel> _screenwriters;

        protected List<DtoPairModel> _actors;

        public List<DtoPairModel> Countries
        {
            get => _countries;
            set => _countries = value;
        }

        public List<DtoPairModel> Genres
        {
            get => _genres;
            set => _genres = value;
        }

        public List<DtoPairModel> Companies
        {
            get => _companies;
            set => _companies = value;
        }

        public List<string> ReleaseAuthors
        {
            get => _releaseAuthors;
            set => _releaseAuthors = value;
        }

        public List<DtoPairModel> Regisseurs
        {
            get => _regisseurs;
            set => _regisseurs = value;
        }

        public List<DtoPairModel> Screenwriters
        {
            get => _screenwriters;
            set => _screenwriters = value;
        }

        public List<DtoPairModel> Actors
        {
            get => _actors;
            set => _actors = value;
        }

        #endregion

        #region SERIAL_DATA

        protected List<string> _serialTypes;

        public List<string> SerialTypes
        {
            get { return _serialTypes; }
            set { _serialTypes = value; }
        }

        protected private string _episodes;

        public string Episodes
        {
            get => _episodes;
            set => SetProperty(ref _episodes, value, "Episodes");
        }

        #endregion

        #region MEDIA_DATA

        #region VIDEO_DATA

        protected VideoDataModel _selectedVideoItem;

        protected List<string> _videoQuality;

        protected List<string> _videoRelation;

        protected List<ushort> _videoResolutionWidth;

        protected List<ushort> _videoResolutionHeigth;

        protected List<string> _videoFormats;

        public VideoDataModel SelectedVideoItem
        {
            get => _selectedVideoItem;
            set => _selectedVideoItem = value;
        }

        public List<string> VideoFormats
        {
            get => _videoFormats;
            set => _videoFormats = value;
        }

        public List<string> VideoQuality
        {
            get => _videoQuality;
            set => _videoQuality = value;
        }

        public List<string> VideoRelation
        {
            get => _videoRelation;
            set => _videoRelation = value;
        }

        public List<ushort> VideoResolutionWidth
        {
            get => _videoResolutionWidth;
            set => _videoResolutionWidth = value;
        }

        public List<ushort> VideoResolutionHeigth
        {
            get => _videoResolutionHeigth;
            set => _videoResolutionHeigth = value;
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

        protected AudioDataModel _selectedAudioItem;

        protected List<string> _audioFormat;

        protected List<string> _audioChannel;

        protected List<string> _audioLanguage;

        protected List<string> _audioAuthor;

        public AudioDataModel SelectedAudioItem
        {
            get => _selectedAudioItem;
            set => SetProperty(ref _selectedAudioItem, value, "SelectedAudioItem");
        }

        public List<string> AudioFormat
        {
            get => _audioFormat;
            set => _audioFormat = value;
        }

        public List<string> AudioChannel
        {
            get => _audioChannel;
            set => _audioChannel = value;
        }

        public List<string> AudioLanguage
        {
            get => _audioLanguage;
            set => _audioLanguage = value;
        }

        public List<string> AudioAuthor
        {
            get => _audioAuthor;
            set => _audioAuthor = value;
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

        protected SubtitleDataModel _selectedSubtitleItem;

        protected List<string> _subtitleLanguage;

        protected List<string> _subtitleAuthor;

        protected List<string> _subtitleFormat;

        public SubtitleDataModel SelectedSubtitleItem
        {
            get => _selectedSubtitleItem;
            set => SetProperty(ref _selectedSubtitleItem, value, "SelectedSubtitleItem");
        }

        public List<string> SubtitleLanguage
        {
            get => _subtitleLanguage;
            set => _subtitleLanguage = value;
        }

        public List<string> SubtitleAuthor
        {
            get => _subtitleAuthor;
            set => _subtitleAuthor = value;
        }

        public List<string> SubtitleFormat
        {
            get => _subtitleFormat;
            set => _subtitleFormat = value;
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

        #region INITIALIZATION

        public RecordEditorBaseModel(LoadRepository repository, PropertyLibrary config)
        {
            _repository = repository;
            _configModel = config;
            _fileAdmin = new ImageFileAdmin();

            _countries = _repository.GetCountiesList();
            _genres = _repository.GetGenresList();
            _companies = _repository.GetCompaniesList();
            _releaseAuthors = _repository.GetReleaseAuthorsList();
            _regisseurs = _repository.GetProducersList();
            _screenwriters = _repository.GetScreenwritersList();
            _actors = _repository.GetActorsList();

            _serialTypes = _repository.GetSerialTypeList();

            _videoQuality = _repository.GetVideoQualityList();
            _videoRelation = _repository.GetVideoRelationList();
            _videoResolutionWidth = _repository.GetVideoWidthList();
            _videoResolutionHeigth = _repository.GetVideoHeightList();
            _videoFormats = _repository.GetVideoFormatsList();

            _audioFormat = _repository.GetAudioFormatsList();
            _audioChannel = _repository.GetAudioChanelsList();
            _audioLanguage = _repository.GetAudioLanguagesList();
            _audioAuthor = _repository.GetAudioAuthorsList();

            _subtitleLanguage = _repository.GetSubtitleLanguagesList();
            _subtitleAuthor = _repository.GetSubtitleAuthorsList();
            _subtitleFormat = _repository.GetSubtitlesFormatList();
        }

        #endregion
    }
}
