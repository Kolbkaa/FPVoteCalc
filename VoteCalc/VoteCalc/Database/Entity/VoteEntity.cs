using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteCalc.Database.Entity
{
    class VoteEntity
    {
        public VotersEntity VotersEntity { get; set; }
        public CandidateEntity CandidateEntity { get; set; }
    }
}
