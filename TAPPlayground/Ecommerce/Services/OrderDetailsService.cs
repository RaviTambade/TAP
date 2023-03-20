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

<<<<<<< HEAD
    public List<OrderDetails> GetAll()
=======
<<<<<<< HEAD
    public List<OrderDetails> GetAllOrderDetails() => _repo.GetAllOrderDetails();

    public List<OrderDetails> GetOrderDetails(int orderId) => _repo.GetOrderDetails(orderId);
    public OrderDetails GetOrderDetailById(int id) => _repo.GetOrderDetailById(id);

    public List<OrderDetailsOrder> GetProductsOfOrder(int orderId) => _repo.GetProductsOfOrder(orderId);

    public bool InsertOrderdetails(OrderDetails orderDetail) => _repo.InsertOrderdetails(orderDetail);

    public bool UpdateOrderDetails(OrderDetails orderDetails) => _repo.UpdateOrderDetails(orderDetails);

    public bool DeleteOrdeDetails(int id) => _repo.DeleteOrdeDetails(id);

    // old methods

   // public List<Product> GetOrderdProducts(int orderId)=> _repo.GetOrderdProducts(orderId);

    public List<OrderHistory> OrderHistory(int customerId) => _repo.OrderHistory(customerId);



    public bool InsertOrderdetails(int orderId, int productId, int quantity)
=======
    public List<OrderDetails> AllOrderDetails()
>>>>>>> 40da76ae528d7e7ac4830e7816c257a56cf17f75
>>>>>>> 13f14108d8bf7351271f63c372606eaa47654f64
    {
        return _repo.GetAll();
    }

    public bool DeleteByOrderDetailsId(int orderDetailsId)
    {
        return _repo.DeleteByOrderDetailsId(orderDetailsId);
    }

    public bool DeleteByOrderId(int orderId)
    {
        return _repo.DeleteByOrderId(orderId);
    }


    public OrderDetails GetById(int orderDetailsId)
    {
        return _repo.GetById(orderDetailsId);
    }

    public List<OrderDetailsOrder> GetOrderDetailsByOrder(int orderId)
    {
        return _repo.GetOrderDetailsByOrder(orderId);
    }

    public bool Insert(OrderDetails orderDetails)
    {
        return _repo.Insert(orderDetails);
    }

    public List<OrderHistory> GetOrderHistory(int customerId)
    {
        return _repo.GetOrderHistory(customerId);
    }

    public bool Update(OrderDetails orderDetails)
    {
        return _repo.Update(orderDetails);
    }
}
