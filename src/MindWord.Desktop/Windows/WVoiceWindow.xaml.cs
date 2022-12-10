using Microsoft.Win32;
using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.DataAccess.Repositories;
using MindWord.Domain.Entities;
using MindWord.Service.Services;
using MindWord.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace MindWord.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for WVoiceWindow.xaml
    /// </summary>
    public partial class WVoiceWindow : Window
    {
        static int index = 0;
        static int correctPoints = 0;
        static int maxPage;
        static List<Word> res;
        static List<VoicetestResultViewModel> Answers= new List<VoicetestResultViewModel>();    

        public WVoiceWindow()
        {
            InitializeComponent();
            Answers.Clear();    
        }

        private async void btVoice_Click(object sender, RoutedEventArgs e)
        {
            int cor = 0;
            int err = 0;
            VoicetestResultViewModel voicetestResult = new VoicetestResultViewModel();
            if (index != res.Count)
            {
               voicetestResult = new VoicetestResultViewModel()
                {
                    Answer = txVoice.Text.ToString(),
                    AudioPath = res[index].AudioPath,
                    Translate = res[index].Translate,
                    Id = index + 1,
                    Status = "❌"
                };
            }

            if (index == res.Count || index >= 15)
            {
                GameVoiceResultWindow gameVoiceResultWindow = new GameVoiceResultWindow();
                gameVoiceResultWindow.dgData.ItemsSource = Answers;
                this.Close();
                gameVoiceResultWindow.lbResultgame.Content = string.Format("Result {0}/{1}", correctPoints, Answers.Count);
                gameVoiceResultWindow.ShowDialog();
                index = 0;
                correctPoints = 0;
            }
            
            else if(txVoice.Text.ToString().ToLower() == res[index].Translate.ToLower())
            {
                cor = 1;
                correctPoints++;
                voicetestResult.Status = "✔️";
            }
            else
            {
                err = 1;
            }
            
            IWordRepository repository = new WordRepository();
            Word word = new Word()
            {
                Name = res[index].Name,
                Description = res[index].Description,
                Translate = res[index].Translate,
                AudioPath = res[index].AudioPath,
                ErrorCoins = (res[index].ErrorCoins + err),
                CorrectCoins = (res[index].CorrectCoins + cor),
                CategoryId = res[index].CategoryId,
                UserId = res[index].UserId
            };

            await repository.UpdateAsync(res[index].Id, word);
            txVoice.Text = "";
            lbPage.Content = $"{index + 1}/{maxPage}";
            index++;
            Answers.Add(voicetestResult);
           

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                GameService gameService = new GameService();
                res = await gameService.RandomTestVoiceAsync();
                index = 0;
                correctPoints = 0;
                
                if (res.Count == 0)
                {
                    throw new Exception();
                }
                else
                {
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
            }
            catch
            {
                HelperShowWindow helperShowWindow = new HelperShowWindow();
                helperShowWindow.tbHelperShow.Text = "Word is not enough!";
                this.Close();
                helperShowWindow.ShowDialog();
            }
        }

        private void btPlay_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            FileInfo fileInfo = new FileInfo(res[index].AudioPath);
            var file = fileInfo.FullName;
            mediaPlayer.Open(new Uri(file));
            mediaPlayer.Play();
        }

        private void mouse(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
