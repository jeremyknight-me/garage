using Garage.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Garage.Web.DependencyInjection;

internal static class MigrationExtensions
{
    internal static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }
}
