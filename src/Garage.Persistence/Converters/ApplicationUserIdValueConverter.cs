using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Garage.Persistence.Converters;

internal sealed class ApplicationUserIdValueConverter(ConverterMappingHints? mappingHints = null)
    : ValueConverter<ApplicationUserId, string>(id => id.Id, value => new ApplicationUserId(value), mappingHints)
{
    public ApplicationUserIdValueConverter() : this(null) { }
}
