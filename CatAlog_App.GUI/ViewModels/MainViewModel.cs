using CatAlog_App.ConfigurationWorker;
using CatAlog_App.Db.Repositories;
using CatAlog_App.GUI.Infrastructure.Services;
using CatAlog_App.GUI.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace CatAlog_App.GUI.ViewModels
{
    public class MainViewModel : WindowsManager
    {
        private LoadRepository _loadDb;
        private DeleteRepository _deleteDb;
        private CategoryModel _selectedCategoryModel;
        private ShortRecordInfoModel _selectedShortRecordModel;
        private DataPackModel _mainInfoModel;
        private ObservableCollection<CatalogHierarchyModel> _categoryHierarhy;
        private ObservableCollection<ShortRecordInfoModel> _displayedCollection;
        private object _viewContent;
        private SettingsManager _settingsManager;
        private ImageFileAdmin _imageAdmin;

        public ObservableCollection<CatalogHierarchyModel> CategoryHierarhy
        {
            get => _categoryHierarhy;
            set => _categoryHierarhy = value;
        }

        public ObservableCollection<ShortRecordInfoModel> DisplayedCollection
        {
            get => _displayedCollection; 
            set => _displayedCollection = value; 
        }

        public DataPackModel MainInfoModel
        {
            get => _mainInfoModel;
            set => SetProperty(ref _mainInfoModel, value, "MainInfoModel");
        }

        public object ViewContent
        {
            get => _viewContent;
            set => SetProperty(ref _viewContent, value, "ViewContent");
        }

        public ShortRecordInfoModel SelectedShortRecordModel
        {
            get => _selectedShortRecordModel;
            set => SetProperty(ref _selectedShortRecordModel, value, "SelectedShortRecordModel");
        }

        public MainViewModel()
        {
            _loadDb = new LoadRepository();
            _deleteDb = new DeleteRepository();
            _categoryHierarhy = new ObservableCollection<CatalogHierarchyModel>();
            _displayedCollection = new ObservableCollection<ShortRecordInfoModel>();
            _settingsManager = new SettingsManager();
            _imageAdmin = new ImageFileAdmin();
            GetDataForTreeView();
        }

        private RellayCommand _treeViewSelectionChanged;
        private RellayCommand _listBoxSelectionChanged;
        private RellayCommand _openTemplateSelectionView;
        private RellayCommand _removieSelectedRecord;
        private RellayCommand _dbAdd;
        private RellayCommand _updateSelectedRecord;

        public RellayCommand TreeViewSelectionChanged
        {
            get 
            {
                return _treeViewSelectionChanged ??
                    (_treeViewSelectionChanged = new RellayCommand(obj =>
                    {
                        if (obj is CategoryModel model)
                        {
                            _selectedCategoryModel = model;
                            FillDataList();
                        }
                    }));
            }
        }

        public RellayCommand ListBoxSelectionChanged
        {
            get
            {
                return _listBoxSelectionChanged ??
                    (_listBoxSelectionChanged = new RellayCommand(obj =>
                    {
                        if (_selectedShortRecordModel != null)
                        {
                            MainInfoModel = new DataPackModel(_loadDb.GetFullVideoData(_selectedShortRecordModel.Id));
                        }

                    }));
            }
        }

        public RellayCommand OpenTemplateSelectionView
        {
            get
            {
                return _openTemplateSelectionView ??
                    (_openTemplateSelectionView = new RellayCommand(obj =>
                    {
                        TemplateSelectionVCModel tSelectionVC = new TemplateSelectionVCModel(_loadDb);
                        tSelectionVC.CloseHandler += (() => ViewContent = null);
                        tSelectionVC.OkHandler += ((sender, e) => OpenEditorRecordWindow(sender, e));
                        ViewContent = tSelectionVC;
                    }));
            }
        }

        public RellayCommand RemovieSelectedRecord
        {
            get
            {
                return _removieSelectedRecord ??
                    (_removieSelectedRecord = new RellayCommand(obj =>
                    {
                        uint id = MainInfoModel.MainData.Id;
                        _deleteDb.RemoveRecord(id);
                        string pathToFolder = Path.GetDirectoryName(MainInfoModel.MainData.TitleImage);
                        _imageAdmin.DeleteFolder(pathToFolder);
                        _displayedCollection.Remove(_selectedShortRecordModel);
                        _selectedCategoryModel.Count -= 1;
                    },
                        (obj) => MainInfoModel != null
                    ));
            }
        }

        public RellayCommand DbAdd
        {
            get
            {
                return _dbAdd ??
                    (_dbAdd = new RellayCommand(obj =>
                    {
                        NewDataBaseOptionsVCModel dbOptions = new NewDataBaseOptionsVCModel();
                        dbOptions.CloseHandler += (() => ViewContent = null);
                        dbOptions.OkHandler += (() => CreateNewDb());
                        ViewContent = dbOptions;

                    }));
            }
        }
        private void OpenEditorRecordWindow(object sender, EventArgs e)
        {
            ViewControlEventArgs eventArgs = e as ViewControlEventArgs;
            CreatorRecordViewModel baseModel = new CreatorRecordViewModel(eventArgs.FirstValue, eventArgs.SecondValue, _loadDb, _settingsManager.Settings)
            {
                Title = $"Filling in a new {eventArgs.FirstValue.ToLower()} record"
            };
            baseModel.OkHandler += (() => _selectedCategoryModel.Count += 1); // Ошибка при отсутствии выбора в дереве
            ShowDialog(baseModel);
        }

        public RellayCommand UpdateSelectedRecord
        {
            get
            {
                return _updateSelectedRecord ??
                    (_updateSelectedRecord = new RellayCommand(obj =>
                    {
                        UpdaterRecordViewModel updaterRecord = new UpdaterRecordViewModel(MainInfoModel, _loadDb, _settingsManager.Settings)
                        {
                            Title = $"Editing {MainInfoModel.MainData.Name.FirstName} record"
                        };
                        ShowDialog(updaterRecord);
                    },
                        (obj) => MainInfoModel != null
                    ));
            }
        }

        private void CreateNewDb()
        {
            throw new NotImplementedException();
        }

        private void GetDataForTreeView()
        {
            var result = _loadDb.GetHierarchy();
            result.ForEach(d => _categoryHierarhy.Add(new CatalogHierarchyModel(d)));
        }

        private void FillDataList()
        {
            DisplayedCollection.Clear();
            string categoryName = _selectedCategoryModel.Type;
            var resultCollection = _loadDb.GetShortInfo(categoryName);
            resultCollection.ForEach(d => DisplayedCollection.Add(new ShortRecordInfoModel(d)));
        }
    }
}
