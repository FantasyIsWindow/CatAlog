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

        private const float MINIMUM = 0;

        private DispatcherTimer _upTimer;

        private DispatcherTimer _downTimer;

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

        public NumericUpDownControl()
        {
            InitializeComponent();

            _upTimer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 200) };
            _upTimer.Tick += UpValue;
            _downTimer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 200) };
            _downTimer.Tick += DownValue;
        }

        static NumericUpDownControl()
        {
            NewWidthProperty = DependencyProperty.Register(
                "NewWidth",
                typeof(float),
                typeof(NumericUpDownControl),
                new FrameworkPropertyMetadata(
                    5f,
                    new PropertyChangedCallback(SetNewWidthData)
                )
             );

            NewValueProperty = DependencyProperty.Register(
                "NewValue",
                typeof(float),
                typeof(NumericUpDownControl),
                new FrameworkPropertyMetadata(
                    MINIMUM,
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
            if (NewValue >= MINIMUM && NewValue <= MAXIMUM)
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

        private void mainTB_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == "." || e.Text == ",")
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
                if (currentValue > 10)
                {
                    NewValue = MAXIMUM;
                }
                else
                {
                    NewValue = currentValue;
                }
            }
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)  => UpValue(null, EventArgs.Empty);      

        private void DownButton_Click(object sender, RoutedEventArgs e) => DownValue(null, EventArgs.Empty);

        private void UpButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => _upTimer.Start();        

        private void UpButton_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e) => _upTimer.Stop();

        private void DownButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => _downTimer.Start();

        private void DownButton_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e) => _downTimer.Stop();

        private void UpValue(object sender, EventArgs e)
        {
            float currentValue = StringValueConverter(mainTB.Text);
            currentValue += 0.1f;
            if (currentValue <= MAXIMUM)
            {
                mainTB.Text = String.Format("{0:F1}", currentValue);
            }
        }

        private void DownValue(object sender, EventArgs e)
        {
            float currentValue = StringValueConverter(mainTB.Text);
            currentValue -= 0.1f;
            if (currentValue >= MINIMUM)
            {
                mainTB.Text = String.Format("{0:F1}", currentValue);
            }
        }

        private float StringValueConverter(string text)
        {
            float value = 0;
            text = text.Replace('.', ',');
            if (float.TryParse(text, out value))
            {
                return value;
            }
            return value; 
        }
    }
}
