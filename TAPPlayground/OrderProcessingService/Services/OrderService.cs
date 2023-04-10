using System.Collections.Generic;
using OrderProcessingService.Models;
using OrderProcessingService.Repositories.Interfaces;
using OrderProcessingService.Services.Interfaces;

namespace OrderProcessingService.Services;
public class OrderService : IOrderService{
    private readonly IOrderRepository _repo;
    public OrderService(IOrderRepository repo){
        this._repo=repo;
    }

    public List<Order> GetAll() => _repo.GetAll();

    public List<Order> GetAllCancelled() => _repo.GetAllCancelled();
    public List<Order> GetAllDelivered() => _repo.GetAllDelivered();

    public Order GetById(int id) => _repo.GetById(id);

    public Order GetOrderByCustId(int id) => _repo.GetOrderByCustId(id);
    public int GetOrderId(int id) => _repo.GetOrderId(id);

    public bool InsertOrder(int id)=>_repo.InsertOrder(id);

    public bool Insert(Order order)=>_repo.Insert(order);

    public bool Update(Order order)=>_repo.Update(order);

    public bool Delete(int id)=>_repo.Delete(id);
}