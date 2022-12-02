using Integrated.Interfaces;
using Integrated.Services;
using MindWord.DataAccess.Interfaces.Repositories;
using System;
using System.IO;
using System.Security.Policy;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MindWord.Desktop.Windows
{
    /// <summary>
    /// Логика взаимодействия для WordPage.xaml
    /// </summary>


    public partial class WordWindow : Window
    {
        public WordWindow()
        {
            InitializeComponent();
            
            
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void txWord_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }


        private async void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            IDefinationAPIService definationAPI = new DefinationAPIService();


            if (txWord.Text != "" || txTranslation.Text != "")
            {

                 var Word =  await definationAPI.GetWordAsync(txWord.Text);

                if (Word.successful)
                {
                    if(Word.word.AudioPath != null)
                    {
                        
                        MediaPlayer mediaPlayer = new MediaPlayer();
                        FileInfo fileInfo = new FileInfo(Word.word.AudioPath);
                        var file = fileInfo.FullName;

                        mediaPlayer.Open(new Uri(file));
                        mediaPlayer.Play();

                    }
                    TxbDescription.Text = "Description: " + Word.word.Description;
                }
            }
            
        }

        private void txWord_TextChanged_1(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
