using CatalogService.Domain.Entities;

namespace CatalogService.Infrastructure.Data;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(CatalogDbContext dbContext, CancellationToken cancellationToken = default)
    {
        if (dbContext.Products.Any())
        {
            return;
        }

        dbContext.Products.AddRange(
            new Product { Name = "Sample Product A", Description = "Seeded sample product", Price = 19.99m },
            new Product { Name = "Sample Product B", Description = "Seeded sample product", Price = 29.99m }
        );

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
