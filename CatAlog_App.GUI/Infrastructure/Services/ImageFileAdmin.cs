using CatAlog_App.GUI.Infrastructure.Constants;
using System.Collections.Generic;
using System.IO;
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Resources;
using System.Drawing;
using CatAlog_App.GUI.Models;
using System.Collections.ObjectModel;

namespace CatAlog_App.GUI.Infrastructure.Services
{
    public class ImageFileAdmin
    {
        public string SaveTitleImage(string pathToImage, string newPath, string fileName)
        {
            string filePath = Path.Combine(newPath, fileName);
            DeleteExistingFile(newPath, fileName);
            return CopyFile(pathToImage, filePath);
        }

        public void SaveScreenshots(ObservableCollection<ScreenshotDataModel> screenshots, string newPath)
        {
            int index = 0;

            for (int i = 0; i < screenshots.Count; i++)
            {
                string filePath = GetNewName(ref index, newPath, screenshots[i]);
                screenshots[i].Path = CopyFile(screenshots[i].Path, filePath);
            }
        }

        public void CreateNewFolder(string newPath)
        {
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
        }

        private void DeleteExistingFile(string newPath, string fileName)
        {
            string name = fileName.Split('.')[0];
            string template = name + ".*";
            var existingFiles = Directory.GetFiles(newPath, template, SearchOption.TopDirectoryOnly);
            for (int i = 0; i < existingFiles.Length; i++)
            {
                File.Delete(existingFiles[i]);
            }
        }

        public void DeleteScreenshotFiles(ObservableCollection<ScreenshotDataModel> screenshots)
        {
            foreach (var item in screenshots)
            {
                string folderPath = Path.GetDirectoryName(item.Path);
                string pattern = Path.GetFileName(item.Path);
                var existingFiles = Directory.GetFiles(folderPath, pattern, SearchOption.TopDirectoryOnly);
                for (int i = 0; i < existingFiles.Length; i++)
                {
                    File.Delete(existingFiles[i]);
                }
            }
        }

        public void DeleteFolder(string folderPath)
        {
            Directory.Delete(folderPath, true);
        }

        public void RenameFolder(string oldPath, string newPath)
        {
            Directory.Move(oldPath, newPath);
        }

        private string GetNewName(ref int index, string newPath, ScreenshotDataModel screenshot)
        {
            string number = "";
            for (; ; index++)
            {
                number = index >= 10 ? index.ToString() : '0' + index.ToString();
                var existingFiles = Directory.GetFiles(newPath, number + ".*", SearchOption.TopDirectoryOnly);
                if (existingFiles.Length == 0)
                {
                    break;
                }
            }
            return Path.Combine(newPath, number);
        }

        private string CopyFile(string pathToImage, string newPath)
        {
            newPath += Path.GetExtension(pathToImage);
            if (pathToImage.Contains("/Resources/Images/"))
            {
                StreamResourceInfo res = Application.GetResourceStream(new Uri(pathToImage, UriKind.Relative));
                using var fileStream = new FileStream(newPath, FileMode.OpenOrCreate) { Position = 0 };
                res.Stream.CopyTo(fileStream);
                fileStream.Flush();
            }
            else
            {
                Image image;
                if (IsUrl(pathToImage))
                {
                    using WebClient webClient = new WebClient();
                    byte[] arr = webClient.DownloadData(pathToImage);
                    MemoryStream stream = new MemoryStream(arr);
                    image = ImageResize(Image.FromStream(stream));
                }
                else
                {
                    image = Image.FromFile(pathToImage);
                }

                image = ImageResize(image);
                image.Save(newPath);
            }
            return newPath;
        }

        private bool IsUrl(string path) =>
            Regex.IsMatch(path, RegexConstants.HttpPattern, RegexOptions.Compiled);

        private Image ImageResize(Image image)
        {
            if (image.Height > 500)
            {
                float part = image.Height / 500f;
                float newHeight = image.Height / part;
                float newWidth = image.Width / part;
                var size = new System.Drawing.Size((int)newWidth, (int)newHeight);
                return (Image)(new Bitmap(image, size));
            }
            return image;
        }
    }
}
