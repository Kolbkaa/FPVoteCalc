using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Navigation;
using VoteCalc.Annotations;
using VoteCalc.Database.Repository;

namespace VoteCalc.Model
{
    class StatisticViewModel
    {
        private int _allValidVote;
        public string AllValidVote => $"Valid vote: {Math.Round(((double)_allValidVote / ((double)_allValidVote + (double)_allInvalidVote)) * 100)}%";
        private int _allInvalidVote;
        private ObservableCollection<KeyValuePair<string, int>> _candidateStatistic;
        private ObservableCollection<KeyValuePair<string, int>> _partyStatistic;
        public string AllInvalidVote => $"Invalid vote: {Math.Round(((double)_allInvalidVote / ((double)_allValidVote + (double)_allInvalidVote)) * 100)}%";

        public string AllVote => $"All vote: {_allInvalidVote + _allValidVote}";
        public ObservableCollection<KeyValuePair<string, string>> CandidateStatistic
        {
            get
            {
                var candidate = new ObservableCollection<KeyValuePair<string, string>>();
                foreach (var keyValuePair in _candidateStatistic.OrderByDescending(x=>x.Value))
                {
                    candidate.Add(new KeyValuePair<string, string>(keyValuePair.Key,$"{Math.Round(((double)keyValuePair.Value / ((double)_allValidVote)) * 100)}%"));
                }

                return candidate;
            }
        }

        public ObservableCollection<KeyValuePair<string, string>> PartyStatistic
        {
            get
            {
                var party = new ObservableCollection<KeyValuePair<string, string>>();
                foreach (var keyValuePair in _partyStatistic.OrderByDescending(x => x.Value))
                {
                    party.Add(new KeyValuePair<string, string>(keyValuePair.Key, $"{Math.Round(((double)keyValuePair.Value / ((double)_allValidVote)) * 100)}%"));
                }

                return party;
            }
        }

        public StatisticViewModel()
        {
            LoadStatistic();
        }
        public void LoadStatistic()
        {
            var statisticRepository = new StatisticRepository();

            _allValidVote = statisticRepository.CountAllValidVote();
            _allInvalidVote = statisticRepository.CountAllInvalidVote();
            _candidateStatistic = new ObservableCollection<KeyValuePair<string, int>>(statisticRepository.CandidateStatistic());
            _partyStatistic = new ObservableCollection<KeyValuePair<string, int>>(statisticRepository.PartyStatistic());
        

        }

    }
}
