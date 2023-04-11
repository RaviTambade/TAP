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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _deptsrv;
        public DepartmentsController(IDepartmentService deptsrv)
        {
            _deptsrv = deptsrv;
        }

        [HttpGet]
        [Route("getalldepartments")]
        public IEnumerable<Department> GetAllDepartments()
        {
            List<Department> departments = _deptsrv.GetAll();
            return departments;
        }

        [HttpGet]
        [Route("getdepartmentdetails/{id}")]
        public Department GetById(int id)
        {
            Department department = _deptsrv.GetById(id);
            return department;
        }

        //[Authorize(Roles = Role.Employee)]
        [HttpPut]
        [Route("update/{id}")]
        public bool Update( int id,[FromBody] Department department)
        {
            Department oldDepartment = _deptsrv.GetById(id);
            if(oldDepartment.DeptId==0){
                return false;
            }
            department.DeptId=id;
            bool status = _deptsrv.Update(department);
            return status;
        }

        //[Authorize(Roles = Role.Employee)]
        [HttpPost]
        [Route("adddepartment")]
        public bool Insert([FromBody] Department department)
        {
            bool status = _deptsrv.Insert(department);
            return status;
        }

        //[Authorize(Roles = Role.Employee)]
        [HttpDelete]
        [Route("delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _deptsrv.Delete(id);
            return status;
        }
    }
}