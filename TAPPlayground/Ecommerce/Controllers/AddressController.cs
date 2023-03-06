using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using ECommerceApp.Helpers;
namespace ECommerceApp.Controllers;

public class AddressController : Controller
{
    private readonly IAddressService _addresssrv;

    public AddressController(IAddressService addresssrv)
    {
        _addresssrv = addresssrv;
    }

     [HttpGet]
     public IActionResult Address(){
        return View();
     }

     [HttpPost]
     public IActionResult Address(Address address){
         int customerid =HttpContext.Session.GetObjectFromJson<Customer>("Customer").CustomerId;
         address.CustomerId=customerid;
        _addresssrv.InsertAddress(address);
        return RedirectToAction("GetAddresses");
     }

    [HttpGet]
    public IActionResult GetAddresses()
    {
        var customer =HttpContext.Session.GetObjectFromJson<Customer>("Customer");
       var addresses= _addresssrv.GetAddresses(customer.CustomerId);
       return View(addresses);
    }

   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
