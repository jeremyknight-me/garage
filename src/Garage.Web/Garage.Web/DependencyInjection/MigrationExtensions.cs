using Garage.Infrastructure.Data;
using Garage.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Garage.Web.DependencyInjection;

internal static class MigrationExtensions
{
    internal static void ApplyMigrations(this WebApplication app)
    {
        app.ApplyIdentityMigration();
        app.ApplyApplicationMigration();
    }

    private static void ApplyApplicationMigration(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<GarageDbContext>();
        context.Database.Migrate();
    }

    private static void ApplyIdentityMigration(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<GarageIdentityDbContext>();
        context.Database.Migrate();
    }
}
