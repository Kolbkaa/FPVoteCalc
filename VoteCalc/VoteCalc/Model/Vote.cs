using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteCalc.Model
{
    class Vote
    {
        public int Id { get; set; }
        public Voter Voters{ get; set; }
        public Candidate Candidate { get; set; }
        public bool ValidVote { get; set; }
    }
}
