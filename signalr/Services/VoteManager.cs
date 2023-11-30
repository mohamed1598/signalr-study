
using Microsoft.AspNetCore.SignalR;
using signalr.Hubs;

namespace signalr.Services
{
    public class VoteManager : IVoteManager
    {
        public static Dictionary<string, int> votes;
        public IHubContext<VoteHub> _hubContext;
         static VoteManager()
        {
            votes = new Dictionary<string, int>();
            votes.Add("Pie", 0);
            votes.Add("Bacon", 0);
        }
        public VoteManager(IHubContext<VoteHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task CastVote(string voteFor)
        {
            votes[voteFor]++;
            await _hubContext.Clients.All.SendAsync("updateVotes", votes);
        }

        public Dictionary<string, int> GetCurrentVotes()
        {
            return votes;
        }
    }
}
