using JK.Garage.Common;
using JK.Garage.Data.Sqlite.Converters;
using Microsoft.EntityFrameworkCore;

namespace JK.Garage.Data.Sqlite;

public class GarageContext : DbContext
{
    public GarageContext()
    {
    }

    public GarageContext(DbContextOptions<GarageContext> options)
        : base(options)
    {
    }

    public DbSet<Common.Garage> Garages { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Maintenance> Maintenances { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<LocationId>()
            .HaveConversion<LocationIdConverter>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = this.GetType().Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly, x => x.Namespace == "JK.Garage.Data.Sqlite.EntityConfigs");
    }
}
