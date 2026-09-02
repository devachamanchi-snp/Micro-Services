using CatalogService.Application.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly CatalogDbContext _dbContext;

    public ProductRepository(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Products
            .AsNoTracking()
            .OrderBy(product => product.Id)
            .ToListAsync(cancellationToken);
    }
}
