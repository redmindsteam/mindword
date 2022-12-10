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
    /// Interaction logic for RanTransGameResWindow.xaml
    /// </summary>
    public partial class RanTransGameResWindow : Window
    {
        
        public RanTransGameResWindow()
        {
            InitializeComponent();
        }

      
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void mouse(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
