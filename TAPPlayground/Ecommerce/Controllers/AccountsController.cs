using System.Diagnostics;
using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace ECommerceApp.Controllers;
public class AccountsController : Controller
{
    private readonly IAccountService _accountserv;
    public AccountsController(IAccountService accountserv)
    {
        _accountserv = accountserv;
    }
    [HttpGet]
    public JsonResult GetAll()
    {
        var accounts = _accountserv.GetAll();
     
        return Json(accounts);
    }
    [HttpGet]
    public IActionResult AccountsDetails()
    {
        return View();
    }

    [HttpGet]
    public JsonResult GetById(int id)
    {
        var account = _accountserv.GetById(id);
        return Json(account);
    }
    [HttpGet]
    public IActionResult Search(int id)
    {
        return View();
    }
    [HttpGet]
    public IActionResult AccountsIndex()
    {
        return View();
    }
    [HttpPost]
    public JsonResult Insert([FromBody] Account account)
    {
        bool status = _accountserv.Insert(account);
        return Json(status);
    }

    [HttpPut]
    public JsonResult Update([FromBody] Account account)
    {
        Console.WriteLine(account.AccountNumber);
        bool status = _accountserv.Update(account);
        return Json(status);
    }
    [HttpDelete]
    public JsonResult Delete(Int32 id)
    {
        bool status = _accountserv.Delete(id);
        return Json(status);
    }
    // public IActionResult Insert()
    // {
    //     return View();
    // }
    //  public IActionResult Update()
    // {
    //     return View();
    // }
    // public IActionResult Delete()
    // {
    //    return View(); 
    // }
}