using MindWord.Desktop.Themes;
using MindWord.Domain.Entities;
using System.Windows;

namespace MindWord.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void rdSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Themes_Click(object sender, RoutedEventArgs e)
        {
            if (Themes.IsChecked == true)
                ThemesController.SetTheme(ThemesController.ThemeTypes.Light);
            else
                ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void rdWords_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
