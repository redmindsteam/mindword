using MindWord.Service.ViewModel;
using System.Windows;

namespace MindWord.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for TitleCreate.xaml
    /// </summary>
    public partial class TitleCreate : Window
    {
        public TitleCreate()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CategoryViewModel model = new CategoryViewModel()
            {
                Title = txTitle.Text,
                Description = txDescriptionTitle.Text
            };

        }
    }
}
