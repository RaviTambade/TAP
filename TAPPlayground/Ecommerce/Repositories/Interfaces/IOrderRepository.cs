using System.Collections.Generic;
using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface IOrderRepository
{
    List<Order> GetAllOrders();

    List<Order> GetAllCancelledOrders();
    List<Order> GetAllDeliveredOrders();
   
    Order GetOrderById(int id);

    int GetOrderId(int id);
    bool InsertOrder(int id);

    Order GetOrderByCustId(int id);

    bool InsertOrders(Order order);

    bool UpdateOrder(Order order);

    bool DeleteOrder(int id);
}