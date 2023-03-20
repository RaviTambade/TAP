using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface IOrderDetailsRepository
{
    List<OrderDetails> AllOrderDetails();
    OrderDetails GetById(int id);
    
    List<OrderDetailsOrder> GetProductsOfOrder(int orderId );

    bool Insert(OrderDetails orderDetails);     

    bool Update(OrderDetails orderDetails);

    bool Delete(int id);
    
    List<OrderHistory> OrderHistory(int customerId);
}