using Garage.Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Garage.Persistence.Converters;

internal sealed class MaintenanceIdValueConverter(ConverterMappingHints? mappingHints = null)
    : ValueConverter<MaintenanceId, int>(id => id.Value, value => new MaintenanceId(value), mappingHints)
{
    public MaintenanceIdValueConverter() : this(null) { }
}
