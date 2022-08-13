using Microsoft.EntityFrameworkCore;
using XMCore.API.Models;

namespace XMCore.API.Data
{
    public class PriceSourceDbContext : DbContext
    {
        public PriceSourceDbContext(DbContextOptions<PriceSourceDbContext> options) : base(options) { }

        public DbSet<PriceSource> PriceSource { get; set; }
    }
}
