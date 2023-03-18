using System.Collections.Generic;
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

    public List<Order> GetAllCancelledOrders() => _repo.GetAllCancelledOrders();
    public List<Order> GetAllDeliveredOrders() => _repo.GetAllDeliveredOrders();

    public Order GetOrderById(int id) => _repo.GetOrderById(id);

    public Order GetOrderByCustId(int id) => _repo.GetOrderByCustId(id);
    public int GetOrderId(int customerId) => _repo.GetOrderId(customerId);

    public bool InsertOrder(int customerId)=>_repo.InsertOrder(customerId);

    public bool InsertOrders(Order order)=>_repo.InsertOrders(order);

    public bool UpdateOrder(Order order)=>_repo.UpdateOrder(order);

    public bool DeleteOrder(int id)=>_repo.DeleteOrder(id);
}