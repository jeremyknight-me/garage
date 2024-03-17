using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Garage.Persistence.Postgres.Extensions;

public static class HostExtensions
{
    public static IHost ApplyGarageMigrations(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<GarageDbContext>();
        context.Database.Migrate();

        return host;
    }
}
