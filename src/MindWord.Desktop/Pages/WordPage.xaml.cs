using MindWord.Desktop.Windows;
using MindWord.Service.Interfaces.Services;
using MindWord.Service.Services;
using MindWord.Service.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MindWord.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for WordPage.xaml
    /// </summary>
    public partial class WordPage : Page
    {
        int PageNumber = 1;
        IPagedList<WordCreateViewModel> words;
        IWordService service = new WordService();
        public WordPage()
        {
            InitializeComponent();
        }

        private async void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            words =  await service.GetPagedListAsync(PageNumber,int.Parse(pageSize.Text));
            btnLeft.IsEnabled = words.HasPreviousPage;
            btnRight.IsEnabled = words.HasNextPage;
            dgData.ItemsSource = words;
            lbPage.Content = string.Format("Page{0}/{1}", PageNumber, words.PageCount);

            
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            WordWindow wordWindow = new WordWindow();
            wordWindow.ComboBoxCategory.Items.Clear();
            ICategoryService categoryService = new CategoryService();   
            var categories = await categoryService.GetStringsAsync();

            foreach (var item in categories)
            {
                wordWindow.ComboBoxCategory.Items.Add(item);
            }
            wordWindow.ShowDialog();
        }
        private void rdWordGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            words = await service.GetPagedListAsync(--PageNumber,int.Parse(pageSize.Text));
            btnLeft.IsEnabled = words.HasPreviousPage;
            btnRight.IsEnabled = words.HasNextPage;
            dgData.ItemsSource = words;
            lbPage.Content = string.Format("Page{0}/{1}", PageNumber, words.PageCount);


        }

        private async void btnRight_Click(object sender, RoutedEventArgs e)
        {
            words = await service.GetPagedListAsync(++PageNumber,int.Parse(pageSize.Text));
            btnRight.IsEnabled = words.HasNextPage;
            btnLeft.IsEnabled = words.HasPreviousPage;
            dgData.ItemsSource = words;
            lbPage.Content = string.Format("Page{0}/{1}", PageNumber, words.PageCount);
        }
        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
                      
         }

        private void BtnInfo_click(object sender, RoutedEventArgs e)
        {
            int id = (dgData.SelectedIndex + 1) + ((PageNumber - 1) * 5);
            var res = words.First(x => x.Id == id);
            var desc = res.Title;
            MessageBox.Show(desc);
        }

        private void btnUpdate(object sender, RoutedEventArgs e)
        {
            int UpdateId = (dgData.SelectedIndex + 1) + (PageNumber - 1) * 5;
            WordUpdate update = new WordUpdate();
            update.ShowDialog();
        }

        private void btnDelete(object sender, RoutedEventArgs e)
        {
            int DeleteId = (dgData.SelectedIndex + 1) + (PageNumber - 1) * 5;
        }
    }
}
