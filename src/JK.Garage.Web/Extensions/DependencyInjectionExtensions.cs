using JK.Garage.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace JK.Garage.Web.Extensions;

internal static class DependencyInjectionExtensions
{
    internal static void AddDependencies(this IServiceCollection services)
    {
        services.AddDbContextFactory<GarageContext>(options =>
        {
            options.UseSqlite("Data Source=garage.dat");
        });
    }
}
