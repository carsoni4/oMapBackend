namespace oMapBackend.DTO;

public class LoginDTO
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public required string Password { get; set; }
}

public class RegisterDTO
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}

public class AuthResponseDTO
{
    public required string Token { get; set; } 
    public required string UserId { get; set; }
    public required string Email { get; set; }
    public required string Username { get; set; }
}