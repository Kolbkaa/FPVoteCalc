using VoteCalc.Logic;

namespace VoteCalc.Model
{
    internal class Voter:CryptData
    {
        public int Id { get; set; }
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
