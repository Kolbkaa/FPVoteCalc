using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using VoteCalc.Model;

namespace VoteCalc.Logic
{
    class CandidateJsonData:JsonDownload<CandidateJsonData.RootObject>
    {
        protected internal CandidateJsonData() : base(@"http://webtask.future-processing.com:8069/candidates")
        {
        }
        public List<Candidate> GetAll()
        {
            var jsonData = DownloadJson() as RootObject;
            return jsonData?.candidates.candidate;
        }

        internal class Candidates
        {
            public string publicationDate { get; set; }
            public List<Candidate> candidate { get; set; }
        }

        internal class RootObject
        {
            public Candidates candidates { get; set; }
        }
    }
    
    
}
