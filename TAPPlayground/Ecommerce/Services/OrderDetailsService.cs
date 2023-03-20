using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class OrderDetailsService : IOrderDetailsService
{
    private readonly IOrderDetailsRepository _repo;
    public OrderDetailsService(IOrderDetailsRepository repo)
    {
        this._repo = repo;
    }

    public List<OrderDetails> AllOrderDetails()
    {
        return _repo.AllOrderDetails();
    }

    public bool Delete(int id)
    {
        return _repo.Delete(id);

    }

    public OrderDetails GetById(int id)
    {
        return _repo.GetById(id);

    }

    public List<OrderDetailsOrder> GetProductsOfOrder(int orderId)
    {
        return _repo.GetProductsOfOrder(orderId);
    }

    public bool Insert(OrderDetails orderDetails)
    {
        return _repo.Insert(orderDetails);
    }

    public List<OrderHistory> OrderHistory(int customerId)
    {
        return _repo.OrderHistory(customerId);
    }

    public bool Update(OrderDetails orderDetails)
    {
        return _repo.Update(orderDetails);
    }
}
