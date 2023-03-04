using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionManagement.Models;
using SessionManagement.Services;

namespace SessionManagement.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    public IActionResult ShowAll()
    {
        var products = _service.GetAllProducts();
        return View(products);
    }
    /*

    public IActionResult GetDetails()
    {
        var products = _service.GetProductsDetails();
        return View(products);
    }
*/


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
