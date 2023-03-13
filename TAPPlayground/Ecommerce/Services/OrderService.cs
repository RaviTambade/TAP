using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class OrderService : IOrderService{
    private readonly IOrderRepository _repo;
    public OrderService(IOrderRepository repo){
        this._repo=repo;
    }

    public List<Order> GetAllOrders() => _repo.GetAllOrders();
    public Order GetOrderById(int id) => _repo.GetOrderById(id);

    public int GetOrderId(int customerId) => _repo.GetOrderId(customerId);

    public bool InsertOrder(int customerId)=>_repo.InsertOrder(customerId);
}