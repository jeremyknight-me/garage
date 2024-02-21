using Garage.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Garage.Web.DependencyInjection;

internal static class GarageDataExtensions
{
    internal static IServiceCollection AddGarageData(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(Constants.ConnectionStrings.Garage_App)
            ?? throw new InvalidOperationException($"Connection string '{Constants.ConnectionStrings.Garage_App}' not found.");

        services.AddDbContext<GarageDbContext>(options => options.UseNpgsql(connectionString));

        return services;
    }
}
