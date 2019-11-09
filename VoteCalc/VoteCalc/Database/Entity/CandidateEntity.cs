using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteCalc.Model;

namespace VoteCalc.Database.Entity
{
    class CandidateEntity: Candidate
    {

        private string _name;
        public new string Name
        {
            get =>_name;
            set => _name = Encrypt(value);
        }
        private string _party;
        public new string Party
        {
            get => _party;
            set => _party = Encrypt(value);
        }

        public Candidate GetDecryptCandidate()
        {
            var candidate = new Candidate()
            {
                Id = base.Id,Name = Decrypt(this.Name), Party = Decrypt(this.Party)
            };
            return candidate;
        }
    }
}
