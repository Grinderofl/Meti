using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WindowsApp
{
    public partial class MainWindow : Window
    {
        private readonly Brush _black = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        private readonly Brush _gray = new SolidColorBrush(Color.FromArgb(255, 128, 128, 128));

        #region System tools

        private void DraggableAreaMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void ChangeViewButtonMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Normal;
        }

        private void MinimizeButtonMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeButtonMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void CloseButtonMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void SystemMouseEnter(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Foreground = _black;
        }

        private void SystemMouseLeave(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Foreground = _gray;
        }

        #endregion
    }
}
