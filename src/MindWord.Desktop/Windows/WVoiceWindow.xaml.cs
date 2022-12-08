using Microsoft.Win32;
using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.DataAccess.Repositories;
using MindWord.Domain.Entities;
using MindWord.Service.Services;
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
        static List<Word> res;

        public WVoiceWindow()
        {
            InitializeComponent();
        }

        private async void btVoice_Click(object sender, RoutedEventArgs e)
        {
            int cor = 0;
            int err = 0;
            if(index == res.Count)
            {
                HelperShowWindow helperShowWindow = new HelperShowWindow();
                helperShowWindow.tbHelperShow.Text = $"Your score is {correctPoints} from {res.Count}!";
                helperShowWindow.ShowDialog();
                index = 0;
                correctPoints = 0;
                this.Close();
            }
            else if(txVoice.Text.ToString().ToLower() == res[index].Translate.ToLower())
            {
                cor = 1;
                correctPoints++;
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
            index++;
            if (index == res.Count)
            {
                HelperShowWindow helperShowWindow = new HelperShowWindow();
                helperShowWindow.tbHelperShow.Text = $"Your score is {correctPoints} from {res.Count}!";
                helperShowWindow.ShowDialog();
                index = 0;
                correctPoints = 0;
                this.Close();
            }

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GameService gameService = new GameService();
            res = await gameService.RandomTestVoiceAsync();
        }

        private void btPlay_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            FileInfo fileInfo = new FileInfo(res[index].AudioPath);
            var file = fileInfo.FullName;
            mediaPlayer.Open(new Uri(file));
            mediaPlayer.Play();
        }
    }
}
