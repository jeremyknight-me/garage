using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace JK.Garage.Data.Sqlite;

public sealed class GarageContextDesignTimeFactory : IDesignTimeDbContextFactory<GarageContext>
{
    public GarageContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<GarageContext>();
        builder.UseSqlite("Data Source=foo.dat");
        return new GarageContext(builder.Options);
    }
}
