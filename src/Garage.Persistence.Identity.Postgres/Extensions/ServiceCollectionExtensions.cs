using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace Garage.Persistence.Identity.Postgres.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGarageIdentityDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<GarageIdentityDbContext>(options => options
            .UseNpgsql(connectionString, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(StringLiterals.MigrationAssembly);
                sqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, GarageIdentityDbContext.Schema);
            }));

        return services;
    }
}
