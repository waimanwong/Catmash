using System.Threading.Tasks;

namespace Catmash.Domain
{
    public interface ILeaderboardService
    {
        Task<LeaderboardDto> GetLeaderboardAsync();
    }
}