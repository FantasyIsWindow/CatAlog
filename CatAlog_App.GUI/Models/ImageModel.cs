using System.Windows.Media;

namespace CatAlog_App.GUI.Models
{
    public class ImageModel 
    {
        public string Name { get; set; }

        public ImageSource Icon { get; set; }

        public ImageModel(string name, ImageSource icon)
        {
            Name = name;
            Icon = icon;
        }
    }
}
