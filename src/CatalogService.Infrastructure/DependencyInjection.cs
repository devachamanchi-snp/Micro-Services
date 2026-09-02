using CatalogService.Application.Interfaces;
using CatalogService.Infrastructure.Data;
using CatalogService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddCatalogInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CatalogDb");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Connection string 'CatalogDb' was not found.");
        }

        services.AddDbContext<CatalogDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
