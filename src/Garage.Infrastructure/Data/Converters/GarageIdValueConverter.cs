using Garage.Core;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Garage.Infrastructure.Data.Converters;

internal sealed class GarageIdValueConverter(ConverterMappingHints? mappingHints = null)
    : ValueConverter<GarageId, Guid>(id => id.Id, value => new GarageId(value), mappingHints)
{
    public GarageIdValueConverter() : this(null) { }
}
