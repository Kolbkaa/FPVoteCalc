using Microsoft.EntityFrameworkCore;
using VoteCalc.Database.Entity;

namespace VoteCalc.Database
{
    internal class AppDbContext:DbContext
    {
        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=FPVoteCalc2;Trusted_Connection=True;";
        public DbSet<CandidateEntity> Candidates { get; set; }
        public DbSet<VotersEntity> Voters { get; set; }
        public DbSet<VoteEntity> Vote { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
                
            base.OnConfiguring(optionsBuilder);
        }
    }
}
