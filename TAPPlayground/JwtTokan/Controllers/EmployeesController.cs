using System.Collections.Generic;
//using ECommerceApp.Entities;
using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

using MySql.Data.MySqlClient;

namespace ECommerceApp.Controllers
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
        [Route("/getallemployees")]
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> employees = _empsrv.GetAll();
            return employees;
        }

        [HttpGet]
        [Route("/getemployeedetails/{id}")]
        public Employee GetById(int id)
        {
            Employee employee = _empsrv.GetById(id);
            return employee;
        }

        [Authorize(Roles = Role.Employee)]
        [HttpPut]
        [Route("/update/{id}")]
        public bool Update( int id,[FromBody] Employee employee)
        {
            Employee oldEmployee = _empsrv.GetById(id);
            if(oldEmployee.EmpId==0){
                return false;
            }
            employee.EmpId=id;
            bool status = _empsrv.Update(employee);
            return status;
        }

        [Authorize(Roles = Role.Employee)]
        [HttpPost]
        [Route("/addemployee/")]
        public bool Insert([FromBody] Employee employee)
        {
            bool status = _empsrv.Insert(employee);
            return status;
        }

        [Authorize(Roles = Role.Employee)]
        [HttpDelete]
        [Route("/delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _empsrv.Delete(id);
            return status;
        }
    }
}