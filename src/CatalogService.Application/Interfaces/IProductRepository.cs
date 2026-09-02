using CatalogService.Domain.Entities;

namespace CatalogService.Application.Interfaces;

public interface IProductRepository
{
    Task<IReadOnlyCollection<Product>> GetAllAsync(CancellationToken cancellationToken = default);
}
