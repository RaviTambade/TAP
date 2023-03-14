using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class OrderDetailsService:IOrderDetailsService{
    private readonly IOrderDetailsRepository _repo;
    public OrderDetailsService(IOrderDetailsRepository repo){
        this._repo=repo;
    }

    public List<OrderDetails> GetAllOrderDetails() => _repo.GetAllOrderDetails();

    public List<OrderDetails> GetOrderDetails(int orderId) => _repo.GetOrderDetails(orderId);
    public OrderDetails GetOrderDetailById(int id) => _repo.GetOrderDetailById(id);

    public List<OrderDetailsOrder> GetProductsOfOrder(int orderId) => _repo.GetProductsOfOrder(orderId);

    public bool InsertOrderdetails(OrderDetails orderDetail) => _repo.InsertOrderdetails(orderDetail);

    public bool UpdateOrderDetails(OrderDetails orderDetails) => _repo.UpdateOrderDetails(orderDetails);

    public bool DeleteOrdeDetails(int id) => _repo.DeleteOrdeDetails(id);

    // old methods

    public List<Product> GetOrderdProducts(int orderId)=> _repo.GetOrderdProducts(orderId);

    public List<OrderHistory> OrderHistory(int customerId) => _repo.OrderHistory(customerId);



    public bool InsertOrderdetails(int orderId, int productId, int quantity)
    {
        throw new NotImplementedException();
    }
}
