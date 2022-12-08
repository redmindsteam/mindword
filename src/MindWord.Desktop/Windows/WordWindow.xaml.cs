using Integrated.Interfaces;
using Integrated.Services;
using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.DataAccess.Repositories;
using MindWord.Domain.Entities;
using MindWord.Service.Attributes;
using MindWord.Service.Interfaces.Services;
using MindWord.Service.Services.Common;
using System;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            //BtnVoice.Visibility = Visibility.Collapsed;
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

        private async void BtnAddWord_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxCategory.Text == "")
            {
                HelperShowWindow helperShowWindow = new HelperShowWindow();
                helperShowWindow.tbHelperShow.Text = "Please, choose any category if don't have please create!";
                helperShowWindow.ShowDialog();
                this.Close();
            }
            else
            {

                IDefinationAPIService definationAPI = new DefinationAPIService();


                if (txWord.Text != "" && txTranslation.Text != "")
                {

                    var Word = await definationAPI.GetWordAsync(txWord.Text);
                    Word.word.Translate = txTranslation.Text;
                    Category category;
                    {
                        ICategoryRepository categoryRepository = new CategoryRepository();
                        category = await categoryRepository.GetByTitleAsync(ComboBoxCategory.SelectedItem.ToString());
                    }
                    Word.word.CategoryId = (category).Id;
                    Word.word.UserId = IdentitySingelton.currentId().UserId;
                    if (Word.successful)
                    {
                        IWordRepository wordRepository = new WordRepository();

                        var res = await wordRepository.CreateAsync(Word.word);
                        if (res)
                        {
                            HelperShowWindow helperShowWindow = new HelperShowWindow();
                            helperShowWindow.tbHelperShow.Text = "Added Word";
                            helperShowWindow.ShowDialog();
                            txWord.Text = "";
                            txTranslation.Text = "";
                            TxbDescription.Text = "";
                        }
                        else
                        {
                            HelperShowWindow helperShowWindow = new HelperShowWindow();
                            helperShowWindow.tbHelperShow.Text = "No Added";
                            helperShowWindow.ShowDialog();
                            TxbDescription.Text = "";
                        }

                    }
                    else
                    {
                        HelperShowWindow helperShowWindow = new HelperShowWindow();
                        helperShowWindow.tbHelperShow.Text = "No Word!";
                        helperShowWindow.ShowDialog();
                    }
                }
            }
        }
            private void btnClose_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }

            private void ComboBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

            }
        
    }
}
