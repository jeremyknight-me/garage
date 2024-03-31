using Garage.Web.Components;
using Garage.Web.DependencyInjection;
using Garage.Web.Features.Garages;
using Garage.Web.Features.Vehicles;
using Serilog;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;

namespace Garage.Web;

public class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateBootstrapLogger();

        try
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuation = builder.Configuration;
            var services = builder.Services;

            services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            services.AddGarageIdentity(configuation);
            services.AddGarageData(configuation);

            builder.Host.UseSerilog((ctx, svc, loggerConfig) =>
            {
                loggerConfig
                    .ReadFrom.Configuration(ctx.Configuration)
                    .ReadFrom.Services(svc)
                    .Enrich.WithExceptionDetails(new DestructuringOptionsBuilder()
                        .WithDefaultDestructurers()
                        .WithDestructurers([
                            new Serilog.Exceptions.MsSqlServer.Destructurers.SqlExceptionDestructurer(),
                            new Serilog.Exceptions.EntityFrameworkCore.Destructurers.DbUpdateExceptionDestructurer()
                        ])
                    )
                    .Enrich.FromLogContext()
                    .WriteTo.Console();
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.UseSerilogRequestLogging();

            app
                .UseGarageEndpoints()
                .UseVehicleEndpoints();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.MapAdditionalIdentityEndpoints(); // Add additional endpoints required by the Identity /Account Razor components.

            app.ApplyMigrations();
            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
