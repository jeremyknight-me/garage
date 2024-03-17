using Garage.Core.ValueObjects;

namespace Garage.Core.Entities;

public sealed class Vehicle : EntityBase<VehicleId>
{
    private readonly List<Maintenance> maintenances = [];
    private readonly List<Garage> garages = [];

    private Vehicle()
    {
    }

    private Vehicle(string make, string model, short year)
    {
        this.SetMake(make);
        this.SetModel(model);
        this.SetYear(year);
    }

    public string Make { get; private set; } = null!;
    public string Model { get; private set; } = null!;
    public short Year { get; private set; }

    public IReadOnlyList<Garage> Garages
    {
        get => this.garages.AsReadOnly();
        init
        {
            this.garages.Clear();
            this.garages.AddRange(value);
        }
    }

    public IReadOnlyList<Maintenance> Maintenances
    {
        get => this.maintenances.AsReadOnly();
        init
        {
            this.maintenances.Clear();
            this.maintenances.AddRange(value);
        }
    }

    public static Vehicle Create(string make, string model, short year)
        => new(make, model, year);

    public void SetMake(string make)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(make, nameof(make));
        this.Make = make;
    }

    public void SetModel(string model)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(model, nameof(model));
        this.Model = model;
    }

    public void SetYear(short year)
    {
        if (year < 1900)
        {
            throw new ArgumentException($"Invalid year: {year}", nameof(year));
        }

        this.Year = year;
    }
}
