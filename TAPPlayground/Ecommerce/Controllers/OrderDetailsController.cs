using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers;

public class OrderDetailsController : Controller
{
    private readonly IOrderDetailsService _srv;

    public OrderDetailsController(IOrderDetailsService srv)
    {
        _srv = srv;
    }

    // Getting all Records of orderdetails
    [HttpGet]
    public JsonResult GetAllOrderDetails()
    {
        var orderDetails = _srv.GetAllOrderDetails();
        return Json(orderDetails);
    }

    //Getting orderdetail record by  its id
    [HttpGet]
    public JsonResult GetOrderDetailById(int id)
    {
        var orderDetail =_srv.GetOrderDetailById(id);
        return Json(orderDetail);
    }

    // Getting all information of a Order  
    
    [HttpGet]
    public JsonResult GetOrderDetails(int orderId)
    {
        var orderDetails=_srv.GetOrderDetails(orderId);
        return Json(orderDetails);
    }
    


    //Getting all products of a order
      [HttpGet]
    public JsonResult GetProductsOfOrder(int orderId)
    {
        var orderDetails=_srv.GetProductsOfOrder(orderId);
        return Json(orderDetails);
    }

    

    [HttpGet]
    public IActionResult OrderHistory()
    {
        var customerId = HttpContext.Session.GetObjectFromJson<Customer>("Customer").CustomerId;
        var history = _srv.OrderHistory(customerId);
        return View(history);
    }
}