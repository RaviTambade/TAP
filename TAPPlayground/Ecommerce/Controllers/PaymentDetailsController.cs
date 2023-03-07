using System.Diagnostics;
using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ECommerceApp.Controllers;

public class PaymentDetailsController : Controller
{

      private readonly IOrderService _ordersrv;
      private readonly IOrderDetailsService _orderdetailssrv;

    public PaymentDetailsController(IOrderService ordersrv, IOrderDetailsService orderdetailssrv)
    {
        _ordersrv = ordersrv;
        _orderdetailssrv = orderdetailssrv;
    }

    [HttpGet]
    public IActionResult PlaceOrder()
    {
        var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
        return View(cart);
    }

    [HttpPost]
    public IActionResult OrderPlaced(PaymentDetails details)
    {
       var customerId= HttpContext.Session.GetObjectFromJson<Customer>("Customer").CustomerId;
       bool status = _ordersrv.InsertOrder(customerId);
        if(status){
            int orderId=_ordersrv.GetOrderId(customerId);
            var products= HttpContext.Session.GetObjectFromJson<Cart>("Cart").Products;
            foreach(var product in products){
                // Console.WriteLine(orderId);
                // Console.WriteLine(product.ProductId);
                // Console.WriteLine(product.BuyQuantity);
                _orderdetailssrv.InsertOrderdetails(orderId,product.ProductId,product.BuyQuantity);
            }
        }

        return View(details);
    }

}