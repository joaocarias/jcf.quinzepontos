# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

**JCF Quinze Pontos** is a .NET 10 backend system that automatically fetches and stores Lotofácil lottery results from the Caixa Econômica Federal API into a PostgreSQL database.

## Commands

### Docker (recommended)

```bash
# Build and start all services (postgres + api + worker)
docker compose up --build

# Run in background
docker compose up --build -d

# View logs
docker compose logs -f api
docker compose logs -f worker

# Stop and remove containers
docker compose down

# Remove containers and the postgres volume (resets the database)
docker compose down -v
```

The API is available at `http://localhost:5031` (Swagger UI in development mode at `http://localhost:5031/swagger`).

### Local (without Docker)

All commands run from `src/Jcf.QuinzePontos.Backend/` (no `.sln` file — target projects directly).

```bash
# Build all projects
dotnet build

# Run the API
dotnet run --project Jcf.QuinzePontos.Api

# Run the background worker
dotnet run --project Jcf.QuinzePontos.GetResultsWorker

# Run all tests
dotnet test Jcf.QuinzePontos.Tests

# Run a single test
dotnet test Jcf.QuinzePontos.Tests --filter "FullyQualifiedName~TestClassName"

# EF Core migrations (run from the Backend directory)
dotnet ef migrations add <MigrationName> --project Jcf.QuinzePontos.infrastructure --startup-project Jcf.QuinzePontos.Api
dotnet ef database update --project Jcf.QuinzePontos.infrastructure --startup-project Jcf.QuinzePontos.Api
```

## Architecture

Clean/layered architecture with these projects (dependency order: Domain ← Infrastructure ← Application ← Worker/Api):

| Project | Role |
|---|---|
| `Jcf.QuinzePontos.Domain` | Entities (`LotofacilConcurso`, `LotofacilDezenas`, `LotofacilRateio`, `LotofacilGanhadorUF`) and repository interfaces |
| `Jcf.QuinzePontos.infrastructure` | EF Core + Dapper, PostgreSQL contexts, repository implementations, migrations |
| `Jcf.QuinzePontos.Application` | `LotofacilConcursoService`, `LotofacilConcursoClient` (typed `HttpClient`), DTOs |
| `Jcf.QuinzePontos.Api` | ASP.NET Core Web API (OpenAPI/Swagger in development) |
| `Jcf.QuinzePontos.GetResultsWorker` | `BackgroundService` that polls every 1 minute, calling the service to fetch and persist the next unsaved contest |
| `Jcf.QuinzePontos.Tests` | xUnit tests referencing all projects |

## Data Access Pattern (dual EF + Dapper)

The base repository `LotoFacilRepositoryBase<T>` holds both `AppDbContext` (EF Core) and `AppDapperContext` (Dapper) and exposes:
- EF Core for writes (`CreateAsync`, `UpdateAsync`, `DeleteAsync`) and simple reads (`GetByIdAsync`, `GetAllAsync`)
- Dapper via the protected `ExecuteQueryAsync<TResult>(string query, Func<GridReader, Task<TResult>> map)` for complex multi-result queries

Raw SQL lives in `Infrastructure/Data/Queries/<Entity>/SqlGet.cs` as static string constants. Use `QueryMultipleAsync` + `GridReader` to map multiple related tables in a single round-trip (see `LotofacilConcursoRepository.GetLastAsync` for the established pattern).

## Key Configuration

- **PostgreSQL schema**: `loto_facil`
- **External API**: Caixa Econômica Federal — `https://servicebus3.caixa.gov.br/portaldeloterias/api/lotofacil/{numero}`
- Connection string and API options live in `appsettings.json`; override secrets locally with `dotnet user-secrets` (the Worker project has a `UserSecretsId`)
- CORS is configured via `AddCorsConfiguration` in the Api's `Program.cs`

## Adding a New Repository

1. Define the interface in `Domain/Interfaces/Repositories/`, extending `ILotoFacilRepositoryBase<T>`
2. Implement in `Infrastructure/Data/Repositories/`, extending `LotoFacilRepositoryBase<T>`
3. Add SQL constants to `Infrastructure/Data/Queries/<Entity>/`
4. Register the scoped dependency in `Infrastructure/DependencyInjection/RepositoriesConfigurations.cs`
