using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using oMapBackend.Models;

namespace oMapBackend.Data;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Office> Offices => Set<Office>();
    public DbSet<Device> Devices => Set<Device>();
    public DbSet<OfficeUser> OfficeUsers => Set<OfficeUser>();
}