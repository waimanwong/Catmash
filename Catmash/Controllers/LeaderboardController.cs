using Catmash.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catmash.Controllers
{
    [ApiController]
    public class LeaderboardController
    {
        private readonly ILeaderboardService _leaderboardService;

        public LeaderboardController(ILeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        [HttpGet]
        [Route("leaderboard")]
        public Task<LeaderboardDto> GetLeaderBoardAsync()
        {
            return _leaderboardService.GetLeaderboardAsync();
        }
    }
}
