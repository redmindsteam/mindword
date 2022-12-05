using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.DataAccess.Repositories;
using MindWord.Desktop.Windows;
using MindWord.Service.Attributes;
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
using static System.Data.Entity.Infrastructure.Design.Executor;

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

            words = await service.GetPagedListAsync(PageNumber, int.Parse(pageSize.Text));
            btnLeft.IsEnabled = words.HasPreviousPage;
            btnRight.IsEnabled = words.HasNextPage;
            dgData.ItemsSource = words;
            lbPage.Content = string.Format("Page{0}/{1}", PageNumber, words.PageCount);
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
            int id = ((dgData.SelectedIndex + 1) + (PageNumber - 1) * int.Parse(pageSize.Text)) + 2;
            var res = words.First(x => x.Id == id);
            var desc = res.Title;
            MessageBox.Show(desc);
        }

        private async void btnUpdate(object sender, RoutedEventArgs e)
        {
            var res = (WordCreateViewModel)dgData.SelectedItem;
            int UpdateId = res.Id;
            IdentitySingelton.SaveUpdateId(UpdateId);
            WordUpdate update = new WordUpdate();
            update.ShowDialog();

            words = await service.GetPagedListAsync(PageNumber, int.Parse(pageSize.Text));
            btnLeft.IsEnabled = words.HasPreviousPage;
            btnRight.IsEnabled = words.HasNextPage;
            dgData.ItemsSource = words;
            lbPage.Content = string.Format("Page{0}/{1}", PageNumber, words.PageCount);
        }

        private async void btnDelete(object sender, RoutedEventArgs e)
        {
            IWordRepository wordRepository = new WordRepository();
            var res = (WordCreateViewModel)dgData.SelectedItem;
            int DeletedId = res.Id;
            var result = await wordRepository.DeleteAsync(DeletedId);
            if(result == true)
            {
                MessageBox.Show("Deleted");

                words = await service.GetPagedListAsync(PageNumber, int.Parse(pageSize.Text));
                btnLeft.IsEnabled = words.HasPreviousPage;
                btnRight.IsEnabled = words.HasNextPage;
                dgData.ItemsSource = words;
                lbPage.Content = string.Format("Page{0}/{1}", PageNumber, words.PageCount);
            }
            else
            {
                MessageBox.Show("Failed to delete");
            }
        }
    }
}
