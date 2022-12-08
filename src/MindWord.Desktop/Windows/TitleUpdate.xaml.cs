using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.DataAccess.Repositories;
using MindWord.Domain.Entities;
using MindWord.Service.Attributes;
using MindWord.Service.ViewModel;
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
    /// Логика взаимодействия для TitleUpdate.xaml
    /// </summary>
   

    public partial class TitleUpdate : Window
    {
        public TitleUpdate()
        {
            InitializeComponent();
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ICategoryRepository categoryRepository = new CategoryRepository();
            Category category = new Category()
            {
                UserId = IdentitySingelton.currentId().UserId,
                Title = txTitle.Text,
                Description = txDescriptionTitle.Text,
                Id = IdentitySingelton.UpdateId().updateId
            };
            var res = await categoryRepository.UpdateAsync(IdentitySingelton.UpdateId().updateId, category);
            if(res == true)
            {
                HelperShowWindow helperShowWindow = new HelperShowWindow();
                helperShowWindow.tbHelperShow.Text = "Updated";
                helperShowWindow.ShowDialog();
                this.Close();
            }
            else
            {
                HelperShowWindow helperShowWindow = new HelperShowWindow();
                helperShowWindow.tbHelperShow.Text = "Failed!";
                helperShowWindow.ShowDialog();
            }
        }
    }
}
