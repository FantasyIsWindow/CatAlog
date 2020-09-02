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

        private readonly string _placeholder = "Paste the url and press Enter";

        private string _uris;

        public delegate void NotifyDelegate();

        /// <summary>
        /// Event that returns a new collection containing new URLs
        /// </summary>
        public event EventHandler OkHandler;

        /// <summary>
        /// Event for canceling adding new links
        /// </summary>
        public event NotifyDelegate CloseHandler;

        public UriEnteringVCModel()
        {
            _uris = _placeholder;
        }

        public string Urls
        {
            get => _uris;
            set => SetProperty(ref _uris, value, "Urls");
        }

        public string Placeholder
        {
            get => _placeholder;
        }

        private RellayCommand _okCommand;
        private RellayCommand _closeCommand;
        private RellayCommand _gotFocusCommand;
        private RellayCommand _lostFocusCommand;

        public RellayCommand OkCommand
        {
            get
            {
                return _okCommand ??
                       (_okCommand = new RellayCommand(obj =>
                       {
                           if (!string.IsNullOrEmpty(_uris) && _uris != _placeholder)
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
                           _closeCommand.Execute(null);
                       }));
            }
        }

        public RellayCommand CloseCommand =>
            _closeCommand = new RellayCommand(c => CloseHandler?.Invoke());

        public RellayCommand GotFocusCommand
        {
            get
            {
                return _gotFocusCommand ??
                    (_gotFocusCommand = new RellayCommand(obj =>
                    {
                        if (Urls == _placeholder)
                        {
                            Urls = "";
                        }
                    }));
            }
        }

        public RellayCommand LostFocusCommand
        {
            get
            {
                return _lostFocusCommand ??
                    (_lostFocusCommand = new RellayCommand(obj =>
                    {
                        if (string.IsNullOrEmpty(Urls))
                        {
                            Urls = Placeholder;
                        }
                    }));
            }
        }
    }
}