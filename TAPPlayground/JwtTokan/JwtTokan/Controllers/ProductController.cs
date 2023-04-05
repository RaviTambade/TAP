using System.Collections.Generic;
using ECommerceApp.Entities;
using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

using MySql.Data.MySqlClient;

namespace ECommerceApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase

    {
        private readonly IProductService _productsrv;
        public ProductsController(IProductService productsrv)
        {
            _productsrv = productsrv;
        }

        [HttpGet]
        [Route("/api/products/GetAllProducts")]
        public IEnumerable<Product> GetAllProducts()
        {
            List<Product> products = _productsrv.GetAll();
            return products;
        }

        [HttpGet]
        [Route("/api/products/GetProductDetails/{id}")]
        public Product GetById(int id)
        {
            Product product = _productsrv.GetById(id);
            return product;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("/api/products/update/{id}")]
        public bool Update( int id,[FromBody] Product product)
        {
            Product oldProduct = _productsrv.GetById(id);
            if(oldProduct.ProductId==0){
                return false;
            }
            product.ProductId=id;
            bool status = _productsrv.Update(product);
            return status;
        }

        [Authorize(Roles = Role.Admin+","+Role.Customer)]
        [HttpPost]
        [Route("/api/products/Addproduct/")]
        public bool Insert([FromBody] Product product)
        {
            bool status = _productsrv.Insert(product);
            return status;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete]
        [Route("/api/products/delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _productsrv.Delete(id);
            return status;
        }
    }
}





//  [HttpGet]
//     public IActionResult Index()
//     {  
//         return View();
//     }
//     public IActionResult MockupScreen()
//     {
//        return View();
//     } 

//     [HttpGet]
//     public IActionResult ShowAll()
//     {
//         var products=_productsrv.GetAll();
//         return View(products);
//     }

//     [HttpGet]
//     public JsonResult GetAll()
//     {
//         var products = _productsrv.GetAll();
//         return Json(products);
//     }
//     [HttpGet]
//     public JsonResult GetById(int id)
//     {
//        var product = _productsrv.GetById(id);
//         return Json(product);
//     }

//      [HttpPost]
//     public JsonResult Insert([FromBody] Product product)
//     {
//        bool status = _productsrv.Insert(product);
//        return Json(status);
//     }

//      [HttpPut]
//     public JsonResult Update([FromBody]Product product){
//         bool status=_productsrv.Update(product);
//         return Json(status);
//     }

//       [HttpDelete]
//     public JsonResult Delete(int id)
//     {
//         bool status = _productsrv.Delete(id);
//         return Json(status);
//     }

//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//     }
// }

