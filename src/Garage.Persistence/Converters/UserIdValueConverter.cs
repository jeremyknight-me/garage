using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Garage.Persistence.Converters;

internal sealed class UserIdValueConverter(ConverterMappingHints? mappingHints = null)
    : ValueConverter<UserId, string>(id => id.Value, value => new UserId(value), mappingHints)
{
    public UserIdValueConverter() : this(null) { }
}
