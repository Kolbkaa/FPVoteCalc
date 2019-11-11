using System.Collections.ObjectModel;
using VoteCalc.Database.Repository;
using VoteCalc.Model;

namespace VoteCalc.ViewModel
{
    internal class VoteViewModel
    {
        public VoteViewModel()
        {
            var candidateRepository = new CandidateRepository();
            Candidates =new ObservableCollection<Candidate>(candidateRepository.GetAll());
        }
        public ObservableCollection<Candidate> Candidates { get; set; }
    }
}
