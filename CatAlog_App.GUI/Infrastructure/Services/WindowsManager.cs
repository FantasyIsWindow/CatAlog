using CatAlog_App.GUI.Views.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CatAlog_App.GUI.Infrastructure.Services
{
    public class WindowsManager : DependencyObject, INotifyPropertyChanged
    {
        private TempWindow _tempWindow = null;

        public static readonly DependencyProperty TitleProperty;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        static WindowsManager()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(WindowsManager));
        }

        protected virtual void Closed()
        { }

        public bool Close()
        {
            if (_tempWindow != null)
            {
                _tempWindow.Close();
                _tempWindow = null;
                return true;
            }
            return false;
        }

        protected void ShowDialog(WindowsManager model)
        {
            model._tempWindow = new TempWindow();
            model._tempWindow.DataContext = model;
            model._tempWindow.Closed += (sender, e) => Close();
            model._tempWindow.ShowDialog();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected void SetProperty<T>(ref T storage, T value, string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return;
            }
            storage = value;
            OnPropertyChanged(propertyName);
        }
    }
}
