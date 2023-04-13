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
        public EmployeesController(IEmployeeService empsrv)
        {
            _empsrv = empsrv;
        }

        [HttpGet]
        [Route("getallemployees")]
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            List<Employee> employees =await _empsrv.GetAll();
            return employees;
        }

        [HttpGet]
        [Route("getemployeedetails/{id}")]
        public async Task<Employee> GetById(int id)
        {
            Employee employee =await _empsrv.GetById(id);
            return employee;
        }

        [HttpGet]
        [Route("employeesbydeparment/{id}")]
        public IEnumerable<Employee> GetEmployeesByDepartmentId(int id)
        {
            List<Employee> employees = _empsrv.GetEmployeesByDepartmentId(id);
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
            bool status = _empsrv.Update(employee);
            return status;
        }

        //[Authorize(Roles = Role.Employee)]
        [HttpPost]
        [Route("addemployee")]
        public bool Insert([FromBody] Employee employee)
        {
            bool status = _empsrv.Insert(employee);
            return status;
        }

        //[Authorize(Roles = Role.Employee)]
        [HttpDelete]
        [Route("delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _empsrv.Delete(id);
            return status;
        }
    }
}