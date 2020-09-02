using CatAlog_App.Db.Repositories;
using CatAlog_App.GUI.Infrastructure.Services;
using System;
using System.Collections.Generic;

namespace CatAlog_App.GUI.ViewModels
{
    public class ViewControlEventArgs : EventArgs
    {
        public string FirstValue { get; set; }

        public string SecondValue { get; set; }
    }

    public class TemplateSelectionVCModel : ViewControlsBaseModel
    {
        public event EventHandler OkHandler;

        private string _selectedTemplate;
        private string _selectedCategory;
        private string _newGeneralType;
        private LoadRepository _repository;

        public List<string> Templates { get; }

        public List<string> Categories { get; }

        public string NewGeneralType
        {
            set => SetProperty(ref _newGeneralType, value, "NewGeneralType");
        }

        public string SelectedTemplate
        {
            set => SetProperty(ref _selectedTemplate, value, "SelectedTemplate");
        }

        public string SelectedCategory
        {
            set => SetProperty(ref _selectedCategory, value, "SelectedCategory");
        }

        public TemplateSelectionVCModel(LoadRepository repository)
        {
            _repository = repository;
            Templates = repository.GetTemplates();
            Categories = repository.GetCategories();
            Categories.Add("-- New record type --");
        } 

        public RellayCommand OkCommand
        {
            get
            {
                return _okCommand ??
                    (_okCommand = new RellayCommand(obj =>
                    {
                        CloseCommand.Execute(null);
                        string type = !string.IsNullOrEmpty(_newGeneralType) ? _newGeneralType : _selectedCategory;
                        if (OkHandler != null)
                        {

                            ViewControlEventArgs args = new ViewControlEventArgs()
                            {
                                FirstValue = _selectedTemplate,
                                SecondValue = _selectedCategory
                            };

                            OkHandler.Invoke(this, args); 
                        }
                    }));
            }
        }
    }
}
