using Garage.Core.ValueObjects;

namespace Garage.Core.Entities;

public sealed class Location : EntityBase<LocationId>
{
    private Location()
    {
    }

    private Location(string name)
    {
        this.SetName(name);
    }

    public string Name { get; private set; } = null!;

    public static Location Create(string name)
        => new(name);

    public void SetName(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        this.Name = name;
    }
}
