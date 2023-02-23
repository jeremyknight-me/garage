using JK.Garage.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JK.Garage.Data.Sqlite.EntityConfigs;

internal sealed class MaintenanceConfig : IEntityTypeConfiguration<Maintenance>
{
    public void Configure(EntityTypeBuilder<Maintenance> builder)
    {
        builder.ToTable("Maintenances");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(i => i.Value, l => new MaintenanceId(l))
            .HasColumnName("Id");
        builder.Property(x => x.Cost).HasPrecision(10,2).IsRequired(false);
        builder.Property(x => x.LocationId).HasColumnName("LocationId").IsRequired();
        builder.Property(x => x.Notes).IsRequired(false).IsUnicode(true);
    }
}
