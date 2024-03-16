using Garage.Persistence.Config;
using Garage.Persistence.Converters;
using Garage.Persistence.Interceptors;

namespace Garage.Persistence;

public sealed class GarageDbContext(DbContextOptions<GarageDbContext> options) : DbContext(options)
{
    private const string schema = "app";

    public DbSet<Core.Garage> Garages { get; set; }
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

        modelBuilder.HasDefaultSchema(schema);

        var assembly = type.Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly, x =>
            x.Namespace is not null
            && x.Namespace.StartsWith(type.Namespace));
    }
}
