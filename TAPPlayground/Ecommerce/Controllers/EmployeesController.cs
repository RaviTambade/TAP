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
    public JsonResult InsertEmp([FromBody] Employee employee)
    {
        bool result = _empsrv.InsertEmp(employee);
        return Json(result);
    }

    [HttpPut]
    public JsonResult UpdateEmp([FromBody] Employee emp)
    {
        bool result = _empsrv.UpdateEmp(emp);
        return Json(result);
    }
   

    [HttpDelete]
    public JsonResult DeleteEmp(int id)
    {
        bool result = _empsrv.DeleteEmp(id);
        return Json(result);
    }








    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
