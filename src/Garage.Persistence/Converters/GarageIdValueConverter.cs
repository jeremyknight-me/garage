using Garage.Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Garage.Persistence.Converters;

internal sealed class GarageIdValueConverter(ConverterMappingHints? mappingHints = null)
    : ValueConverter<GarageId, int>(id => id.Value, value => new GarageId(value), mappingHints)
{
    public GarageIdValueConverter() : this(null) { }
}
