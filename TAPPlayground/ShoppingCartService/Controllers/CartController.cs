using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using ShoppingCartService.Models;
using ShoppingCartService.Services.Interfaces;

namespace ShoppingCartService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartSrv;
        private readonly IDistributedCache _distributedCache;
        private readonly ILogger<CartController> _logger;
        public CartController(ICartService cartService, ILogger<CartController> logger, IDistributedCache distributedCache)
        {
            _cartSrv = cartService;
            _logger = logger;
            _distributedCache = distributedCache;
        }

      
        [HttpGet]
        [Route("getallcartitems")]
        public async Task<List<Cart>> GetAllCarts()
        {
            string cacheKey = "AllCarts";
            List<Cart> carts = await _distributedCache.GetDataAsync<List<Cart>>(cacheKey);
            if (carts != null)
            {
                _logger.LogInformation($" data fetch from cache");
            }

            if (carts == null)
            {
                carts = await _cartSrv.GetAllCarts();
                _logger.LogInformation($"data fetching  from database");
                await _distributedCache.SetDataAsync(cacheKey, carts, TimeSpan.FromMinutes(1), TimeSpan.FromHours(1));

            }
            return carts;
        }


        [HttpGet]
        [Route("getcartdetails/{id}")]
        public async Task<Cart> GetCart(int id)
        {
            string cacheKey = $"Cart{id}";
            Cart cart = await _distributedCache.GetDataAsync<Cart>(cacheKey);
            if (cart != null)
            {
                _logger.LogInformation($" data fetch from cache");
            }
            if (cart == null)
            {
                cart = await _cartSrv.GetCart(id);
                _logger.LogInformation($"data fetching  from database");
                await _distributedCache.SetDataAsync(cacheKey, cart, TimeSpan.FromMinutes(1), TimeSpan.FromHours(1));
            }
            return cart;
        }

        [HttpPost]
        [Route("addtocart/{id}")]
        public async Task<bool> AddToCart(int id, Item item)
        {
            string cacheKey = $"Cart{id}";
            Cart theCart = await _cartSrv.GetCart(id);
            if (theCart.CartId == 0)
            {
                return false;
            }
            bool status = await _cartSrv.AddItem(theCart.CartId, item);
            if (status)
            {
                await _distributedCache.RemoveAsync(cacheKey);
            }
            return status;
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<bool> UpdateCart(int id, Item item)
        {
            string cacheKey = $"Cart{id}";
            Cart theCart = await _cartSrv.GetCart(id);
            if (theCart.CartId == 0)
            {
                return false;
            }
            bool status = await _cartSrv.UpdateItem(theCart.CartId, item);
            if (status)
            {
                await _distributedCache.RemoveAsync(cacheKey);
            }
            return status;
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<bool> RemoveFromCart(int id, Item item)
        {
            string cacheKey = $"Cart{id}";
            Cart theCart = await _cartSrv.GetCart(id);
            if (theCart.CartId == 0)
            {
                return false;
            }
            bool status = await _cartSrv.RemoveItem(theCart.CartId, item);
            if (status)
            {
                await _distributedCache.RemoveAsync(cacheKey);
            }
            return status;
        }

        [HttpPost]
        [Route("createorder/{id}")]
        public async Task<bool> CreateOrder(int id)
        {
            bool status = await _cartSrv.CreateOrder(id);
            return status;
        }
    }
}