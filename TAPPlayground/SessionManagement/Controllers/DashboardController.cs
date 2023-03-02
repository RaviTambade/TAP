using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionManagement.Models;
using SessionManagement.Services;

namespace SessionManagement.Controllers;

public class DashboardController : Controller
{
    private readonly IProductService _service;

    public DashboardController(IProductService service)
    {
        this._service = service;
    }

    public JsonResult GetDetails()
    {
        var products = _service.GetProductsDetails();
        return Json(products);
    }

    public IActionResult Index()
    {
        return View();
    }

     public IActionResult BarChart()
    {
        return View();
    }
    public IActionResult PieChart()
    {
        return View();
    }
    public IActionResult LineChart()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
