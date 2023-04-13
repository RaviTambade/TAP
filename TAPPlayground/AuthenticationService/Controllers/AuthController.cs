using AuthenticationService.Models;
using AuthenticationService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _svc;
        public AuthController(IUserService svc)
        {
            _svc = svc;

        }

        [HttpPost("login")] 
        public IActionResult Authenticate([FromBody] AuthenticateRequest request)
        {
            var user = _svc.Authenticate(request);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        // This method is not reuired 

        [HttpGet("/getall")]  
        public IEnumerable<User> GetAll()
        {
            var users = _svc.GetAll();
            return users;
        }
    }
}