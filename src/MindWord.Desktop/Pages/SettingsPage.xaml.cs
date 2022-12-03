using Microsoft.Win32;
using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.DataAccess.Repositories;
using MindWord.Service.Attributes;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MindWord.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public  SettingsPage()
        {
            InitializeComponent();
            IUserRepository userRepository = new UserRepository();
            var user =  userRepository.GetByIdAsync(IdentitySingelton.currentId().UserId);
            txFullNameUpdate.Text = user.Result.FullName;
            txEmailUpdate.Text = user.Result.Email;
           ResourceDictionary resourceDictionary = new ResourceDictionary();
            var image =  File.ReadAllBytesAsync(user.Result.AccountImagePath);
            resourceDictionary.Add("image", image.Result);
           
            imagePicture.Resources =  resourceDictionary;
        }

        private void btnImage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.bmp;*.jpg;*.png;";
            openFileDialog.FilterIndex = 1;

            if(openFileDialog.ShowDialog() == true)
            {
                imagePicture.Source = new BitmapImage(new System.Uri(openFileDialog.FileName)); 
            }
        }
    }
}
