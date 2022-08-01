using generic_repository_pattern.Models;
using Microsoft.EntityFrameworkCore;

namespace generic_repository_pattern.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer>Customers { get; set; }
        public DbSet<Shop> Shops { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
