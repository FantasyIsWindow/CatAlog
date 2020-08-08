using System;
using System.Globalization;
using System.Windows.Data;

namespace CatAlog_App.GUI.Infrastructure.Converters
{
    public class TemplateSelectionCVMultyConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string _template = values[0] as string;
            string _recordType = values[1] as string;
            string _newRecordType = values[2] as string;

            if (!string.IsNullOrEmpty(_template))
            {
                if (!string.IsNullOrEmpty(_recordType) && _recordType != "-- New record type --")
                {
                    return true;
                }
                else if (!string.IsNullOrEmpty(_recordType) && _recordType == "-- New record type --")
                {
                    if (!string.IsNullOrEmpty(_newRecordType))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
