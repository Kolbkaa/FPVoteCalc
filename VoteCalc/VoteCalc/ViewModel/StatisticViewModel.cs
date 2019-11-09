using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using VoteCalc.Database.Repository;

namespace VoteCalc.Model
{
    class StatisticViewModel
    {
        private double _allValidVote;
        public string AllValidVote => $"{Math.Round((_allValidVote / (_allValidVote + _allInvalidVote)) * 100)}";
        private double _allInvalidVote;
        public string AllInvalidVote => $"{Math.Round((_allInvalidVote / (_allValidVote + _allInvalidVote)) * 100)}";
        public ObservableCollection<KeyValuePair<string, int>> CandidateStatistic { get; set; }
        public ObservableCollection<KeyValuePair<string, int>> PartyStatistic { get; set; }

        public StatisticViewModel()
        {
            LoadStatistic();
        }
        public void LoadStatistic()
        {
            var statisticRepository = new StatisticRepository();

            _allValidVote = statisticRepository.CountAllValidVote();
            _allInvalidVote = statisticRepository.CountAllInvalidVote();
            CandidateStatistic = new ObservableCollection<KeyValuePair<string, int>>(statisticRepository.CandidateStatistic());
            PartyStatistic = new ObservableCollection<KeyValuePair<string, int>>(statisticRepository.PartyStatistic());


        }
    }
}
