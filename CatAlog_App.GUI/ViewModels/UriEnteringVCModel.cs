using CatAlog_App.GUI.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CatAlog_App.GUI.ViewModels
{
    public class UriEventArgs : EventArgs
    {
        public IEnumerable<string> Uri { get; set; }
    }

    public class UriEnteringVCModel : ModelBase
    {
        private readonly string urlPattern = @"(http|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";

        public delegate void NotifyDelegate();

        /// <summary>
        /// Event that returns a new collection containing new URLs
        /// </summary>
        public event EventHandler OkHandler;

        /// <summary>
        /// Event for canceling adding new links
        /// </summary>
        public event NotifyDelegate CloseHandler;

        private string _uris;

        public string Urls
        {
            get => _uris;
            set => SetProperty(ref _uris, value, "Urls");
        }

        private RellayCommand _okCommand;

        private RellayCommand _closeWindow;

        public RellayCommand OkCommand
        {
            get
            {
                return _okCommand ??
                       (_okCommand = new RellayCommand(obj =>
                       {
                           if (!string.IsNullOrEmpty(_uris))
                           {
                               if (OkHandler != null)
                               {
                                   UriEventArgs args = new UriEventArgs()
                                   {
                                       Uri = _uris.Split(new char[] { '\n', ' ' }).Where(u => Regex.IsMatch(u, urlPattern, RegexOptions.Compiled))
                                   };
                                   OkHandler.Invoke(this, args);
                               }
                           }
                           _closeWindow.Execute(null);
                       }));
            }
        }

        public RellayCommand CloseWindow =>
            _closeWindow = new RellayCommand(c => CloseHandler?.Invoke());
    }
}
