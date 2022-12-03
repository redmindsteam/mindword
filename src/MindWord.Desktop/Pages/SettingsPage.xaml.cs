using Microsoft.Win32;
using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.DataAccess.Repositories;
using MindWord.Domain.Constants;
using MindWord.Service.Attributes;
using MindWord.Service.Security;
using MindWord.Service.Services.Common;
using System.IO;
using System.Security.AccessControl;
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

            var image = new FileInfo(user.Result.AccountImagePath).FullName;
            
           
            imagePicture.Source =  new BitmapImage(new System.Uri(image));
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

        private async void BtnUpdate_click(object sender, RoutedEventArgs e)
        {


            IUserRepository userRepository = new UserRepository();
            var user = await userRepository.GetByIdAsync(IdentitySingelton.currentId().UserId);
            EmailAttribute emailAttribute = new EmailAttribute();   
            StrongPasswordAttribute strongPasswordAttribute  = new StrongPasswordAttribute();
            
            if (emailAttribute.IsValid(txEmailUpdate.Text).isSuccessful)
            { 
                if (strongPasswordAttribute.IsValid(txPasswordUpdate.Password).isSuccessful || txPasswordUpdate.Password == "")
                {
                    if (user.FullName != txFullNameUpdate.Text && txFullNameUpdate.Text != "")
                    {
                        user.FullName = txFullNameUpdate.Text;
                    }
                    if (user.Email != txEmailUpdate.Text)
                    {
                        var checkUser = userRepository.GetByEmail(user.Email);
                        if (checkUser != null)
                        {
                            user.Email = txEmailUpdate.Text;
                        }
                        else
                        {
                            LbEmailUpdate.Content = "That username is taken.Try Another";
                            return;
                        }
                    }
                    if (txPasswordUpdate.Password != "")
                    {
                        PasswordHasher passwordHasher = new PasswordHasher();

                        var hash = passwordHasher.Hash(txPasswordUpdate.Password);
                        user.PasswordHash = hash.passwordHash;
                        user.Salt = hash.salt;

                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
            
            var imagepath = imagePicture.Source.ToString().Substring(8);

            var imagebytes = await File.ReadAllBytesAsync(imagepath);
            var userImagePath = new FileInfo(user.AccountImagePath).FullName;   
            if (userImagePath != new FileInfo(imagepath).FullName)
            {
                ImageService imageService = new ImageService();
                imagepath = await imageService.SaveImageAsync(imagebytes);
                user.AccountImagePath = imagepath;
            }

            var res = await userRepository.UpdateAsync(IdentitySingelton.currentId().UserId, user);

            if (res)
            {
                MessageBox.Show("Updated");

            }else
            {
                MessageBox.Show("Not updated");
            }
        }

        private void txEmailUpdate_TextChanged(object sender, TextChangedEventArgs e)
        {
            EmailAttribute emailAttribute = new EmailAttribute();
            var result = emailAttribute.IsValid(txEmailUpdate.Text);
            if (result.isSuccessful)
            {
                txEmailUpdate.BorderBrush = new SolidColorBrush(Color.FromRgb(50, 205, 50));
                LbEmailUpdate.Content = "";
            }
            else
            {
                LbEmailUpdate.Content = result.Message;
                txEmailUpdate.BorderBrush = new SolidColorBrush(Color.FromRgb(188, 32, 32));
            }
        }

        private void PasswordTextchanged(object sender, RoutedEventArgs e)
        {
            if (txPasswordUpdate.Password == "")
            {
                txPasswordUpdate.BorderBrush = new SolidColorBrush(Color.FromRgb(50, 205, 50));
                LbPasswordUpdate.Content = "if this text is empty, Password not updated";

            }
            else
            {
                StrongPasswordAttribute passwordAttribute = new StrongPasswordAttribute();
                var result = passwordAttribute.IsValid(txPasswordUpdate.Password);
                if (result.isSuccessful)
                {
                    txPasswordUpdate.BorderBrush = new SolidColorBrush(Color.FromRgb(50, 205, 50));
                    LbPasswordUpdate.Content = "";
                }
                else
                {
                    LbPasswordUpdate.Content = result.Message;
                    txPasswordUpdate.BorderBrush = new SolidColorBrush(Color.FromRgb(188, 32, 32));
                }
            }
        }
    }
}
