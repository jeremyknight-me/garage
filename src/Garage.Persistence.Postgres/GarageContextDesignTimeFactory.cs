using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Garage.Persistence.Postgres;

public sealed class GarageContextDesignTimeFactory : IDesignTimeDbContextFactory<GarageDbContext>
{
    public GarageDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<GarageDbContext> builder = new();
        builder.UseNpgsql(
            connectionString: "Host=localhost;Database=Garage;Username=postgres;Password=test;",
            options => options.MigrationsAssembly("Garage.Persistence.Postgres"));
        return new GarageDbContext(builder.Options);
    }
}
