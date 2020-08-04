using CatAlog_App.GUI.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace CatAlog_App.GUI.Infrastructure.Converters
{
    public class SerialTypeConverter : IValueConverter
    {
        //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //    {
        //        if (value != null && value is SerialDataModel serial)
        //        {
        //            var seriesCount = serial.Series?.Count;
        //            var isSeries = serial.Series != null ? true : false;
        //            string note = serial.Note != null ? '[' + serial.Note + ']' : "";

        //            if (seriesCount != 0 && serial.CountSpecials != 0)
        //            {
        //                return string.Format($"{serial.Type} ({seriesCount} эп. + {serial.CountSpecials} спзшл.) {note}");
        //            }
        //            else if (seriesCount != 0)
        //            {
        //                return string.Format($"{serial.Type} ({seriesCount} эп.) {note}");
        //            }
        //            else if (!isSeries)
        //            {
        //                return string.Format($"{serial.Type} {note}");
        //            }
        //            else if (!isSeries && serial.CountSpecials == 1)
        //            {
        //                return string.Format($"{serial.Type} - спэшл. {note}");
        //            }
        //        }
        //        return null;
        //    }

        //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        //    {
        //        return null;
        //    }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
