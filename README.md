# Garage - Car Maintenance Tracker

This is designed to be a self-hosted car maintenance tracker which can be shared with members of your household and/or with access to your network (Cloudflare Tunnels, etc).

### Security

If you're going to allow outside/exteranl access, I highly recommend a technology like Cloudflare Tunnels or Ubiquiti Teleport. These services will give more control over access to your self-hosted system. 

### Entity Framework Commands

To run migrations for `GarageDbContext` navigate to `src/Garage.Persistence.Postgres` and run the following where `Initial` is the migration name:

```powershell
dotnet ef migrations add Initial
```

To run migrations for `GarageIdentityDbContext` navigate to `src/Garage.Persistence.Identity.Postgres` and run the following where `Initial` is the migration name:

```powershell
dotnet ef migrations add Initial
```
