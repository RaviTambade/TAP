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
    public class CartController : ControllerBase
    {
        private readonly RedisCartController _redisCartController;
        private readonly ICartService _cartSrv;
        private readonly IDistributedCache _distributedCache;
        private readonly ILogger<CartController> _logger;
        public CartController(ILogger<CartController> logger, IDistributedCache distributedCache, ICartService cartService, RedisCartController redisCartController)
        {
            _redisCartController = redisCartController;
            _cartSrv = cartService;
            _logger = logger;
            _distributedCache = distributedCache;
        }


        [HttpGet]
        [Route("getallcartitems")]
        public async Task<List<Cart>> GetAllCarts()
        {
            List<Cart> carts = await _redisCartController.GetAllCarts();
            if (carts == null)
            {
                carts = await _cartSrv.GetAllCarts();
                // await _redisCartController.SetAllCarts(carts);
            }
            return carts;
        }


        [HttpGet]
        [Route("getcartdetails/{id}")]
        public async Task<Cart> GetCart(int id)
        {
            Cart cart = await _redisCartController.GetCart(id);
            if (cart != null)
            {
                _logger.LogInformation($" data fetch from cache");
            }
            if (cart == null)
            {
                cart = await _cartSrv.GetCart(id);
                _logger.LogInformation($"data fetching  from database");
            }
            return cart;
        }

        [HttpPost]
        [Route("addtocart/{id}")]
        public async Task<bool> AddToCart(int id, Item item)
        {
            string cacheKey = $"Cart{id}";
            Cart cart = await _distributedCache.GetDataAsync<Cart>(cacheKey);
            if (cart == null)
            {
                cart = await _cartSrv.GetCart(id);
                await _distributedCache.SetDataAsync(cacheKey, cart, TimeSpan.FromMinutes(1), TimeSpan.FromHours(1));
                cart.Items.Add(item);
                _logger.LogInformation($" item is added to cart " + id + " First it is fetched from database");

            }
            else
            {
                cart.Items.Add(item);
                _logger.LogInformation($" item is added to cart " + id);
            }


            bool status = await _cartSrv.AddItem(cart.CartId, item);
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
            /*
             1.Get cart from cache
             2.If Cache does not contain cart retrive cart data from  Data service.
             3.if Cache consist of cart then  update existing item with new quantity
            */


            string cacheKey = $"Cart{id}";
            Cart cart = await _distributedCache.GetDataAsync<Cart>(cacheKey);
            if (cart == null)
            {
                cart = await _cartSrv.GetCart(id);
                await _distributedCache.SetDataAsync(cacheKey, cart, TimeSpan.FromMinutes(1), TimeSpan.FromHours(1));
                //update data into cached cart
                cart.Items = cart.Items.Where(x => x.ProductId != item.ProductId).ToList();
                cart.Items.Add(item);

            }
            else
            {
                //Get all items excluding item whose ProductId matches with item  ID
                cart.Items = cart.Items.Where(x => x.ProductId != item.ProductId).ToList();
                cart.Items.Add(item);

            }

            bool status = await _cartSrv.UpdateItem(cart.CartId, item);
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



        [HttpGet]
        [Route("emptycart/{id}")]
        public async Task<bool> EmptyCart(int id)
        {
            /*
              1.Get cart from cache
              2.If Cache does not contain cart retrive cart data from  Data service.
              3.Remove all items from cart
              4.Update items into database
             */

            bool status = false;
            string cacheKey = $"Cart{id}";
            Cart cart = await _distributedCache.GetDataAsync<Cart>(cacheKey);
            if (cart == null)
            {
                cart = await _cartSrv.GetCart(id);
                _logger.LogInformation($"data fetching  from database");
                await _distributedCache.SetDataAsync(cacheKey, cart, TimeSpan.FromMinutes(1), TimeSpan.FromHours(1));
            }
            _logger.LogInformation($" data fetch from cache");
            cart.Items.Clear();
            //Invoice dataservice method to clear all items from shopping cart whose id is macthing
            status = true;
            return status;
        }


        [HttpPost]
        [Route("createorder/{id}")]
        public async Task<bool> CreateOrder(int id)
        {
            //Get Shopping Cart from Cache or from database
            //Get all Items details from Shopping Cart
            //Create New Order object
            //Add all items received from shopping cart to new Order
            //Store order and order details to table using service
            //clear shopping cart Items
            //Clear Cache for shopping cart which has been maintained

            bool status = false;
            string cacheKey = $"Cart{id}";
            Cart cart = await _distributedCache.GetDataAsync<Cart>(cacheKey);
            if (cart == null)
            {
                cart = await _cartSrv.GetCart(id);
                _logger.LogInformation($"data fetching  from database");
                await _distributedCache.SetDataAsync(cacheKey, cart, TimeSpan.FromMinutes(1), TimeSpan.FromHours(1));
            }
            _logger.LogInformation($" data fetch from cache");
            cart.Items.Clear();

            //Invoice dataservice method to clear all items from shopping cart whose id is macthing
            status = await _cartSrv.CreateOrder(id);
            if (status)
            {
                status = await _cartSrv.CreateOrder(cart.CartId);
                if (status)
                {
                    await _distributedCache.RemoveAsync(cacheKey);
                    _logger.LogInformation($"Shpping cart is removed due to order creattion");
                }
            }
            return status;
        }
    }
}