using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace ECommerceApp.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PaymentsController : Controller
{
    private readonly IPaymentService _paymentsrv;

    
    public PaymentsController(IPaymentService paymentsrv)
    {
        _paymentsrv = paymentsrv;
    }

    [HttpGet]
    [Route("/getallpayments")]
    public  IEnumerable<Payment> GetAll()
    {
        List<Payment> payment=_paymentsrv.GetAllPayments();
        return payment;
    }
      
     
     [HttpGet]
    [Route("/getpaymentdetails/{id}")]     
     public Payment GetById(int id)
    {
        var payment=_paymentsrv.GetPaymentById(id);
        return payment;
    }

   [HttpPost]
   [Route("/addpayment")]
   public bool Insert([FromBody]Payment payment)
    {
        Console.WriteLine("In controller");
        Console.WriteLine(payment);
        var pay=_paymentsrv.InsertPayments(payment);
        return pay;
    }
  
    [HttpPut]
    [Route("/update/{id}")]
   public bool Update(int id,[FromBody]Payment payment)
    {
        Payment payments=_paymentsrv.GetPaymentById(id);
        if(payment.payments==0){
        return false;
        }
       payment.payments=id;
        var status=_paymentsrv.UpdatePayment(payment);
        return status;
    }

    [HttpDelete]
    [Route("/delete/{id}")]
    public bool Delete(int id)
    {
        bool status=_paymentsrv.DeletePayment(id);
        return status;
    }
    
}  
    