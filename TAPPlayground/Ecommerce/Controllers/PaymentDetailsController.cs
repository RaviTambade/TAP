// using System.Diagnostics;
// using ECommerceApp.Helpers;
// using ECommerceApp.Models;
// using ECommerceApp.Services.Interfaces;
// using Microsoft.AspNetCore.Mvc;

<<<<<<< HEAD
namespace ECommerceApp.Controllers;

public class PaymentDetailsController : Controller
{
    private readonly IOrderService _ordersrv;
    private readonly IOrderDetailsService _orderdetailssrv;
    private readonly IAddressService _addresssrv;
=======

// namespace ECommerceApp.Controllers;

// public class PaymentDetailsController : Controller
// {

//     private readonly IOrderService _ordersrv;
//     private readonly IOrderDetailsService _orderdetailssrv;

//     private readonly IAddressService _addresssrv;
>>>>>>> d0b78bd1cc09b94bed33ee4958d6b2e822fc6ef1

//     public PaymentDetailsController(IOrderService ordersrv, IOrderDetailsService orderdetailssrv, IAddressService addresssrv)
//     {
//         _ordersrv = ordersrv;
//         _orderdetailssrv = orderdetailssrv;
//         _addresssrv = addresssrv;
//     }

//     [HttpGet]
//     public IActionResult PlaceOrder()
//     {
//         var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
//         return View(cart);
//     }

<<<<<<< HEAD
    [HttpPost]
    public IActionResult OrderPlaced(PaymentDetails details)
    {
        var customerId = HttpContext.Session.GetObjectFromJson<Customer>("Customer").CustomerId;
        var addresId = HttpContext.Session.GetObjectFromJson<int>("AddressId");
        bool status = _ordersrv.InsertOrder(customerId);
        if (status)
        {
            int orderId = _ordersrv.GetOrderId(customerId);
            var products = HttpContext.Session.GetObjectFromJson<Cart>("Cart").Products;
            foreach (var product in products)
            {
                // Console.WriteLine(orderId);
                // Console.WriteLine(product.ProductId);
                // Console.WriteLine(product.BuyQuantity);
                _orderdetailssrv.InsertOrderdetails(orderId, product.ProductId, product.BuyQuantity);
                ViewData["products"] = _orderdetailssrv.GetOrderdProducts(orderId);
                ViewBag.address = _addresssrv.GetById(addresId);
            }
        }
        return View(details);
    }
}
=======
//     [HttpPost]
//     public IActionResult OrderPlaced(PaymentDetails details)
//     {
//         var customerId = HttpContext.Session.GetObjectFromJson<Customer>("Customer").CustomerId;
//         var addresId = HttpContext.Session.GetObjectFromJson<int>("AddressId");
//         bool status = _ordersrv.InsertOrder(customerId);
//         if (status)
//         {
//             int orderId = _ordersrv.GetOrderId(customerId);
//             var products = HttpContext.Session.GetObjectFromJson<Cart>("Cart").Products;
//             foreach (var product in products)
//             {
//                 // Console.WriteLine(orderId);
//                 // Console.WriteLine(product.ProductId);
//                 // Console.WriteLine(product.BuyQuantity);
//                 _orderdetailssrv.InsertOrderdetails(orderId, product.ProductId, product.BuyQuantity);
//                 ViewData["products"] = _orderdetailssrv.GetOrderdProducts(orderId);
//                 ViewBag.address = _addresssrv.GetAddressById(addresId);
//             }

//         }

//         return View(details);
//     }

// }
>>>>>>> d0b78bd1cc09b94bed33ee4958d6b2e822fc6ef1
