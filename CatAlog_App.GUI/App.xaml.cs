using CatAlog_App.GUI.ViewModels;
using CatAlog_App.GUI.Views.Windows;
using Ninject;
using System;
using System.Windows;

namespace CatAlog_App.GUI
{
    public partial class App : Application
    {
        private readonly IKernel _kernel;

        public App()
        {
            _kernel = new StandardKernel();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindowInit();
        }

        private void MainWindowInit()
        {
            var mainVM = _kernel.Get<MainViewModel>();
            MainWindow = new MainWindow();
            MainWindow.DataContext = mainVM;
            MainWindow.Show();
        }
    }
}
