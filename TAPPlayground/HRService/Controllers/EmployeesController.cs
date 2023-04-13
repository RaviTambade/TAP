using System.Collections.Generic;
using HRService.Models;
using HRService.Services;
using HRService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace HRService.Controllers
{
   [ApiController]
    [Route("/api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _empsrv;
        private readonly ILogger<EmployeesController> _logger;
        public EmployeesController(ILogger<EmployeesController> logger,IEmployeeService empsrv)
        {
            _logger = logger;
            _empsrv = empsrv;
        }

        [HttpGet]
        [Route("getallemployees")]
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            List<Employee> employees =await _empsrv.GetAll();
            _logger.LogInformation("Get All method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return employees;
        }

        [HttpGet]
        [Route("getemployeedetails/{id}")]
        public async Task<Employee> GetById(int id)
        {
            Employee employee =await _empsrv.GetById(id);
             _logger.LogInformation("Get Employee By ID method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return employee;
        }

        [HttpGet]
        [Route("employeesbydeparment/{id}")]
        public IEnumerable<Employee> GetEmployeesByDepartmentId(int id)
        {
            List<Employee> employees = _empsrv.GetEmployeesByDepartmentId(id);
             _logger.LogInformation("Get Employee By Dept ID method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return employees;
        }

        //[Authorize(Roles = Role.Employee)]
        [HttpPut]
        [Route("update/{id}")]
        public async Task <bool> Update( int id,[FromBody] Employee employee)
        {
            Employee oldEmployee = await _empsrv.GetById(id);
            if(oldEmployee.EmpId==0){
                return false;
            }
            employee.EmpId=id;
            bool status =await _empsrv.Update(employee);
             _logger.LogInformation("Employee update is invoked");
            return status;
        }

        //[Authorize(Roles = Role.Employee)]
        [HttpPost]
        [Route("addemployee")]
        public async Task<bool> Insert([FromBody] Employee employee)
        {
            bool status =await _empsrv.Insert(employee);
             _logger.LogInformation("employee data  is inserted");  
            return status;
        }

        //[Authorize(Roles = Role.Employee)]
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task <bool> Delete(int id)
        {
            bool status =await _empsrv.Delete(id);
            _logger.LogInformation("employee data  is deleted");   
            return status;
        }
    }
}