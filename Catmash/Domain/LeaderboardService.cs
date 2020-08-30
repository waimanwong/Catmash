using System;
using System.Linq;
using System.Threading.Tasks;

namespace Catmash.Domain
{
    public class LeaderboardService : ILeaderboardService
    {
        private readonly IImageStatisticsProvider _imageStatisticsProvider;
        private readonly IBattleOutcomeRepository _battleOutcomeRepository;

        public LeaderboardService(
            IImageStatisticsProvider imageStatisticsProvider,
            IBattleOutcomeRepository battleOutcomeRepository)
        {
            _imageStatisticsProvider = imageStatisticsProvider;
            _battleOutcomeRepository = battleOutcomeRepository;
        }

        public async Task<LeaderboardDto> GetLeaderboardAsync()
        {
            var leaderboardSize = 10; //arbitrary size
            var imageStatistics = await _imageStatisticsProvider.GetMostSelectedImagesAsync(leaderboardSize);
            var totalVotes = await _battleOutcomeRepository.CountAsync();

            return new LeaderboardDto
            {
                TotalVotes = totalVotes,
                TopImages = imageStatistics.Select(x => new ImageDto { Id = x.Id, Url = x.Url }).ToList()
            };

        }
    }
}
