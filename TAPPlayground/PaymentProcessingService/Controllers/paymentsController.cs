
using PaymentProcessingService.Models;
using PaymentProcessingService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace PaymentProcessingService.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PaymentsController : Controller
{
     private readonly ILogger<PaymentsController> _logger;
    private readonly IPaymentService _paymentsrv;

    
    public PaymentsController(ILogger<PaymentsController> logger,IPaymentService paymentsrv)
    {
        _logger = logger;
        _paymentsrv = paymentsrv;
    }

    [HttpGet]
    [Route("/api/payments/getallpayments")]
    public async Task<IEnumerable<Payment>> GetAll()
    {
       IEnumerable<Payment> payment=await _paymentsrv.GetAllPayments();
        _logger.LogInformation("Get All method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
        return payment;
    }
      
     
     [HttpGet]
    [Route("/api/payments/getpaymentdetails/{id}")]     
     public async Task<Payment> GetById(int id)
    {
        var payment= await _paymentsrv.GetPaymentById(id);
         _logger.LogInformation("Get All method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
        return payment;
    }

   [HttpGet]
    [Route("/api/payments/GetPaymentByOrder/{id}")]     
     public async Task<IEnumerable<Payment>> GetPaymentByOrderId(int id)
    {
        var payment=await _paymentsrv.GetPaymentByOrderId(id);
         _logger.LogInformation("Get All method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
        return payment;
    }


   [HttpPost]
   [Route("/api/payments/addpayment")]
   public async Task<bool> Insert([FromBody]Payment payment)
    {
        Console.WriteLine("In controller");
        Console.WriteLine(payment);
        var pay=await _paymentsrv.InsertPayments(payment);
         _logger.LogInformation("Payment data is inserted");
        return pay;
    }
  
    [HttpPut]
    [Route("/api/payments/update/{id}")]
   public async Task<bool> Update(int id,[FromBody]Payment payment)
    {
        Payment oldpayment=await _paymentsrv.GetPaymentById(id);
        if(oldpayment.PaymentId==0){
        return false;
        }
       payment.PaymentId=id;
        bool status=await _paymentsrv.UpdatePayment(payment);
         _logger.LogInformation("Payment data is updeted");
        return status;
    }

    [HttpDelete]
    [Route("/api/payments/delete/{id}")]
    public async Task<bool> Delete(int id)
    {
        bool status=await _paymentsrv.DeletePayment(id);
         _logger.LogInformation("Payment data is deleted");
        return status;
    }

    
    [HttpGet]
    [Route("/api/payments/GetPaymentByCustomer/{id}")]     
     public async Task<IEnumerable<Payment>> GetPaymentByCustomer(int id)
    {
        var payment= await _paymentsrv.GetPaymentByCustomer(id);
         _logger.LogInformation("Get All method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
        return payment;
    }


    
}  
    