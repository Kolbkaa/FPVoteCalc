using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using VoteCalc.Tools;

namespace VoteCalc.Database.Repository
{
    internal class StatisticRepository
    {
        public int CountAllValidVote()
        {
            try
            {
                using (var dbContext = new AppDbContext())
                {
                    return dbContext.Vote.Count(x => x.ValidVote);
                }
            }
            catch (Exception exception)
            {
                ErrorMessage.ShowError($"Can not connect to database.\n", exception);
                Application.Current.Shutdown();
                return int.MinValue;
            }
        }
        public int CountAllInvalidVote()
        {
            try
            {
                using (var dbContext = new AppDbContext())
                {
                    return dbContext.Vote.Count(x => !x.ValidVote);
                }
            }
            catch (Exception exception)
            {
                ErrorMessage.ShowError($"Can not connect to database.\n", exception);
                Application.Current.Shutdown();
                return int.MinValue;
            }
        }

        public int CountAllWithoutRightVote()
        {
            try
            {
                using (var dbContext = new AppDbContext())
                {
                    return dbContext.Vote.Count(x => x.WithoutRight);
                }
            }
            catch (Exception exception)
            {
                ErrorMessage.ShowError($"Can not connect to database.\n", exception);
                Application.Current.Shutdown();
                return int.MinValue;
            }
        }

        public bool IsAnyVote()
        {
            try
            {
                using (var dbContext = new AppDbContext())
                {
                    return dbContext.Vote.Any();
                }
            }
            catch (Exception exception)
            {
                ErrorMessage.ShowError($"Can not connect to database.\n", exception);
                Application.Current.Shutdown();
                return false;
            }
        }

        public Dictionary<string, int> CandidateStatistic()
        {
            try
            {
                var dictionary = new Dictionary<string, int>();
                var candidateRepository = new CandidateRepository();
                var candidateList = candidateRepository.GetAll();
                using (var dbContext = new AppDbContext())
                {
                    foreach (var candidate in candidateList)
                    {
                        if (dictionary.ContainsKey(candidate.Name)) continue;
                        var count = dbContext.Vote.Count(x => x.CandidateEntity.Id == candidate.Id && x.WithoutRight != true);
                        dictionary.Add(candidate.Name, count);
                    }

                    return dictionary;
                }
            }
            catch (Exception exception)
            {
                ErrorMessage.ShowError($"Can not connect to database.\n", exception);
                Application.Current.Shutdown();
                return null;
            }

        }
        public Dictionary<string, int> PartyStatistic()
        {
            try
            {
                var dictionary = new Dictionary<string, int>();
                var candidates = new CandidateRepository().GetAll();

                using (var dbContext = new AppDbContext())
                {
                    foreach (var candidate in candidates)
                    {
                        if (dictionary.ContainsKey(candidate.Party)) continue;

                        var count = dbContext.Vote.Where(x => x.CandidateEntity != null && x.WithoutRight != true).Count(x => x.CandidateEntity.GetDecryptCandidate().Party == candidate.Party);
                        dictionary.Add(candidate.Party, count);
                    }
                    return dictionary;
                }
            }
            catch (Exception exception)
            {
                ErrorMessage.ShowError($"Can not connect to database.\n", exception);
                Application.Current.Shutdown();
                return null;
            }

        }
    }
}
