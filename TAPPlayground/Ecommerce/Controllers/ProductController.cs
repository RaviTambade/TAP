using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Diagnostics;


namespace ECommerceApp.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productsrv;
    public ProductController(IProductService productsrv)
    {
        _productsrv = productsrv;
    }

 [HttpGet]
    public IActionResult Index()
    {  
        return View();
    }
    public IActionResult MockupScreen()
    {
       return View();
    } 

    [HttpGet]
    public IActionResult ShowAll()
    {
        var products=_productsrv.GetAll();
        return View(products);
    }

    [HttpGet]
    public JsonResult GetAll()
    {
        var products = _productsrv.GetAll();
        return Json(products);
    }
    [HttpGet]
    public JsonResult GetById(int id)
    {
       var product = _productsrv.GetById(id);
        return Json(product);
    }

     [HttpPost]
    public JsonResult Insert([FromBody] Product product)
    {
       bool status = _productsrv.Insert(product);
       return Json(status);
    }

     [HttpPut]
    public JsonResult Update([FromBody]Product product){
        bool status=_productsrv.Update(product);
        return Json(status);
    }

      [HttpDelete]
    public JsonResult Delete(int id)
    {
        bool status = _productsrv.Delete(id);
        return Json(status);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
