//using Microsoft.AspNetCore.Mvc;
//using MyBackendApi.Data;
//using MyBackendApi.Models;

using Microsoft.AspNetCore.Mvc;

namespace MyBackendApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    // Hardcoded users
    private static readonly List<User> Users = new()
    {
        new User { Username = "admin", Password = "123", Role = "admin", Email = "admin@example.com" },
        new User { Username = "user", Password = "123", Role = "user", Email = "user@example.com" }
    };

    [HttpPost("register")]
    public IActionResult Register(User newUser)
    {
        if (Users.Any(u => u.Username == newUser.Username))
            return BadRequest("Username already exists.");

        newUser.Role = "user";
        Users.Add(newUser);

        return Ok(new { message = "User registered successfully." });
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] User login)
    {
        var user = Users.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);

        if (user == null)
            return Unauthorized("Invalid credentials");

        return Ok(new { username = user.Username, role = user.Role });
    }
}

// User class definition
public class User
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = "user";
    public string Email { get; set; } = string.Empty;
}
