using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ECommerceApp.Controllers
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
        [Route("getallorderdetails")]
        public IEnumerable<OrderDetails> GetAll()
        {
            List<OrderDetails> orderDetails = _srv.GetAll();
            return orderDetails;
        }

        [HttpGet]
        [Route("getorderdetails/{id}")]
        public OrderDetails GetById(int id)
        {
            OrderDetails orderDetail = _srv.GetById(id);
            return orderDetail;
        }

        [Authorize(Roles = Role.Customer)]
        [HttpPut]
        [Route("update/{id}")]
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
        [Route("addorderdetails")]
        public bool Insert([FromBody] OrderDetails orderDetail)
        {
            bool status = _srv.Insert(orderDetail);
            return status;
        }

        [Authorize(Roles = Role.Customer)]
        [HttpDelete]
        [Route("delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _srv.DeleteByOrderDetailsId(id);
            return status;
        }
    }
}







