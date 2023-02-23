using JK.Garage.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JK.Garage.Data.Sqlite.EntityConfigs;

internal sealed class GarageConfig : IEntityTypeConfiguration<Common.Garage>
{
    public void Configure(EntityTypeBuilder<Common.Garage> builder)
    {
        builder.ToTable("Garages");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(i => i.Value, l => new GarageId(l))
            .HasColumnName("Id");
        builder.Property(x => x.Name)
            .HasMaxLength(250)
            .IsRequired()
            .IsUnicode(true);

        builder.HasMany(x => x.Vehicles).WithOne();
    }
}
