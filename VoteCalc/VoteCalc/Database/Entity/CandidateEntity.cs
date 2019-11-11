using VoteCalc.Logic;
using VoteCalc.Model;

namespace VoteCalc.Database.Entity
{
    internal class CandidateEntity:CryptData
    {
        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get =>_name;
            set => _name = Encrypt(value);
        }
        private string _party;
        public  string Party
        {
            get => _party;
            set => _party = Encrypt(value);
        }

        public Candidate GetDecryptCandidate()
        {
            var candidate = new Candidate()
            {
                Id = this.Id,Name = Decrypt(this.Name), Party = Decrypt(this.Party)
            };
            return candidate;
        }
    }
}
