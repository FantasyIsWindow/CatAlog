using CatAlog_App.Db.DtoModels;
using System.Collections.ObjectModel;

namespace CatAlog_App.GUI.Models
{
    public class CatalogHierarchyModel : ModelBase
    {
        private DtoCatalogHierarchy _model;

        private ObservableCollection<CategoryModel> _categories;

        public CatalogHierarchyModel(DtoCatalogHierarchy model)
        {
            _model = model;
            _categories = new ObservableCollection<CategoryModel>();
            model.Categories.ForEach(c => _categories.Add(new CategoryModel(c)));
        }

        public string Name
        {
            get => _model.TemplateName;
            set
            {
                _model.TemplateName = value;
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
        private DtoCategory _category;

        public CategoryModel(DtoCategory category)
        {
            _category = category;
        }

        public string Type
        {
            get => _category.CategoryName;
            set
            {
                _category.CategoryName = value;
                OnPropertyChanged("Type");
            }
        }

        public ushort Count
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
