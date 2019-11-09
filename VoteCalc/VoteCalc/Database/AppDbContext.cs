using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VoteCalc.Database.Entity;
using VoteCalc.Model;

namespace VoteCalc.Database
{
    class AppDbContext:DbContext
    {
        private const string _connectionString = @"Server=.\SQLEXPRESS;Database=FPVoteCalc;Trusted_Connection=True;";
        public DbSet<CandidateEntity> Candidates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
                ;
            base.OnConfiguring(optionsBuilder);
        }
    }
}
