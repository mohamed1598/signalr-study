using Microsoft.AspNetCore.SignalR;
using signalr.Services;

namespace signalr.Hubs
{
    public class VoteHub:Hub
    {
        private readonly IVoteManager voteManager;

        public VoteHub(IVoteManager voteManager)
        {
            this.voteManager = voteManager;
        }

        public Dictionary<string, int> GetCurrentVotes()
        {
            return voteManager.GetCurrentVotes();
        }

        public async Task Vote(string voteFor)
        {
            await voteManager.CastVote(voteFor);
        }
    }
}
