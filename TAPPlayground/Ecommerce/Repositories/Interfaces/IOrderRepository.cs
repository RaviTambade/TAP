using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface IOrderRepository
{
    bool InsertOrder(Order order);
}