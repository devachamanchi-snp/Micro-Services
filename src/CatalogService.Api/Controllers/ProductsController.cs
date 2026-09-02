using CatalogService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<CatalogService.Domain.Entities.Product>>> Get(CancellationToken cancellationToken)
    {
        var products = await _productService.GetProductsAsync(cancellationToken);
        return Ok(products);
    }
}
