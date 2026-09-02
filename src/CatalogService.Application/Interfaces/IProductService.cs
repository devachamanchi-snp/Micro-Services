using CatalogService.Domain.Entities;

namespace CatalogService.Application.Interfaces;

public interface IProductService
{
    Task<IReadOnlyCollection<Product>> GetProductsAsync(CancellationToken cancellationToken = default);
}
