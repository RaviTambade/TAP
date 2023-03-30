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
    public JsonResult GetAll()
    {
        var payment=_paymentsrv.GetAllPayments();
        return Json(payment);
    }
      
     
     
     public JsonResult GetById(int id)
    {
        var payment=_paymentsrv.GetPaymentById(id);
        return Json(payment);
    }
   
   
     public JsonResult GetPayment(int id)
    {
        var payment=_paymentsrv.GetPaymentById(id);
        return Json(payment);
    }
   
   
   [HttpPost]
   public JsonResult Insert([FromBody]Payment payment)
    {
        Console.WriteLine("In controller");
        Console.WriteLine(payment);
        var pay=_paymentsrv.InsertPayments(payment);
        return Json(pay);
    }
  
    [HttpPut]
   public JsonResult Update([FromBody]Payment payment)
    {
        var pay=_paymentsrv.UpdatePayment(payment);
        return Json(pay);
    }

     [HttpDelete]
    public JsonResult Delete(int id)
    {
        bool pay=_paymentsrv.DeletePayment(id);
        return Json(pay);
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
