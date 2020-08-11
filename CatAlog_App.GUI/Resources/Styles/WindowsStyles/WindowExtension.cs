using System;
using System.Windows;
using System.Windows.Interop;

namespace CatAlog_App.GUI.Resources.Styles.WindowsStyles
{
    public static class WindowExtension
    {
        public static IntPtr GetWindowHandler(this Window window)
        {
            WindowInteropHelper helper = new WindowInteropHelper(window);
            return helper.Handle;
        }
    }
}
