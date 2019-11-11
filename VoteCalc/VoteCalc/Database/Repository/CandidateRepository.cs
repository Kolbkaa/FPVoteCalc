using System;
using System.Collections.Generic;
using System.Linq;
using VoteCalc.Database.Entity;
using VoteCalc.Model;

namespace VoteCalc.Database.Repository
{
    public sealed class CandidateRepository : Repository<Candidate>
    {
        public override List<Candidate> GetAll()
        {
            using (var dbContext = new AppDbContext())
            {
                var candidates = dbContext.Candidates;

                return candidates.Select(candidate => candidate.GetDecryptCandidate()).ToList();
            }
        }

        public override void AddAll(IList<Candidate> list)
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

        public override void Save(Candidate model)
        {
            throw new NotImplementedException();
        }

        public bool IsAnyCandidate()
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Candidates.Any();
            }
        }
    }
}
