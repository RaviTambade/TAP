
using PaymentProcessingService.Models;
using PaymentProcessingService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using PaymentProcessingService.Helpers;
using Microsoft.Extensions.Caching.Memory;

namespace PaymentProcessingService.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PaymentsController : Controller
{
    private readonly IMemoryCache _memoryCache;
    private readonly ILogger<PaymentsController> _logger;
    private readonly IPaymentService _paymentsrv;
    private object memoryCache;

    public PaymentsController(IMemoryCache memoryCache, ILogger<PaymentsController> logger, IPaymentService paymentsrv)
    {
        _memoryCache = memoryCache;
        _logger = logger;
        _paymentsrv = paymentsrv;
    }



    //[Authorize(Roles=Role.Admin)]
    [HttpGet]
    [Route("/api/payments/getallpayments")]                          //------->link for fetching GetAll() method Data.
    public async Task<IEnumerable<Payment>> GetAll()                 //This method return all payments details.
    {
        var cacheKey = "paymentList";
        if (!_memoryCache.TryGetValue(cacheKey, out IEnumerable<Payment> paymentList))
        {
            paymentList = await _paymentsrv.GetAllPayments();
            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(20)
            };
            _memoryCache.Set(cacheKey, paymentList, cacheExpiryOptions);
            _logger.LogInformation("Get All method invoked at  {DT}", DateTime.UtcNow.ToLongTimeString());

        }
        return paymentList;
    }


    [HttpGet]
    [Route("/api/payments/getpaymentdetails/{id}")]
    public async Task<Payment> GetById(int id)                         // This method return payment details of provideded id.
    {
        var payment = await _paymentsrv.GetPaymentById(id);
        _logger.LogInformation("Get All method invoked at  {DT}", DateTime.UtcNow.ToLongTimeString());
        return payment;
    }

    [HttpGet]
    [Route("/api/payments/GetPaymentByOrder/{id}")]
    public async Task<IEnumerable<Payment>> GetPaymentByOrderId(int id)
    {
        var payment = await _paymentsrv.GetPaymentByOrderId(id);
        _logger.LogInformation("Get All method invoked at  {DT}", DateTime.UtcNow.ToLongTimeString());
        return payment;
    }


    [HttpPost]
    [Route("/api/payments/addpayment")]
    public async Task<bool> Insert([FromBody] Payment payment)              //This method adds payment.
    {
        Console.WriteLine("In controller");
        Console.WriteLine(payment);
        var pay = await _paymentsrv.InsertPayments(payment);
        _logger.LogInformation("Payment data is inserted");
        return pay;
    }

    [HttpPut]
    [Route("/api/payments/update/{id}")]
    public async Task<bool> Update(int id, [FromBody] Payment payment)        //This method return for update payment by id
    {
        Payment oldpayment = await _paymentsrv.GetPaymentById(id);
        if (oldpayment.PaymentId == 0)
        {
            return false;
        }
        payment.PaymentId = id;
        bool status = await _paymentsrv.UpdatePayment(payment);
        _logger.LogInformation("Payment data is updeted");
        return status;
    }

    [HttpDelete]
    [Route("/api/payments/delete/{id}")]
    public async Task<bool> Delete(int id)                                      //This method delete the payment payment details by id.
    {
        bool status = await _paymentsrv.DeletePayment(id);
        _logger.LogInformation("Payment data is deleted");
        return status;
    }


    [HttpGet]
    [Route("/api/payments/GetPaymentByCustomer/{id}")]            
    public async Task<IEnumerable<Payment>> GetPaymentByCustomer(int id)       //This method gives payment details by customer id.
    {
        var payment = await _paymentsrv.GetPaymentByCustomer(id);
        _logger.LogInformation("Get All method invoked at  {DT}", DateTime.UtcNow.ToLongTimeString());
        return payment;
    }



}
