using System.IO;
using Ookii.Dialogs.Wpf;

namespace CatAlog_App.GUI.Infrastructure.Services
{
    public static class OpenDialogManager
    {
        private static readonly string imageFilter = "(*.jpg)|*.jpg|(*.png)|*.png|(*.jpeg)|*.jpeg";

        private const string DbExpansion = ".db";

        public static string OpenFileDialog()
        {
            var fileDialog = DialogInitialisation(imageFilter);
            if (fileDialog.ShowDialog() == true)
            {
                return fileDialog.FileName;
            }

            return null;
        }

        public static string[] OpenFilesDialog()
        {
            var fileDialog = DialogInitialisation(imageFilter);
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() == true)
            {
                return fileDialog.FileNames;
            }

            return null;
        }

        private static VistaOpenFileDialog DialogInitialisation(string filter)
        {           
            VistaOpenFileDialog fileDialog = new VistaOpenFileDialog();
            fileDialog.Filter = filter;
            fileDialog.FilterIndex = 2;
            return fileDialog;
        }

        public static string OpenFolderDialog()
        {
            VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog();
            if (dialog.ShowDialog().HasValue)
            {
                string selectedPath = dialog.SelectedPath;

                var paths = Directory.GetFiles(selectedPath, '*' + DbExpansion, SearchOption.TopDirectoryOnly);
                if (paths.Length != 0)
                {
                    return paths[0];
                }
                else
                {
                    return selectedPath;
                }
            }
            return null;
        }
    }
}
