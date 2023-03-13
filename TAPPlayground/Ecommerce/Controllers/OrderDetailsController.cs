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

    [HttpGet]
    public JsonResult GetAllOrderDetails()
    {
        var orderDetails = _srv.GetAllOrderDetails();
        return Json(orderDetails);
    }

    [HttpGet]
    public JsonResult GetOrderDetailById(int id)
    {
        var orderDetail =_srv.GetOrderDetailById(id);
        return Json(orderDetail);
    }

    [HttpGet]
    public IActionResult OrderHistory()
    {
        var customerId = HttpContext.Session.GetObjectFromJson<Customer>("Customer").CustomerId;
        var history = _srv.OrderHistory(customerId);
        return View(history);
    }
}