using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.DataAccess.Repositories;
using MindWord.Domain.Entities;
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
    /// Interaction logic for WDescriptionWindow.xaml
    /// </summary>
    public partial class WDescriptionWindow : Window
    {
        static int correctPoints = 0;
        static int index = 0;
        static int maxPage;
        static List<Word> words;
        static List<WordAnswerViewModel>  Answers = new List<WordAnswerViewModel>();
        public WDescriptionWindow()
        {
            InitializeComponent();
            Answers.Clear();    
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void btDesc_Click(object sender, RoutedEventArgs e)
        {
            if (index == words.Count())
            {
                GameResultWindow gameResultWindow = new GameResultWindow();
                WordService wordService = new WordService();
                var pagelist = await wordService.GetAnswersPagedListAsync(1, int.Parse(gameResultWindow.pageSize.Text), Answers);
                gameResultWindow.dgData.ItemsSource = pagelist;
                gameResultWindow.lbResultgame.Content = string.Format("Result: {0}/{1}", correctPoints, Answers.Count);

                gameResultWindow.ShowDialog();
                correctPoints = 0;
                index = 0;
                this.Close();
            }
            int cor = 0;
            int err = 0;
            if (txDesc.Text is null || words[index].Name.ToLower() != txDesc.Text.ToLower())
            {
                err= 1;
                WordAnswerViewModel wordAnswerView = new WordAnswerViewModel()
                {
                    Id = words[index].Id,   
                    Word = words[index].Name,
                    Translate = words[index].Translate,
                    Info = words[index].Description,
                    Status = "❌"
                }; 
                Answers.Add(wordAnswerView);    
            }
            else
            {
                cor= 1;
                correctPoints++;
                WordAnswerViewModel wordAnswerView = new WordAnswerViewModel()
                {
                    Id = words[index].Id,
                    Word = words[index].Name,
                    Translate = words[index].Translate,
                    Info = words[index].Description,
                    Status = "✔️"
                };
                Answers.Add(wordAnswerView);
            }
            IWordRepository repository = new WordRepository();
            
            await repository.UpdateAsync(words[index].Id, words[index]);
            index++;
            if (index == words.Count())
            {
                GameResultWindow gameResultWindow = new GameResultWindow();
                WordService wordService = new WordService();
                var pagelist = await wordService.GetAnswersPagedListAsync(1,int.Parse(gameResultWindow.pageSize.Text),Answers);
                gameResultWindow.dgData.ItemsSource = pagelist;
                gameResultWindow.lbResultgame.Content = string.Format("Result: {0}/{1}", correctPoints, Answers.Count);

                gameResultWindow.ShowDialog();

               
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
