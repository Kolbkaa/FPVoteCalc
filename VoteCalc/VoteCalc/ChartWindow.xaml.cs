using System.Windows;
using VoteCalc.Tools;
using VoteCalc.ViewModel;

namespace VoteCalc
{
    /// <summary>
    /// Interaction logic for ChartWindow.xaml
    /// </summary>
    public partial class ChartWindow : Window
    {
        public ChartWindow()
        {
            var chartViewModel = new ChartViewModel();
            this.DataContext = chartViewModel;
            InitializeComponent();
            
        }

        private void LogOff_Click(object sender, RoutedEventArgs e)
        {
            Logoff.LogoffToLogin();
        }

       
    }
}
