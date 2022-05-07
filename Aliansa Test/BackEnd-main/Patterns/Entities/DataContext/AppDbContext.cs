using Microsoft.EntityFrameworkCore;
using Entities.Domain;

namespace Entities.DataContext
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {
        }

        public DbSet<Toy> Toys { get; set; }

        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            optionsBuilder.UseInMemoryDatabase("Patterns_DB");
        }
    }
}
