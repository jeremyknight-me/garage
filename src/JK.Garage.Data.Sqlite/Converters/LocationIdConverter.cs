using JK.Garage.Common;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JK.Garage.Data.Sqlite.Converters;

internal sealed class LocationIdConverter : ValueConverter<LocationId, Guid>
{
    public LocationIdConverter()
        : base(
            locationId => locationId.Value,
            id => new LocationId(id))
    {
    }
}
