using System.Linq;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using ECommerceApp.Helpers;

namespace ECommerceApp.Controllers;

public class SecureController : Controller
{
  
    private readonly ISecureService _securessvr;

    public SecureController(ISecureService secureservice)
    {
        this._securessvr = secureservice;
    }

   
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public JsonResult Register([FromBody]Customer customer)
    {
        Console.WriteLine(customer.FirstName);
        bool result = _securessvr.RegisterCustomer(customer);
        return Json(result);
    }

    [HttpPost]
    public JsonResult Validate([FromBody]Credential user)
    {
        Console.WriteLine("user email"+user.Email);
        bool result = _securessvr.ValidateUser(user);
        return Json(result);
    }

    [HttpPut]
    public JsonResult ChangePassword([FromBody]ChangedCredential user)
    { 
        Console.WriteLine(user.Email);
        bool result=_securessvr.ChangePassword(user);
        return Json(result);
    }
  



}
