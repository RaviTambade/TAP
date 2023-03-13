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
        var suppliers=_srv.GetSupplierById(productId);
        return Json(suppliers);
    }
}
