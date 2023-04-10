
using PaymentProcessingService.Models;
using PaymentProcessingService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace PaymentProcessingService.Controllers;

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

   [HttpGet]
    [Route("/GetPaymentByOrder/{id}")]     
     public List<Payment> GetPaymentByOrderId(int id)
    {
        var payment=_paymentsrv.GetPaymentByOrderId(id);
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
        Payment oldpayment=_paymentsrv.GetPaymentById(id);
        if(oldpayment.PaymentId==0){
        return false;
        }
       payment.PaymentId=id;
        bool status=_paymentsrv.UpdatePayment(payment);
        return status;
    }

    [HttpDelete]
    [Route("/delete/{id}")]
    public bool Delete(int id)
    {
        bool status=_paymentsrv.DeletePayment(id);
        return status;
    }

    
    [HttpGet]
    [Route("/GetPaymentByCustomer/{id}")]     
     public List<Payment> GetPaymentByCustomer(int id)
    {
        var payment=_paymentsrv.GetPaymentByCustomer(id);
        return payment;
    }


    
}  
    