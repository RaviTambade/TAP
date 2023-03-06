using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using ECommerceApp.Helpers;

namespace ECommerceApp.Controllers;

public class PaymentDetailsController : Controller
{

    public PaymentDetailsController()
    {
       
    }

      [HttpPost]
    public IActionResult BuyNow()
    {
         var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart")
                   ?? new Cart();
        return View(cart);
    }
    

}