using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ECommerceApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailssController : ControllerBase

    {
        private readonly IOrderDetailsService _srv;
        public OrderDetailssController(IOrderDetailsService srv)
        {
            _srv=srv;
        }

        [HttpGet]
        [Route("/api/orderdetails/getall")]
        public IEnumerable<OrderDetails> GetAll()
        {
            List<OrderDetails> orderDetails = _srv.GetAll();
            return orderDetails;
        }

        [HttpGet]
        [Route("/api/orderdetails/getorderdetails/{id}")]
        public OrderDetails GetById(int id)
        {
            OrderDetails orderDetail = _srv.GetById(id);
            return orderDetail;
        }

        [Authorize(Roles = Role.Customer)]
        [HttpPut]
        [Route("/api/orderdetails/update/{id}")]
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

        [Authorize(Roles = Role.Customer)]
        [HttpPost]
        [Route("/api/orderdetails/addorderdetails/")]
        public bool Insert([FromBody] OrderDetails orderDetail)
        {
            bool status = _srv.Insert(orderDetail);
            return status;
        }

        [Authorize(Roles = Role.Customer)]
        [HttpDelete]
        [Route("/api/orderdetails/delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _srv.DeleteByOrderDetailsId(id);
            return status;
        }
    }
}







