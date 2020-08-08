using System;
using System.Windows;
using System.Windows.Input;

namespace CatAlog_App.GUI.Styles.WindowsStyles
{
    public partial class MechanicsTempWindow : ResourceDictionary
    {
        public MechanicsTempWindow()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e) =>
            sender.ForWindowFromTemplate(w => w.Close());

        private void Window_Move(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                sender.ForWindowFromTemplate(w => w.DragMove());
            }
        }

        private void WindowTitleBarMouseMove_Click(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                sender.ForWindowFromTemplate(w =>
                {
                    if (w.WindowState == WindowState.Maximized)
                    {
                        const double adjusment = 40.0;
                        var mouse = e.MouseDevice.GetPosition(w);
                        var width_01 = Math.Max(w.ActualWidth - 2 * adjusment, adjusment);
                        var width_02 = Math.Max(w.ActualWidth - 2 * adjusment, adjusment);

                        w.BeginInit();
                        w.WindowState = WindowState.Normal;
                        w.Left = (mouse.X - adjusment) * (1 - width_02 / width_01);
                        w.Top = -7;
                        w.EndInit();
                        w.DragMove();
                    }
                });
            }
        }
    }
}
