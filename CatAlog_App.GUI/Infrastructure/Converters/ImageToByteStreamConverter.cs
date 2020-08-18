using CatAlog_App.GUI.Infrastructure.Constants;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CatAlog_App.GUI.Infrastructure.Converters
{
    public class ImageToByteStreamConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                if (!File.Exists(str))
                {
                    return OtherConstants.TitleImageDummy;
                }
                else
                {
                    byte[] data = File.ReadAllBytes(str);
                    BitmapImage source = new BitmapImage();
                    source.BeginInit();
                    source.StreamSource = new MemoryStream(data);
                    source.EndInit();
                    ImageSource imageSource = source;
                    return imageSource;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
