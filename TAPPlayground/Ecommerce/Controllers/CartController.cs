using System.Data.Common;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;


namespace SessionManagement.Controllers;

public class CartController : Controller
{
    private readonly IProductService _productsrv;

    public CartController(IProductService srv)
    {
        _productsrv = srv;
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
    public IActionResult BuyQuantity(int id)
    {
        var product = _productsrv.GetProduct(id);
        return View(product);
    }

    [HttpPost]
    public IActionResult BuyQuantity(Product product)
    {
        AddToCart(product);
        return RedirectToAction("Index", "Cart");
    }


    public IActionResult AddToCart(Product product)
    {
       
        var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart")
                   ?? new Cart();

        if (cart.Products == null)
        {
            cart.Products = new List<Product>();
        }

        if (cart.Products.Any(p => p.ProductId == product.ProductId))
        {
            Product oldproduct = cart.Products.First(p => p.ProductId == product.ProductId);
            product.BuyQuantity += oldproduct.BuyQuantity;
            cart.Products.Remove(oldproduct);
            cart.Products.Add(product);
            HttpContext.Session.SetObjectAsJson("Cart", cart);
            return Ok();
        }

        cart.Products.Add(product);

        HttpContext.Session.SetObjectAsJson("Cart", cart);
        return Ok();
    }

    public IActionResult RemoveFromCart(int id)
    {
        
        var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();

        if (cart.Products != null && cart.Products.Any(p => p.ProductId == id))
        {
            var productToRemove = cart.Products.First(p => p.ProductId == id);
            cart.RemoveProduct(productToRemove);
            HttpContext.Session.SetObjectAsJson("Cart", cart);
        }

        return RedirectToAction("Index");
    }



    // [HttpGet]
    // public IActionResult BuyNow()
    // {
        
    //     var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart")
    //                ?? new Cart();
    //     return View(cart);
        
    // }

    // [HttpPost]
    // public IActionResult OrderPlaced(PaymentDetails details){
    //       var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
    //       foreach(var product in cart.Products){
    //       var foundProduct=  _service.GetProductById(product.Id);
    //       foundProduct.Count=product.Count;
    //      _service.UpdateProduct(foundProduct);
    //       }
    //     return View(details);
    // }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
