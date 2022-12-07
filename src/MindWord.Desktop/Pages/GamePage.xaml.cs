using MaterialDesignThemes.Wpf;
using MindWord.Desktop.Windows;
using System.Windows.Controls;

namespace MindWord.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public GamePage()
        {
            InitializeComponent();
        }

        private void btnWRandom_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            WRandomWindow wRandomWindow = new WRandomWindow();
            wRandomWindow.ShowDialog();
        }

        private void btnWVoice_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            WVoiceWindow wVoiceWindow = new WVoiceWindow(); 
            wVoiceWindow.ShowDialog();
        }

        private void btnWDescription_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            WDescriptionWindow wDescriptionWindow = new WDescriptionWindow();
            wDescriptionWindow.ShowDialog();
        }

        private void btnWTranslate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            WTranslateWindow wTranslateWindow = new WTranslateWindow();
            wTranslateWindow.ShowDialog();
        }
    }
}
