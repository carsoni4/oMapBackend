using Microsoft.EntityFrameworkCore;
using oMapBackend.Models;

namespace oMapBackend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Office> Offices => Set<Office>();
    public DbSet<OfficeMap> OfficeMaps => Set<OfficeMap>();
    public DbSet<Device> Devices => Set<Device>();
}