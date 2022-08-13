using Microsoft.EntityFrameworkCore;
using XMCore.API.Models;

namespace XMCore.API.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
    }
}
