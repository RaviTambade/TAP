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
        public IEnumerable<Cart> GetAllCarts()
        {
            List<Cart> carts = _cartSrv.GetAllCarts();
            return carts;
        }

        [HttpGet]
        [Route("getcartdetails/{id}")]
        public Cart GetCart(int id)
        {
            Cart cart = _cartSrv.GetCart(id);
            return cart;
        }

        [HttpPost]
        [Route("addtocart/{id}")]
        public bool AddToCart(int id, Item item)
        {
            Cart theCart = _cartSrv.GetCart(id);
            bool status = _cartSrv.AddItem(theCart, item);
            return status;
        }

        [HttpPut]
        [Route("update/{id}")]
        public bool UpdateCart(int id, Item item)
        {
            Cart theCart = _cartSrv.GetCart(id);
            bool status = _cartSrv.UpdateItem(theCart, item);
            return status;
        }

        [HttpPost]
        [Route("delete/{id}")]
        public bool RemoveFromCart(int id, Item item)
        {
            Cart theCart = _cartSrv.GetCart(id);
            bool status = _cartSrv.RemoveItem(theCart, item);
            return status;
        }

        [HttpPost]
        [Route("createorder/{id}")]
        public bool CreateOrder(int id)
        {
            bool status = _cartSrv.CreateOrder(id);
            return status;
        }

    }
}







