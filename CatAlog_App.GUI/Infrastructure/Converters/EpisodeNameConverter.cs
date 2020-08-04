using CatAlog_App.GUI.Models;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace CatAlog_App.GUI.Infrastructure.Converters
{
    public class EpisodeNameConverter : IValueConverter
    {
        //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //    {
        //        if (value != null && value is ObservableCollection<EpisodeViewModel> info)
        //        {
        //            if (info.Count != 0)
        //            {
        //                StringBuilder builder = new StringBuilder();
        //                for (int i = 0; i < info.Count; i++)
        //                {
        //                    builder.Append($"{info[i].Number}. {info[i].Name}.\n");
        //                }
        //                return builder.ToString();
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
