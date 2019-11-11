using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using VoteCalc.Database.Entity;
using VoteCalc.Model;
using VoteCalc.Tools;

namespace VoteCalc.Database.Repository
{
    internal sealed class CandidateRepository : Repository<Candidate>
    {
        public override List<Candidate> GetAll()
        {
            try
            {
                using (var dbContext = new AppDbContext())
                {
                    var candidates = dbContext.Candidates;

                    return candidates.Select(candidate => candidate.GetDecryptCandidate()).ToList();
                }
            }
            catch (Exception exception)
            {
                ErrorMessage.ShowError($"Can not connect to database.\n", exception);
                Application.Current.Shutdown();
                return null;
            }
        }

        public override void AddAll(IList<Candidate> list)
        {
            try
            {
                using (var dbContext = new AppDbContext())
                {
                    foreach (var candidate in list)
                    {
                        dbContext.Candidates.Add(new CandidateEntity()
                        {
                            Name = candidate.Name,
                            Party = candidate.Party
                        });
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                ErrorMessage.ShowError($"Can not connect to database.\n", exception);
                Application.Current.Shutdown();
            }
        }

        public override void Save(Candidate model)
        {
            throw new NotImplementedException();
        }

        public bool IsAnyCandidate()
        {
            try
            {
                using (var dbContext = new AppDbContext())
                {
                    return dbContext.Candidates.Any();
                }
            }
            catch (Exception exception)
            {
                ErrorMessage.ShowError($"Can not connect to database.\n", exception);
                Application.Current.Shutdown();
                return false;
            }
        }
    }
}
