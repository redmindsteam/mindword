using MindWord.Service.Interfaces.Services;
using MindWord.Service.Services;
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txTitle.Text != "")
            {
                CategoryViewModel model = new CategoryViewModel()
                {
                    Title = txTitle.Text,
                    Description = txDescriptionTitle.Text
                };
                ICategoryService categoryService = new CategoryService();

                var res =  await categoryService.CreateAsync(model);
                MessageBox.Show(res.Message);
            }
            else
            {

            }
            
        }
    }
}
