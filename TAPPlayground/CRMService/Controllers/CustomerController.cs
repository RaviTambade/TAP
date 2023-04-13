using System.Collections.Generic;
using CRMService.Models;
using CRMService.Services;
using CRMService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

using MySql.Data.MySqlClient;

namespace CRMService.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class CustomersController : ControllerBase

    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerService _custsrv;
        public CustomersController(ICustomerService custsrv, ILogger<CustomersController> logger, IMemoryCache memoryCache )
        {
            _custsrv = custsrv;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        [Route("getallcustomers")]
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var cacheKey="customerList";    //checks if cache entries exists
            if(!_memoryCache.TryGetValue(cacheKey, out IEnumerable<Customer> customerList))
            {
              customerList = await _custsrv.GetAll();
             _logger.LogInformation("Get All method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            //setting up cache options
             var cacheExpiryOptions = new MemoryCacheEntryOptions
             {
                AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(20)
             };
             //setting cache entries
             _memoryCache.Set(cacheKey, customerList, cacheExpiryOptions);
            }
            return customerList;
        }

        [HttpGet]
        [Route("getcustomerdetails/{id}")]
        public async Task<Customer> GetById(int id)
        {
            Customer customer =await _custsrv.GetById(id);
            _logger.LogInformation("Get By Id method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return customer;
        }

        // [Authorize(Roles = Role.Employee)]
        [HttpPut]
        [Route("update/{id}")]
        public async Task<bool> Update( int id,[FromBody] Customer customer)
        {
            Customer oldCustomer =await _custsrv.GetById(id);
            _logger.LogInformation("Update method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            if(oldCustomer.CustomerId==0){
                return false;
            }
            customer.CustomerId=id;
            bool status =await _custsrv.Update(customer);
            return status;
        }

        // [Authorize(Roles = Role.Employee)]
        [HttpPost]
        [Route("addcustomer")]
        public async Task<bool> Insert([FromBody] Customer customer)
        {
            bool status = await _custsrv.Insert(customer);
            _logger.LogInformation("Insert method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }

        // [Authorize(Roles = Role.Employee)]
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<bool> Delete(int id)
        {
            bool status = await _custsrv.Delete(id);
            _logger.LogInformation("Delete method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }
    }
}