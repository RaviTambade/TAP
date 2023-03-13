using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Controllers;

public class MiniStatementController : Controller
{
    private readonly IMiniStatementService _miniStatementsrv;

    public MiniStatementController(IMiniStatementService miniStatementsrv)
    {
        _miniStatementsrv = miniStatementsrv;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public JsonResult ShowMiniStatement(int custId)
    {
       var miniStatement = _miniStatementsrv.GetMiniStatement(custId);
       return Json(miniStatement); 
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
