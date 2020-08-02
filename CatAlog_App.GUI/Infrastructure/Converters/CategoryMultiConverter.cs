using System;
using System.Globalization;
using System.Windows.Data;

namespace CatAlog_App.GUI.Infrastructure.Converters
{
    public class CategoryMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is string str)
            {
                return str;
            }
            else
            {
                return string.Format("{0} ({1})", values[1], values[2]);
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
