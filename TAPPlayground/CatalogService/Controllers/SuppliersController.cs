using System.Collections.Generic;
using CatalogService.Models;
using CatalogService.Services;
using CatalogService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
namespace CatalogService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _srv;
        private readonly ILogger<SuppliersController> _logger;
        //store data
        public SuppliersController(ISupplierService srv,ILogger<SuppliersController> logger)
        {
            _srv = srv;
            _logger=logger;
        }

        [HttpGet]
        [Route("getallsuppliers")]
        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            IEnumerable<Supplier> suppliers =await _srv.GetAll();
            _logger.LogInformation("Get all suppliers method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return suppliers;
        }

        [HttpGet]
        [Route("getdetails/{id}")]
        public async Task<Supplier> GetById(int id)
        {
            Supplier supplier =await _srv.GetById(id);
            _logger.LogInformation("Get details of supplier method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return supplier;
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("update/{id}")]
        public async Task<bool> Update(int id, [FromBody] Supplier supplier)
        {
            Supplier oldSupplier =await _srv.GetById(id);
            if (oldSupplier.SupplierId == 0)
            {
                return false;
            }
            supplier.SupplierId = id;
            bool status =await _srv.Update(supplier);
            _logger.LogInformation("Update supplier method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("addsupplier")]
        public async Task<bool> Insert([FromBody] Supplier supplier)
        {
            bool status =await _srv.Insert(supplier);
            _logger.LogInformation("Insert supplier method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<bool> Delete(int id)
        {
            bool status =await _srv.Delete(id);
            _logger.LogInformation("Delete supplier method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }
    }
}