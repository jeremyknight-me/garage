using JK.Garage.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace JK.Garage.Web.Extensions;

internal static class WebApplicationExtensions
{
    internal static void ApplyMigrations(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<GarageContext>>();
            using (var context = factory.CreateDbContext())
            {
                context.Database.Migrate();
            }
        }
    }
}
