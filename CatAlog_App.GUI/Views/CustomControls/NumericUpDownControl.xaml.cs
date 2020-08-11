using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace CatAlog_App.GUI.Views.CustomControls
{
    public partial class NumericUpDownControl : UserControl
    {
        private const float MAXIMUM = 10f;

        private DispatcherTimer _upTimer;

        public float Rating { get; set; }

        public static readonly DependencyProperty NewWidthProperty;

        public static readonly DependencyProperty NewValueProperty;

        public float NewWidth
        {
            get => (float)GetValue(NewWidthProperty);
            set => SetValue(NewWidthProperty, value);
        }

        public float NewValue
        {
            get => (float)GetValue(NewValueProperty);
            set => SetValue(NewValueProperty, value);
        }

        public string this[string columnName]
        {
            get
            {
                string error = null;
                if (columnName == "Rating")
                {
                    if (this.Rating < 0 || this.Rating > 10)
                    {
                        error = "The rating cannot be less than 0 or more than 10 points";
                    }
                }
                return error;
            }
        }

        public string Error =>
            throw new NotImplementedException();

        public NumericUpDownControl()
        {
            InitializeComponent();

            _upTimer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 80) };
            _upTimer.Tick += UpValue;
        }

        static NumericUpDownControl()
        {
            NewWidthProperty = DependencyProperty.Register(
                "NewWidth",
                typeof(float),
                typeof(NumericUpDownControl),
                new FrameworkPropertyMetadata(
                    MAXIMUM,
                    new PropertyChangedCallback(SetNewWidthData)
                )
             );

            NewValueProperty = DependencyProperty.Register(
                "NewValue",
                typeof(float),
                typeof(NumericUpDownControl),
                new FrameworkPropertyMetadata(
                    0f,
                    new PropertyChangedCallback(SetNewValueData)
                )
            );
        }

        private static void SetNewValueData(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((NumericUpDownControl)d).SetNewValue();
        }

        private void SetNewValue()
        {
            if (NewValue >= 0 && NewValue <= 10)
            {
                mainTB.Text = NewValue.ToString();
            }
        }

        private static void SetNewWidthData(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((NumericUpDownControl)d).SetNewWidth();
        }

        private void SetNewWidth()
        {
            mainTB.Width = NewWidth;
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            float currentValue = 0;
            if (float.TryParse(mainTB.Text, out currentValue))
            {
                currentValue += 0.1f;
                if (currentValue <= 10.0)
                {
                    string str = String.Format("{0:F1}", currentValue);
                    mainTB.Text = str;
                }
            }
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            float currentValue = 0;
            if (float.TryParse(mainTB.Text, out currentValue))
            {
                if (currentValue > 10)
                {
                    mainTB.Text = MAXIMUM.ToString();
                }

                currentValue -= 0.1f;

                if (currentValue >= 0 && currentValue < MAXIMUM)
                {
                    string str = String.Format("{0:F1}", currentValue);
                    mainTB.Text = str;
                }
            }
        }

        private void mainTB_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!mainTB.Text.Contains(".") && mainTB.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void mainTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            float currentValue = 0;
            if (float.TryParse(mainTB.Text, out currentValue))
            {
                NewValue = currentValue;
            }
        }

        private void UpButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _upTimer.Start();
        }

        private void UpButton_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _upTimer.Stop();
        }

        private void UpValue(object sender, EventArgs e)
        {
            float currentValue = 0;
            if (float.TryParse(mainTB.Text, out currentValue))
            {
                currentValue += 0.1f;
                if (currentValue <= 10.0)
                {
                    string str = String.Format("{0:F1}", currentValue);
                    mainTB.Text = str;
                }
            }
        }

        private void DownButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void DownButton_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
