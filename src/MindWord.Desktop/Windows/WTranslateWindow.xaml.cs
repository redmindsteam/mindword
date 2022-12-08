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
    /// Interaction logic for WTranslateWindow.xaml
    /// </summary>
    public partial class WTranslateWindow : Window
    {

        static int index = 0;
        static int correctPoints = 0;
        static List<List<string>> res;
        public WTranslateWindow()
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

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private async  void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                GameService gameService = new GameService();
                res = await gameService.RandomTranslateTestAsync();
                if (res.Count == 0)
                {
                    HelperShowWindow helperShowWindow = new HelperShowWindow();
                    helperShowWindow.tbHelperShow.Text = "So'z yetarli emas !";
                    helperShowWindow.ShowDialog();
                    this.Close();
                }
                lbRandomWord.Content = res[index][0];
                aBtn.Content = res[index][1];
                bBtn.Content = res[index][2];
                cBtn.Content = res[index][3];
                dBtn.Content = res[index][4];
            }
            catch
            {
                HelperShowWindow helperShowWindow = new HelperShowWindow();
                helperShowWindow.tbHelperShow.Text = "No word";
                helperShowWindow.ShowDialog();
                this.Close();
            }
        }

        private void aBtn_Click(object sender, RoutedEventArgs e)
        {
            if (aBtn.Content == res[index][5])
            {
                correctPoints++;
            }
            index++;
            if (index == res.Count)
            {
                HelperShowWindow helperShowWindow = new HelperShowWindow();
                helperShowWindow.tbHelperShow.Text = $"Your score is {correctPoints}!";
                helperShowWindow.ShowDialog();
                index = 0;
                correctPoints = 0;
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
            if (index == res.Count)
            {
                HelperShowWindow helperShowWindow = new HelperShowWindow();
                helperShowWindow.tbHelperShow.Text = $"Your score is {correctPoints}!";
                helperShowWindow.ShowDialog();
                index = 0;
                correctPoints = 0;
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
                HelperShowWindow helperShowWindow = new HelperShowWindow();
                helperShowWindow.tbHelperShow.Text = $"Your score is {correctPoints}!";
                helperShowWindow.ShowDialog();
                index = 0;
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
            if (index == res.Count)
            {
                HelperShowWindow helperShowWindow = new HelperShowWindow();
                helperShowWindow.tbHelperShow.Text = $"Your score is {correctPoints}!";
                helperShowWindow.ShowDialog();
                index = 0;
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
