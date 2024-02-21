using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garage.Infrastructure.Data.Config;

internal sealed class GarageConfig : IEntityTypeConfiguration<Core.Garage>
{
    public void Configure(EntityTypeBuilder<Core.Garage> builder)
    {
        builder.ToTable("Garage");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(250).IsRequired();

        builder.HasMany(g => g.Vehicles)
            .WithMany(v => v.Garages);
    }
}
