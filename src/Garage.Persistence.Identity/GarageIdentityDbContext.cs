using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Garage.Persistence.Identity;

public class GarageIdentityDbContext(DbContextOptions<GarageIdentityDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    private const string schema = "identity";

    protected override void OnModelCreating(ModelBuilder builder)
    {
        _ = builder.HasDefaultSchema(schema);
        base.OnModelCreating(builder);
    }
}
