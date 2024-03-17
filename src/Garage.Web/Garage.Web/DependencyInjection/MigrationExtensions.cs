using Garage.Persistence.Identity.Postgres.Extensions;
using Garage.Persistence.Postgres.Extensions;

namespace Garage.Web.DependencyInjection;

internal static class MigrationExtensions
{
    internal static void ApplyMigrations(this WebApplication app)
        => _ = app
            .ApplyGarageIdentityMigrations()
            .ApplyGarageMigrations();
}
