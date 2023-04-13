using System.Collections;
using System.Net.Http.Headers;
using OrderProcessingService.Models;
namespace OrderProcessingService.Repositories.Interfaces;
public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAll();
    Task<IEnumerable<Order>> GetAllCancelled();
    Task<IEnumerable<Order>> GetAllDelivered();
    Task<Order> GetById(int id);
    Task<int> GetOrderId(int id);
    Task<bool> InsertOrder(int id);
    Task<Order> GetOrderByCustId(int id);
    Task<bool> Insert(Order order);
    Task<bool> Update(Order order);
    Task<bool> Delete(int id);
}