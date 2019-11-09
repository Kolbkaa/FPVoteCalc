using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteCalc.Database.Repository;
using VoteCalc.Model;

namespace VoteCalc.ViewModel
{
    class VoteViewModel
    {
        public VoteViewModel()
        {
            var candidateRepository = new CandidateRepository();
            Candidates =new ObservableCollection<Candidate>(candidateRepository.GetAll());
        }
        public ObservableCollection<Candidate> Candidates { get; set; }
    }
}
