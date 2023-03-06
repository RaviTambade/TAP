using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using ECommerceApp.Helpers;

namespace ECommerceApp.Controllers;

public class AuthController : Controller
{
    private readonly ICustomerService _customersrv;
    private readonly IUserService _usersrv;
    public AuthController(ICustomerService srv,IUserService userService)
    {
        this._customersrv = srv;
        this._usersrv=userService;
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(Customer customer)
    {
        _customersrv.InsertCustomer(customer);
        return RedirectToAction("LogIn", "Auth");
    }


    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult LogIn(User user)
    {
        bool status = _usersrv.ValidateUser(user);
        if (status)
        {
            var customer = _customersrv.GetCustomer(user.ContactNumber);
            HttpContext.Session.SetObjectAsJson("Customer", customer);

            return RedirectToAction("ShowAll", "Product");
        }
        return RedirectToAction("Invalid", "Auth");
    }

    public IActionResult Valid()
    {
        return View();
    }

    public IActionResult InValid()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
