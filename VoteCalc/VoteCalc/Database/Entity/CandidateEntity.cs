using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteCalc.Model;

namespace VoteCalc.Database.Entity
{
    class CandidateEntity: Candidate, IEntity
    {
        public int Id { get; set; }
    }
}
