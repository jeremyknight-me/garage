using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garage.Persistence.Config;

internal sealed class GarageConfig : IEntityTypeConfiguration<Core.Entities.Garage>
{
    public void Configure(EntityTypeBuilder<Core.Entities.Garage> builder)
    {
        builder.ToTable("Garage");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name).HasMaxLength(250).IsRequired();

        builder.HasMany(g => g.Vehicles)
            .WithMany(v => v.Garages);
    }
}
