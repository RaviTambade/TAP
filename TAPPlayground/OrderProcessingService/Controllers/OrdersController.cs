using OrderProcessingService.Models;
using OrderProcessingService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace OrderProcessingService.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _ordersvc;
        public OrdersController(IOrderService ordersvc)
        {
        _ordersvc = ordersvc;
        } 

        [HttpGet]
        [Route("/getallorders")]
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            IEnumerable<Order> orders = await _ordersvc.GetAll();
            return orders;
        }

        [HttpGet]
        [Route("/getorder/{id}")]
        public async Task<Order> GetById(int id)
        {
            Order order = await _ordersvc.GetById(id);
            return order;
        }

        [HttpPost]
        [Route("/addorder")]
        public async Task<bool> Insert([FromBody] Order order)
        {
            bool status = await _ordersvc.Insert(order);
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
            return status;
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        public async Task<bool> Delete(int id)
        {
            bool status =await _ordersvc.Delete(id);
            return status;
        }
    }
}