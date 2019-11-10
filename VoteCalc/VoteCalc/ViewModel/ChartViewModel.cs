using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteCalc.Model;

namespace VoteCalc.ViewModel
{
    public class ChartViewModel:StatisticViewModel
    {

        public double ChartWidth { get; } = 200;
        public new KeyValuePair<string,double> AllValidVote => new KeyValuePair<string, double>( $"{Math.Round(((double)_allValidVote / ((double)_allValidVote + (double)_allInvalidVote)) * 100) }%",Math.Round(((double)_allValidVote / ((double)_allValidVote + (double)_allInvalidVote)) * 100) *(ChartWidth / 100));
        public new KeyValuePair<string, double> AllInvalidVote => new KeyValuePair<string, double>($"{Math.Round(((double)_allInvalidVote / ((double)_allValidVote + (double)_allInvalidVote)) * 100)}%", Math.Round(((double)_allInvalidVote / ((double)_allValidVote + (double)_allInvalidVote)) * 100) * (ChartWidth / 100));

        public new double AllVote => _allInvalidVote + _allValidVote;
        public new ObservableCollection<KeyValuePair<string, KeyValuePair<string, double>>> CandidateStatistic
        {
            get
            {
                var candidate = new ObservableCollection<KeyValuePair<string, KeyValuePair<string, double>>>();
                foreach (var keyValuePair in _candidateStatistic.OrderByDescending(x => x.Value))
                {
                    candidate.Add(new KeyValuePair<string, KeyValuePair<string, double>>(keyValuePair.Key, new KeyValuePair<string, double>($"{(Math.Round(((double)keyValuePair.Value / ((double)_allValidVote)) * 100))}%", (Math.Round(((double)keyValuePair.Value / ((double)_allValidVote)) * 100)) * (ChartWidth / 100))));
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
                    party.Add(new KeyValuePair<string, KeyValuePair<string, double>>(keyValuePair.Key, new KeyValuePair<string, double>($"{(Math.Round(((double)keyValuePair.Value / ((double)_allValidVote)) * 100))}%", (Math.Round(((double)keyValuePair.Value / ((double)_allValidVote)) * 100)) * (ChartWidth / 100))));
                }

                return party;
            }
        }

    }
}
