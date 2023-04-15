using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using ShoppingCartService.Models;
using ShoppingCartService.Extensions;
using ShoppingCartService.Services.Interfaces;

namespace ShoppingCartService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class RedisCartController : ControllerBase
    {
        private readonly ICartService _cartSrv;
        private readonly IDistributedCache _distributedCache;
        private readonly ILogger<CartController> _logger;
        public RedisCartController(ICartService svc,ILogger<CartController> logger, IDistributedCache distributedCache)
        {
            _cartSrv = svc;
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
               
                _logger.LogInformation($"data fetching  from database");
                await _distributedCache.SetDataAsync(cacheKey, carts, TimeSpan.FromMinutes(1), TimeSpan.FromHours(1));

            }
            return carts;
        }


        [HttpGet]
        [Route("getcartdetails/{id}")]
        public async Task<Cart> GetCart(int id)
        { 
            string cacheKey = "AllCarts";
            List<Cart> carts = await _distributedCache.GetDataAsync<List<Cart>>(cacheKey);
            Cart  cart  = (Cart) carts.Where(x => x.CartId == id);
            return cart;
        }

        [HttpPost]
        [Route("addtocart/{id}")]
        public async Task<bool> AddToCart(int id, Item item)
        {  
            string cacheKey = "AllCarts";
            List<Cart> carts = await _distributedCache.GetDataAsync<List<Cart>>(cacheKey);
            Cart  cart  = (Cart) carts.Where(x => x.CartId == id);
            cart.Items.Add(item);
            List<Cart> remainingCarts=carts.Where(x => x.CartId != id).ToList();
            remainingCarts.Add(cart);
            await _distributedCache.SetDataAsync(cacheKey, carts, TimeSpan.FromMinutes(1), TimeSpan.FromHours(1));   
            Boolean status=true;  
            return status;
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<bool> UpdateCart(int id, Item item)
        {
            string cacheKey = "AllCarts";
            List<Cart> carts = await _distributedCache.GetDataAsync<List<Cart>>(cacheKey);
            Cart  cart  = (Cart) carts.Where(x => x.CartId == id);
            cart.Items = cart.Items.Where(x => x.ProductId != item.ProductId).ToList();
            cart.Items.Add(item);
            List<Cart> remainingCarts=carts.Where(x => x.CartId != id).ToList();
            remainingCarts.Add(cart);
            await _distributedCache.SetDataAsync(cacheKey, carts, TimeSpan.FromMinutes(1), TimeSpan.FromHours(1));   
            Boolean status=true;  
            return status;
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<bool> RemoveFromCart(int id, Item item)
        {
            string cacheKey = "AllCarts";
            List<Cart> carts = await _distributedCache.GetDataAsync<List<Cart>>(cacheKey);   
            Cart foundCart=(Cart )carts.Where(x => x.CartId == id);
            List<Item> remainingItems=foundCart.Items.Where(x => x.ProductId != item.ProductId).ToList();
            foundCart.Items=remainingItems as List<Item>;
            List<Cart> remainingCarts =(List<Cart>) carts.Where(x => x.CartId != id);
            remainingCarts.Add(foundCart);
            await _distributedCache.SetDataAsync(cacheKey, remainingCarts, TimeSpan.FromMinutes(1), TimeSpan.FromHours(1));   
            Boolean status=true;  
            return status;
        }



        [HttpGet]
        [Route("emptycart/{id}")]
        public async Task<bool> EmptyCart(int id)
        {
            string cacheKey = "AllCarts";
            List<Cart> carts = await _distributedCache.GetDataAsync<List<Cart>>(cacheKey);   
            Cart foundCart=(Cart )carts.Where(x => x.CartId == id);
            foundCart.Items.Clear(); 
            List<Cart> remainingCarts =(List<Cart>) carts.Where(x => x.CartId != id);
            remainingCarts.Add(foundCart);
            await _distributedCache.SetDataAsync(cacheKey, remainingCarts, TimeSpan.FromMinutes(1), TimeSpan.FromHours(1));   
            Boolean status=true;  
            return status;
        }


        [HttpPost]
        [Route("createorder/{id}")]
        public async Task<bool> CreateOrder(int id)
        {
            string cacheKey = "AllCarts";
            List<Cart> carts = await _distributedCache.GetDataAsync<List<Cart>>(cacheKey);   
            Cart foundCart=(Cart )carts.Where(x => x.CartId == id);
            bool  status = await _cartSrv.CreateOrder(foundCart.CartId);
            List<Cart> remainingCarts =(List<Cart>) carts.Where(x => x.CartId != id);
            remainingCarts.Add(foundCart);
            await _distributedCache.SetDataAsync(cacheKey, remainingCarts, TimeSpan.FromMinutes(1), TimeSpan.FromHours(1));   
            return status;
        }
    }
}