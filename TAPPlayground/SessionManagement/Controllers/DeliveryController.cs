using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionManagement.Models;
using SessionManagement.Services;

namespace SessionManagement.Controllers;

public class DeliveryController : Controller
{
    private readonly IAddressService _addressservice;

    public DeliveryController(IAddressService addressservice)
    {
        _addressservice= addressservice;
    }

    [HttpGet]
    public IActionResult DeliveryAddress()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DeliveryAddress(Address address)
    {
        _addressservice.InsertAddress(address);
        return RedirectToAction("BuyNow","Cart");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
