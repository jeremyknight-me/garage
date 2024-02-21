using Garage.Core;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Garage.Infrastructure.Data.Converters;

internal sealed class MaintenanceIdValueConverter(ConverterMappingHints? mappingHints = null)
    : ValueConverter<MaintenanceId, Guid>(id => id.Id, value => new MaintenanceId(value), mappingHints)
{
    public MaintenanceIdValueConverter() : this(null) { }
}
