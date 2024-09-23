using Microsoft.EntityFrameworkCore;

namespace FociWebApplication.Models
{
    public class FociDbContext : DbContext
    {
        public FociDbContext(DbContextOptions<FociDbContext> options) : base(options)
        {

        }


        public DbSet<Meccs> Meccsek { get; set; }

    }
}
