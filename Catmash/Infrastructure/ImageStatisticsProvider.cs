using Catmash.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catmash.Infrastructure
{
    public class ImageStatisticsProvider : IImageStatisticsProvider
    {
        private readonly CatmashDbContext _dbContext;

        public ImageStatisticsProvider(CatmashDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<ImageStatistics>> GetMostSelectedImagesAsync(int topN)
        {
            return _dbContext.ImageStatistics.AsNoTracking()
                .OrderByDescending(stat => stat.SelectedCount)
                .Take(topN)
                .ToListAsync();
        }
    }
}
