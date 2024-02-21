using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Garage.Web.Data;

public class GarageIdentityDbContext(DbContextOptions<GarageIdentityDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
}
