// using System.Diagnostics;
// using ECommerceApp.Helpers;
// using ECommerceApp.Models;
// using ECommerceApp.Services.Interfaces;
// using Microsoft.AspNetCore.Mvc;
// namespace ECommerceApp.Controllers;
// public class CustomersAccountsController : Controller
// {
//     private readonly ICustomersAccountsService _accountserv;
//     public CustomersAccountsController(ICustomersAccountsService accountserv){
//      _accountserv = accountserv;
//     }
//     [HttpGet]
//     public JsonResult GetAllCustomersAccounts()
//     {
//         var accounts=_accountserv.GetAllCustomersAccounts();
//         return Json(accounts);
//     }
// }