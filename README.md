# Garage - Car Maintenance Tracker

This is designed to be a self-hosted car maintenance tracker which can be shared with members of your household and/or with access to your network (Cloudflare Tunnels, etc).

### Security

The current iteration has no external auth. If you're going to allow outside access, I highly recommend a technology like Cloudflare Tunnels. It will allow the setup access policies (access by email, domain, etc.). 

### Entity Framework Commands

To run migrations for `GarageDbContext` navigate to `src/Garage.Infrastructure` and run:

```powershell
dotnet ef migrations add Initial -o Data/Migrations/Postgres -c GarageDbContext
```

To run migrations for `GarageIdentityDbContext` navigate to `src/Garage.Web/Garage.Web` and run `dotnet ef migrations add Initial -o Data/Migrations/Postgres`.

```powershell
dotnet ef migrations add Initial -o Data/Migrations/Postgres -c GarageIdentityDbContext
```