using System.Collections.Generic;
using OrderProcessingService.Models;
using OrderProcessingService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace OrderProcessingService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _srv;
        public OrderDetailsController(IOrderDetailsService srv)
        {
            _srv=srv;
        }

        [HttpGet]
        [Route("/getallorderdetails")]
        public async Task<IEnumerable<OrderDetails>> GetAll()
        {
            IEnumerable<OrderDetails> orderDetails = await _srv.GetAll();
            return orderDetails;
        }

        [HttpGet]
        [Route("/getorderdetails/{id}")]
        public async Task<OrderDetails> GetById(int id)
        {
            OrderDetails orderDetail = await _srv.GetById(id);
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
            return status;
        }
 
        [HttpPost]
        [Route("/addorderdetails")]
        public async Task<bool> Insert([FromBody] OrderDetails orderDetail)
        {
            bool status =await _srv.Insert(orderDetail);
            return status;
        }
   
        [HttpDelete]
        [Route("/deleteorderdetails/{id}")]
        public async Task<bool> Delete(int id)
        {
            bool status = await  _srv.DeleteByOrderDetailsId(id);
            return status;
        }
    }
}