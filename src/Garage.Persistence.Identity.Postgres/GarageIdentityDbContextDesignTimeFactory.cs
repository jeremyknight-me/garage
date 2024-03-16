using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Garage.Persistence.Identity.Postgres;

public sealed class GarageIdentityDbContextDesignTimeFactory : IDesignTimeDbContextFactory<GarageIdentityDbContext>
{
    public GarageIdentityDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<GarageIdentityDbContext> builder = new();
        builder.UseNpgsql(
            connectionString: "Host=localhost;Database=GarageIdentity;Username=postgres;Password=test;",
            options => options.MigrationsAssembly("Garage.Persistence.Identity.Postgres"));
        return new GarageIdentityDbContext(builder.Options);
    }
}
