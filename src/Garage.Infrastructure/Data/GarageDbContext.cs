using Garage.Core;
using Garage.Infrastructure.Data.Config;
using Garage.Infrastructure.Data.Converters;
using Microsoft.EntityFrameworkCore;

namespace Garage.Infrastructure.Data;

public sealed class GarageDbContext(DbContextOptions<GarageDbContext> options) : DbContext(options)
{
    public DbSet<Core.Garage> Garages { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Maintenance> Maintenances { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    public override int SaveChanges()
    {
        this.UpdateEntityBaseValues();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        this.UpdateEntityBaseValues();
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().AreUnicode(unicode: true);

        configurationBuilder.Properties<GarageId>().HaveConversion<GarageIdValueConverter>();
        configurationBuilder.Properties<LocationId>().HaveConversion<LocationIdValueConverter>();
        configurationBuilder.Properties<MaintenanceId>().HaveConversion<MaintenanceIdValueConverter>();
        configurationBuilder.Properties<VehicleId>().HaveConversion<VehicleIdValueConverter>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var type = typeof(GarageConfig);
        if (type.Namespace is null)
        {
            throw new ArgumentNullException(nameof(type.Namespace));
        }

        var assembly = type.Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly, x =>
            x.Namespace is not null
            && x.Namespace.StartsWith(type.Namespace));
    }

    private void UpdateEntityBaseValues()
    {
        foreach (var change in this.ChangeTracker.Entries())
        {
            if (change.State == EntityState.Modified
                && change.Entity is EntityBase entityBase)
            {
                entityBase.SetDateModified();
            }
        }
    }
}
