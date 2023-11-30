namespace signalr.Services
{
    public interface IVoteManager
    {
        Task CastVote(string voteFor);
        Dictionary<string, int> GetCurrentVotes();
    }
}
