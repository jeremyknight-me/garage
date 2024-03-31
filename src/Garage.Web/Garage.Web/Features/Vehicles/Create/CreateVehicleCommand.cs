namespace Garage.Web.Features.Vehicles.Create;

internal sealed record CreateVehicleCommand(int GarageId, string Name, string UserId);
