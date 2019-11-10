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
using VoteCalc.Database.Repository;
using VoteCalc.Logic;
using VoteCalc.Model;
using VoteCalc.Tools;
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
            Logoff.LogoffToLogin();
        }

        private void Vote_OnClick(object sender, RoutedEventArgs e)
        {
            
            var vote = new Vote();
            var confirmVote = MessageBox.Show("Please confirm your vote.", "VOTE", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(confirmVote == MessageBoxResult.No) return;

            var block = new BlockedJsonData().GetAll();
            if(block == null) return;
            if (block.Contains(_voter.Pesel))
            {
                vote.ValidVote = false;
                vote.WithoutRight = true;
                MessageBox.Show("You do not have the right to vote. Your vote will not be valid.", "Warning",
                    MessageBoxButton.OK);
  
            }

            if (_voteViewModel.Candidates.Count(x => x.Vote) != 1)
            {
                vote.ValidVote = false;
            }
            else
            {
                vote.Candidate = _voteViewModel.Candidates.SingleOrDefault(x => x.Vote);
            }
            vote.Voters = _voter;

            var votersRepository = new VotersRepository();
            if (votersRepository.IsExist(_voter))
            {
                
                    MessageBox.Show("You can't vote. You have already cast your vote.", "Warning",
                        MessageBoxButton.OK);
                    return;
            }

            votersRepository.Save(_voter);

            var voteRepository = new VoteRepository();
            voteRepository.Save(vote);

            StatisticWindow statisticWindow = new StatisticWindow();
            statisticWindow.Show();

            Close();

        }

        private void Statistic_Click(object sender, RoutedEventArgs e)
        {
            StatisticWindow statisticWindow = new StatisticWindow();
            statisticWindow.ShowDialog();
        }
    }

}
