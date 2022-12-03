using MindWord.Desktop.Windows;
using MindWord.Domain.Entities;
using MindWord.Service.Interfaces.Services;
using MindWord.Service.Services;
using MindWord.Service.ViewModel;
using PagedList;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MindWord.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for TitlePage.xaml
    /// </summary>
    public partial class TitlePage : Page
    {
        int PageNumber = 1;
        IPagedList<CategoryViewModel> categories;
        ICategoryService service = new CategoryService();
        public TitlePage()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            TitleCreate titleCreate = new TitleCreate();
            titleCreate.ShowDialog();
        }

        private async void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            categories = await service.GetPagedListAsync(PageNumber,int.Parse(pageSize.Text));
            btnLeft.IsEnabled = categories.HasPreviousPage;
            btnRight.IsEnabled = categories.HasNextPage;
            dgDataTitle.ItemsSource = categories;
            lbPage.Content = string.Format("Page{0}/{1}", PageNumber, categories.PageCount);
        }

        private async void btnRight_Click(object sender, RoutedEventArgs e)
        {
            categories = await service.GetPagedListAsync(++PageNumber, PageNumber);
            btnRight.IsEnabled = categories.HasNextPage;
            btnLeft.IsEnabled = categories.HasPreviousPage;
            dgDataTitle.ItemsSource = categories;
            lbPage.Content = string.Format("Page{0}/{1}", PageNumber, categories.PageCount);
        }

        private async void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            categories = await service.GetPagedListAsync(--PageNumber, PageNumber);
            btnLeft.IsEnabled = categories.HasPreviousPage;
            btnRight.IsEnabled = categories.HasNextPage;
            dgDataTitle.ItemsSource = categories;
            lbPage.Content = string.Format("Page{0}/{1}", PageNumber, categories.PageCount);
        }

        private void dgDataTitle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnInfoTitle(object sender, RoutedEventArgs e)
        {
            int id = (dgDataTitle.SelectedIndex + 1) + ((PageNumber - 1) * 5);
            var res = categories.First(x => x.Id == id);
            var desc = res.Description;
            MessageBox.Show(desc);
        }

        private void btnUpdate(object sender, RoutedEventArgs e)
        {
            
        }

        private void btndelete(object sender, RoutedEventArgs e)
        {
            int Deleteid =((dgDataTitle.SelectedIndex + 1)+((PageNumber - 1) * 5));

        }
    }
}
