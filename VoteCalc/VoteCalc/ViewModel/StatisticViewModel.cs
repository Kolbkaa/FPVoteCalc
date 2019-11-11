using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VoteCalc.Database.Repository;
using VoteCalc.Logic;

namespace VoteCalc.ViewModel
{
    internal class StatisticViewModel
    {
        protected int _allValidVote;
        public string AllValidVote => $"Valid vote: {Math.Round(_allValidVote / (_allValidVote + (double)_allInvalidVote) * 100)}%";

        protected int _allInvalidVote;
        public string AllInvalidVote => $"Invalid vote: {Math.Round(_allInvalidVote / (_allValidVote + (double)_allInvalidVote) * 100)}%";

        public string AllVote => $"All vote: {_allInvalidVote + _allValidVote}";

        protected int _allVoteWithoutRight;
        protected ObservableCollection<KeyValuePair<string, int>> _candidateStatistic;
        public ObservableCollection<KeyValuePair<string, string>> CandidateStatistic
        {
            get
            {
                var candidate = new ObservableCollection<KeyValuePair<string, string>>();
                foreach (var keyValuePair in _candidateStatistic.OrderByDescending(x => x.Value))
                {
                    candidate.Add(_allValidVote == 0
                        ? new KeyValuePair<string, string>(keyValuePair.Key, "0%")
                        : (new KeyValuePair<string, string>(keyValuePair.Key,
                            $"{Math.Round(keyValuePair.Value / (double)_allValidVote * 100)}%")));
                }

                return candidate;
            }
        }

        protected ObservableCollection<KeyValuePair<string, int>> _partyStatistic;
        public ObservableCollection<KeyValuePair<string, string>> PartyStatistic
        {
            get
            {
                var party = new ObservableCollection<KeyValuePair<string, string>>();
                foreach (var keyValuePair in _partyStatistic.OrderByDescending(x => x.Value))
                {
                    party.Add(_allValidVote == 0
                        ? new KeyValuePair<string, string>(keyValuePair.Key, "0%")
                        : new KeyValuePair<string, string>(keyValuePair.Key,
                            $"{Math.Round(keyValuePair.Value / (double)_allValidVote * 100)}%"));
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
            _allVoteWithoutRight = statisticRepository.CountAllWithoutRightVote();

            var candidateStatistic = statisticRepository.CandidateStatistic();
            if (candidateStatistic != null)
                _candidateStatistic = new ObservableCollection<KeyValuePair<string, int>>(candidateStatistic);

            var partyStatistic = statisticRepository.PartyStatistic();
            if (partyStatistic != null)
                _partyStatistic = new ObservableCollection<KeyValuePair<string, int>>(partyStatistic);

        }

        public void ExportDataToCsv()
        {
            var exportCsv = new ExportDataToCsv();
            exportCsv.AddDataToFile("All invalid vote", _allInvalidVote.ToString());
            exportCsv.AddDataToFile("All valid vote", _allValidVote.ToString());
            exportCsv.AddDataToFile("All vote without rights", _allVoteWithoutRight.ToString());
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
            exportPdf.AddDataToFile("All vote without rights", _allVoteWithoutRight.ToString());
            exportPdf.AddDataToFile("All vote", (_allInvalidVote + _allValidVote).ToString());
            exportPdf.AddTextToFile("");

            exportPdf.AddTextToFile("Candidate statistic:");
            exportPdf.AddTextToFile("");
            exportPdf.AddDataToFile(_candidateStatistic.ToDictionary(x => x.Key, y => y.Value.ToString()));
            exportPdf.AddTextToFile("");

            exportPdf.AddTextToFile("Party statistic:");
            exportPdf.AddTextToFile("");
            exportPdf.AddDataToFile(_partyStatistic.ToDictionary(x => x.Key, y => y.Value.ToString()));
            exportPdf.AddTextToFile("");

            exportPdf.Export();
        }
    }
}
