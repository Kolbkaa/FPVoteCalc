using VoteCalc.Logic;
using VoteCalc.Model;

namespace VoteCalc.Database.Entity
{
    internal class VotersEntity : CryptData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        private string _lastName;
        public string LastName { get => _lastName; set => _lastName = Encrypt(value); }
        private string _pesel;
        public string Pesel { get => _pesel; set => _pesel = Encrypt(value); }


        public Voter GetDecryptVoter()
        {
            var voter = new Voter()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = Decrypt(_lastName),
                Pesel = Decrypt(_pesel)
            };
            return voter;
        }
    }
}
