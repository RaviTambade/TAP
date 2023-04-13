using OrderProcessingService.Models;
using OrderProcessingService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingService.Helpers;

namespace OrderProcessingService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly ILogger<OrderDetailsController> _logger;
        private readonly IOrderDetailsService _srv;
        public OrderDetailsController(ILogger<OrderDetailsController> logger,IOrderDetailsService srv)
        {
            _logger=logger;
            _srv=srv;
        }

        [HttpGet]
        [Authorize(Roles=Role.Admin)]
        [Route("/getallorderdetails")]
        public async Task<IEnumerable<OrderDetails>> GetAll()
        {
            IEnumerable<OrderDetails> orderDetails = await _srv.GetAll();
            _logger.LogInformation("Get All method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return orderDetails;
        }

        [HttpGet]
        [Route("/getorderdetails/{id}")]
        public async Task<OrderDetails> GetById(int id)
        {
            OrderDetails orderDetail = await _srv.GetById(id);
            _logger.LogInformation("Get by id method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return orderDetail;
        }

        [HttpPut]
        [Route("/updateorderdetails/{id}")]
        public async Task<bool> Update( int id,[FromBody] OrderDetails orderDetail)
        {
            OrderDetails oldOrderDetail = await _srv.GetById(id);
            if(oldOrderDetail.OrderDetailsId==0){
                return false;
            }
            orderDetail.OrderDetailsId=id;
            bool status = await _srv.Update(orderDetail);
            _logger.LogInformation("update method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }
 
        [HttpPost]
        [Route("/addorderdetails")]
        public async Task<bool> Insert([FromBody] OrderDetails orderDetail)
        {
            bool status =await _srv.Insert(orderDetail);
            _logger.LogInformation("insert method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }
   
        [HttpDelete]
        [Route("/deleteorderdetails/{id}")]
        public async Task<bool> Delete(int id)
        {
            bool status = await  _srv.DeleteByOrderDetailsId(id);
            _logger.LogInformation("delete method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }
    }
}