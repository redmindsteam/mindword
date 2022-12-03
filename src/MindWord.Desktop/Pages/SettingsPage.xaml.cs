using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MindWord.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
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
