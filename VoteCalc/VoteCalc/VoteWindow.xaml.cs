using System.Linq;
using System.Windows;
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
    internal partial class VoteWindow
    {
        private readonly Voter _voter;
        private readonly VoteViewModel _voteViewModel;

        internal VoteWindow(Voter voter)
        {
            _voteViewModel = new VoteViewModel();

            this.DataContext = _voteViewModel;
            InitializeComponent();
            _voter = voter;

        }

        private void LogOff_Click(object sender, RoutedEventArgs e)
        {
            Logoff.LogoffToLogin();
        }

        private void Vote_OnClick(object sender, RoutedEventArgs e)
        {

            var vote = new Vote();
            var confirmVote = MessageBox.Show("Please confirm your vote.", "VOTE", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirmVote == MessageBoxResult.No) return;

            var block = new BlockedJsonData().GetAll();
            if (block == null)
            {
                ErrorMessage.ShowError("Error blocked pesel data.");
                return;
            }
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

            new StatisticWindow().Show();
            Close();

        }

        private void Statistic_Click(object sender, RoutedEventArgs e)
        {
            if (new StatisticRepository().IsAnyVote())
            {
                new StatisticWindow().ShowDialog();
            }
            else
            {
                MessageBox.Show("No vote in database.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }

}
