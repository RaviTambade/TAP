using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Controllers;

public class TransactionController : Controller
{
    private readonly ITransactionService _transactionsrv;

    public TransactionController(ITransactionService transactionsrv)
    {
        _transactionsrv = transactionsrv;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public JsonResult ShowAllTransactions()
    {
        var transactions=_transactionsrv.GetAllTransaction();
        return Json(transactions);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
