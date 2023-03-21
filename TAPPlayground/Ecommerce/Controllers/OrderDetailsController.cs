
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
    public JsonResult GetAll()
    {
        var orderDetails = _service.GetAll();
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
    public JsonResult GetOrderDetailsByOrder(int id)
    {
        var orderDetails = _service.GetOrderDetailsByOrder(id);     //orderId
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
        bool orderDetails = _service.DeleteByOrderDetailsId(id);
        return Json(orderDetails);
    }


    //showing customers orderhistory
    [HttpGet]
    public IActionResult GetOrderHistory(int id)  //customerId
    {
        // var customerId = HttpContext.Session.GetObjectFromJson<Customer>("Customer").CustomerId;
        var history = _service.GetOrderHistory(id);
        return View(history);
    }
}