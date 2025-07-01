//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBackendApi.Data;
using MyBackendApi.Models;

namespace MyBackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
    }
}
