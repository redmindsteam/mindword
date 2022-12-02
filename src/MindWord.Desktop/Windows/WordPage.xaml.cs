using System.Windows;
using System.Windows.Input;

namespace MindWord.Desktop.Windows
{
    /// <summary>
    /// Логика взаимодействия для WordPage.xaml
    /// </summary>
    public partial class WordPage : Window
    {
        public WordPage()
        {
            InitializeComponent();
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
