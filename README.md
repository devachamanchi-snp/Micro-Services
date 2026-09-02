# Micro-Services

Sample .NET Core microservices scaffold with layered architecture.

## Solution Structure

- `/src/CatalogService.Api` - API layer (controllers, app startup)
- `/src/CatalogService.Application` - service layer and contracts
- `/src/CatalogService.Domain` - domain entities
- `/src/CatalogService.Infrastructure` - repository + EF Core DbContext + SQL Server wiring

## Sample Microservice

`CatalogService` exposes:

- `GET /api/products` - reads products from SQL Server via service -> repository -> `CatalogDbContext`

## Configuration

Set the SQL Server connection string in:

- `/home/runner/work/Micro-Services/Micro-Services/src/CatalogService.Api/appsettings.json`
- `/home/runner/work/Micro-Services/Micro-Services/src/CatalogService.Api/appsettings.Development.json`

Default key:

```json
"ConnectionStrings": {
  "CatalogDb": "Server=localhost,1433;Database=CatalogDb;Integrated Security=True;TrustServerCertificate=True;Encrypt=False"
}
```

`SeedDataOnStartup` is enabled for local sample data seeding.

## Run Locally

1. Start SQL Server locally (for example, SQL Server container on `localhost:1433`).
2. Update `ConnectionStrings:CatalogDb` with your credentials.
3. Run:

```bash
dotnet restore
dotnet build /home/runner/work/Micro-Services/Micro-Services/MicroServices.slnx
dotnet run --project /home/runner/work/Micro-Services/Micro-Services/src/CatalogService.Api/CatalogService.Api.csproj
```

4. Call:

```bash
curl http://localhost:5000/api/products
```
