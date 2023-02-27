using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using E_AgroServiceDemo.Models;
using E_AgroServiceDemo.Services.Interfaces;
using E_AgroServiceDemo.Services;
using Microsoft.AspNetCore.Mvc.Localization;

namespace E_AgroServiceDemo.Controllers;

public class FarmerController : Controller
{
    private readonly IFarmerService _farmerService;


  public FarmerController(IFarmerService farmerService)
    {
        this._farmerService=farmerService;
    }

  [HttpGet]
    public IActionResult ShowAll()
    {
          ViewData["allFarmers"]=_farmerService.GetAllFarmers();
        return View();
    }


 [HttpGet]
    public IActionResult GetById(){
      return View();
    }

    [HttpGet]
    public IActionResult Search(){
      return View();
    }

    [HttpPost]

    public IActionResult Search(int id){
    var farmer= _farmerService.GetFarmerById(id);
    return View("GetById",farmer);
    }


[HttpGet]
public IActionResult Insert(){
  Farmer farmer=null;
  return View(farmer);
}

[HttpPost]

public IActionResult Insert(Farmer farmer)
{
  _farmerService.InsertFarmer(farmer);
  return RedirectToAction("ShowAll","Farmer");
}

 [HttpGet]
    public IActionResult Update(int id)
    {
       var farmer =_farmerService.GetFarmerById(id);
        return View(farmer);
    }
    [HttpPost]
    public IActionResult Update(Farmer farmer)
    {
       _farmerService.UpdateFarmer(farmer);
        return RedirectToAction("ShowAll", "Farmer");
    }

        [HttpGet]
    public IActionResult Delete(int id)
    {
       var farmer= _farmerService.GetFarmerById(id);
        return View(farmer);
    }

  public IActionResult Delete(Farmer farmer)
    {
       _farmerService.DeleteFarmer(farmer.FarmerId);
          return RedirectToAction("ShowAll", "Farmer");
    }

}
