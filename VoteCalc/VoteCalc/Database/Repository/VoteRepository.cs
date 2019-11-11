using System;
using System.Collections.Generic;
using System.Linq;
using VoteCalc.Database.Entity;
using VoteCalc.Model;

namespace VoteCalc.Database.Repository
{
    class VoteRepository : Repository<Vote>
    {
        public override List<Vote> GetAll()
        {
            throw new NotImplementedException();
        }

        public override void AddAll(IList<Vote> list)
        {
            throw new NotImplementedException();
        }

        public override void Save(Vote model)
        {
            using (var dbContext = new AppDbContext())
            {
                CandidateEntity candidate = null;
                if (model.Candidate != null)
                    candidate = dbContext.Candidates?.SingleOrDefault(x => x.Id == model.Candidate.Id);

                var voters = dbContext.Voters.Single(x => x.Id == model.Voters.Id);
                dbContext.Vote.Add(new VoteEntity()
                {
                    CandidateEntity = candidate,
                    ValidVote = model.ValidVote,
                    WithoutRight = model.WithoutRight,
                    VotersEntity = voters
                });
                dbContext.SaveChanges();
            }
        }
    }
}
