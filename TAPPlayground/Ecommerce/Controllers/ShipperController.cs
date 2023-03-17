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
    public JsonResult GetAllShippers()
    {
        var shippers=_shippersrv.GetAllShippers();
        return Json(shippers);
    }

    [HttpGet]
    public JsonResult GetShipperById(int id)
    {
        var shipper=_shippersrv.GetShipperById(id);
        return Json(shipper);
    }

  [HttpGet]
    public IActionResult InsertShipper()
    {
        return View();
    }



   /*[HttpPost]
    public JsonResult InsertShipper([FromBody]Shipper shipper)
    {
        bool status=_shippersrv.InsertShipper(shipper);
        return Json(status);
    }
    */

  [HttpPost]
      [Route("shipper/insertshipper")]
     
    public JsonResult InsertShipper([FromBody] Shipper shipper){
             Console.WriteLine(shipper.Email);
             Console.WriteLine(shipper.AcountNumber);
             bool status=_shippersrv.InsertShipper(shipper);
             return Json(status);
         
    }


    [HttpPut]
    public JsonResult UpdateShipper([FromBody]Shipper shipper)
    {
        System.Console.WriteLine(shipper);
        bool status=_shippersrv.UpdateShipper(shipper);
        return Json(status);  
         Console.WriteLine(shipper);


    }

   [HttpDelete]
    public JsonResult DeleteShipper(int id)
    {
        bool status=_shippersrv.DeleteShipper(id);
        return Json(status);
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
