namespace VoteCalc.Model
{
    internal class Vote
    {
        public int Id { get; set; }
        public Voter Voters { get; set; }
        public Candidate Candidate { get; set; }
        public bool ValidVote { get; set; } = true;
        public bool WithoutRight { get; set; }
    }
}
