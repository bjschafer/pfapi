# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Pathfinder API - A REST API for Pathfinder 1st Edition rules reference data (spells, classes). Built with ASP.NET Core Web API targeting .NET 10 and C# 14.

Live API: https://pfapi.whizkid.dev/

## Build & Development Commands

Uses `mise` as the task runner (defined in `mise.toml`):

```bash
mise run build              # Build the project
mise run serve              # Run development server
mise run clean              # Clean build artifacts
mise run migratedb <name>   # Create and run EF migration
mise run tools:install      # Install/restore dotnet tools
mise run upgrade-deps       # Update dependencies
mise run docker-build       # Build container image
```

Direct dotnet commands:
```bash
dotnet build api/api.csproj
dotnet run --project api/api.csproj
dotnet ef migrations add <Name> --project api/api.csproj
dotnet ef database update --project api/api.csproj
```

## Architecture

### Project Structure

- `api/` - Main ASP.NET Core Web API project
- `Data Helper/` - Utility for importing spell data (not part of main API)

### Key Directories (in api/)

- `Controllers/` - API endpoints (SpellController, ClassController, AdminController)
- `Models/Database/` - EF Core entities (Spell, Class, Descriptor, ClassLevel, SourceMaterial)
- `Models/Request/` - DTOs for incoming data
- `Models/Response/` - DTOs for outgoing data
- `Data/` - DbContext, AutoMapper profiles, seed data helpers
- `Utils/` - Extension methods and configuration helpers
- `Migrations/` - EF Core migrations

### Database Configuration

Database type selected via `Database:Type` setting (env var: `Database_Type`):
- `postgres` (default) - Uses connection details from `Database_*` env vars
- `sqlite` - Uses connection string from appsettings

Configuration priority: environment variables > appsettings.json (uses `_` instead of `:` for env var names)

### Patterns & Conventions

**Primary Constructor DI** (C# 12+):
```csharp
public class SpellController(ApiContext context, IMapper mapper, ILogger<SpellController> logger) : ControllerBase
```

**Conditional Query Building** - Use `WhereIf<T>()` extension for optional filters:
```csharp
context.Spell
    .WhereIf(school is not null, s => s.School == school.ToTitleCase())
    .WhereIf(level.HasValue, s => s.ClassLevels.Any(cl => cl.Level == level))
```

**String Normalization** - Use `ToTitleCase()` extension for case-insensitive lookups against stored data

**Entity-DTO Mapping** - AutoMapper profiles in `Data/Mapper.cs` handle all transformations

### Data Model Notes

- `Spell.ClassLevels` - Owned collection storing spell level per class (not a separate table)
- `Class.SpellsPerDay` - JSON-serialized `IDictionary<int, IDictionary<int, int>>` for spells-per-day tables
- Seed data for Classes and Descriptors loaded from JSON in `Data/Seed/`

## API Documentation

Swagger UI available at root path (`/`) in all environments. API version: `v1alpha1`
