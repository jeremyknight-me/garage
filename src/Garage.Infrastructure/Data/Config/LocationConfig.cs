using Garage.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garage.Infrastructure.Data.Config;

internal sealed class LocationConfig : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Location");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(250).IsRequired();
    }
}
