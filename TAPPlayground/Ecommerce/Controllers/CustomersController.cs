using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Controllers;

public class CustomersController : Controller
{
    private readonly ICustomerService _customersSrv;

    public CustomersController(ICustomerService customerSrv)
    {
        _customersSrv = customerSrv;
    }

    public IActionResult Index()
    {
        return View();
    }

     public IActionResult Login()
    {
        return View();
    }
     public IActionResult WishList()
    {
        return View();
    }
     public IActionResult DeliveredOrders()
    {
        return View();
    }
     public IActionResult CancelledOrders()
    {
        return View();
    }
     public IActionResult Dashboard()
    {
        return View();
    }


    [HttpGet]
    public JsonResult GetAll()
    {
        var customers=_customersSrv.GetAllCustomers();
        return Json(customers);
    }

    [HttpGet]
    public JsonResult GetById(int id)
    {
        Console.WriteLine(id);
        var customer=_customersSrv.GetCustomerById(id);
        return Json(customer);
    }

    [HttpPost]
    public JsonResult InsertCustomer([FromBody] Customer customer)
    {
        Console.WriteLine(customer.CustomerId+" "+ customer.FirstName);
        bool result = _customersSrv.InsertCustomer(customer);
        return Json(result);
    }

    [HttpDelete]
    public JsonResult DeleteCustomer(int id)
    {
        bool result = _customersSrv.DeleteCustomer(id);
        return Json(result);
    }

    [HttpPut]
    public JsonResult UpdateCustomer([FromBody]Customer customer)
    {
        Console.WriteLine("firstname "+customer.FirstName+" lastname " + customer.LastName +" id "+ customer.CustomerId);
        bool result = _customersSrv.UpdateCustomer(customer);
        return Json(result);
    }

     [HttpGet]
    public IActionResult Search(int id)
    {
        return View();
    }
    
}
