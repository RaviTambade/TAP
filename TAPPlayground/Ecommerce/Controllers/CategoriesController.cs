using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
namespace ECommerceApp.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryService _srv;

    public CategoriesController(ICategoryService srv)
    {
        _srv=srv;
    }

     [HttpGet]
    public JsonResult GetAll(int id)
    {
       var categories= _srv.GetAll();
        return Json(categories);
    }
    
}