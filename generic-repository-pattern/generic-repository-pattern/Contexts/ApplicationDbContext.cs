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
        public DbSet<CustomerPurchasesProduct> CustomerPurchasesProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerPurchasesProduct>().HasKey(cp=> new { cp.ProductId,cp.CustomerId});            
            base.OnModelCreating(modelBuilder);

        }
    }
}
