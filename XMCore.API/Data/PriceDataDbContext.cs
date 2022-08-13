using Microsoft.EntityFrameworkCore;
using XMCore.API.Models;

namespace XMCore.API.Data
{
    public class PriceDataDbContext : DbContext
    {
        public PriceDataDbContext(DbContextOptions<PriceDataDbContext> options) : base(options) { }

        public DbSet<PriceData> PriceData { get; set; }
    }
}
