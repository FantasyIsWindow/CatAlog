using CatAlog_App.DbWorker.DtoModels;
using System.Collections.ObjectModel;

namespace CatAlog_App.GUI.Models
{
    public class CatalogShemaModel : ModelBase
    {
        private DtoCatalogShemaModel _model;

        private ObservableCollection<CategoryModel> _categories;

        public CatalogShemaModel(DtoCatalogShemaModel model)
        {
            _model = model;
            _categories = new ObservableCollection<CategoryModel>();
            model.Categories.ForEach(c => _categories.Add(new CategoryModel(c)));
        }

        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public ObservableCollection<CategoryModel> Categories
        {
            get => _categories;
            set => _categories = value;
        }
    }

    public class CategoryModel : ModelBase
    {
        private DtoCategoryModel _category;

        public CategoryModel(DtoCategoryModel category)
        {
            _category = category;
        }

        public string Type
        {
            get => _category.Type;
            set
            {
                _category.Type = value;
                OnPropertyChanged("Type");
            }
        }

        public int Count
        {
            get => _category.Count;
            set
            {
                _category.Count = value;
                OnPropertyChanged("Count");
            }
        }
    }
}
