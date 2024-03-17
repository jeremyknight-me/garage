using Garage.Core.Entities;
using Garage.Core.ValueObjects;
using Garage.Persistence.Config;
using Garage.Persistence.Converters;
using Garage.Persistence.Interceptors;

namespace Garage.Persistence;

public sealed class GarageDbContext(DbContextOptions<GarageDbContext> options) : DbContext(options)
{
    public const string Schema = "app";

    public DbSet<Core.Entities.Garage> Garages { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Maintenance> Maintenances { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().AreUnicode(unicode: true);

        configurationBuilder.Properties<GarageId>().HaveConversion<GarageIdValueConverter>();
        configurationBuilder.Properties<LocationId>().HaveConversion<LocationIdValueConverter>();
        configurationBuilder.Properties<MaintenanceId>().HaveConversion<MaintenanceIdValueConverter>();
        configurationBuilder.Properties<VehicleId>().HaveConversion<VehicleIdValueConverter>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new UpdateEntityBaseInterceptor());
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var type = typeof(GarageConfig);
        if (type.Namespace is null)
        {
            throw new ArgumentNullException(nameof(type.Namespace));
        }

        modelBuilder.HasDefaultSchema(Schema);

        var assembly = type.Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly, x =>
            x.Namespace is not null
            && x.Namespace.StartsWith(type.Namespace));
    }
}
