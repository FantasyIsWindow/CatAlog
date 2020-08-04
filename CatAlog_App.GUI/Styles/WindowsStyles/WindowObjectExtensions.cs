using System;
using System.Windows;

namespace CatAlog_App.GUI.Styles.WindowsStyles
{
    public static class WindowObjectExtesion
    {
        public static void ForWindowFromTemplate(this object element, Action<Window> action)
        {
            Window window = ((FrameworkElement)element).TemplatedParent as Window;
            if (window != null)
            {
                action(window);
            }
        }
    }
}
