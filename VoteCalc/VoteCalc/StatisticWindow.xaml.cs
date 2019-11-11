using System.Windows;
using VoteCalc.Tools;
using VoteCalc.ViewModel;

namespace VoteCalc
{
    /// <summary>
    /// Interaction logic for StatisticWindow.xaml
    /// </summary>
    public partial class StatisticWindow
    {
        private readonly StatisticViewModel _statisticModel;
        public StatisticWindow()
        {
            _statisticModel = new StatisticViewModel();
            this.DataContext = _statisticModel;
            InitializeComponent();

        }

        private void LogOff_Click(object sender, RoutedEventArgs e)
        {
            Logoff.LogoffToLogin();
        }
        private void Chart_Click(object sender, RoutedEventArgs e)
        {
            new ChartWindow().ShowDialog();
        }

        private void ExportToCSV_Click(object sender, RoutedEventArgs e)
        {
            _statisticModel.ExportDataToCsv();
        }

        private void ExportToPDF_Click(object sender, RoutedEventArgs e)
        {
            _statisticModel.ExportDataToPdf();
        }
    }
}
