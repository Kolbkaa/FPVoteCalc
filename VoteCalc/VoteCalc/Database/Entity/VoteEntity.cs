namespace VoteCalc.Database.Entity
{
    internal class VoteEntity
    {
        public int Id { get; set; }
        public VotersEntity VotersEntity { get; set; }
        public CandidateEntity CandidateEntity { get; set; }
        public bool ValidVote { get; set; }
        public bool WithoutRight { get; set; }
    }
}
