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
        public SuppliersController(ISupplierService srv)
        {
            _srv = srv;
        }

        [HttpGet]
        [Route("getallsuppliers")]
        public IEnumerable<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliers = _srv.GetAll();
            return suppliers;
        }

        [HttpGet]
        [Route("getdetails/{id}")]
        public Supplier GetById(int id)
        {
            Supplier supplier = _srv.GetById(id);
            return supplier;
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("update/{id}")]
        public bool Update(int id, [FromBody] Supplier supplier)
        {
            Supplier oldSupplier = _srv.GetById(id);
            if (oldSupplier.SupplierId == 0)
            {
                return false;
            }
            supplier.SupplierId = id;
            bool status = _srv.Update(supplier);
            return status;
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("addsupplier")]
        public bool Insert([FromBody] Supplier supplier)
        {
            bool status = _srv.Insert(supplier);
            return status;
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpDelete]
        [Route("delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _srv.Delete(id);
            return status;
        }
    }
}



