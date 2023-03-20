using System.Diagnostics;
using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers;

public class OrderDetailsController : Controller
{
    private readonly IOrderDetailsService _service;

    public OrderDetailsController(IOrderDetailsService srv)
    {
        _service = srv;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Search(int id)
    {
        return View();
    }

    // Getting all Records of orderdetails
    [HttpGet]
    public JsonResult AllOrderDetails()
    {
        var orderDetails = _service.AllOrderDetails();
        return Json(orderDetails);
    }

    //Getting orderdetail record by  its id
    [HttpGet]
    public JsonResult GetById(int id)
    {
        var orderDetail = _service.GetById(id);
        return Json(orderDetail);
    }

    //Getting all products of a order
    [HttpGet]
    public JsonResult GetProductsOfOrder(int id)
    {
        var orderDetails = _service.GetProductsOfOrder(id);
        return Json(orderDetails);
    }

    //Inserting  orderdetails
    [HttpPost]
    public JsonResult Insert([FromBody] OrderDetails orderDetails)
    {
        bool result = _service.Insert(orderDetails);
        return Json(result);
    }

    //updating orderdetails

    [HttpPut]
    public JsonResult Update([FromBody] OrderDetails orderDetails)
    {
        bool result = _service.Update(orderDetails);
        return Json(result);
    }

    //Deleting Record from orderdetails
    [HttpDelete]
    public JsonResult Delete(int id)
    {
        bool orderDetails = _service.Delete(id);
        return Json(orderDetails);
    }


    //showing customers orderhistory
    [HttpGet]
    public IActionResult OrderHistory(int id)  //customerId
    {
        // var customerId = HttpContext.Session.GetObjectFromJson<Customer>("Customer").CustomerId;
        var history = _service.OrderHistory(id);
        return View(history);
    }
}