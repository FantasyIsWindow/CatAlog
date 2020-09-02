using CatAlog_App.GUI.Infrastructure.Constants;
using System.IO;
using System;
using System.Windows;
using System.Windows.Resources;
using System.Drawing;
using CatAlog_App.GUI.Models;
using System.Collections.ObjectModel;

namespace CatAlog_App.GUI.Infrastructure.Services
{
    /// <summary>
    /// Contains methods for working with images
    /// </summary>
    public class ImageAdmin
    {
        private HttpManager _httpManager;

        public ImageAdmin()
        {
            _httpManager = new HttpManager();
        }

        /// <summary>
        /// Saves a new title image and replaces the existing one if it exists
        /// </summary>
        /// <param name="currentPath">Current path to image</param>
        /// <param name="newPath">New path to image</param>
        /// <param name="fileName">File name</param>
        /// <returns>Path to saved image</returns>
        public string SaveTitleImage(string currentPath, string newPath, string fileName)
        {
            DeleteExistingFile(newPath, fileName);

            string filePath = Path.Combine(newPath, fileName);
            return CopyFile(currentPath, filePath);
        }

        /// <summary>
        /// Saving a collection of screenshots along the specified path
        /// </summary>
        /// <param name="screenshots">Saved screenshots file collection</param>
        /// <param name="newPath">New path to save screenshots collection</param>
        public void SaveScreenshots(ObservableCollection<ScreenshotDataModel> screenshots, string newPath)
        {
            int index = 0;

            for (int i = 0; i < screenshots.Count; i++)
            {
                string filePath = GetNewName(ref index, newPath, screenshots[i]);
                screenshots[i].Path = CopyFile(screenshots[i].Path, filePath);
            }
        }

        /// <summary>
        /// Deleting the specified file by the specified path
        /// </summary>
        /// <param name="path">Path to the file to delete</param>
        /// <param name="fileName">Name of the file to delete</param>
        private void DeleteExistingFile(string path, string fileName)
        {
            string pattern = fileName + ".*";
            var existingFiles = FileManager.GetFiles(path, pattern);
            for (int i = 0; i < existingFiles.Length; i++)
            {
                FileManager.DeleteFile(existingFiles[i]);
            }
        }

        /// <summary>
        /// Deleting a collection of screenshots
        /// </summary>
        /// <param name="screenshots">Collection of deleted screenshots</param>
        public void DeleteScreenshotFiles(ObservableCollection<ScreenshotDataModel> screenshots)
        {
            foreach (var scr in screenshots)
            {
                string path = Path.GetDirectoryName(scr.Path);
                string pattern = Path.GetFileName(scr.Path);
                var existingFiles = FileManager.GetFiles(path, pattern);
                for (int i = 0; i < existingFiles.Length; i++)
                {
                    FileManager.DeleteFile(existingFiles[i]);
                }
            }
        }

        /// <summary>
        /// Generating the file name
        /// </summary>
        /// <param name="index">Suggested file name</param>
        /// <param name="newPath">New path to save file</param>
        /// <param name="screenshot">Saved screenshot</param>
        /// <returns></returns>
        private string GetNewName(ref int index, string newPath, ScreenshotDataModel screenshot)
        {
            string number = "";
            for (; ; index++)
            {
                number = index >= 10 ? index.ToString() : '0' + index.ToString();
                var existingFiles = FileManager.GetFiles(newPath, number + ".*");
                if (existingFiles.Length == 0)
                {
                    break;
                }
            }
            return Path.Combine(newPath, number);
        }

        /// <summary>
        /// Copy image to new folder
        /// </summary>
        /// <param name="pathToImage">Current path to image</param>
        /// <param name="newPath">New path to image</param>
        /// <returns>PAth to copy image</returns>
        private string CopyFile(string pathToImage, string newPath) // Error
        {
            newPath += Path.GetExtension(pathToImage);
            if (pathToImage.Contains(OtherConstants.TitleImageDummy))
            {
                StreamResourceInfo res = Application.GetResourceStream(new Uri(pathToImage, UriKind.Relative));
                using var fileStream = new FileStream(newPath, FileMode.OpenOrCreate) { Position = 0 };
                res.Stream.CopyTo(fileStream);
                fileStream.Flush();
            }
            else
            {
                Image image = GetImage(pathToImage);                
                image.Save(newPath);
            }
            return newPath;
        }

        /// <summary>
        /// Image acquisition and processing
        /// </summary>
        /// <param name="path">Path to image</param>
        /// <returns>Resulting image</returns>
        private Image GetImage(string path)
        {            
            if (RegexManager.IsUrl(path))
            {
                MemoryStream stream = _httpManager.DownloadFile(path);
                return ImageResize(Image.FromStream(stream));
            }
            else
            {
                return ImageResize(Image.FromFile(path));
            }
        }

        /// <summary>
        /// Changing the image size
        /// </summary>
        /// <param name="image">Image to resize</param>
        /// <returns>Modified image</returns>
        private Image ImageResize(Image image)
        {
            if (image.Height > 500)
            {
                float newHeight = image.Height / (image.Height / 500f);
                float newWidth  = image.Width  / (image.Height / 500f);
                var size = new System.Drawing.Size((int)newWidth, (int)newHeight);
                return new Bitmap(image, size);
            }
            return image;
        }
    }
}
