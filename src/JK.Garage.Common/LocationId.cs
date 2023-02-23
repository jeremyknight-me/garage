namespace JK.Garage.Common;

public sealed class LocationId : ValueObjectIdGuid
{
    public LocationId() : base()
    {
    }

    public LocationId(Guid id) : base(id)
    {
    }
}
