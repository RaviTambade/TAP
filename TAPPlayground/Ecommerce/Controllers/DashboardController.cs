
using System.Data.Common;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;


namespace SessionManagement.Controllers;

public class DashboardController : Controller
{
    private readonly IDashboardService _dashboardsrv;

    private readonly IProductService _productsrv;

    public DashboardController(IDashboardService dashboardsrv, IProductService productsrv)
    {
        _dashboardsrv = dashboardsrv;
        _productsrv = productsrv;

    }
    public JsonResult GetDetails()
    {
        var products = _productsrv.GetAllProducts();
        var result = _dashboardsrv.GetProductsData(products);
        return Json(result);
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]

    public IActionResult BarChart()
    {
        return View();
    }
    [HttpGet]

    public IActionResult PieChart()
     {
         return View();
     }
    // public IActionResult LineChart()
    // {
    //     return View();
    // }
}

