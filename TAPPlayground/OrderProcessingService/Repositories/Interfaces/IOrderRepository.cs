using System.Collections.Generic;
using OrderProcessingService.Models;
namespace OrderProcessingService.Repositories.Interfaces;
public interface IOrderRepository
{
    List<Order> GetAll();
    List<Order> GetAllCancelled();
    List<Order> GetAllDelivered();
    Order GetById(int id);
    int GetOrderId(int id);
    bool InsertOrder(int id);
    Order GetOrderByCustId(int id);
    bool Insert(Order order);
    bool Update(Order order);
    bool Delete(int id);
}