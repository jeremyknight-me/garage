namespace JK.Garage.Common;

public sealed class Location : Entity<LocationId>
{
    public Location()
        : base(new LocationId())
    {
    }

    public string Name { get; set; }
}
