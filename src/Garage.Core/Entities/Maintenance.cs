using Garage.Core.ValueObjects;

namespace Garage.Core.Entities;

public sealed class Maintenance : EntityBase<MaintenanceId>
{
    private Maintenance()
    {
    }

    private Maintenance(VehicleId vehicle, DateOnly date, LocationId locationId, int? mileage, decimal? cost, string? notes)
    {
        this.VehicleId = vehicle;
        this.SetDate(date);
        this.SetLocation(locationId);
        this.SetMileage(mileage);
        this.SetCost(cost);
        this.SetNotes(notes);
    }

    public decimal? Cost { get; private set; }
    public DateOnly Date { get; private set; }
    public LocationId LocationId { get; private set; }
    public Location Location { get; private init; } = null!;
    public int? Mileage { get; private set; }
    public string? Notes { get; private set; }
    public VehicleId VehicleId { get; private set; }
    public Vehicle Vehicle { get; private init; } = null!;

    public static Maintenance Create(VehicleId vehicle, DateOnly date, LocationId locationId, int? mileage = null, decimal? cost = null, string? notes = null)
        => new(vehicle, date, locationId, mileage, cost, notes);

    public void SetCost(decimal? cost)
    {
        if (cost is not null && cost < 0)
        {
            throw new ArgumentException("Cost cannot be negative.", nameof(cost));
        }

        this.Cost = cost;
    }

    public void SetDate(DateOnly date)
    {
        this.Date = date;
    }

    public void SetLocation(LocationId locationId)
    {
        this.LocationId = locationId;
    }

    public void SetMileage(int? mileage)
    {
        if (mileage is not null && mileage < 0)
        {
            throw new ArgumentException("Mileage cannot be negative.", nameof(mileage));
        }

        this.Mileage = mileage;
    }

    public void SetNotes(string? notes)
    {
        this.Notes = notes;
    }
}
