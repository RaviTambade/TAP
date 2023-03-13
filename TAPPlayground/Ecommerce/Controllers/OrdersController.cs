using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using ECommerceApp.Helpers;
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
    public IActionResult InsertOrder(){
        return View();
    }
   [HttpGet]
   public JsonResult InsertOrders()
   {
        Order order = null;
        return Json(order);
   }
   [HttpPost]
   public JsonResult InsertOrders(Order order)
   {
       var allorder =_ordersrv.InsertOrders(order);
       return Json(allorder);
   }

   [HttpGet]
   public JsonResult DeleteOrder(int id)
   {
    var order = _ordersrv.GetOrderById(id);
    return Json(order);
   }

     [HttpGet]
   public JsonResult DeleteOrder(Order order)
   {
    var orders = _ordersrv.DeleteOrder(order.OrderId);
    return Json(orders);
   }

   [HttpGet]
   public JsonResult UpdateOrder(int id)
   {
    var order = _ordersrv.GetOrderById(id);
    return Json(order);
   }

   [HttpPost]
   public JsonResult UpdateOrder(Order order)
   {
    var orders = _ordersrv.UpdateOrder(order);
    return Json(orders);
   }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
