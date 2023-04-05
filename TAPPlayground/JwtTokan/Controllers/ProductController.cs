using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


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







