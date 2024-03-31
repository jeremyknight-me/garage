using Garage.Web.Client.Features.Garages;
using Microsoft.AspNetCore.Mvc;

namespace Garage.Web.Features.Garages;

internal static class GarageEndpoints
{
    internal static IEndpointRouteBuilder UseGarageEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/garages")
            .AllowAnonymous();

        group.MapPost("", ([FromBody] CreateGarageRequest request) =>
        {
            return Results.Ok();
        });

        group.MapGet("", () =>
        {
            return Results.Ok();
        });

        group.MapGet("/{garageId:int}", (int garageId) =>
        {
            return Results.Ok();
        });

        return app;
    }
}
