using LiveCharts.Wpf;
using LiveCharts;
using System.Windows.Controls;

namespace MindWord.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public HomePage()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "Series 3",
                    Values = new ChartValues<double> { 4,2,7,2,7 },
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15
                }
            };

            DataContext = this;
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            SeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title= "Home",
                    Values = new ChartValues<double> { 6},
                },
                new PieSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> { 7 },
                },
                new PieSeries
                {
                    Title = "Series 3",
                    Values = new ChartValues<double> { 9},
                }
            };


            circleCharts.Series = SeriesCollection;
        }
    }
}
