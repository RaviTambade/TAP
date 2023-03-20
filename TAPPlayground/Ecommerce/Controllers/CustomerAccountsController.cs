using System.Diagnostics;
using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace ECommerceApp.Controllers;
public class CustomerAccountsController : Controller
{
    private readonly ICustomerAccountService _accountserv;
    public CustomerAccountsController(ICustomerAccountService accountserv){
     _accountserv = accountserv;
    }
    [HttpGet]
    public JsonResult GetAllCustomersAccounts()
    {
        Console.WriteLine("customers");

        var accounts=_accountserv.GetAllCustomersAccounts();
        return Json(accounts);
    }
}