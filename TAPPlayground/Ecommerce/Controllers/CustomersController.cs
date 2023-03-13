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

    [HttpGet]
    public JsonResult GetAll()
    {
        var customers=_customersSrv.GetAllCustomers();
        return Json(customers);
    }

    [HttpGet]
    public JsonResult GetById(int id)
    {
        var customer=_customersSrv.GetCustomerById(id);
        return Json(customer);
    }


    
}
