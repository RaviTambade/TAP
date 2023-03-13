using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Controllers;

public class EmployeeController : Controller
{
    
    private readonly IEmployeeService _empsrv;

    public EmployeeController(IEmployeeService empsrv)
    {
        _empsrv = empsrv;
    }

    public IActionResult Index()
    {
        return View ();
    }

    [HttpGet]
    public JsonResult ShowAll()
    {
        var employees = _empsrv.GetAllEmployees();
        return Json(employees);
    }

    [HttpGet]
    public JsonResult GetById(int id)
    {
        var employee = _empsrv.GetEmployeeById(id);
        return Json(employee);
    }

      [HttpPost]
    public JsonResult Insert([FromBody] Employee emp)
    {
        bool result = _empsrv.InsertEmp(emp);
        return Json(result);
    }

    






    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
