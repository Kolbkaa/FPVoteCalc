﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteCalc.Database.Entity;
using VoteCalc.Model;

namespace VoteCalc.Database.Repository
{
    public sealed class CandidateRepository : Repository<Candidate>
    {
        public override IEnumerable<Candidate> GetAll()
        {
            List<Candidate> list = new List<Candidate>();
            using (var dbContext = new AppDbContext())
            {
                var candidates = dbContext.Candidates;

                foreach (var candidate in candidates)
                {
                    list.Add(new Candidate()
                    {
                        Id = candidate.Id,
                        Name = candidate.Name,
                        Party = candidate.Party
                    });
                }
            }

            return list;
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

        public bool IsAnyCandidate()
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Candidates.Any();
            }
        }
    }
}