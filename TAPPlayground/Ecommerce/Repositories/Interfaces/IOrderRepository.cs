using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface IOrderRepository
{
    List<Order> GetAllOrders();
   
    Order GetOrderById(int id);

    int GetOrderId(int customerId);
    bool InsertOrder(int customerId);
}