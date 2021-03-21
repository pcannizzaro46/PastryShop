using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PastryShop.DAL.Models;

namespace PastryShop.DAL
{
    public abstract class PastryDbContext : IdentityDbContext<IdentityUser> //DbContext
    {
        protected PastryDbContext()
        {
        }

        protected PastryDbContext(DbContextOptions<PastryDbContext> options) : base(options)
        {
        }

        protected PastryDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Dessert> Desserts { get; set; }
        
        public DbSet<Ingredient> Ingredients { get; set; }
        
        public DbSet<ShowcaseItem> ShowcaseItems { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dessert>().Property(r => r.Price).HasColumnType("decimal(6,2)");
            modelBuilder.Entity<Dessert>().HasAlternateKey(c => c.Name);

            modelBuilder.Entity<Ingredient>().Property(r => r.Quantity).HasColumnType("decimal(6,2)");
            //modelBuilder.Entity<Ingredient>().HasAlternateKey(c => c.Name);

            modelBuilder.Entity<ShowcaseItem>().Property(r => r.Price).HasColumnType("decimal(6,2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
