using System.Collections.Generic;
using System.Threading.Tasks;
using BankingService.Models;
using BankingService.Services;
using BankingService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankingService.Controllers
{

   [ApiController]
    [Route("/api/[controller]")]
    public class AccountsController : ControllerBase

    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IAccountService _accountsrv;
    public AccountsController(ILogger<AccountsController> logger, IAccountService srv)
    {
        _logger = logger;
    
            _accountsrv =srv;

        }

        [HttpGet]
        [Route("getallaccounts")]
        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            List<Account> accounts = await _accountsrv.GetAll();
      _logger.LogInformation("Get All method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());

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
        public async Task< Account> GetById(int id)
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
        public async Task <bool> Update(Account account)
        {
            bool status = await _accountsrv.Update(account);
      _logger.LogInformation("Update method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());

            return status;
        }
    }
}
       