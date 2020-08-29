using Catmash.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catmash.Infrastructure
{
    public class ImageProviderService : IImageProviderService
    {
        private readonly CatmashDbContext _dbContext;

        public ImageProviderService(CatmashDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Image>> GetRandomImagesAsync(int count)
        {
            return _dbContext.Images.AsNoTracking()
                .OrderBy(x => Guid.NewGuid())
                .Take(count)
                .ToListAsync();
        }
    }
}
