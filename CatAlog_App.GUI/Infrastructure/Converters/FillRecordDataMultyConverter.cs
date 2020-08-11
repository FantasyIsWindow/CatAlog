using System;
using System.Globalization;
using System.Windows.Data;

namespace CatAlog_App.GUI.Infrastructure.Converters
{
    public class FillRecordDataMultyConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var item in values)
            {
                string temp = item as string;

                if (IsNullOrSpaces(temp))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsNullOrSpaces(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return true;
            }

            foreach (var symbol in str)
            {
                if (symbol != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
