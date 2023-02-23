namespace JK.Garage.Common;

public sealed class VehicleId : ValueObjectIdGuid
{
    public VehicleId() : base()
    {
    }

    public VehicleId(Guid id) : base(id)
    {
    }
}