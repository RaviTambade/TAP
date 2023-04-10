using System.Collections.Generic;
using OrderProcessingService.Models;
using OrderProcessingService.Services;
using OrderProcessingService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
namespace OrderProcessingService.Controllers{
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
        public IEnumerable<Order> GetAllOrders()
        {
            List<Order> orders = _ordersvc.GetAll();
            return orders;
        }

        [HttpGet]
        [Route("/getorder/{id}")]
        public Order GetById(int id)
        {
            Order order = _ordersvc.GetById(id);
            return order;
        }

        [HttpPost]
        [Route("/addorder")]
        public bool Insert([FromBody] Order order)
        {
            bool status = _ordersvc.Insert(order);
            return status;
        }

        [HttpPut]
        [Route("/update/{id}")]
        public bool Update(int id,[FromBody] Order order)
        {
            Order oldOrder = _ordersvc.GetById(id);
            if(oldOrder.OrderId==0)
            {
                return false;
            }
            order.OrderId =id;
            bool status = _ordersvc.Update(order);
            return status;
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _ordersvc.Delete(id);
            return status;
        }
    }
}