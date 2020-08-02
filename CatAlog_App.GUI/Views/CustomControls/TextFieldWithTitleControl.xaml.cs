using System.Windows;
using System.Windows.Controls;

namespace CatAlog_App.GUI.Views.CustomControls
{
    public partial class TextFieldWithTitleControl : UserControl
    {
        public static DependencyProperty TitleNameProperty;

        public static DependencyProperty TextProperty;

        public string TitleName
        {
            get => (string)GetValue(TitleNameProperty);
            set => SetValue(TitleNameProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public TextFieldWithTitleControl()
        {
            InitializeComponent();
        }

        static TextFieldWithTitleControl()
        {
            TitleNameProperty = DependencyProperty.Register("TitleName", typeof(string), typeof(TextFieldWithTitleControl), new FrameworkPropertyMetadata("", new PropertyChangedCallback(SetTitleName)), new ValidateValueCallback(ValidateReceivedData));
            TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TextFieldWithTitleControl), new FrameworkPropertyMetadata("", new PropertyChangedCallback(SetText)), new ValidateValueCallback(ValidateReceivedData));
        }

        private static void SetTitleName(DependencyObject d, DependencyPropertyChangedEventArgs e) =>
            ((TextFieldWithTitleControl)d).SetTitle();

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e) =>
            ((TextFieldWithTitleControl)d).SetText();

        private void SetText() => textBox.Text = Text;

        private void SetTitle() => label.Content = TitleName;

        private static bool ValidateReceivedData(object value) =>
            value != null ? true : false;
    }
}
