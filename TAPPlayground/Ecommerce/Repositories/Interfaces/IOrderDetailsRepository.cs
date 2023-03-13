using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface IOrderDetailsRepository
{
    List<OrderDetails> GetAllOrderDetails();

    OrderDetails GetOrderDetailById(int id);

    bool InsertOrderdetails(int orderId, int productId, int quantity);
    List<Product> GetOrderdProducts(int orderId);
    List<OrderHistory> OrderHistory(int customerId);
}