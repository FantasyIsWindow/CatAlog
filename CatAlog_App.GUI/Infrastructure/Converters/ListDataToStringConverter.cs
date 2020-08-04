using CatAlog_App.GUI.Models;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace CatAlog_App.GUI.Infrastructure.Converters
{
    public class ListDataToStringConverter : IValueConverter
    {
        //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //    {
        //        if (value != null && value is ObservableCollection<PairModel> list)
        //        {
        //            StringBuilder builder = new StringBuilder();
        //            foreach (var item in list)
        //            {
        //                builder.Append(item.Name + ", ");
        //            }
        //            return builder;
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
