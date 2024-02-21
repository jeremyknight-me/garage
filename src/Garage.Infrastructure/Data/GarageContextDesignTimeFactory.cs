using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Garage.Infrastructure.Data;

public sealed class GarageContextDesignTimeFactory : IDesignTimeDbContextFactory<GarageContext>
{
    public GarageContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<GarageContext> builder = new();
        builder.UseNpgsql("Host=localhost;Database=Garage;Username=postgres;Password=test;");
        return new GarageContext(builder.Options);
    }
}
