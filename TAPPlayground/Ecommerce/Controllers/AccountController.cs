using System.Diagnostics;
using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace ECommerceApp.Controllers;
public class AccountsController : Controller
{
    private readonly IAccountService _accountserv;
    public AccountsController(IAccountService accountserv){
     _accountserv = accountserv;
    }
    [HttpGet]
    public JsonResult GetAllAccounts()
    {
        var accounts=_accountserv.GetAllAccounts();
        return Json(accounts);
    }
    [HttpGet]
    public JsonResult GetAccountById(int id)
    {
        var account=_accountserv.GetAccountById(id);
        return Json(account);
    }
}