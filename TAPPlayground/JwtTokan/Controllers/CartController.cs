using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartsrv;
        public CartController(ICartService cartService)
        {
            _cartsrv = cartService;
        }

        [HttpGet]
        [Route("getallcartitems")]
        public IEnumerable<Cart> GetAllCarts()
        {
            List<Cart> carts = _cartsrv.GetAllCarts();
            return carts;
        }

        [HttpGet]
        [Route("getcartdetails/{id}")]
        public Cart GetCart(int id)
        {
            Cart cart = _cartsrv.GetCart(id);
            return cart;
        }

        [HttpPost]
        [Route("addtocart/{id}")]
        public bool AddToCart(int id,Item item)
        {
            Cart theCart=_cartsrv.GetCart(id);
            bool status = _cartsrv.AddItem(theCart,item);
            return status;
        }

        [HttpPut]
        [Route("update/{id}")]
        public bool UpdateCart(int id,Item item)
        {
            Cart theCart=_cartsrv.GetCart(id);
            bool status = _cartsrv.UpdateItem(theCart,item);
            return status;
        }

        [HttpPost]
        [Route("delete/{id}")]
        public bool RemoveFromCart(int id,Item item)
        {
            Cart theCart=_cartsrv.GetCart(id);
            bool status = _cartsrv.RemoveItem(theCart,item);
            return status;
        }

          [HttpPost]
        [Route("createorder/{id}")]
        public  bool CreateOrder(int id){
            bool status=_cartsrv.CreateOrder(id);
            return status;
        }

    }
}

   





