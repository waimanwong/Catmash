using System.Threading.Tasks;

namespace Catmash.Domain
{
    public interface IBattleOutcomeRepository
    {
        Task AddAsync(BattleOutcome battleOutcome);

        Task<int> CountAsync();

        Task CommitAsync();
    }
}
