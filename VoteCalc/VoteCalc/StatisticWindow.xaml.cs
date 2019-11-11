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
using VoteCalc.Logic;
using VoteCalc.Model;
using VoteCalc.Tools;
using VoteCalc.ViewModel;

namespace VoteCalc
{
    /// <summary>
    /// Interaction logic for StatisticWindow.xaml
    /// </summary>
    public partial class StatisticWindow : Window
    {
        private StatisticViewModel _statisticModel;
        public StatisticWindow()
        {
            _statisticModel = new StatisticViewModel();
            this.DataContext = _statisticModel;
            InitializeComponent();

        }



        private void LogOff_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginWindows = new MainWindow();
            loginWindows.Show();
            Logoff.LogoffToLogin();
            
        }
        private void Chart_Click(object sender, RoutedEventArgs e)
        {
            ChartWindow chartWindow = new ChartWindow();
            chartWindow.ShowDialog();
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
