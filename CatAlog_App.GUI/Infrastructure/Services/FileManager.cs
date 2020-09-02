using System.IO;

namespace CatAlog_App.GUI.Infrastructure.Services
{
    /// <summary>
    /// Contains static methods for working with the file system
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Create a folder or all subfolders in the specified path
        /// </summary>
        /// <param name="path">Path of the folder to create</param>
        public static void CreateNewFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Deleting the specified file
        /// </summary>
        /// <param name="path">Path to the file to delete</param>
        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }

        /// <summary>
        /// Deleting a folder and all content
        /// </summary>
        /// <param name="path">Path to the folder to delete</param>
        public static void DeleteFolder(string path)
        {
            Directory.Delete(path, true);
        }

        /// <summary>
        /// Rename a folder
        /// </summary>
        /// <param name="oldPath">Old path to rename folder</param>
        /// <param name="newPath">New path</param>
        public static void RenameFolder(string oldPath, string newPath)
        {
            Directory.Move(oldPath, newPath);
        }

        /// <summary>
        /// Get the paths of all files in a folder
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="pattern">Search pattern</param>
        /// <returns></returns>
        public static string[] GetFiles(string path, string pattern)
        {
           return Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly);
        }
    }
}
