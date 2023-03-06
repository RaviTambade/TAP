using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class OrderService:IOrderService{
    private readonly IOrderRepository _repo;
    public OrderService(IOrderRepository repo){
        this._repo=repo;
    }

    public bool InsertOrder(Order order)=>_repo.InsertOrder(order);
}