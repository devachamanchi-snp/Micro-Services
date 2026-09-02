using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Data;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Products");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Name).IsRequired().HasMaxLength(120);
            entity.Property(x => x.Description).HasMaxLength(500);
            entity.Property(x => x.Price).HasColumnType("decimal(18,2)");
        });
    }
}
