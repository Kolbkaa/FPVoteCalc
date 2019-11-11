using System.Collections.Generic;
using System.Linq;

namespace VoteCalc.Database.Repository
{
    internal class StatisticRepository
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

        public int CountAllWithoutRightVote()
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Vote.Count(x => x.WithoutRight);
            }
        }

        public bool IsAnyVote()
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Vote.Any();
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
            var candidates = new CandidateRepository().GetAll();

            using (var dbContext = new AppDbContext())
            {
                foreach (var candidate in candidates)
                {
                    if (dictionary.ContainsKey(candidate.Party)) continue;

                    var count = dbContext.Vote.Where(x => x.CandidateEntity != null).Count(x => x.CandidateEntity.GetDecryptCandidate().Party == candidate.Party);
                    dictionary.Add(candidate.Party, count);
                }
                return dictionary;
            }

        }
    }
}
