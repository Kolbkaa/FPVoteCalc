using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteCalc.Database.Repository;

namespace VoteCalc.Model
{
    class StatisticViewModel
    {
        public int AllValidVote { get; set; }
        public int AllInvalidVote { get; set; }
        public Dictionary<string,int> CandidateStatistic { get; set; }
        public Dictionary<string,int> PartyStatistic { get; set; }
        public StatisticViewModel()
        {
            LoadStatistic();
        }
        public void LoadStatistic()
        {
            var statisticRepository = new StatisticRepository();

            AllValidVote = statisticRepository.CountAllValidVote();
            AllInvalidVote = statisticRepository.CountAllInvalidVote();
            CandidateStatistic = statisticRepository.CandidateStatistic();
            PartyStatistic = statisticRepository.PartyStatistic();

        }
    }
}
