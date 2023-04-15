using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BankingService.Helpers;
using BankingService.Models;
using BankingService.Services;
using BankingService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using BankingService.Extensions;

namespace BankingService.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class AccountsController : ControllerBase

    {
        private readonly IDistributedCache _distributedCache;
        // private readonly IMemoryCache _memoryCache;
        private readonly ILogger<AccountsController> _logger;
        private readonly IAccountService _accountsrv;
        public AccountsController(ILogger<AccountsController> logger, IAccountService srv, IDistributedCache distCache)
        {
            _logger = logger;
            //_memoryCache = memoryCache;
            _distributedCache = distCache;
            _accountsrv = srv;

        }

        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        [Route("getallaccounts")]
        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
 
            List<Account> accounts = await _accountsrv.GetAll();
            _logger.LogInformation("Get All method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            var cacheKey = "accounts";
           // if (!_memoryCache.TryGetValue(cacheKey, out IEnumerable<Account> accounts))
                 IEnumerable<Account> accounts = await _distributedCache.GetDataAsync<IEnumerable<Account>>(cacheKey);
            if (accounts != null)
            {
               _logger.LogInformation("Get All method invoked at  {DT}", DateTime.UtcNow.ToLongTimeString());
            }
             if (accounts == null)
            {
                accounts = await _accountsrv.GetAll();
               _logger.LogInformation("Get All method invoked at  {DT}", DateTime.UtcNow.ToLongTimeString());
                await _distributedCache.SetDataAsync(cacheKey, accounts, TimeSpan.FromMinutes(1), TimeSpan.FromHours(1));



            //     var cacheExpiryOptions = new MemoryCacheEntryOptions
            //     {
            //         AbsoluteExpiration = DateTime.Now.AddSeconds(50),
            //         Priority = CacheItemPriority.High,
            //         SlidingExpiration = TimeSpan.FromSeconds(20)
            //     };

            //     _memoryCache.Set(cacheKey, accounts, cacheExpiryOptions);
             }
            return accounts;
        }

        // [HttpGet]
        // [Route("/getallaccountsbycustomerid")]
        // public IEnumerable<Account> GetAllAccounts(int customerId)
        // {
        //     List<Account> accounts = _accountsrv.getallAccountsByCustomerId(customerId);
        //     return accounts;
        // }


        [HttpGet]
        [Route("getaccountdetails/{id}")]
        public async Task<Account> GetById(int id)
        {
            Account account = await _accountsrv.GetById(id);
            _logger.LogInformation("Get By Id method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());

            return account;
        }


        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("addaccount")]
        public async Task<bool> Insert([FromBody] Account account)
        {
            bool status =await _accountsrv.Insert(account);
            _logger.LogInformation("Insert method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());

            return status;
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<bool> Delete(int id)
        {
            bool status =  await _accountsrv.Delete(id);
            _logger.LogInformation("Delete method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());

            return status;
        }
        //[Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("update/{id}")]
        public async Task<bool> Update(Account account)
        {
            bool status = await _accountsrv.Update(account);
            _logger.LogInformation("Update method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }
    }
}
