using Garage.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garage.Persistence.Config;

internal sealed class MaintenanceConfig : IEntityTypeConfiguration<Maintenance>
{
    public void Configure(EntityTypeBuilder<Maintenance> builder)
    {
        builder.ToTable("Maintenance");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Cost).HasPrecision(9, 2).IsRequired(false);
        builder.Property(x => x.Notes).IsRequired(false);

        builder.HasOne(m => m.Location)
            .WithMany()
            .HasForeignKey(m => m.LocationId);

        builder.HasOne(m => m.Vehicle)
            .WithMany(v => v.Maintenances)
            .HasForeignKey(m => m.VehicleId);
    }
}
