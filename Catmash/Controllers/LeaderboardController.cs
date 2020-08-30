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
        private readonly IImageStatisticsProvider _imageStatisticsProviderService;

        public LeaderboardController(IImageStatisticsProvider imageStatisticsProviderService)
        {
            _imageStatisticsProviderService = imageStatisticsProviderService;
        }

        [HttpGet]
        [Route("leaderboard")]
        public Task<List<ImageStatistics>> GetLeaderBoardAsync()
        {
            return _imageStatisticsProviderService.GetMostSelectedImagesAsync(10);
        }
    }
}
