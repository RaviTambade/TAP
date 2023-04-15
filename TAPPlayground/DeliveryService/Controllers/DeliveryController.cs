using DeliveryService.Helpers;
using DeliveryService.Models;
using DeliveryService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
namespace DeliveryService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DeliveryController : ControllerBase
    {  
         private readonly IMemoryCache _memoryCache;
        private readonly ILogger<DeliveryController> _logger;
        private readonly IDeliveryService _deliverysrv;
        public DeliveryController(IDeliveryService deliverysrv,ILogger<DeliveryController> logger,IMemoryCache memoryCache)
        {
            _deliverysrv = deliverysrv;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        [Authorize(Roles=Role.Admin)]
        [Route("getalldeliveries")]
        public async Task <IEnumerable<Delivery>> GetAllShippers()
        {
            
            var cacheKey="deliveryList";    //checks if cache entries exists
            if(!_memoryCache.TryGetValue(cacheKey, out IEnumerable<Delivery> deliveryList))
            {
              deliveryList = await _deliverysrv.GetAll();
             _logger.LogInformation("Get All method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            //setting up cache options
             var cacheExpiryOptions = new MemoryCacheEntryOptions
             {
                AbsoluteExpiration = DateTime.Now.AddSeconds(10000),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(5000)
             };
             //setting cache entries
             _memoryCache.Set(cacheKey, deliveryList, cacheExpiryOptions);
            }
            return deliveryList;
             
        }

        [HttpGet]
        [Route("getdeliverydetails/{id}")]
        public async Task <Delivery> GetById(int id)
        {
            Delivery delivery = await _deliverysrv.GetById(id);
             _logger.LogInformation("GetByIdmethod invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return delivery;
        }

     //   [Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("updateDelivery/{id}")]
        public async Task< bool> Update( int id,[FromBody] Delivery delivery)
        {
            Delivery oldDilivery = await _deliverysrv.GetById(id);
            _logger.LogInformation("Update method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            if(oldDilivery.ShipperId==0){
                return false;
            }
            delivery.ShipperId=id;
            bool status = await _deliverysrv.Update(delivery);
            return status;
        }

       // [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("addDelivery/")]
        public async Task <bool> Insert([FromBody] Delivery delivery)
        {
            bool status = await _deliverysrv.Insert(delivery);
            _logger.LogInformation("insert method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }

      //  [Authorize(Roles = Role.Admin)]
        [HttpDelete]
        [Route("deleteDelivery/{id}")]
        public async Task <bool> Delete(int id)
        {
            bool status = await _deliverysrv.Delete(id);
            _logger.LogInformation("delete method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }
    }
}