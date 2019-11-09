using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using VoteCalc.Database;
using VoteCalc.Database.Entity;
using VoteCalc.Database.Repository;
using VoteCalc.Logic;

namespace VoteCalc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CandidateUrl = "http://webtask.future-processing.com:8069/candidates";
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            using (var dbContext = new AppDbContext())
            {
                dbContext.Database.Migrate();
            }

            var candidateRepository = new CandidateRepository();
            if (!candidateRepository.IsAnyCandidate())
            {
                var candidateJsonData = new CandidateJsonData();
                candidateRepository.AddAll(candidateJsonData.GetAll());

            }

        }
    }
}
