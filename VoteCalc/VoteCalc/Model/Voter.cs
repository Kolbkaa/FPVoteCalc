using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteCalc.Logic;

namespace VoteCalc.Model
{
    public class Voter:CryptData
    {
        public string FirstName { get; set; }
        private string _lastName;
        private string _pesel;
        public string LastName
        {
            get => Decrypt(_lastName);
            set => _lastName = Encrypt(value);
        }
        public string Pesel
        {
            get => Decrypt(_pesel);
            set => _pesel = Encrypt(value);
        }
    }
}
