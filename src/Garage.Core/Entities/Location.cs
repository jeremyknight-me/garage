using Garage.Core.ValueObjects;

namespace Garage.Core.Entities;

public sealed class Location : EntityBase<LocationId>
{
    private Location()
    {
    }

    public string Name { get; private set; } = null!;

    public static Location Create(string name)
    {
        var location = new Location();
        location.SetName(name);
        return location;
    }

    public void SetName(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        this.Name = name;
    }
}
