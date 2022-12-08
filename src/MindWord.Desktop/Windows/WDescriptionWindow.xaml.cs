using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.DataAccess.Repositories;
using MindWord.Domain.Entities;
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
    /// Interaction logic for WDescriptionWindow.xaml
    /// </summary>
    public partial class WDescriptionWindow : Window
    {
        static int correctPoints = 0;
        static int index = 0;
        static int maxPage;
        static List<Word> words;
        public WDescriptionWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void btDesc_Click(object sender, RoutedEventArgs e)
        {
            if (index == words.Count())
            {
                HelperShowWindow helperShowWindow = new HelperShowWindow();
                helperShowWindow.tbHelperShow.Text = $"Your result is {correctPoints}";
                helperShowWindow.ShowDialog();
                correctPoints = 0;
                index = 0;
                this.Close();
            }
            int cor = 0;
            int err = 0;
            if (txDesc.Text is null || words[index].Name.ToLower() != txDesc.Text.ToLower())
            {
                err= 1;
            }
            else
            {
                cor= 1;
                correctPoints++;
            }
            IWordRepository repository = new WordRepository();
            Word word = new Word() 
            {
                Name = words[index].Name,
                Description= words[index].Description,
                Translate = words[index].Translate,
                AudioPath= words[index].AudioPath,
                ErrorCoins = (words[index].ErrorCoins + err),
                CorrectCoins = (words[index].CorrectCoins + cor),
                CategoryId= words[index].CategoryId,
                UserId= words[index].UserId
            };
            await repository.UpdateAsync(words[index].Id, word);
            index++;
            if (index == words.Count())
            {
                HelperShowWindow helperShowWindow = new HelperShowWindow();
                helperShowWindow.tbHelperShow.Text = $"Your result is {correctPoints}";
                helperShowWindow.ShowDialog();
                correctPoints = 0;
                index = 0;
                this.Close();
            }
            lbDesc.Text = words[index].Description;
            txDesc.Text = null;
            lbPage.Content = $"{index + 1}/{maxPage}";
        }

        private void txDesc_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                GameService gameService = new GameService();
                words = await gameService.RandomTestDescriptionAsync();
                if(words.Count == 0)
                {
                    throw new Exception();
                }
                else
                {
                    lbDesc.Text = words[index].Description;
                    if (words.Count <= 15)
                    {
                        lbPage.Content = $"{index + 1}/{words.Count}";
                        maxPage = words.Count;
                    }
                    else
                    {
                        lbPage.Content = $"{index + 1}/{15}";
                        maxPage = 15;
                    }
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
    }
}
