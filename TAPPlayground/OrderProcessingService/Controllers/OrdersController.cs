using OrderProcessingService.Models;
using OrderProcessingService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Caching.Memory;

namespace OrderProcessingService.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrderService _ordersvc;
        public OrdersController(IMemoryCache memoryCache,ILogger<OrdersController> logger,IOrderService ordersvc)
        {
        _memoryCache=memoryCache;
        _logger = logger;
        _ordersvc = ordersvc;
        } 

        [HttpGet]
        [Route("/getallorders")]
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            var cacheKey ="orderList";
            if(!_memoryCache.TryGetValue(cacheKey, out IEnumerable<Order> orderList))
            {

            orderList = await _ordersvc.GetAll();
            _logger.LogInformation("Get All method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(20)
            };
            _memoryCache.Set(cacheKey,orderList,cacheExpiryOptions);
            }
            return orderList;
        }

        [HttpGet]
        [Route("/getorder/{id}")]
        public async Task<Order> GetById(int id)
        {
            Order order = await _ordersvc.GetById(id);
            _logger.LogInformation("Get by id method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return order;
        }

        [HttpPost]
        [Route("/addorder")]
        public async Task<bool> Insert([FromBody] Order order)
        {
            bool status = await _ordersvc.Insert(order);
            _logger.LogInformation("insert method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }

        [HttpPut]
        [Route("/update/{id}")]
        public async Task<bool> Update(int id,[FromBody] Order order)
        {
            Order oldOrder = await _ordersvc.GetById(id);
            if(oldOrder.OrderId==0)
            {
                return false;
            }
            order.OrderId =id;
            bool status = await _ordersvc.Update(order);
            _logger.LogInformation("update method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        public async Task<bool> Delete(int id)
        {
            bool status =await _ordersvc.Delete(id);
            _logger.LogInformation("delete method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }
    }
}