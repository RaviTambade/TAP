using System.Collections.Generic;
using OrderProcessingService.Models;
using OrderProcessingService.Services;
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
        public IEnumerable<OrderDetails> GetAll()
        {
            List<OrderDetails> orderDetails = _srv.GetAll();
            return orderDetails;
        }

        [HttpGet]
        [Route("/getorderdetails/{id}")]
        public OrderDetails GetById(int id)
        {
            OrderDetails orderDetail = _srv.GetById(id);
            return orderDetail;
        }

        [HttpPut]
        [Route("/updateorderdetails/{id}")]
        public bool Update( int id,[FromBody] OrderDetails orderDetail)
        {
            OrderDetails oldOrderDetail = _srv.GetById(id);
            if(oldOrderDetail.OrderDetailsId==0){
                return false;
            }
            orderDetail.OrderDetailsId=id;
            bool status = _srv.Update(orderDetail);
            return status;
        }

        
        [HttpPost]
        [Route("/addorderdetails")]
        public bool Insert([FromBody] OrderDetails orderDetail)
        {
            bool status = _srv.Insert(orderDetail);
            return status;
        }

        
        [HttpDelete]
        [Route("/deleteorderdetails/{id}")]
        public bool Delete(int id)
        {
            bool status = _srv.DeleteByOrderDetailsId(id);
            return status;
        }
    }
}







