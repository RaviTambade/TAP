using System.Collections.Generic;
using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

using MySql.Data.MySqlClient;

namespace ECommerceApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase

    {
        private readonly IAccountService _accountsrv;
        public AccountsController(IAccountService accountsrv)
        {
            _accountsrv = accountsrv;
        }

        [HttpGet]
        [Route("/api/accounts/GetAllAccounts")]
        public IEnumerable<Account> GetAllAccount()
        {
            List<Account> accounts = _accountsrv.GetAll();
            return accounts;
        }

        [HttpGet]
        [Route("/api/accounts/GetAccountDetails/{id}")]
        public Account GetById(int id)
        {
            Account account = _accountsrv.GetById(id);
            return account;
        }



        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("/api/accounts/Addaccount")]
        public bool Insert([FromBody] Account account)
        {
            bool status = _accountsrv.Insert(account);
            return status;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete]
        [Route("/api/accounts/delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _accountsrv.Delete(id);
            return status;
        }
        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("/api/accounts/update/{id}")]
        public bool Update(Account account)
        {
            bool status = _accountsrv.Update(account);
            return status;
        }
    }
}



