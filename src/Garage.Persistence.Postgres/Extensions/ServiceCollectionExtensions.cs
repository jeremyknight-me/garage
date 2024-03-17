using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace Garage.Persistence.Postgres.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGarageDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<GarageDbContext>(options => options
            .UseNpgsql(connectionString, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(StringLiterals.MigrationAssembly);
                sqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, GarageDbContext.Schema);
            }));

        return services;
    }
}
