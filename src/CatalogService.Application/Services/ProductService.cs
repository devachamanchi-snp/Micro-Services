using CatalogService.Application.Interfaces;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<IReadOnlyCollection<Product>> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        return _productRepository.GetAllAsync(cancellationToken);
    }
}
