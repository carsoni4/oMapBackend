using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using oMapBackend.DTO;
using oMapBackend.Models;
using oMapBackend.Services;

namespace oMapBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly JwtTokenService _jwtTokenService;

    public AuthController(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        JwtTokenService jwtTokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDTO request)
    {
        var existingUser = await _userManager.FindByEmailAsync(request.Email);

        if (existingUser != null)
        {
            return BadRequest("A user with that email already exists.");
        }

        var user = new User
        {
            UserName = request.Username,
            Email = request.Email
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        var token = await _jwtTokenService.CreateTokenAsync(user);

        return Ok(new AuthResponseDTO
        {
            Token = token,
            UserId = user.Id,
            Email = user.Email ?? "",
            Username = user.UserName ?? ""
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email ?? "");

        if (user == null)
        {
            return Unauthorized("Invalid email or password.");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(
            user,
            request.Password,
            lockoutOnFailure: false
        );

        if (!result.Succeeded)
        {
            return Unauthorized("Invalid email or password.");
        }

        var token = await _jwtTokenService.CreateTokenAsync(user);

        return Ok(new AuthResponseDTO
        {
            Token = token,
            UserId = user.Id,
            Email = user.Email ?? "",
            Username = user.UserName ?? ""
        });
    }
}