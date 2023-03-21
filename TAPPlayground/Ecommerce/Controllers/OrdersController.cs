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
    public JsonResult GetAll()
    {
        var orders = _ordersrv.GetAll();
        return Json(orders);
    }

    [HttpGet]
    public JsonResult GetCancelled()
    {
        var orders = _ordersrv.GetAllCancelled();
        return Json(orders);
    }

    [HttpGet]
    public JsonResult GetDelivered()
    {
        var orders = _ordersrv.GetAllDelivered();
        return Json(orders);
    }

    [HttpGet]
    public JsonResult GetById(int id)
    {
        var order = _ordersrv.GetById(id);
        return Json(order);
    }

    [HttpGet]
    public JsonResult GetOrder(int id)
    {
        var order = _ordersrv.GetOrderByCustId(id);
        return Json(order);
    }
    
    [HttpGet]
    public IActionResult InsertOrder()
    {
        return View();
    }
    

     public IActionResult Index()
    {
        return View();
    }

    public IActionResult Search()
    {
        return View();
    }

    public IActionResult InsertOrders()
    {
        return View();
    }
    public IActionResult Addressdetails()
    {
        return View();
    }

    public IActionResult OrderHistory()
    {
        return View();
    }
    public IActionResult Orderdetails()
    {
        return View();
    }
    public IActionResult Paymode()
    {
        return View();
    }

    public IActionResult OnlinePay()
    {
        return View();
    }

    public IActionResult NetBanking()
    {
        return View();
    }

   [HttpPost]
   public JsonResult Insert([FromBody] Order order)
   {    
        Console.WriteLine("Order date" +order.OrderDate);
        bool result =_ordersrv.Insert(order);
        return Json(result);
   }
  
   [HttpPut]
   public JsonResult Update([FromBody] Order order)
   {
        Console.WriteLine("Order date" +order.OrderDate);
        bool result =_ordersrv.Update(order);
        return Json(result);
   }
   
   [HttpDelete]
   public JsonResult Delete(int id)
   {
    bool result = _ordersrv.Delete(id);
    return Json(result);
   }

   
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
