using Microsoft.AspNetCore.Identity;

namespace oMapBackend.Models;

public class User : IdentityUser
{
    public List<OfficeUser> OfficeUsers { get; set; } = new();
}