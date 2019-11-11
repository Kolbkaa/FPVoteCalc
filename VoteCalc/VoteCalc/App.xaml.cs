using System;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using VoteCalc.Database;
using VoteCalc.Database.Repository;
using VoteCalc.Logic;
using VoteCalc.Tools;

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
            try
            {
                new AppDbContext().CreateDB();
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
            catch (Exception exception)
            {
                ErrorMessage.ShowError($"Can not connect to database.\n",exception);
                Current.Shutdown();
            }
        }
    }
}
