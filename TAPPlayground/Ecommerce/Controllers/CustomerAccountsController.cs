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
    public JsonResult GetAll()
    {
        Console.WriteLine("customers");

        var accounts=_accountserv.GetAll();
        return Json(accounts);
    }
}