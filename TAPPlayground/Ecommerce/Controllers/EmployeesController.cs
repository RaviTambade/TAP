using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Controllers;

public class EmployeesController : Controller
{
    private readonly IEmployeeService _empsrv;
    public EmployeesController(IEmployeeService empsrv)
    {
        _empsrv = empsrv;
    }

      public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public JsonResult ShowAll()
    {
        var employees = _empsrv.GetAll();
        return Json(employees);
    }

    [HttpGet]
    public JsonResult GetById(int id)
    {
        var employee = _empsrv.GetById(id);
        return Json(employee);
    }

    [HttpPost]
    public JsonResult Insert([FromBody] Employee emp)
    {
        bool result = _empsrv.Insert(emp);
        return Json(result);
    }

    [HttpPut]
    public JsonResult Update([FromBody] Employee emp)
    {
        bool result = _empsrv.Update(emp);
        return Json(result);
    }

    [HttpDelete]
    public JsonResult Delete(int id)
    {
        bool result = _empsrv.Delete(id);
        return Json(result);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
