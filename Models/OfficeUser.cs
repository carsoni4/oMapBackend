using oMapBackend.Enums;
namespace oMapBackend.Models;
public class OfficeUser
{
    public int Id { get; set; }
    public int OfficeId { get; set; }
    public Office? Office { get; set; }
    public string UserId { get; set; } = string.Empty;
    public User? User { get; set; } 
    public UserRole Role { get; set; } = UserRole.Member;
}