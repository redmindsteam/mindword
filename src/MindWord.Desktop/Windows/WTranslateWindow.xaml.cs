using MindWord.Service.Services;
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
    /// Interaction logic for WTranslateWindow.xaml
    /// </summary>
    public partial class WTranslateWindow : Window
    {

        static int index = 0;
        static int correctPoints = 0;
        static int maxPage;
        static List<List<string>> res;
        static List<RandomTestViewModel> listTestAnswer = new List<RandomTestViewModel>();
        public WTranslateWindow()
        {
            InitializeComponent();
            listTestAnswer.Clear();
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
                    throw new Exception();
                }
                lbRandomWord.Content = res[index][0];
                aBtn.Content = res[index][1];
                bBtn.Content = res[index][2];
                cBtn.Content = res[index][3];
                dBtn.Content = res[index][4];

                if (res.Count <= 15)
                {
                    lbPage.Content = $"{index + 1}/{res.Count}";
                    maxPage = res.Count;
                }
                else
                {
                    lbPage.Content = $"{index + 1}/{15}";
                    maxPage = 15;
                }
            }
            catch
            {
                HelperShowWindow helperShowWindow = new HelperShowWindow();
                helperShowWindow.tbHelperShow.Text = "Word is not enough!";
                helperShowWindow.ShowDialog();
                this.Close();
            }
        }

        private void aBtn_Click(object sender, RoutedEventArgs e)
        {
            RandomTestViewModel viewModel = new RandomTestViewModel()
            {
                Id = index + 1,
                Word = res[index][0],
                Translate = res[index][5],
                Choice = aBtn.Content.ToString(),
                Status = "❌"


            };
            if (aBtn.Content.ToString() == res[index][5])
            {
                correctPoints++;
                viewModel.Status = "✔️";
            }
            index++;
            listTestAnswer.Add(viewModel);
            if (index == res.Count || index >= 15)
            {
                RanTransGameResWindow gameResWindow = new RanTransGameResWindow();
                gameResWindow.dgData.ItemsSource = listTestAnswer;
                gameResWindow.lbResultgame.Content = string.Format("Result: {0}/{1}", correctPoints, listTestAnswer.Count);
                this.Close();
                gameResWindow.ShowDialog();
                index = 0;
                correctPoints = 0;
            }
            lbRandomWord.Content = res[index][0];
            aBtn.Content = res[index][1];
            bBtn.Content = res[index][2];
            cBtn.Content = res[index][3];
            dBtn.Content = res[index][4];
            lbPage.Content = $"{index + 1}/{maxPage}";
        }

        private void bBtn_Click(object sender, RoutedEventArgs e)
        {
            RandomTestViewModel viewModel = new RandomTestViewModel()
            {
                Id = index + 1,
                Word = res[index][0],
                Translate = res[index][5],
                Choice = bBtn.Content.ToString(),
                Status = "❌"


            };
            if (bBtn.Content.ToString() == res[index][5])
            {
                correctPoints++;
                viewModel.Status = "✔️";
            }
            index++;
            listTestAnswer.Add(viewModel);
            if (index == res.Count || index >= 15)
            {
                RanTransGameResWindow gameResWindow = new RanTransGameResWindow();
                gameResWindow.dgData.ItemsSource = listTestAnswer;
                gameResWindow.lbResultgame.Content = string.Format("Result: {0}/{1}", correctPoints, listTestAnswer.Count);
                this.Close();
                gameResWindow.ShowDialog();
                index = 0;
                correctPoints = 0;
            }
            lbRandomWord.Content = res[index][0];
            aBtn.Content = res[index][1];
            bBtn.Content = res[index][2];
            cBtn.Content = res[index][3];
            dBtn.Content = res[index][4];
            lbPage.Content = $"{index + 1}/{maxPage}";
        }

        private void cBtn_Click(object sender, RoutedEventArgs e)
        {
            RandomTestViewModel viewModel = new RandomTestViewModel()
            {
                Id = index + 1,
                Word = res[index][0],
                Translate = res[index][5],
                Choice = cBtn.Content.ToString(),
                Status = "❌"


            };
            if (cBtn.Content.ToString() == res[index][5])
            {
                correctPoints++;
                viewModel.Status = "✔️";
            }
            index++;
            listTestAnswer.Add(viewModel);
            if (index == res.Count || index >= 15)
            {
                RanTransGameResWindow gameResWindow = new RanTransGameResWindow();
                gameResWindow.dgData.ItemsSource = listTestAnswer;
                gameResWindow.lbResultgame.Content = string.Format("Result: {0}/{1}", correctPoints, listTestAnswer.Count);
                this.Close();
                gameResWindow.ShowDialog();
                index = 0;
                correctPoints = 0;
            }
            lbRandomWord.Content = res[index][0];
            aBtn.Content = res[index][1];
            bBtn.Content = res[index][2];
            cBtn.Content = res[index][3];
            dBtn.Content = res[index][4];
            lbPage.Content = $"{index + 1}/{maxPage}";
        }

        private void dBtn_Click(object sender, RoutedEventArgs e)
        {
            RandomTestViewModel viewModel = new RandomTestViewModel()
            {
                Id = index + 1,
                Word = res[index][0],
                Translate = res[index][5],
                Choice = dBtn.Content.ToString(),
                Status = "❌"


            };
            if (dBtn.Content.ToString() == res[index][5])
            {
                correctPoints++;
                viewModel.Status = "✔️";
            }
            index++;
            listTestAnswer.Add(viewModel);
            if (index == res.Count || index >= 15)
            {
                RanTransGameResWindow gameResWindow = new RanTransGameResWindow();
                gameResWindow.dgData.ItemsSource = listTestAnswer;
                gameResWindow.lbResultgame.Content = string.Format("Result: {0}/{1}", correctPoints, listTestAnswer.Count);
                this.Close();
                gameResWindow.ShowDialog();
                index = 0;
                correctPoints = 0;
            }
            lbRandomWord.Content = res[index][0];
            aBtn.Content = res[index][1];
            bBtn.Content = res[index][2];
            cBtn.Content = res[index][3];
            dBtn.Content = res[index][4];
            lbPage.Content = $"{index + 1}/{maxPage}";
        }
    }
}
