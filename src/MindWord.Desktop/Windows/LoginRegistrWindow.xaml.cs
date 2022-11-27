﻿using MindWord.Service.Attributes;
using MindWord.Service.Interfaces.Services;
using MindWord.Service.Services;
using MindWord.Service.Services.Common;
using MindWord.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MindWord.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>

    public partial class LoginWindow : Window
  {
        private string _password = "";
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Visibility == Visibility.Visible)
            {
                txPasswordRegistorBox.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                txEmailRegistor.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                ImageLogin.Visibility = Visibility.Collapsed;
                ImageRegister.Visibility = Visibility.Visible;
                Login.Visibility = Visibility.Collapsed;
                RegistorPage.Visibility = Visibility.Visible;
            }
            else
            {
                txPasswordBox.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                txEmail.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                ImageRegister.Visibility = Visibility.Collapsed;
                ImageLogin.Visibility = Visibility.Visible;
                RegistorPage.Visibility = Visibility.Collapsed;
                Login.Visibility = Visibility.Visible;
            }
        }

        private void txEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            EmailAttribute emailAttribute = new EmailAttribute();
            var result = emailAttribute.IsValid(txEmail.Text);
            if (result.isSuccessful)
            {
                txEmail.BorderBrush = new SolidColorBrush(Color.FromRgb(50, 205, 50));
               
                LbEmailIsCorrect.Content = "";
            }
            else
            {
               
                LbEmailIsCorrect.Content = result.Message;
                txEmail.BorderBrush = new SolidColorBrush(Color.FromRgb(188, 32, 32));
            }
        }

        private void txEmailRegis_TextChanged(object sender, TextChangedEventArgs e)
        {
            EmailAttribute emailAttribute = new EmailAttribute();
            var result = emailAttribute.IsValid(txEmailRegistor.Text);
            if (result.isSuccessful)
            {
                txEmailRegistor.BorderBrush = new SolidColorBrush(Color.FromRgb(50, 205, 50));
                RegistLbEmail.Content = "";
            }
            else
            {
                RegistLbEmail.Content = result.Message; 
                txEmailRegistor.BorderBrush = new SolidColorBrush(Color.FromRgb(188, 32, 32));
            }
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            IUserService service = new UserService();
            var res = await service.LoginAsync(txEmail.Text,txPasswordBox.Password);
            if (res.isSuccessful == true)
            {
                // go main menu
                MessageBox.Show("Succes");
            }
            else
            {
                MessageBox.Show(res.Message);

            }
        }

        private void txPasswordRegis_TextChanged(object sender, RoutedEventArgs e)
        {
            StrongPasswordAttribute passwordAttribute = new StrongPasswordAttribute();
            var result = passwordAttribute.IsValid(txPasswordRegistorBox.Password);
            if (result.isSuccessful)
            {
                txPasswordRegistorBox.BorderBrush = new SolidColorBrush(Color.FromRgb(50, 205, 50));
                RegistLbPassword.Content = "";
            }
            else
            {
                RegistLbPassword.Content = result.Message;  
                txPasswordRegistorBox.BorderBrush = new SolidColorBrush(Color.FromRgb(188, 32, 32));
            }
        }

        private void txPasswordLogin_TextChanged(object sender, RoutedEventArgs e)
        {
            StrongPasswordAttribute passwordAttribute = new StrongPasswordAttribute();
            var result = passwordAttribute.IsValid(txPasswordBox.Password);
            if (result.isSuccessful)
            {
                txPasswordBox.BorderBrush = new SolidColorBrush(Color.FromRgb(50, 205, 50));
            }
            else
            {
                txPasswordBox.BorderBrush = new SolidColorBrush(Color.FromRgb(188, 32, 32));
            }
        }

        private async void BtnRegistr(object sender, RoutedEventArgs e)
        {

            EmailAttribute emailAttribute = new EmailAttribute();
            StrongPasswordAttribute strongPasswordAttribute = new StrongPasswordAttribute();

            if (emailAttribute.IsValid(txEmailRegistor.Text).isSuccessful)
            {
                if (strongPasswordAttribute.IsValid(txPasswordRegistorBox.Password).isSuccessful)
                {


                    ImageService imageService = new ImageService();
                    UserViewModel userViewModel = new UserViewModel()
                    {
                        FullName = txFullName.Text,
                        Email = txEmailRegistor.Text,
                        Password = txPasswordRegistorBox.Password,
                        AccountImagePath = imageService.DefaultImage()

                    };

                    UserService userService = new UserService();
                    var result = await userService.RegisterAsync(userViewModel);
                    if (result.isSuccessful == true)
                    {
                        MessageBox.Show(result.Message);
                        ImageRegister.Visibility = Visibility.Collapsed;
                        ImageLogin.Visibility = Visibility.Visible;
                        RegistorPage.Visibility = Visibility.Collapsed;
                        Login.Visibility = Visibility.Visible;
                    }
                }

            }
        }
    }
}