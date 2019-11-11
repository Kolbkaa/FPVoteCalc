using System.Collections.Generic;
using VoteCalc.Model;

namespace VoteCalc.Logic
{
    internal class CandidateJsonData:JsonDownload<CandidateJsonData.RootObject>
    {
        protected internal CandidateJsonData() : base(@"http://webtask.future-processing.com:8069/candidates")
        {
        }
        public List<Candidate> GetAll()
        {
            var jsonData = DownloadJson() as RootObject;
            return jsonData?.Candidates.Candidate;
        }

        internal class Candidates
        {
            public string PublicationDate { get; set; }
            public List<Candidate> Candidate { get; set; }
        }

        internal class RootObject
        {
            public Candidates Candidates { get; set; }
        }
    }
    
    
}
