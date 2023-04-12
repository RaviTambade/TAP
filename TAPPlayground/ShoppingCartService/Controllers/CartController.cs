using Microsoft.AspNetCore.Mvc;
using ShoppingCartService.Models;
using ShoppingCartService.Services.Interfaces;

namespace ShoppingCartService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartSrv;
        public CartController(ICartService cartService)
        {
            _cartSrv = cartService;
        }

        [HttpGet]
        [Route("getallcartitems")]
        public async Task<IEnumerable<Cart>> GetAllCarts()
        {
            List<Cart> carts =await _cartSrv.GetAllCarts();
            return carts;
        }

        [HttpGet]
        [Route("getcartdetails/{id}")]
        public async Task<Cart> GetCart(int id)
        {
            Cart cart = await _cartSrv.GetCart(id);
            return cart;
        }

        [HttpPost]
        [Route("addtocart/{id}")]
        public async Task<bool> AddToCart(int id, Item item)
        {
            Cart theCart =await _cartSrv.GetCart(id);
            if(theCart.CartId==0){
                return false;
            }
            bool status =await _cartSrv.AddItem(theCart.CartId, item);
            return status;
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<bool> UpdateCart(int id, Item item)
        {
            Cart theCart =await _cartSrv.GetCart(id);
            if(theCart.CartId==0){
                return false;
            }
            bool status =await _cartSrv.UpdateItem(theCart.CartId, item);
            return status;
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<bool> RemoveFromCart(int id, Item item)
        {
            Cart theCart =await _cartSrv.GetCart(id);
            if(theCart.CartId==0){
                return false;
            }
            bool status =await _cartSrv.RemoveItem(theCart.CartId, item);
            return status;
        }

        [HttpPost]
        [Route("createorder/{id}")]
        public async Task<bool> CreateOrder(int id)
        {
            bool status =await _cartSrv.CreateOrder(id);
            return status;
        }
    }
}