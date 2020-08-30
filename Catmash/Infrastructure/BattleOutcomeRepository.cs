using Catmash.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Catmash.Infrastructure
{
    public class BattleOutcomeRepository : IBattleOutcomeRepository
    {
        private readonly CatmashDbContext _dbContext;

        public BattleOutcomeRepository(CatmashDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(BattleOutcome battleOutcome)
        {
            return _dbContext.BattleOutcomes.AddAsync(battleOutcome).AsTask();
        }

        public Task CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public Task<int> CountAsync()
        {
            return _dbContext.BattleOutcomes.CountAsync();
        }
    }
}
