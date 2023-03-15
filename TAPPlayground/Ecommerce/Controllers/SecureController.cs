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
    [HttpPost]
    public JsonResult Register(Customer customer)
    {
        Console.WriteLine(customer.FirstName);
        bool result = _securessvr.RegisterCustomer(customer);
        return Json(result);
    }

    [HttpPost]
    public JsonResult Validate(User user)
    {
        bool result = _securessvr.ValidateUser(user);
        return Json(result);
    }

    // [HttpPut]
    // public IActionResult ChangePassword()
    // {
        
    // }
  



}
