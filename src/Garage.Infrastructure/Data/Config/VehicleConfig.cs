using Garage.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garage.Infrastructure.Data.Config;

internal sealed class VehicleConfig : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicle");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Make).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Model).HasMaxLength(50).IsRequired();
    }
}
