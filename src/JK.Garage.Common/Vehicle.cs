namespace JK.Garage.Common;

public sealed class Vehicle : Entity<VehicleId>
{
    private readonly List<Maintenance> maintenances = new();

    public Vehicle()
        : base(new VehicleId())
    {
    }

    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public IReadOnlyList<Maintenance> Maintenances
    {
        get => this.maintenances.AsReadOnly();
        init
        {
            this.maintenances.Clear();
            this.maintenances.AddRange(value);
        }
    }
}
