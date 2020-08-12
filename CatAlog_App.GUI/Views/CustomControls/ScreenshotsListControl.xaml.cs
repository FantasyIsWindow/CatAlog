using CatAlog_App.GUI.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace CatAlog_App.GUI.Views.CustomControls
{
    public partial class ScreenshotsListControl : UserControl
    {
        public static readonly DependencyProperty DataListProperty;

        public static readonly DependencyProperty PlacementTargetProperty;

        public ObservableCollection<ScreenshotDataModel> DataList
        {
            get => (ObservableCollection<ScreenshotDataModel>)GetValue(DataListProperty);
            set => SetValue(DataListProperty, value);
        }

        public object PlacementTarget
        {
            get => (object)GetValue(PlacementTargetProperty);
            set => SetValue(PlacementTargetProperty, value);
        }

        public ScreenshotsListControl()
        {
            InitializeComponent();
        }

        static ScreenshotsListControl()
        {
            DataListProperty = DependencyProperty.Register("DataList", typeof(ObservableCollection<ScreenshotDataModel>), typeof(ScreenshotsListControl), new PropertyMetadata(null));
            PlacementTargetProperty = DependencyProperty.Register("PlacementTarget", typeof(object), typeof(ScreenshotsListControl), new PropertyMetadata(null));
        }
    }
}
