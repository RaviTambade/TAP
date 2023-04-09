using System.Collections.Generic;
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

        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("update/{id}")]
        public bool Update( int id,[FromBody] Supplier supplier)
        {
            Supplier oldSupplier = _srv.GetById(id);
            if(oldSupplier.SupplierId==0){
                return false;
            }
            supplier.SupplierId=id;
            bool status = _srv.Update(supplier);
            return status;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("addsupplier")]
        public bool Insert([FromBody] Supplier supplier)
        {
            bool status = _srv.Insert(supplier);
            return status;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete]
        [Route("delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _srv.Delete(id);
            return status;
        }
    }


    

    // [HttpGet]
    // public JsonResult GetAllSuppliers(){
    //    var suppliers= _srv.GetAll();
    //    return Json(suppliers);
    // }

    // [HttpGet]
    // public JsonResult GetSupplierById(int id){
    //     var supplier=_srv.GetById(id);
    //     return Json(supplier);
    // }

    //   [HttpGet]
    // public JsonResult GetSuppliersOfProduct(int id){
    //     var suppliers=_srv.GetSuppliers(id);
    //     return Json(suppliers);
    // }

    //   [HttpPost]
    //   [Route("suppliers/insertsupplier")]
    //    public JsonResult InsertSupplier([FromBody] Supplier supplier){
    //     bool status=_srv.Insert(supplier);
    //     return Json(status);
        
    // }

    //   [HttpPut]
    //   [Route("suppliers/updatesupplier")]
    // public JsonResult UpdateSupplier([FromBody]Supplier supplier){
    //   Console.WriteLine(supplier.AccountNumber);
    //   Console.WriteLine(supplier.CompanyName);
    //     bool status=_srv.Update(supplier);
    //     return Json(status);
    // }

    //   [HttpDelete]
    // public JsonResult DeleteSupplier(int id)
    // {
    //     bool status = _srv.Delete(id);
    //     return Json(status);
    // }
   
    //  [HttpGet]
    //   [Route("suppliers/getproductsupplier/{id}")]
    // public JsonResult GetProductSupplier(int id){
    //     var suppliers=_srv.GetProductSupplier(id);
    //     return Json(suppliers);
    // }

}



