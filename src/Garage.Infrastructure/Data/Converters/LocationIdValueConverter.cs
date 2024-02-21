using Garage.Core;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Garage.Infrastructure.Data.Converters;

internal sealed class LocationIdValueConverter(ConverterMappingHints? mappingHints = null)
    : ValueConverter<LocationId, Guid>(id => id.Id, value => new LocationId(value), mappingHints)
{
    public LocationIdValueConverter() : this(null) { }
}
