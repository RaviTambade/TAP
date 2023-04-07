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
        private readonly ICartService _cartsrv;
        public CartController(ICartService cartService)
        {
            _cartsrv = cartService;
        }

        [HttpGet]
        [Route("/api/cart/GetAllCartItems")]
        public IEnumerable<Cart> GetAllCarts()
        {
            List<Cart> carts = _cartsrv.GetAllCarts();
            return carts;
        }

        [HttpGet]
        [Route("/api/cart/GetCartDetails/{id}")]
        public Cart GetCart(int id)
        {
            Cart cart = _cartsrv.GetCart(id);
            return cart;
        }

        [HttpPost]
        [Route("/api/cart/Addtocart/{id}")]
        public bool AddToCart(int id,Item item)
        {
            Cart theCart=_cartsrv.GetCart(id);
            bool status = _cartsrv.AddItem(theCart,item);
            return status;
        }

        [HttpPut]
        [Route("/api/cart/update/{id}")]
        public bool UpdateCart(int id,Item item)
        {
            Cart theCart=_cartsrv.GetCart(id);
            bool status = _cartsrv.UpdateItem(theCart,item);
            return status;
        }

        [HttpDelete]
        [Route("/api/cart/Addtocart/{id}")]
        public bool RemoveFromCart(int id,Item item)
        {
            Cart theCart=_cartsrv.GetCart(id);
            bool status = _cartsrv.RemoveItem(theCart,item);
            return status;
        }
    }
}

         
//         [HttpPut]
//         [Route("/api/cart/update/{id}")]
//         public bool UpdateCartItem( int id,[FromBody] Product product)
//         {
//             Product oldProduct = _productsrv.GetById(id);
//             if(oldProduct.ProductId==0){
//                 return false;
//             }
//             product.ProductId=id;
//             bool status = _productsrv.Update(product);
//             return status;
//         }

         
//         [HttpPost]
//         [Route("/api/cart/add/")]
//         public bool AddToCart([FromBody] Item item)
//         {
//             bool status = _productsrv.Insert(product);
//             return status;
//         }

//         [Authorize(Roles = Role.Admin)]
//         [HttpDelete]
//         [Route("/api/Cart/delete/{id}")]
//         public bool DeleteCartItem(int id)
//         {
//             bool status = _productsrv.Delete(id);
//             return status;
//         }
//     }
// }

    





