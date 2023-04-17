using System.Collections.Generic;
using HRService.Models;
using HRService.Services;
using HRService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Caching.Memory;

namespace HRService.Controllers
{
   [ApiController]
    [Route("/api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IDepartmentService _deptsrv;
         private readonly ILogger<DepartmentsController> _logger;
        public DepartmentsController(ILogger<DepartmentsController> logger,IDepartmentService deptsrv, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _logger = logger;
            _deptsrv = deptsrv;
        }

        [HttpGet]
        [Route("getalldepartments")]
        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            var cacheKey = "deptList";  //check if cache entried exist
            if(! _memoryCache.TryGetValue(cacheKey,out IEnumerable<Department> deptList))
            {
                deptList = await _deptsrv.GetAll();
                _logger.LogInformation("Get All Dept method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(20)
                };
                //setting cache entries
                _memoryCache.Set(cacheKey , deptList , cacheExpiryOptions);
            }
            return deptList;
        }
       

        [HttpGet]
        [Route("getdepartmentdetails/{id}")]
        public async Task<Department> GetById(int id)
        {
            Department department =await _deptsrv.GetById(id);
             _logger.LogInformation("Get Dept By ID method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return department;
        }

        //[Authorize(Roles = Role.Employee)]
        [HttpPut]
        [Route("update/{id}")]
        public async Task <bool> Update( int id,[FromBody] Department department)
        {
            Department oldDepartment =await _deptsrv.GetById(id);
            if(oldDepartment.DeptId==0){
                return false;
            }
            department.DeptId=id;
            bool status =await _deptsrv.Update(department);
            _logger.LogInformation("department update is invoked");
            return status;
        }

        //[Authorize(Roles = Role.Employee)]
        [HttpPost]
        [Route("adddepartment")]
        public async Task<bool> Insert([FromBody] Department department)
        {
            bool status =await _deptsrv.Insert(department);
            _logger.LogInformation("department data  is inserted"); 
            return status;
        }

        //[Authorize(Roles = Role.Employee)]
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task< bool> Delete(int id)
        {
            bool status =await _deptsrv.Delete(id);
            _logger.LogInformation("department data  is deleted"); 
            return status;
        }
    }
}