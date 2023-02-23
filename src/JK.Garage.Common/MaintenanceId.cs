namespace JK.Garage.Common;

public sealed class MaintenanceId : ValueObjectIdGuid
{
    public MaintenanceId() : base()
    {
    }

    public MaintenanceId(Guid id) : base(id)
    {
    }
}
