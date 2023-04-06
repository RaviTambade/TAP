using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers{


    public class UsersController:ControllerBase
    {


     private readonly IUserService _svc;


     public UsersController(IUserService svc)
     {
        _svc=svc;
        
     }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateRequest request)
        {
            Console.WriteLine("authenticate is called.");
            Console.WriteLine(request.Email+","+request.Password);
            var user = _svc.Authenticate(request);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


        [Authorize(Roles=Role.Customer +","+Role.Employee)]
        [HttpGet ("users/GetAll")]
        public IActionResult GetAll(){

        var users = _svc.GetAll();
    
         return Ok(users);

        }
        
    }
}