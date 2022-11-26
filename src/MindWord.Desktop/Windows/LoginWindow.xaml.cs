using MindWord.Service.Attributes;
using MindWord.Service.Interfaces.Services;
using MindWord.Service.Services;
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

        }

        private void txEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            EmailAttribute emailAttribute = new EmailAttribute();
            var result = emailAttribute.IsValid(txEmail.Text);
            if (result.isSuccessful)
            {
                txEmail.BorderBrush = new SolidColorBrush(Color.FromRgb(50, 205, 50));
            }
            else
            {
                txEmail.BorderBrush = new SolidColorBrush(Color.FromRgb(188, 32, 32));
            }
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            IUserService service = new UserService();
            var res = await service.LoginAsync(txEmail.Text,PasswordBox.Password);
            if (res.isSuccessful == true)
            {
                // go main menu
            }
            else
            {
                MessageBox.Show(res.Message);

            }
        }

    }
}
