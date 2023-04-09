using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
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

        [HttpPost("/login")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest request)
        {
            Console.WriteLine("authenticate is called.");
            Console.WriteLine(request.Email + "," + request.Password);
            var user = _svc.Authenticate(request);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


        [Authorize(Roles = Role.Admin)]
        [HttpGet("/getall")]
        public IEnumerable<User> GetAll()
        {
            var users = _svc.GetAll();
            return users;
        }

        [HttpPut("/update-email")]
        public bool UpdateEmail([FromBody] ChangedCredential credential)
        {
            return _svc.UpdateEmail(credential);
        }

        [HttpPut("/forgot-password")]
        public bool ForgotPassword([FromBody] User user)
        {
            return _svc.ForgotPassword(user);
        }

        [HttpPut("/update-password")]
        public bool UpdatePassword([FromBody] ChangedCredential credential)
        {
            return _svc.UpdatePassword(credential);
        }

    }
}