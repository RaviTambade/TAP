using CatalogService.Models;
using CatalogService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {

        
        private readonly IProductService _productsrv;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProductService productsrv,ILogger<ProductsController> logger)
        {
            _logger=logger;
            _productsrv = productsrv;
        }

        [HttpGet]
        [Route("getallproducts")]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            IEnumerable<Product> products =await _productsrv.GetAll();
<<<<<<< HEAD
            
=======
            _logger.LogInformation("Get all products method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
>>>>>>> ae08fd02ef6e92e6ebcf248ab8a13e19709998de
            return products;
        }

        [HttpGet]
        [Route("getproductdetails/{id}")]
        public async Task<Product> GetById(int id)
        {
            Product product = await _productsrv.GetById(id);
<<<<<<< HEAD
            
=======
            _logger.LogInformation("Get details of product method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
>>>>>>> ae08fd02ef6e92e6ebcf248ab8a13e19709998de
            return product;
        }

        // [Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("update/{id}")]
        public async Task<bool> UpdateAsync(int id, [FromBody] Product product)
        {
            Product oldProduct =await _productsrv.GetById(id);
            if (oldProduct.ProductId == 0)
            {
                return false;
            }
            product.ProductId = id;
            bool status = await _productsrv.Update(product);
<<<<<<< HEAD
           
=======
            _logger.LogInformation("Update product method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
>>>>>>> ae08fd02ef6e92e6ebcf248ab8a13e19709998de
            return status;
        }

        //[Authorize(Roles = Role.Admin + "," + Role.Customer)]
        [HttpPost]
        [Route("addproduct")]
        public async Task<bool> Insert([FromBody] Product product)
        {
            bool status =await  _productsrv.Insert(product);
<<<<<<< HEAD
             
=======
            _logger.LogInformation("Insert product method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
>>>>>>> ae08fd02ef6e92e6ebcf248ab8a13e19709998de
            return status;
        }

        // [Authorize(Roles = Role.Admin)]
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<bool> Delete(int id)
        {
            bool status =await _productsrv.Delete(id);
<<<<<<< HEAD
          
=======
            _logger.LogInformation("Delete product method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
>>>>>>> ae08fd02ef6e92e6ebcf248ab8a13e19709998de
            return status;
        }

        [HttpPut]
        [Route("hikeprice/{id}")]
        public async Task<bool> HikePrice(double id)
        {
<<<<<<< HEAD
            return await _productsrv.HikePrice(id);
           
=======
            bool status= await _productsrv.HikePrice(id);
            _logger.LogInformation("Hike price of products method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;

>>>>>>> ae08fd02ef6e92e6ebcf248ab8a13e19709998de
        }
    }
}