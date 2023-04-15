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
                carts= await _cartSrv.GetAllCarts();
                await _distributedCache.SetDataAsync(cacheKey, carts, TimeSpan.FromMinutes(10), TimeSpan.FromHours(1));
            }
            return carts;
        }
        // [Route("setallcartitems")]
        // public async Task  SetAllCarts( List<Cart> carts){
        //      string cacheKey = "AllCarts";
        //     await _distributedCache.SetDataAsync(cacheKey, carts, TimeSpan.FromMinutes(10), TimeSpan.FromHours(1));
        // }

        [HttpGet]
        [Route("getcartdetails/{id}")]
        public async Task<Cart> GetCart(int id)
        { 
            string cacheKey = "AllCarts";
            List<Cart> carts = await _distributedCache.GetDataAsync<List<Cart>>(cacheKey);
            Cart  cart  =  carts.Where(x => x.CartId == id).FirstOrDefault();
            return cart;
        }

        [HttpPost]
        [Route("addtocart/{id}")]
        public async Task<bool> AddToCart(int id, Item item)
        {  
            string cacheKey = "AllCarts";
            List<Cart> carts = await _distributedCache.GetDataAsync<List<Cart>>(cacheKey);
            Cart  cart  =  carts.Where(x => x.CartId == id).FirstOrDefault();
            cart.Items.Add(item);
            List<Cart> remainingCarts=carts.Where(x => x.CartId != id).ToList();
            remainingCarts.Add(cart);
            await _distributedCache.SetDataAsync(cacheKey, carts, TimeSpan.FromMinutes(10), TimeSpan.FromHours(1));   
            Boolean status=true;  
            return status;
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<bool> UpdateCart(int id, Item item)
        {
            string cacheKey = "AllCarts";
            List<Cart> carts = await _distributedCache.GetDataAsync<List<Cart>>(cacheKey);
            Cart  cart  =  carts.Where(x => x.CartId == id).FirstOrDefault();
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
            Cart foundCart=carts.Where(x => x.CartId == id).FirstOrDefault();
            List<Item> remainingItems=foundCart.Items.Where(x => x.ProductId != item.ProductId).ToList();
            foundCart.Items=remainingItems ;
            List<Cart> remainingCarts = carts.Where(x => x.CartId != id).ToList();
            remainingCarts.Add(foundCart);
            await _distributedCache.SetDataAsync(cacheKey, remainingCarts, TimeSpan.FromMinutes(1), TimeSpan.FromHours(1));   
            Boolean status=true;  
            return status;
        }

        [HttpDelete]
        [Route("emptycart/{id}")]
        public async Task<bool> EmptyCart(int id)
        {
            string cacheKey = "AllCarts";
            List<Cart> carts = await _distributedCache.GetDataAsync<List<Cart>>(cacheKey);   
            Cart foundCart=carts.Where(x => x.CartId == id).FirstOrDefault();
            foundCart.Items.Clear(); 
            List<Cart> remainingCarts = carts.Where(x => x.CartId != id).ToList();
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
            Cart foundCart=carts.Where(x => x.CartId == id).FirstOrDefault();
            bool  status = await _cartSrv.CreateOrder(foundCart.CartId);
            foundCart.Items.Clear(); 
            List<Cart> remainingCarts = carts.Where(x => x.CartId != id).ToList();
            remainingCarts.Add(foundCart);
            await _distributedCache.SetDataAsync(cacheKey, remainingCarts, TimeSpan.FromMinutes(1), TimeSpan.FromHours(1));   
            return status;
        }
    }
}