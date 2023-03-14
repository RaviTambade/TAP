using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
namespace ECommerceApp.Controllers;

public class OrdersController : Controller
{
    private readonly IOrderService _ordersrv;

    public OrdersController(IOrderService ordersrv)
    {
        _ordersrv = ordersrv;
    }
    [HttpGet]
    public JsonResult GetAllOrders()
    {
        var orders = _ordersrv.GetAllOrders();
        return Json(orders);
    }

    [HttpGet]

    public JsonResult GetOrderById(int id)
    {
        var order = _ordersrv.GetOrderById(id);
        return Json(order);
    }

    [HttpGet]

    public JsonResult GetOrderByCustId(int custid)
    {
        var order = _ordersrv.GetOrderByCustId(custid);
        return Json(order);
    }
    
    [HttpGet]
    public IActionResult InsertOrder()
    {
        return View();
    }

    [HttpGet]
   public IActionResult InsertOrders()
   {
       return View();
   }

   [HttpPost]
   public JsonResult InsertOrders([FromBody] Order order)
   {
        bool result =_ordersrv.InsertOrders(order);
        return Json(result);
   }
  
    [HttpGet]
   public IActionResult UpdateOrder()
   {
       return View();
   }

    [HttpPut]
   public JsonResult UpdateOrder([FromBody] Order order)
   {
        bool result =_ordersrv.UpdateOrder(order);
        return Json(result);
   }
   [HttpDelete]
   public JsonResult DeleteOrder(int id)
   {
    bool result = _ordersrv.DeleteOrder(id);
    return Json(result);
   }

   
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
