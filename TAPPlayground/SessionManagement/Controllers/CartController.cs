using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using SessionManagement.Models;
using SessionManagement.Services;

namespace SessionManagement.Controllers;

public class CartController : Controller
{
    private readonly IProductService _service;

    public CartController(IProductService service)
    {
        _service = service;
    }



    public IActionResult Index()
    {
        var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
        if (cart.Products == null )
            return RedirectToAction("Empty", "Cart");
        return View(cart);
    }




    public IActionResult Empty()
    {
        return View();
    }

    public IActionResult AddToCart(int id)
    {
        var product = _service.GetProductById(id);

        var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart")
                   ?? new Cart();

        if (cart.Products == null)
        {
            cart.Products = new List<Product>();
        }

        cart.Products.Add(product);

        HttpContext.Session.SetObjectAsJson("Cart", cart);

        return RedirectToAction("ShowAll", "Product");
    }

    public IActionResult RemoveFromCart(int id)
{
    var product = _service.GetProductById(id);

    var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();

    if (cart.Products != null && cart.Products.Any(p => p.Id == id))
    {
        var productToRemove = cart.Products.First(p => p.Id == id);
        cart.RemoveProduct(productToRemove);
        HttpContext.Session.SetObjectAsJson("Cart", cart);
    }

    return RedirectToAction("Index");
}




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
