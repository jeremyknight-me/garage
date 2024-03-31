using Garage.Core.ValueObjects;

namespace Garage.Core.Entities;

public sealed class Garage : EntityBase<GarageId>
{
    private readonly List<Vehicle> vehicles = [];

    private Garage()
    {
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
    {
        var garage = new Garage();
        garage.SetName(name);
        return garage;
    }

    public void SetName(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        this.Name = name;
    }
}
