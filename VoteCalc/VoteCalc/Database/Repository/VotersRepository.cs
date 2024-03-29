﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using VoteCalc.Database.Entity;
using VoteCalc.Model;
using VoteCalc.Tools;

namespace VoteCalc.Database.Repository
{
    internal class VotersRepository : Repository<Voter>
    {
        public override List<Voter> GetAll()
        {
            throw new NotImplementedException();
        }

        public override void AddAll(IList<Voter> list)
        {
            throw new NotImplementedException();
        }

        public override void Save(Voter model)
        {
            try
            {
                using (var dbContext = new AppDbContext())
                {
                    var voter = new VotersEntity()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Pesel = model.Pesel
                    };
                    dbContext.Voters.Add(voter);
                    dbContext.SaveChanges();
                    model.Id = voter.Id;
                }
            }
            catch (Exception exception)
            {
                ErrorMessage.ShowError($"Can not connect to database.\n", exception);
                Application.Current.Shutdown();

            }
        }

        public bool IsExist(Voter model)
        {
            try
            {
                using (var dbContext = new AppDbContext())
                {
                    var voter = new VotersEntity()
                    {
                        Pesel = model.Pesel
                    };
                    return dbContext.Voters.Select(x => x.Pesel).Contains(voter.Pesel);
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
