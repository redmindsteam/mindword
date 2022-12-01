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
