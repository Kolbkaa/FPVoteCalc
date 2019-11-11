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
            var candidate = candidateRepository.GetAll();
            if (candidate != null)
                Candidates = new ObservableCollection<Candidate>(candidate);
        }
        public ObservableCollection<Candidate> Candidates { get; set; }
    }
}
