using MindWord.Service.Services;
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
    /// Interaction logic for WRandomWindow.xaml
    /// </summary>
    public partial class WRandomWindow : Window
    {
        static int index = 0;
        static int correctPoints = 0;
        static List<List<string>> res;
        public WRandomWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                GameService gameService = new GameService();
                res = await gameService.RandomTestAsync();
                lbRandomWord.Content = res[index][0];
                aBtn.Content = res[index][1];
                bBtn.Content = res[index][2];
                cBtn.Content = res[index][3];
                dBtn.Content = res[index][4];

            }
            catch
            {
                MessageBox.Show("No Word");
                this.Close();
            }
        }

        private void aBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if(aBtn.Content == res[index][5])
            {
                correctPoints++;
            }
            index++;
            if (index == res.Count)
            {
                MessageBox.Show($"Your score is {correctPoints}!");
                index= 0;
                correctPoints= 0;
                this.Close();
            }
            lbRandomWord.Content = res[index][0];
            aBtn.Content = res[index][1];
            bBtn.Content = res[index][2];
            cBtn.Content = res[index][3];
            dBtn.Content = res[index][4];
        }

        private void cBtn_Click(object sender, RoutedEventArgs e)
        {
            if (cBtn.Content == res[index][5])
            {
                correctPoints++;
            }
            index++;
            if (index == res.Count)
            {
                MessageBox.Show($"Your score is {correctPoints}!");
                index= 0;
                correctPoints =0;
                this.Close();
            }
            lbRandomWord.Content = res[index][0];
            aBtn.Content = res[index][1];
            bBtn.Content = res[index][2];
            cBtn.Content = res[index][3];
            dBtn.Content = res[index][4];
        }

        private void bBtn_Click(object sender, RoutedEventArgs e)
        {
            if (bBtn.Content == res[index][5])
            {
                correctPoints++;
            }
            index++;
            if (index == res.Count )
            {
                MessageBox.Show($"Your score is {correctPoints}!");
                index= 0;
                correctPoints = 0;
                this.Close();
            }
            lbRandomWord.Content = res[index][0];
            aBtn.Content = res[index][1];
            bBtn.Content = res[index][2];
            cBtn.Content = res[index][3];
            dBtn.Content = res[index][4];
        }

        private void dBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dBtn.Content == res[index][5])
            {
                correctPoints++;
            }
            index++;
            if (index == res.Count )
            {
                MessageBox.Show($"Your score is {correctPoints}!");
                index= 0;
                correctPoints = 0;
                this.Close();
            }
            lbRandomWord.Content = res[index][0];
            aBtn.Content = res[index][1];
            bBtn.Content = res[index][2];
            cBtn.Content = res[index][3];
            dBtn.Content = res[index][4];
        }
    }
}
