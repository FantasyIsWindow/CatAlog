using CatAlog_App.GUI.Models;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CatAlog_App.GUI.Views.CustomControls
{
    /// <summary>
    /// Interaction logic for EpisodesTextBoxControl.xaml
    /// </summary>
    public partial class EpisodesTextBoxControl : UserControl
    {
        public static readonly DependencyProperty TextProperty;

        private readonly string patternText = "1. series name";

        public ObservableCollection<EpisodeModel> Text
        {
            get => (ObservableCollection<EpisodeModel>)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public EpisodesTextBoxControl()
        {
            InitializeComponent();
        }

        static EpisodesTextBoxControl()
        {
            TextProperty = DependencyProperty.Register
                (
                    "Text", 
                    typeof(ObservableCollection<EpisodeModel>), 
                    typeof(EpisodesTextBoxControl), 
                    new FrameworkPropertyMetadata
                    (
                        null,
                        new PropertyChangedCallback(SetTextData)
                    )
                );
        }

        private static void SetTextData(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((EpisodesTextBoxControl)d).CollectionParser();   
        }

        private void CollectionParser()
        {
            if (Text == null || Text.Count == 0)
            {
                textBox.Text = patternText;
            }
            else
            {
                StringBuilder builder = new StringBuilder();
                foreach (var info in Text)
                {
                    builder.Append($"{info.Number}. {info.Name}.\n");
                }
                textBox.Text = builder.ToString();
            }
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == patternText)
            {
                textBox.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = patternText;
            }
            else
            {
                if (textBox.Text != patternText)
                {
                    TextToCollection();
                }
            }                
        }

        private void TextToCollection()
        {
            if (Text == null)
            {
                Text = new ObservableCollection<EpisodeModel>();
            }
            else
            {
                Text.Clear();
            }

            try
            {
                var temp = textBox.Text.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in temp)
                {
                    var str = item.Split(new string[] { ". ", ") " }, StringSplitOptions.RemoveEmptyEntries);
                    EpisodeModel sGui = new EpisodeModel()
                    {
                        Number = str[0],
                        Name = str[1]
                    };
                    Text.Add(sGui);
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
