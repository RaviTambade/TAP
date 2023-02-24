using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using E_AgroServiceDemo.Models;
using E_AgroServiceDemo.Services.Interfaces;
using E_AgroServiceDemo.Services;

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
}