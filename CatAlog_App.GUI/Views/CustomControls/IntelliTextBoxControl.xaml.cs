using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using CatAlog_App.Db.DtoModels;
using CatAlog_App.GUI.Models;
using System.Text;
using System.Linq;

namespace CatAlog_App.GUI.Views.CustomControls
{
    public partial class IntelliTextBoxControl : UserControl
    {
        private ObservableCollection<DtoPairModel> _displayedData;

        private DtoPairModel _selectedItem;

        public static readonly DependencyProperty TextProperty;

        public static readonly DependencyProperty DataSourceProperty;

        public DtoPairModel SelectedItem
        {
            get => _selectedItem;
            set => _selectedItem = value;
        }

        public ObservableCollection<DtoPairModel> DisplayedData
        {
            get => _displayedData;
            set => _displayedData = value;
        }

        public ObservableCollection<PairModel> Text
        {
            get => (ObservableCollection<PairModel>)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public List<DtoPairModel> DataSource
        {
            get => (List<DtoPairModel>)GetValue(DataSourceProperty);
            set => SetValue(DataSourceProperty, value);
        }

        public IntelliTextBoxControl()
        {
            InitializeComponent();
            _displayedData = new ObservableCollection<DtoPairModel>();
        }

        static IntelliTextBoxControl()
        {
            TextProperty = DependencyProperty.Register
                (
                    "Text",
                    typeof(ObservableCollection<PairModel>),
                    typeof(IntelliTextBoxControl),
                    new FrameworkPropertyMetadata
                    (
                        null,
                        new PropertyChangedCallback(SetData)
                    )
                );

            DataSourceProperty = DependencyProperty.Register
                (
                    "DataSource",
                    typeof(List<DtoPairModel>),
                    typeof(IntelliTextBoxControl)
                );
        }

        private static void SetData(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((IntelliTextBoxControl)d).ParsText();
        }

        private void ParsText()
        {
            if (Text.Count != 0 && Text != null)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var item in Text)
                {
                    builder.Append(item.Name);
                    builder.Append(", ");
                }
                textBox.Text = builder.ToString();
            }
        }

        private void textBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Down && popup.IsOpen == true)
            {
                displayDictionary.Focus();
                return;
            }
            else if (e.Key == Key.Space)
            {
                popup.IsOpen = false;
                return;
            }

            if (sender is TextBox tb && tb.CaretIndex != 0)
            {
                int wStart = tb.Text.LastIndexOf(' ', tb.CaretIndex - 1);
                if (wStart == -1)
                {
                    wStart = 0;
                }

                string lastWord = tb.Text.Substring(wStart, tb.CaretIndex - wStart).Trim();
                FillDisplayedCollection(lastWord);

                if (_displayedData.Count != 0)
                {
                    ShowPopup(tb.GetRectFromCharacterIndex(tb.CaretIndex));
                }
                else
                {
                    popup.IsOpen = false;
                }
            }
        }

        private void FillDisplayedCollection(string lastWord)
        {
            _displayedData.Clear();
            DataSource.ForEach(delegate (DtoPairModel pair)
            {
                if (pair.Name.IndexOf(lastWord, StringComparison.CurrentCultureIgnoreCase) >= 0)
                {
                    _displayedData.Add(pair);
                }
            });
        }

        private void ShowPopup(Rect rect)
        {
            popup.PlacementRectangle = rect;
            popup.IsOpen = true;
            displayDictionary.SelectedIndex = 0;
        }

        private void displayDictionary_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Left && e.Key != Key.Up &&
                e.Key != Key.Right && e.Key != Key.Down)
            {
                textBox.Focus();
            }

            switch (e.Key)
            {
                case Key.Enter:
                    {
                        displayDictionary_MouseEnter(sender, null);
                        break;
                    }
                case Key.Escape:
                    {
                        popup.IsOpen = false;
                        break;
                    }
            }
        }

        private void displayDictionary_MouseEnter(object sender, MouseButtonEventArgs e)
        {
            textBox.Focus();
            popup.IsOpen = false;
            int endWordIndex = textBox.CaretIndex - 1;
            int startWordIndex = textBox.Text.LastIndexOf(' ', endWordIndex);
            if (startWordIndex == -1)
            {
                startWordIndex = 0;
            }
            int wordLength = endWordIndex - startWordIndex;
            if (startWordIndex == 0)
            {
                textBox.Text = "";
                endWordIndex = 0;
            }
            else
            {
                textBox.Text = textBox.Text.Remove(startWordIndex + 1, wordLength);
                endWordIndex = startWordIndex + 1;
            }

            string str = _selectedItem.Name + ", ";
            textBox.Text = textBox.Text.Insert(endWordIndex, str);
            textBox.CaretIndex = endWordIndex + str.Length;
        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox.IsFocused == false && popup.IsOpen == false)
            {
                Text.Clear();
                var temp = textBox.Text.Split(new string[] { ", " , ","}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in temp)
                {
                    uint id = DataSource.FirstOrDefault(i => i.Name == item.Trim())?.Id ?? 0;
                    Text.Add(new PairModel() { Id = id, Name = item.Trim() });
                }
            }
        }
    }
}
