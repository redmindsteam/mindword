using System;
using System.Windows.Controls;


namespace MindWord.Desktop.Components.Basic
{
    /// <summary>
    /// Interaction logic for SearchBox.xaml
    /// </summary>
    public partial class SearchBox : UserControl
    {
        public string Text
        {
            get
            {
                return tbSearchBox.Text;
            }
            set
            {
                tbSearchBox.Text = value;
            }
        } 

        public Action<string> TextParentChangedEvent { get; set; } = null!;

        public SearchBox()
        {
            InitializeComponent();
        }

        private void tbSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextParentChangedEvent(tbSearchBox.Text);
        }
    }
}
