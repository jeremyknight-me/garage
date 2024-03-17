using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Garage.Persistence.Identity;

public class GarageIdentityDbContext(DbContextOptions<GarageIdentityDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public const string Schema = "identity";

    protected override void OnModelCreating(ModelBuilder builder)
    {
        _ = builder.HasDefaultSchema(Schema);
        base.OnModelCreating(builder);
    }
}
