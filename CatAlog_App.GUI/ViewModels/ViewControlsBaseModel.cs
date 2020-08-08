using CatAlog_App.GUI.Infrastructure.Commands;
using CatAlog_App.GUI.Models;

namespace CatAlog_App.GUI.ViewModels
{
    public class ViewControlsBaseModel : ModelBase
    {
        public delegate void NotifyDelegate();
        public event NotifyDelegate CloseHandler;

        protected RellayCommand _okCommand;

        private RellayCommand _closeCommand;

        public RellayCommand CloseCommand =>
            _closeCommand = new RellayCommand(c => CloseHandler?.Invoke());
    }
}
