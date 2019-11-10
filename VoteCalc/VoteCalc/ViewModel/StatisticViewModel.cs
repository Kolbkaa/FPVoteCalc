using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Navigation;
using VoteCalc.Annotations;
using VoteCalc.Database.Repository;
using VoteCalc.Logic;

namespace VoteCalc.Model
{
    public class StatisticViewModel
    {
        protected int _allValidVote;
        public string AllValidVote => $"Valid vote: {Math.Round(((double)_allValidVote / ((double)_allValidVote + (double)_allInvalidVote)) * 100)}%";
        protected int _allInvalidVote;
        protected ObservableCollection<KeyValuePair<string, int>> _candidateStatistic;
        protected ObservableCollection<KeyValuePair<string, int>> _partyStatistic;
        public string AllInvalidVote => $"Invalid vote: {Math.Round(((double)_allInvalidVote / ((double)_allValidVote + (double)_allInvalidVote)) * 100)}%";

        public string AllVote => $"All vote: {_allInvalidVote + _allValidVote}";
        public ObservableCollection<KeyValuePair<string, string>> CandidateStatistic
        {
            get
            {
                var candidate = new ObservableCollection<KeyValuePair<string, string>>();
                foreach (var keyValuePair in _candidateStatistic.OrderByDescending(x => x.Value))
                {
                    candidate.Add(new KeyValuePair<string, string>(keyValuePair.Key, $"{Math.Round(((double)keyValuePair.Value / ((double)_allValidVote)) * 100)}%"));
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
        
        public void ExportDataToCsv()
        {
            var exportCsv = new ExportDataToCsv();
            exportCsv.AddDataToFile("All invalid vote", _allInvalidVote.ToString());
            exportCsv.AddDataToFile("All valid vote", _allValidVote.ToString());
            exportCsv.AddDataToFile("All vote", (_allInvalidVote + _allValidVote).ToString());

            exportCsv.AddDataToFile(_candidateStatistic.ToDictionary(x => x.Key, y => y.Value.ToString()));

            exportCsv.AddDataToFile(_partyStatistic.ToDictionary(x => x.Key, y => y.Value.ToString()));

            exportCsv.Export();


        }

        public void ExportDataToPdf()
        {
            var exportPdf = new ExportDataToPdf();
            exportPdf.AddTextToFile("Statistic:");
            exportPdf.AddTextToFile("");

            exportPdf.AddDataToFile("All invalid vote", _allInvalidVote.ToString());
            exportPdf.AddDataToFile("All valid vote", _allValidVote.ToString());
            exportPdf.AddDataToFile("All vote", (_allInvalidVote + _allValidVote).ToString());
            exportPdf.AddTextToFile("");

            exportPdf.AddTextToFile("Candidate statistic:");
            exportPdf.AddTextToFile("");
            exportPdf.AddDataToFile(_candidateStatistic.ToDictionary(x => x.Key, y => y.Value.ToString()));
            exportPdf.AddTextToFile("");

            exportPdf.AddTextToFile("Party statistic:");
            exportPdf.AddTextToFile("");
            exportPdf.AddDataToFile(_partyStatistic.ToDictionary(x => x.Key, y => y.Value.ToString())); exportPdf.AddTextToFile("Statistic:");
            exportPdf.AddTextToFile("");

            exportPdf.AddDataToFile("All invalid vote", _allInvalidVote.ToString());
            exportPdf.AddDataToFile("All valid vote", _allValidVote.ToString());
            exportPdf.AddDataToFile("All vote", (_allInvalidVote + _allValidVote).ToString());
            exportPdf.AddTextToFile("");

            exportPdf.AddTextToFile("Candidate statistic:");
            exportPdf.AddTextToFile("");
            exportPdf.AddDataToFile(_candidateStatistic.ToDictionary(x => x.Key, y => y.Value.ToString()));
            exportPdf.AddTextToFile("");

            exportPdf.AddTextToFile("Party statistic:");
            exportPdf.AddTextToFile("");
            exportPdf.AddDataToFile(_partyStatistic.ToDictionary(x => x.Key, y => y.Value.ToString())); exportPdf.AddTextToFile("Statistic:");
            exportPdf.AddTextToFile("");

            exportPdf.AddDataToFile("All invalid vote", _allInvalidVote.ToString());
            exportPdf.AddDataToFile("All valid vote", _allValidVote.ToString());
            exportPdf.AddDataToFile("All vote", (_allInvalidVote + _allValidVote).ToString());
            exportPdf.AddTextToFile("");

            exportPdf.AddTextToFile("Candidate statistic:");
            exportPdf.AddTextToFile("");
            exportPdf.AddDataToFile(_candidateStatistic.ToDictionary(x => x.Key, y => y.Value.ToString()));
            exportPdf.AddTextToFile("");

            exportPdf.AddTextToFile("Party statistic:");
            exportPdf.AddTextToFile("");
            exportPdf.AddDataToFile(_partyStatistic.ToDictionary(x => x.Key, y => y.Value.ToString()));

            exportPdf.Export();
        }
    }
}
