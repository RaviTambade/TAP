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

        public IActionResult GetDetails()
    {
        return View();
    }

      public IActionResult TotalSold()
    {
        return View();
    }
    
      public IActionResult AvailableQuantity()
    {
        return View();
    }

       public IActionResult AddProduct()
    {
        return View();
    }

      public IActionResult UpdateProduct()
    {
        return View();
    }

     public IActionResult ReturnedProducts()
    {
        return View();
    }
     public IActionResult CancelledProducts()
    {
        return View();
    }

      public IActionResult Home()
    {
        return View();
    }

       public IActionResult ShowAllSuppliers()
    {
        return View();
    }
       public IActionResult ShowById()
    {
        return View();
    }
   
       [HttpPost]
       public IActionResult ShowById(int id)
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
    public JsonResult GetSuppliersOfProduct(int id){
        var suppliers=_srv.GetSuppliersOfProduct(id);
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
      Console.WriteLine(supplier.AccountNumber);
      Console.WriteLine(supplier.CompanyName);
        bool status=_srv.UpdateSupplier(supplier);
        return Json(status);
    }

      [HttpDelete]
    public JsonResult DeleteSupplier(int id)
    {
        bool supplier = _srv.DeleteSupplier(id);
        return Json(supplier);
    }

      [HttpGet]
    public IActionResult Search(int id)
    {
        return View();
    }
    
}
