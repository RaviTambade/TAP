using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class OrderORMService : IOrderORMService{
    private readonly IOrderORMRepository _repo;
    public OrderORMService(IOrderORMRepository repo){
        this._repo=repo;
    }
    public List<Order> GetAll() => _repo.GetAll();
}