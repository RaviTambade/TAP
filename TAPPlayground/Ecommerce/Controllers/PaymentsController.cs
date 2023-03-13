using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Controllers;

public class PaymentsController : Controller
{
    private readonly IPaymentService _paymentsrv;

    public PaymentsController(IPaymentService paymentsrv)
    {
        _paymentsrv = paymentsrv;
    }

    [HttpGet]
    public JsonResult ShowAllPayments()
    {
        var payment=_paymentsrv.GetAllPayments();
        return Json(payment);
    }
    
     public JsonResult GetPaymentById(int paymentId)
    {
        var payment=_paymentsrv.GetPaymentById(paymentId);
        return Json(payment);
    }
     public JsonResult GetPaymentByOrderId(int OrderId)
    {
        var payment=_paymentsrv.GetPaymentById(OrderId);
        return Json(payment);
    }
    public IActionResult Index()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
