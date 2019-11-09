using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VoteCalc.Logic;
using VoteCalc.Model;
using VoteCalc.ViewModel;

namespace VoteCalc
{
    /// <summary>
    /// Interaction logic for VoteWindow.xaml
    /// </summary>
    public partial class VoteWindow : Window
    {
        private Voter _voter;
        private VoteViewModel _voteViewModel;
        public VoteWindow(Voter voter)
        {
            _voteViewModel = new VoteViewModel();

            this.DataContext = _voteViewModel;
            InitializeComponent();
            Candidate.ItemsSource = _voteViewModel.Candidates;
            _voter = voter;

        }

        private void LogOff_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginWindows = new MainWindow();
            loginWindows.Show();
            this.Close();
        }

        private void Vote_OnClick(object sender, RoutedEventArgs e)
        {
            var validVote = true;

            var confirmVote = MessageBox.Show("Please confirm your vote.", "VOTE", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(confirmVote == MessageBoxResult.No) return;

            var block = new BlockedJsonData();
            if (block.GetAll().Contains(_voter.Pesel))
            {
                validVote = false;
                MessageBox.Show("You do not have the right to vote. Your vote will not be valid.", "Warning",
                    MessageBoxButton.OK);
  
            }

            if (_voteViewModel.Candidates.Count(x => x.Vote) != 1)
            {
                validVote = false;
            }
        }
    }

}
