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
using VoteCalc.Model;
using VoteCalc.Tools;
using VoteCalc.ViewModel;

namespace VoteCalc
{
    /// <summary>
    /// Interaction logic for ChartWindow.xaml
    /// </summary>
    public partial class ChartWindow : Window
    {
  
        public ChartViewModel ChartViewModel { get; }

        public ChartWindow()
        {
            ChartViewModel = new ChartViewModel();
            this.DataContext = ChartViewModel;
            InitializeComponent();
            
        }

        private void LogOff_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginWindows = new MainWindow();
            loginWindows.Show();
            Logoff.LogoffToLogin();
            
        }

       
    }
}
