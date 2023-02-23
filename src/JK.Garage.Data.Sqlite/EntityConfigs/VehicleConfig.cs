using JK.Garage.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JK.Garage.Data.Sqlite.EntityConfigs;

internal sealed class VehicleConfig : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicles");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(i => i.Value, l => new VehicleId(l))
            .HasColumnName("Id");
        builder.Property(x => x.Make).HasMaxLength(50).IsRequired().IsUnicode(true);
        builder.Property(x => x.Model).HasMaxLength(50).IsRequired().IsUnicode(true);

        builder.HasMany(x => x.Maintenances).WithOne();
    }
}
