using Catmash.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Catmash.Infrastructure
{
    public class CatmashDbContext : DbContext
    { 
        public CatmashDbContext(DbContextOptions<CatmashDbContext> options) : base(options)
        {
        }

        public DbSet<Image> Images { get; set; }
    }
}
