using CatAlog_App.ConfigurationWorker.Model;
using System;
using System.IO;
using System.Xml.Serialization;

namespace CatAlog_App.ConfigurationWorker
{
    public class SettingsManager
    {
        private readonly string ConfigurationFilePath;

        /// <summary>
        /// Application setting
        /// </summary>
        public PropertyLibrary Settings { get; set; }

        public SettingsManager()
        {
            ConfigurationFilePath = Path.Combine(Environment.CurrentDirectory, "settings.xml");
            Settings = new PropertyLibrary();
            if (!File.Exists(ConfigurationFilePath))
            {
                CreateConfigurationFile();
            }
            else
            {
                ReadConfig();
            }
        }

        /// <summary>
        /// Save the new configuration data to a file
        /// </summary>
        public void SaveConfig()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PropertyLibrary));
                using (TextWriter writer = new StreamWriter(ConfigurationFilePath))
                {
                    serializer.Serialize(writer, Settings);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Reading configuration data from a file
        /// </summary>
        public void ReadConfig()
        {
            if (File.Exists(ConfigurationFilePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PropertyLibrary));
                using (TextReader reader = new StreamReader(ConfigurationFilePath))
                {
                    Settings = serializer.Deserialize(reader) as PropertyLibrary;
                }
            }
            else
            {
                throw new Exception("Configuration file not found");
            }
        }

        /// <summary>
        /// Initialize configuration file
        /// </summary>
        private void CreateConfigurationFile()
        {
            Settings.DbFileName = "catalog";
            Settings.Extension = ".db";
            Settings.DbFolderPath = Path.Combine(Environment.CurrentDirectory, "CatAlog DataBase");
            Settings.GraphicDataFolderName = "Image Library";
            Settings.TitleImageName = "title";

            SaveConfig();
        }
    }
}