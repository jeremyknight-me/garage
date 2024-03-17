using Garage.Core.ValueObjects;

namespace Garage.Core.Entities;

public sealed class Garage : EntityBase<GarageId>
{
    private readonly List<Vehicle> vehicles = [];

    private Garage()
    {
    }

    private Garage(string name)
    {
        this.SetName(name);
    }

    public string Name { get; private set; } = null!;

    public IReadOnlyList<Vehicle> Vehicles
    {
        get => this.vehicles.AsReadOnly();
        init
        {
            this.vehicles.Clear();
            this.vehicles.AddRange(value);
        }
    }

    public static Garage Create(string name)
        => new(name);

    public void SetName(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        this.Name = name;
    }
}
