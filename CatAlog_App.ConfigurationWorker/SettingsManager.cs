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
            ReadConfig();
        }

        /// <summary>
        /// Save the new configuration data to a file
        /// </summary>
        public void SaveConfig()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PropertyLibrary));
            using (TextWriter writer = new StreamWriter(ConfigurationFilePath))
            {
                serializer.Serialize(writer, Settings);
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
    }
}