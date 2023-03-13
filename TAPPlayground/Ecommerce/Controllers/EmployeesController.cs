using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Controllers;

public class EmployeesController : Controller
{
    
    private readonly IEmployeesService _empsrv;

    public EmployeesController(IEmployeesService empsrv)
    {
        _empsrv = empsrv;
    }

    public IActionResult Index()
    {
        return View ();
    }

    [HttpGet]
    public JsonResult ShowAllEmployees()
    {
        var employees = _empsrv.GetAllEmployees();
        return Json(employees);
    }

    public JsonResult GetById(int id)
    {
        var employee = _empsrv.GetEmployeeById(id);
        return Json(employee);
    }

    






    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
