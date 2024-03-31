using Garage.Web.Client.Features.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace Garage.Web.Features.Vehicles;

internal static class VehicleEndpoints
{
    internal static IEndpointRouteBuilder UseVehicleEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/garages/{garageId:int}/vehicles")
            .AllowAnonymous();

        group.MapPost("", ([FromBody] CreateVehicleRequest request) =>
        {
            return Results.Ok();
        });

        group.MapGet("", (int garageId) =>
        {
            return Results.Ok();
        });

        group.MapGet("/{vehicleId:int}", (int garageId, int vehicleId) =>
        {
            return Results.Ok();
        });

        return app;
    }
}
