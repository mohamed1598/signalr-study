using Microsoft.AspNetCore.Mvc;
using signalr.Services;

namespace signalr.Controllers
{
    public class VoteController : ControllerBase
    {
        private IVoteManager _voteManager;
        public VoteController(IVoteManager voteManager)
        {
            _voteManager = voteManager;
        }
        [HttpPost("/vote/pie")]
        public async Task<IActionResult> VotePie()
        {
            await _voteManager.CastVote("Pie");
            return Ok();
        }
        [HttpPost("/vote/bacon")]
        public async Task<IActionResult> VoteBacon()
        {
            await _voteManager.CastVote("Bacon");
            return Ok();
        }
    }
}
