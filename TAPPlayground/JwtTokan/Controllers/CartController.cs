using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ECommerceApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase

    {
        private readonly ICartService _cartSrv;
        public CartController(ICartService cartService)
        {
            _cartSrv = cartService;
        }

        [HttpGet]
        [Route("/api/cart/")]
        public IEnumerable<Item> GetAllCartItems()
        {
            List<Product> items = _productsrv.GetAll();
            return products;
        }

        [HttpGet]
        [Route("/api/cart/GetProductDetails/{id}")]
        public Product GetById(int id)
        {
            Product product = _productsrv.GetById(id);
            return product;
        }

         
        [HttpPut]
        [Route("/api/cart/update/{id}")]
        public bool UpdateCartItem( int id,[FromBody] Product product)
        {
            Product oldProduct = _productsrv.GetById(id);
            if(oldProduct.ProductId==0){
                return false;
            }
            product.ProductId=id;
            bool status = _productsrv.Update(product);
            return status;
        }

         
        [HttpPost]
        [Route("/api/cart/add/")]
        public bool AddToCart([FromBody] Item item)
        {
            bool status = _productsrv.Insert(product);
            return status;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete]
        [Route("/api/Cart/delete/{id}")]
        public bool DeleteCartItem(int id)
        {
            bool status = _productsrv.Delete(id);
            return status;
        }
    }
}







