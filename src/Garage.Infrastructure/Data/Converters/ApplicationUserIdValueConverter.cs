using Garage.Core;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Garage.Infrastructure.Data.Converters;

internal sealed class ApplicationUserIdValueConverter(ConverterMappingHints? mappingHints = null)
    : ValueConverter<ApplicationUserId, string>(id => id.Id, value => new ApplicationUserId(value), mappingHints)
{
    public ApplicationUserIdValueConverter() : this(null) { }
}
