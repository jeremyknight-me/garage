namespace JK.Garage.Common;

public sealed class Maintenance : Entity<MaintenanceId>
{
    public Maintenance()
        : base(new MaintenanceId())
    {
    }

    public decimal? Cost { get; set; }
    public DateOnly Date { get; set; }
    public LocationId LocationId { get; set; }
    public Location Location { get; set; }
    public int Mileage { get; set; }
    public string? Notes { get; set; }
}
