using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Contexts;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Controllers;

public class CustomersController : Controller
{
    private readonly ICustomerService _customersSrv;
    private readonly ICustomerORMService _customersOrmSrv;

    public CustomersController(ICustomerService customerSrv, ICustomerORMService customerOrmService)
    {
        _customersSrv = customerSrv;
        _customersOrmSrv = customerOrmService;
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
    
    public IActionResult CustomerService()
    {
        return View();
    }


    [HttpGet]
    public JsonResult GetAll()
    {
        var customers=_customersSrv.GetAll();
        // var customers=_customersOrmSrv.GetAll(); 
        return Json(customers);
    }

    [HttpGet]
    public JsonResult GetById(int id)
    {
        Console.WriteLine(id);
        var customer=_customersSrv.GetById(id);
        return Json(customer);
    }

    [HttpPost]
    public JsonResult InsertCustomer([FromBody] Customer customer)
    {
        Console.WriteLine(customer.ToString());
        bool result = _customersSrv.Insert(customer);
        return Json(result);
    }

    [HttpDelete]
    public JsonResult DeleteCustomer(int id)
    {
        bool result = _customersSrv.Delete(id);
        return Json(result);
    }

    [HttpPut]
    public JsonResult UpdateCustomer([FromBody]Customer customer)
    {
        Console.WriteLine(customer.ToString());
        bool result = _customersSrv.Update(customer);
        return Json(result);
    }

     [HttpGet]
    public IActionResult Search(int id)
    {
        return View();
    }
    
}
