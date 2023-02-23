namespace JK.Garage.Common;

public sealed class Garage : Entity<GarageId>
{
    private readonly List<Vehicle> vehicles = new();

    public Garage() 
        : base(new GarageId())
    {
    }

    public string Name { get; set; }

    public IReadOnlyList<Vehicle> Vehicles
    {
        get => this.vehicles.AsReadOnly();
        init
        {
            this.vehicles.Clear();
            this.vehicles.AddRange(value);
        }
    }
}
