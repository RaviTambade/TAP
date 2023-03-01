using System.Data.Common;
using System.Diagnostics;
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
        if (cart.Products == null)
            return RedirectToAction("Empty", "Cart");
        return View(cart);
    }




    public IActionResult Empty()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Count(int id)
    {
        var product = _service.GetProductById(id);
        return View(product);
    }

    [HttpPost]
    public IActionResult Count(Product product)
    {
        Console.WriteLine(product.Count);
        AddToCart(product.Id, product.Count);
        return RedirectToAction("Index", "Cart");
    }


    public IActionResult AddToCart(int id, int count)
    {
        var product = _service.GetProductById(id);
        product.Count = count;

        var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart")
                   ?? new Cart();

        if (cart.Products == null)
        {
            cart.Products = new List<Product>();
        }

        if (cart.Products.Any(p => p.Id == product.Id))
        {
            var oldproduct = cart.Products.First(p => p.Id == id);
            product.Count += oldproduct.Count;
            cart.Products.Remove(oldproduct);
            cart.Products.Add(product);
            HttpContext.Session.SetObjectAsJson("Cart", cart);
            return Ok();
        }

        cart.Products.Add(product);

        HttpContext.Session.SetObjectAsJson("Cart", cart);
        return RedirectToAction("BuyNow", "Cart");
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

    [HttpGet]
    public IActionResult BuyNow(List<Cart> products)
    {
        
        var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart")
                   ?? new Cart();
        return View(cart);
        
    }


    [HttpPost]
    public IActionResult BuyNow()
    {
        return RedirectToAction("OrderPlaced","Cart");
    }

    [HttpGet]
    public IActionResult OrderPlaced(){
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
