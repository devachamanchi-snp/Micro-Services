using CatalogService.Application.Interfaces;
using CatalogService.Application.Services;
using CatalogService.Infrastructure;
using CatalogService.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddCatalogInfrastructure(builder.Configuration);
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (builder.Configuration.GetValue("SeedDataOnStartup", false))
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();
    await dbContext.Database.EnsureCreatedAsync();
    await DatabaseSeeder.SeedAsync(dbContext);
}

app.MapControllers();

app.Run();
