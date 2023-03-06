using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using ECommerceApp.Helpers;
namespace ECommerceApp.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _ordersrv;

    public OrderController(IOrderService ordersrv)
    {
        _ordersrv = ordersrv;
    }
    [HttpGet]
    public IActionResult InsertOrder(){
        return View();
    }

     [HttpPost]
     public IActionResult InsertOrder(Order order){
         _ordersrv.InsertOrder(order);
        return RedirectToAction();
  
     }


   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
