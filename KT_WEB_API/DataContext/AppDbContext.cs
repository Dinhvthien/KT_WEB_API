using KT_WEB_API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace KT_WEB_API.DataContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductDetailPropertyDetails> ProductDetailPropertyDetails { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<PropertyDetails> PropertyDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDetails>()
                .Property(e => e.Price)
                .HasColumnType("float(53)");
            modelBuilder.Entity<ProductDetails>()
                .Property(e => e.ShellPrice)
                .HasColumnType("float(53)");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=DESKTOP-VVKT5NE\\SQLEXPRESS;database=KT_API;trusted_connection=true;");
        }
    }
}
