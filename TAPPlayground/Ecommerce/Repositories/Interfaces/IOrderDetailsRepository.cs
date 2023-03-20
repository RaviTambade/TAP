using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface IOrderDetailsRepository
{
    List<OrderDetails> GetAll();
    OrderDetails GetById(int orderDetailsId);
    
    List<OrderDetailsOrder> GetOrderDetailsByOrder(int orderId );

    bool Insert(OrderDetails orderDetails);     

    bool Update(OrderDetails orderDetails);

    bool DeleteByOrderDetailsId(int orderDetailsId);
    bool DeleteByOrderId(int orderId);
    List<OrderHistory> GetOrderHistory(int customerId);
}