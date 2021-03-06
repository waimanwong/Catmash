﻿using Catmash.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catmash.Infrastructure
{
    public class ImageProvider : IImageProvider
    {
        private readonly CatmashDbContext _dbContext;

        public ImageProvider(CatmashDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> DoesImageExist(string id)
        {
            return _dbContext.Images.AnyAsync(img => img.Id == id);
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
