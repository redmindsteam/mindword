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
<<<<<<< HEAD:src/MindWord.Desktop/Windows/LoginWindow.xaml.cs
    public partial class LoginWindow : Window
=======
    public partial class LoginPage : Window
>>>>>>> fb6f136 (Login Wpf):src/MindWord.Desktop/Pages/LoginPage.xaml.cs
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
