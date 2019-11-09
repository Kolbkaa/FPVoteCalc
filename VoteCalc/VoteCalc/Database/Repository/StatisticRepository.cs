using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace VoteCalc.Database.Repository
{
    class StatisticRepository
    {

        public int CountAllValidVote()
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Vote.Count(x => x.ValidVote);
            }
        }
        public int CountAllInvalidVote()
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Vote.Count(x => !x.ValidVote);
            }
        }

        public Dictionary<string, int> CandidateStatistic()
        {
            var dictionary = new Dictionary<string, int>();
            var candidateRepository = new CandidateRepository();
            var candidateList = candidateRepository.GetAll();
            using (var dbContext = new AppDbContext())
            {
                foreach (var candidate in candidateList)
                {
                    if (dictionary.ContainsKey(candidate.Name)) continue;
                    var count = dbContext.Vote.Count(x => x.CandidateEntity.Id == candidate.Id);
                    dictionary.Add(candidate.Name, count);
                }

                return dictionary;
            }

        }
        public Dictionary<string, int> PartyStatistic()
        {
            var dictionary = new Dictionary<string, int>();
            var candidateRepository = new CandidateRepository();
            var candidateList = candidateRepository.GetAll();
            using (var dbContext = new AppDbContext())
            {
                foreach (var candidate in candidateList)
                {
                    if (dictionary.ContainsKey(candidate.Party)) continue;
                    var count = dbContext.Vote.Count(x => x.CandidateEntity.Party == candidate.Party);
                    dictionary.Add(candidate.Party, count);
                }

                return dictionary;
            }

        }
    }
}
