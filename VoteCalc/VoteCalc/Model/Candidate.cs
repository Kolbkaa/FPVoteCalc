using VoteCalc.Logic;

namespace VoteCalc.Model
{
    internal class Candidate : CryptData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }
        public bool Vote { get; set; }
    }


}

