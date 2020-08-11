using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace CatAlog_App.GUI.Resources.Styles.WindowsStyles
{
    public enum SizingAction
    {
        Left = 1,
        Right,
        Top,
        TopLeft,
        TopRight,
        Bottom,
        BottomLeft,
        BottomRight
    }

    public partial class MechanicsMainWindow : ResourceDictionary
    {
        private const int WM_SYSCOMMAND = 0x112;

        private const int SC_SIZE = 0xF000;

        private const int SC_KEYMENU = 0xF100;

        public MechanicsMainWindow()
        {
            InitializeComponent();
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e) =>
            sender.ForWindowFromTemplate(w => w.WindowState = WindowState.Minimized);

        private void MaximizeBtn_Click(object sender, RoutedEventArgs e) =>
            sender.ForWindowFromTemplate(w => w.WindowState =
            (w.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized);

        private void CloseBtn_Click(object sender, RoutedEventArgs e) =>
            CloseWindow(sender);

        private void Window_Move(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount > 1)
            {
                MaximizeBtn_Click(sender, e);
            }
            else if (e.LeftButton == MouseButtonState.Pressed)
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

        private void TitleIcon_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount > 1)
            {
                CloseWindow(sender);
            }
            else
            {
                sender.ForWindowFromTemplate(w =>
                SendMessage(w.GetWindowHandler(), WM_SYSCOMMAND, (IntPtr)SC_KEYMENU, (IntPtr)' '));
            }
        }

        private void OnTopSide(object sender, MouseButtonEventArgs e) => OnSize(sender, SizingAction.Top);
        private void OnLeftSide(object sender, MouseButtonEventArgs e) => OnSize(sender, SizingAction.Left);
        private void OnRightSide(object sender, MouseButtonEventArgs e) => OnSize(sender, SizingAction.Right);
        private void OnBottomSide(object sender, MouseButtonEventArgs e) => OnSize(sender, SizingAction.Bottom);
        private void OnTopLeftSide(object sender, MouseButtonEventArgs e) => OnSize(sender, SizingAction.TopLeft);
        private void OnTopRightSide(object sender, MouseButtonEventArgs e) => OnSize(sender, SizingAction.TopRight);
        private void OnBottomLeftSide(object sender, MouseButtonEventArgs e) => OnSize(sender, SizingAction.BottomLeft);
        private void OnBottomRightSide(object sender, MouseButtonEventArgs e) => OnSize(sender, SizingAction.BottomRight);



        private void CloseWindow(object sender) =>
            sender.ForWindowFromTemplate(w => w.Close());

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private void OnSize(object sender, SizingAction action)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                sender.ForWindowFromTemplate(w =>
                {
                    if (w.WindowState == WindowState.Normal)
                    {
                        DragSize(w.GetWindowHandler(), action);
                    }
                });
            }
        }

        private void DragSize(IntPtr handle, SizingAction sizing)
        {
            SendMessage(handle, WM_SYSCOMMAND, (IntPtr)(SC_SIZE + sizing), IntPtr.Zero);
            SendMessage(handle, 514, IntPtr.Zero, IntPtr.Zero);
        }
    }
}