using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Controllers;

public class ShipperController : Controller
{
    private readonly IShipperService _shippersrv;

    public ShipperController(IShipperService shippersrv)
    {
        _shippersrv = shippersrv;
    }

    [HttpGet]
    public JsonResult ShowAllShippers()
    {
        var shippers=_shippersrv.GetAllShippers();
        return Json(shippers);
    }

    public IActionResult Index()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
