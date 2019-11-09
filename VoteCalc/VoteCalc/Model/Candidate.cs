using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteCalc.Logic;

namespace VoteCalc.Model
{
    public class Candidate : CryptData
    {
        private string _name;
        public string Name
        {
            get => Decrypt(_name);
            set => _name = Encrypt(value);
        }
        private string _party;
        public string Party
        {
            get => Decrypt(_party);
            set => _party = Encrypt(value);
        }
    }
}
