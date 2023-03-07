using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface IOrderRepository
{
    int GetOrderId(int customerId);
    bool InsertOrder(int customerId);
}