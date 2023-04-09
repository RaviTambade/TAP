using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ECommerceApp.Controllers
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
        public IEnumerable<Product> GetAllProducts()
        {
            List<Product> products = _productsrv.GetAll();
            return products;
        }

        [HttpGet]
        [Route("getproductdetails/{id}")]
        public Product GetById(int id)
        {
            Product product = _productsrv.GetById(id);
            return product;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("update/{id}")]
        public bool Update(int id, [FromBody] Product product)
        {
            Product oldProduct = _productsrv.GetById(id);
            if (oldProduct.ProductId == 0)
            {
                return false;
            }
            product.ProductId = id;
            bool status = _productsrv.Update(product);
            return status;
        }

        [Authorize(Roles = Role.Admin + "," + Role.Customer)]
        [HttpPost]
        [Route("addproduct")]
        public bool Insert([FromBody] Product product)
        {
            bool status = _productsrv.Insert(product);
            return status;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete]
        [Route("delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _productsrv.Delete(id);
            return status;
        }

        [HttpPut]
        [Route("hikeprice/{id}")]
        public bool HikePrice(double id)
        {
            return _productsrv.HikePrice(id);
        }
    }
}







