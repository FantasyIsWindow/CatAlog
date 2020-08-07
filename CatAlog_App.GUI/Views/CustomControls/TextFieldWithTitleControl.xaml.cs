using System.Windows;
using System.Windows.Controls;

namespace CatAlog_App.GUI.Views.CustomControls
{
    public partial class TextFieldWithTitleControl : UserControl
    {
        public static DependencyProperty FieldNameProperty;

        public static DependencyProperty TextProperty;

        public string FieldName
        {
            get => (string)GetValue(FieldNameProperty);
            set => SetValue(FieldNameProperty, value);
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
            FieldNameProperty = DependencyProperty.Register("FieldName", typeof(string), typeof(TextFieldWithTitleControl), new FrameworkPropertyMetadata("", new PropertyChangedCallback(SetTitleName)), new ValidateValueCallback(ValidateReceivedData));
            TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TextFieldWithTitleControl), new FrameworkPropertyMetadata("", new PropertyChangedCallback(SetText)), new ValidateValueCallback(ValidateReceivedData));
        }

        private static void SetTitleName(DependencyObject d, DependencyPropertyChangedEventArgs e) =>
            ((TextFieldWithTitleControl)d).SetTitle();

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e) =>
            ((TextFieldWithTitleControl)d).SetText();

        private void SetText() => textBox.Text = Text;

        private void SetTitle() => label.Content = FieldName;

        private static bool ValidateReceivedData(object value) =>
            value != null ? true : false;
    }
}
