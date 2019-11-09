using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VoteCalc.Logic;

namespace VoteCalc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string _candidateURL = "http://webtask.future-processing.com:8069/candidates";
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var candidateJsonData = new CandidateJsonData(_candidateURL);
            var candidate = candidateJsonData.GetAll();
        }
    }
}
