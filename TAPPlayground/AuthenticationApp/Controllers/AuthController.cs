using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AuthenticationApp.Models;
using AuthenticationApp.Services;

namespace AuthenticationApp.Controllers;

public class AuthController : Controller
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        this._userService=userService;
    }
  
  [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

[HttpPost]
    public IActionResult Login(User user)
    {
     bool status=  _userService.ValidateUser(user);
     if(status){
        return RedirectToAction("Index","Home");
     }
      return RedirectToAction("InValid","Auth");
       }
    

     public IActionResult Valid()
    {
        return View();
    }

      public IActionResult InValid()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Register(){
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user){
        bool status=_userService.RegisterUser(user);
        if(status){
            return RedirectToAction("Login","Auth");
        }
        return RedirectToAction("InValid2","Auth");
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
