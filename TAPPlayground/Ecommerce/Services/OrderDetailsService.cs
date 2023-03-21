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

    public bool DeleteByOrderDetailsId(int orderDetailsId)
    {
        return _repo.DeleteByOrderDetailsId(orderDetailsId);
    }

    public List<OrderDetails> GetAll()
    {
        return _repo.GetAll();
    }

    public OrderDetails GetById(int orderDetailsId)
    {
        return _repo.GetById(orderDetailsId);
    }

    public List<OrderDetailsOrder> GetOrderDetailsByOrder(int orderId)
    {
        return _repo.GetOrderDetailsByOrder(orderId);
    }

    public List<OrderHistory> GetOrderHistory(int customerId)
    {
        return _repo.GetOrderHistory(customerId);
    }

    public bool Insert(OrderDetails orderDetails)
    {
        return _repo.Insert(orderDetails);
    }

    public bool Update(OrderDetails orderDetails)
    {
      return _repo.Update(orderDetails);
    }
}
