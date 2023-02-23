namespace JK.Garage.Common;

public sealed class GarageId : ValueObjectIdGuid
{
    public GarageId() : base()
    {
    }

    public GarageId(Guid id) : base(id)
    {
    }
}