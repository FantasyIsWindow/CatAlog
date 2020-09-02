using CatAlog_App.ConfigurationWorker;
using CatAlog_App.Db.Repositories;
using CatAlog_App.GUI.Infrastructure.Services;
using CatAlog_App.GUI.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

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
        private ImageAdmin _imageAdmin;

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
            _imageAdmin = new ImageAdmin();
            
            FillTreeViewData();
        }

        private RellayCommand _treeViewSelectionChangedCommand;
        private RellayCommand _listBoxSelectionChangedCommand;
        private RellayCommand _openTemplateSelectionViewCommand;
        private RellayCommand _removieSelectedRecordCommand;
        private RellayCommand _dbAddCommand;
        private RellayCommand _updateSelectedRecordCommand;

        public RellayCommand TreeViewSelectionChangedCommand
        {
            get 
            {
                return _treeViewSelectionChangedCommand ??
                    (_treeViewSelectionChangedCommand = new RellayCommand(obj =>
                    {
                        if (obj is CategoryModel model)
                        {
                            _selectedCategoryModel = model;
                            FillListBoxData();
                        }
                    }));
            }
        }

        public RellayCommand ListBoxSelectionChangedCommand
        {
            get
            {
                return _listBoxSelectionChangedCommand ??
                    (_listBoxSelectionChangedCommand = new RellayCommand(obj =>
                    {
                        if (_selectedShortRecordModel != null)
                        {
                            MainInfoModel = new DataPackModel(_loadDb.GetFullVideoData(_selectedShortRecordModel.Id));
                        }

                    }));
            }
        }

        public RellayCommand OpenTemplateSelectionViewCommand
        {
            get
            {
                return _openTemplateSelectionViewCommand ??
                    (_openTemplateSelectionViewCommand = new RellayCommand(obj =>
                    {
                        var tSelectionVC = new TemplateSelectionVCModel(_loadDb);
                        tSelectionVC.CloseHandler += (() => ViewContent = null);
                        tSelectionVC.OkHandler += ((sender, e) => OpenEditorRecordWindow(sender, e));
                        ViewContent = tSelectionVC;
                    }));
            }
        }

        public RellayCommand RemovieSelectedRecordCommand
        {
            get
            {
                return _removieSelectedRecordCommand ??
                    (_removieSelectedRecordCommand = new RellayCommand(obj =>
                    {
                        uint id = MainInfoModel.MainData.Id;
                        _deleteDb.RemoveRecord(id);
                        string pathToFolder = Path.GetDirectoryName(MainInfoModel.MainData.TitleImage);
                        FileManager.DeleteFolder(pathToFolder);
                        _displayedCollection.Remove(_selectedShortRecordModel);
                        _selectedCategoryModel.Count--;
                    },
                        (obj) => MainInfoModel != null
                    ));
            }
        }

        public RellayCommand DbAddCommand
        {
            get
            {
                return _dbAddCommand ??
                    (_dbAddCommand = new RellayCommand(obj =>
                    {
                        var dbOptions = new NewDataBaseOptionsVCModel();
                        dbOptions.CloseHandler += (() => ViewContent = null);
                        dbOptions.OkHandler += (() => CreateNewDb());
                        ViewContent = dbOptions;

                    }));
            }
        }

        public RellayCommand UpdateSelectedRecordCommand
        {
            get
            {
                return _updateSelectedRecordCommand ??
                    (_updateSelectedRecordCommand = new RellayCommand(obj =>
                    {
                        var updaterRecord = new UpdaterRecordViewModel(MainInfoModel, _loadDb, _settingsManager.Settings)
                        {
                            Title = $"Editing {MainInfoModel.MainData.Name.FirstName} record"
                        };
                        ShowDialog(updaterRecord);
                    },
                        (obj) => MainInfoModel != null
                    ));
            }
        }

        /// <summary>
        /// Open a window for editing a new entry
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Packed data about the template and category of the new entry</param>
        private void OpenEditorRecordWindow(object sender, EventArgs e)
        {
            var arg = e as ViewControlEventArgs;
            var baseModel = new CreatorRecordViewModel(arg.FirstValue, arg.SecondValue, _loadDb, _settingsManager.Settings)
            {
                Title = $"Filling in a new {arg.FirstValue.ToLower()} record"
            };
            baseModel.OkHandler += ((sender, obj) => CategoryUpdate(arg.FirstValue, arg.SecondValue, obj));
            ShowDialog(baseModel);
        }

        /// <summary>
        /// Updating information about the number of categories
        /// </summary>
        /// <param name="template">The template with the updated data</param>
        /// <param name="category">The category with the updated data</param>
        /// <param name="obj">Packaged id number of the added record</param>
        private void CategoryUpdate(string template, string category, EventArgs obj)
        {
            if (_selectedCategoryModel != null)
            {
                _selectedCategoryModel.Count++;
                uint id = (obj as CreateEvent).Id;
                var record = _loadDb.GetShortInfo(id);
                _displayedCollection.Add(new ShortRecordInfoModel(record));
            }
            else
            {
                var cat = _categoryHierarhy.FirstOrDefault(n => n.Name == template);
                cat.Categories.FirstOrDefault(c => c.Type == category).Count++;
            }
        }

        /// <summary>
        /// Creating a new database context and updating the tree view
        /// </summary>
        private void CreateNewDb()
        {
            _loadDb = new LoadRepository();
            Crear();
            FillTreeViewData();
            MainInfoModel = null;
        }

        /// <summary>
        /// Filling in tree data
        /// </summary>
        private void FillTreeViewData()
        {
            var result = _loadDb.GetHierarchy();
            _categoryHierarhy?.Clear();
            result.ForEach(d => _categoryHierarhy.Add(new CatalogHierarchyModel(d)));
        }

        /// <summary>
        /// Filling in the main list with information
        /// </summary>
        private void FillListBoxData()
        {
            Crear();
            string categoryName = _selectedCategoryModel.Type;
            var resultCollection = _loadDb.GetShortInfo(categoryName);
            resultCollection.ForEach(d => DisplayedCollection.Add(new ShortRecordInfoModel(d)));
        }

        /// <summary>
        /// Data cleaning
        /// </summary>
        private void Crear()
        {
            DisplayedCollection?.Clear();
            MainInfoModel = null;
        }
    }
}
