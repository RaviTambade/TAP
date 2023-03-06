using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productsrv;

    public ProductController(IProductService productsrv)
    {
        _productsrv = productsrv;
    }

    [HttpGet]
    public IActionResult ShowAll()
    {
        var products=_productsrv.GetAllProducts();
        return View(products);
    }

   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
