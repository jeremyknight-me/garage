using Garage.Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Garage.Persistence.Converters;

internal sealed class LocationIdValueConverter(ConverterMappingHints? mappingHints = null)
    : ValueConverter<LocationId, int>(id => id.Value, value => new LocationId(value), mappingHints)
{
    public LocationIdValueConverter() : this(null) { }
}
