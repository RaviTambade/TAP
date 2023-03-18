using System.Diagnostics;
using System.Linq;
using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers;

public class SecureController : Controller
{

    private readonly ISecureService _securessvr;

    public SecureController(ISecureService secureservice)
    {
        this._securessvr = secureservice;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpGet]
    public IActionResult NewAccount()
    {
        return View();
    }

    [HttpGet]
    public IActionResult NewPassword()
    {
        return View();
    }

    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View();
    }


    [HttpGet]
    public IActionResult ShowUserByRole()
    {
        return View();
    }

     [HttpGet]
    public JsonResult GetUserByRole(string id)
    {
        List<User> users=new List<User>{
            new User{UserId=1 ,UserName="sahil" ,ContactNumber="9975966045" ,Password="sahil@123",Role="Admin"},
            new User{UserId=2 ,UserName="shubham" ,ContactNumber="9309478546" ,Password="shubham@311",Role="Admin"},
            new User{UserId=3 ,UserName="abhay" ,ContactNumber="7754123965" ,Password="abhay@22",Role="Customer"},
            new User{UserId=4 ,UserName="akshay" ,ContactNumber="9565410237" ,Password="akshay@67",Role="Shipper"},

        };

       List<User> userList=new List<User>();
       foreach (var user in users){
        if(user.Role ==id){
            userList.Add(user);
         Console.WriteLine(user.UserName);
        }
       }
        return Json(userList);
    }

    [HttpPost]
    public JsonResult Register([FromBody] Customer customer)
    {
        Console.WriteLine(customer.FirstName);
        bool result = _securessvr.RegisterCustomer(customer);
        return Json(result);
    }

    [HttpPost]
    public JsonResult Validate([FromBody] Credential user)
    {
        Console.WriteLine("user email" + user.Email);
        bool result = _securessvr.ValidateUser(user);
        return Json(result);
    }

    [HttpPut]
    public JsonResult ChangePassword([FromBody] ChangedCredential user)
    {
        Console.WriteLine(user.Email);
        bool result = _securessvr.ChangePassword(user);
        return Json(result);
    }




}
