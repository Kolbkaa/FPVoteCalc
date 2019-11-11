using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace VoteCalc.ViewModel
{
    internal class ChartViewModel:StatisticViewModel
    {

        public double ChartWidth { get; } = 200;
        public new KeyValuePair<string,double> AllValidVote => new KeyValuePair<string, double>( $"{Math.Round(_allValidVote / (_allValidVote + (double)_allInvalidVote) * 100) }%",Math.Round(_allValidVote / (_allValidVote + (double)_allInvalidVote) * 100) *(ChartWidth / 100));
        public new KeyValuePair<string, double> AllInvalidVote => new KeyValuePair<string, double>($"{Math.Round(_allInvalidVote / (_allValidVote + (double)_allInvalidVote) * 100)}%", Math.Round(_allInvalidVote / (_allValidVote + (double)_allInvalidVote) * 100) * (ChartWidth / 100));

        public new double AllVote => _allInvalidVote + _allValidVote;
        public new ObservableCollection<KeyValuePair<string, KeyValuePair<string, double>>> CandidateStatistic
        {
            get
            {
                var candidate = new ObservableCollection<KeyValuePair<string, KeyValuePair<string, double>>>();
                foreach (var keyValuePair in _candidateStatistic.OrderByDescending(x => x.Value))
                {
                    candidate.Add(new KeyValuePair<string, KeyValuePair<string, double>>(keyValuePair.Key, new KeyValuePair<string, double>($"{Math.Round(keyValuePair.Value / (double)_allValidVote * 100)}%", Math.Round(keyValuePair.Value / (double)_allValidVote * 100) * (ChartWidth / 100))));
                }

                return candidate;
            }
        }

        public new ObservableCollection<KeyValuePair<string, KeyValuePair<string, double>>> PartyStatistic
        {
            get
            {
                var party = new ObservableCollection<KeyValuePair<string, KeyValuePair<string, double>>>();
                foreach (var keyValuePair in _partyStatistic.OrderByDescending(x => x.Value))
                {
                    party.Add(new KeyValuePair<string, KeyValuePair<string, double>>(keyValuePair.Key, new KeyValuePair<string, double>($"{Math.Round(keyValuePair.Value / (double)_allValidVote * 100)}%", Math.Round(keyValuePair.Value / (double)_allValidVote * 100) * (ChartWidth / 100))));
                }

                return party;
            }
        }

    }
}
