﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Garage.Persistence.Identity.Postgres.Extensions;

public static class HostExtensions
{
    public static IHost ApplyGarageIdentityMigrations(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<GarageIdentityDbContext>();
        context.Database.Migrate();

        return host;
    }
}
