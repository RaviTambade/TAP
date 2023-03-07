using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class OrderDetailsService:IOrderDetailsService{
    private readonly IOrderDetailsRepository _repo;
    public OrderDetailsService(IOrderDetailsRepository repo){
        this._repo=repo;
    }

    // public bool InsertOrderdetails(orderdetails orderdetails) => _repo.InsertOrderdetails(orderdetails);

    public bool InsertOrderdetails(int orderId, int productId, int quantity) => _repo.InsertOrderdetails(orderId,productId,quantity);
}
