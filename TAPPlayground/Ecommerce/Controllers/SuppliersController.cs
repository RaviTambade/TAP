using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using System.Security;
using System.Reflection.Metadata.Ecma335;

namespace ECommerceApp.Controllers;

public class SuppliersController:Controller{
    private readonly ISupplierService _srv;
    public SuppliersController(ISupplierService srv){
        this._srv=srv;
    }

    public IActionResult Index()
    {
        return View();
    }


    [HttpGet]
    public JsonResult GetAllSuppliers(){
       var suppliers= _srv.GetAllSuppliers();
       return Json(suppliers);
    }

    [HttpGet]
    public JsonResult GetSupplierById(int id){
        var supplier=_srv.GetSupplierById(id);
        return Json(supplier);
    }

      [HttpGet]
    public JsonResult GetSuppliersOfProduct(int productId){
        var suppliers=_srv.GetSuppliersOfProduct(productId);
        return Json(suppliers);
    }

      [HttpPost]
      [Route("suppliers/insertsupplier")]
    public JsonResult InsertSupplier([FromBody] Supplier supplier){
        bool status=_srv.InsertSupplier(supplier);
        return Json(status);
    }

      [HttpPut]
      [Route("suppliers/updatesupplier")]
    public JsonResult UpdateSupplier([FromBody]Supplier supplier){
        bool status=_srv.InsertSupplier(supplier);
        return Json(status);
    }

      [HttpDelete]
    public JsonResult DeleteSupplier(int id)
    {
        bool supplier = _srv.DeleteSupplier(id);
        return Json(supplier);
    }
}
