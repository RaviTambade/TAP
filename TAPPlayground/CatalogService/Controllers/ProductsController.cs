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
        public ProductsController(IProductService productsrv)
        {
            _productsrv = productsrv;
        }

        [HttpGet]
        [Route("getallproducts")]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            IEnumerable<Product> products =await _productsrv.GetAll();
            return products;
        }

        [HttpGet]
        [Route("getproductdetails/{id}")]
        public async Task<Product> GetById(int id)
        {
            Product product = await _productsrv.GetById(id);
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
            return status;
        }

        //[Authorize(Roles = Role.Admin + "," + Role.Customer)]
        [HttpPost]
        [Route("addproduct")]
        public async Task<bool> Insert([FromBody] Product product)
        {
            bool status =await  _productsrv.Insert(product);
            return status;
        }

        // [Authorize(Roles = Role.Admin)]
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<bool> Delete(int id)
        {
            bool status =await _productsrv.Delete(id);
            return status;
        }

        [HttpPut]
        [Route("hikeprice/{id}")]
        public async Task<bool> HikePrice(double id)
        {
            return await _productsrv.HikePrice(id);
        }
    }
}