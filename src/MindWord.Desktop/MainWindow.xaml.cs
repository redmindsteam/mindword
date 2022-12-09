using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.DataAccess.Repositories;
using MindWord.Desktop.Themes;
using MindWord.Domain.Entities;
using MindWord.Service.Attributes;
using System.Diagnostics.Contracts;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

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
        private async void rdHome_Click(object sender, RoutedEventArgs e)
        {
            AccountImage.ImageSource = new BitmapImage(new System.Uri( await checkAccountImage()));
            frameContent.Navigate(new System.Uri("Pages/HomePage.xaml", System.UriKind.RelativeOrAbsolute));
        }

        private async void rdSettings_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new System.Uri("Pages/SettingsPage.xaml", System.UriKind.RelativeOrAbsolute));
           
            AccountImage.ImageSource = new BitmapImage(new System.Uri ( await checkAccountImage()));
        }

        private void Themes_Click(object sender, RoutedEventArgs e)
        {
            if (Themes.IsChecked == true)
                ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);
            else
                ThemesController.SetTheme(ThemesController.ThemeTypes.Light);
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            AccountImage.ImageSource = new BitmapImage(new System.Uri(await checkAccountImage()));
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private async void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            AccountImage.ImageSource = new BitmapImage(new System.Uri(await checkAccountImage()));
            WindowState = WindowState.Minimized;
        }

        private async void rdWords_Click(object sender, RoutedEventArgs e)
        {
            AccountImage.ImageSource = new BitmapImage(new System.Uri(await checkAccountImage()));
          
            frameContent.Navigate(new System.Uri("Pages/WordPage.xaml", System.UriKind.RelativeOrAbsolute));
        }

        private async void rdGame_Click(object sender, RoutedEventArgs e)
        {
            AccountImage.ImageSource = new BitmapImage(new System.Uri(await checkAccountImage()));
            frameContent.Navigate(new System.Uri("Pages/GamePage.xaml", System.UriKind.RelativeOrAbsolute));
        }

        private async void rdTitle_Click(object sender, RoutedEventArgs e)
        {
            AccountImage.ImageSource = new BitmapImage(new System.Uri(await checkAccountImage()));
            frameContent.Navigate(new System.Uri("Pages/TitlePage.xaml", System.UriKind.RelativeOrAbsolute));
        }

        private async void rdTranslate_Click(object sender, RoutedEventArgs e)
        {
            AccountImage.ImageSource = new BitmapImage(new System.Uri(await checkAccountImage()));
            frameContent.Navigate(new System.Uri("Pages/TranslatePage.xaml", System.UriKind.RelativeOrAbsolute));
        }

        private async void DashboardWindow_Loaded(object sender, RoutedEventArgs e)
        {
            AccountImage.ImageSource = new BitmapImage(new System.Uri(await checkAccountImage()));
        }

        static async Task<string> checkAccountImage()
        {
            IUserRepository userRepository = new UserRepository();
            var user = await userRepository.GetByIdAsync(IdentitySingelton.currentId().UserId);
            var temp = new FileInfo(user.AccountImagePath).FullName;
           
            return temp;
        }
    }
}
