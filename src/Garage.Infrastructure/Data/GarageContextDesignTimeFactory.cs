using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Garage.Infrastructure.Data;

public sealed class GarageContextDesignTimeFactory : IDesignTimeDbContextFactory<GarageDbContext>
{
    public GarageDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<GarageDbContext> builder = new();
        builder.UseNpgsql("Host=localhost;Database=Garage;Username=postgres;Password=test;");
        return new GarageDbContext(builder.Options);
    }
}
