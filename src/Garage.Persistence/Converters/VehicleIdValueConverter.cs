using Garage.Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Garage.Persistence.Converters;

internal sealed class VehicleIdValueConverter(ConverterMappingHints? mappingHints = null)
    : ValueConverter<VehicleId, Guid>(id => id.Value, value => new VehicleId(value), mappingHints)
{
    public VehicleIdValueConverter() : this(null) { }
}
