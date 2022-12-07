using Integrated.Interfaces;
using Integrated.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MindWord.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for TranslatePage.xaml
    /// </summary>
    public partial class TranslatePage : Page
    {
        public TranslatePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var lang = tbFirst.Text;
            tbFirst.Text = tbSecond.Text;
            tbSecond.Text = lang;
        }

        private async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ITranslateAPIService translateAPI = new TranslateAPIService();
            if(tbFirst.Text == "Uzbek")
            {
                var res = await translateAPI.GetTranslatedWordAsync("uz","en",txFirst.Text);
                if(res.isSuccessful == true)
                {
                    txSecond.Text = res.TranslatedWord;
                }
                else
                {
                    txSecond.Text = res.TranslatedWord;
                }
            }
            if(txFirst.Text == "English")
            {
                var res = await translateAPI.GetTranslatedWordAsync("en", "uz", txFirst.Text);
                if(res.isSuccessful == true)
                {
                    txSecond.Text = res.TranslatedWord;
                }
                else
                {
                    txSecond.Text = res.TranslatedWord;
                }
            }
        }
    }
}
