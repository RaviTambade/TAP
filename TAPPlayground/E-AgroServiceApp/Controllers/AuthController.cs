 using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using E_AgroServiceDemo.Models;
using E_AgroServiceDemo.Services.Interfaces;
using E_AgroServiceDemo.Services;

namespace E_AgroServiceDemo.Controllers;

public class AuthController : Controller
{
    private readonly IUserService _userService;


  public AuthController(IUserService userService)
    {
        this._userService=userService;
    }
  
  [HttpGet]
    public IActionResult LoginAsAdmin()
    {
        return View();
    }

[HttpPost]
    public IActionResult LoginAsAdmin(User user)
    {
     bool status=  _userService.ValidateAdmin(user);
     if(status){
        return RedirectToAction("Valid","Auth");
     }
      return RedirectToAction("InValid","Auth");
     }
       
       [HttpGet]
    public IActionResult LoginAsFarmer()
    {
        return View();
    }

[HttpPost]

    public IActionResult LoginAsFarmer(User user)
    {
     bool status=  _userService.ValidateFarmer(user);
     if(status){
        return RedirectToAction("Valid","Auth");
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

    // [HttpGet]
    // public IActionResult Register(){
    //     return View();
    // }

    // [HttpPost]
    // public IActionResult Register(User user){
    //     bool status=_userService.RegisterUser(user);
    //     if(status){
    //         return RedirectToAction("Login","Auth");
    //     }
    //     return RedirectToAction("InValid2","Auth");
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
