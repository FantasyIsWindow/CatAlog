using Ookii.Dialogs.Wpf;

namespace CatAlog_App.GUI.Infrastructure.Services
{
    /// <summary>
    /// Contains static methods for working with file dialogs
    /// </summary>
    public static class OpenDialogManager
    {
        private static readonly string _imageFilter = "*.jpg|*.jpg|*.png|*.png|*.jpeg|*.jpeg|All files|*.*";

        /// <summary>
        /// Open the file selection menu
        /// </summary>
        /// <returns>Path to selected file</returns>
        public static string OpenFileDialog()
        {
            var fileDialog = DialogInitialisation();
            if (fileDialog.ShowDialog() == true)
            {
                return fileDialog.FileName;
            }

            return null;
        }

        /// <summary>
        /// Open the files selection menu
        /// </summary>
        /// <returns>Path to selected files</returns>
        public static string[] OpenFilesDialog()
        {
            var fileDialog = DialogInitialisation();
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() == true)
            {
                return fileDialog.FileNames;
            }

            return null;
        }

        /// <summary>
        /// Initializing the file dialog
        /// </summary>
        /// <returns>Vista Open File Dialog</returns>
        private static VistaOpenFileDialog DialogInitialisation()
        {           
            VistaOpenFileDialog fileDialog = new VistaOpenFileDialog();
            fileDialog.Filter = _imageFilter;
            fileDialog.FilterIndex = 2;
            return fileDialog;
        }

        /// <summary>
        /// Open folder dialog
        /// </summary>
        /// <param name="extension">Extension to search for</param>
        /// <returns>Selected path</returns>
        public static string OpenFolderDialog(string extension)
        {
            VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog();
            if (dialog.ShowDialog().HasValue)
            {
                string pattern = '*' + extension;
                var paths = FileManager.GetFiles(dialog.SelectedPath, pattern);
                if (paths.Length != 0)
                {
                    return paths[0];
                }
                else
                {
                    return dialog.SelectedPath;
                }
            }
            return null;
        }
    }
}
