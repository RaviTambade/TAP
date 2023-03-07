using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using ECommerceApp.Helpers;

namespace ECommerceApp.Controllers;

public class OrderDetailsController : Controller
{
    private readonly IOrderDetailsService _srv;

    public OrderDetailsController(IOrderDetailsService srv)
    {
        _srv = srv;
    }

   [HttpGet]
   public IActionResult OrderHistory()
   {
    var customerId=HttpContext.Session.GetObjectFromJson<Customer>("Customer").CustomerId;
    var history=_srv.OrderHistory(customerId);
    return View(history);
   } 
}