using Microsoft.EntityFrameworkCore;
using System.Windows;
using VoteCalc.Database;
using VoteCalc.Database.Repository;
using VoteCalc.Logic;

namespace VoteCalc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            using (var dbContext = new AppDbContext())
            {
                dbContext.Database.Migrate();
            }

            var candidateRepository = new CandidateRepository();
            if (candidateRepository.IsAnyCandidate()) return;

            var candidateJsonData = new CandidateJsonData().GetAll();
            if (candidateJsonData != null)
            {
                candidateRepository.AddAll(candidateJsonData);
            }
            else
            {
                Current.Shutdown();
            }

        }
    }
}
