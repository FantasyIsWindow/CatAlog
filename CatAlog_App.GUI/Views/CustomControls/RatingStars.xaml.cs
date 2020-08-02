using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CatAlog_App.GUI.Views.CustomControls
{
    public partial class RatingStars : UserControl
    {
        public static readonly DependencyProperty NewValueProperty;

        public static readonly DependencyProperty TrackColorProperty;

        public static readonly DependencyProperty IndicatorColorProperty;

        public float NewValue
        {
            get => (float)GetValue(NewValueProperty);
            set => SetValue(NewValueProperty, value);
        }

        public Brush TrackColor
        {
            get => (Brush)GetValue(TrackColorProperty);
            set => SetValue(TrackColorProperty, value);
        }

        public Brush IndicatorColor
        {
            get => (Brush)GetValue(IndicatorColorProperty);
            set => SetValue(IndicatorColorProperty, value);
        }

        public RatingStars()
        {
            InitializeComponent();
        }

        static RatingStars()
        {
            NewValueProperty = DependencyProperty.Register("NewValue", typeof(float), typeof(RatingStars), new FrameworkPropertyMetadata(0f, new PropertyChangedCallback(SetNewValueData)));
            TrackColorProperty = DependencyProperty.Register("TrackColor", typeof(Brush), typeof(RatingStars), new FrameworkPropertyMetadata(Brushes.Transparent, new PropertyChangedCallback(SetTrackColorData)));
            IndicatorColorProperty = DependencyProperty.Register("IndicatorColor", typeof(Brush), typeof(RatingStars), new FrameworkPropertyMetadata(Brushes.White, new PropertyChangedCallback(SetIndicatorColorData)));
        }

        private static void SetNewValueData(DependencyObject d, DependencyPropertyChangedEventArgs e) =>
            ((RatingStars)d).SetNewValue();

        private static void SetTrackColorData(DependencyObject d, DependencyPropertyChangedEventArgs e) =>
            ((RatingStars)d).SetTrackColor();

        private static void SetIndicatorColorData(DependencyObject d, DependencyPropertyChangedEventArgs e) =>
            ((RatingStars)d).SetIndicatorColor();

        private void SetNewValue()
        {
            if (NewValue >= starsBar.Minimum && NewValue <= starsBar.Maximum)
            {
                starsBar.Value = NewValue;
            }
        }

        private void SetTrackColor() =>
            starsBar.Background = TrackColor;

        private void SetIndicatorColor() =>
            starsBar.Foreground = IndicatorColor;
    }
}
