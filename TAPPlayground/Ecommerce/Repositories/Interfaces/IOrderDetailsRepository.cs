using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface IOrderDetailsRepository
{
    List<OrderDetails> GetAllOrderDetails();

    List<OrderDetails>  GetOrderDetails(int orderId);
    OrderDetails GetOrderDetailById(int id);

    List<OrderDetailsOrder> GetProductsOfOrder(int orderId );

    bool InsertOrderdetails(int orderId, int productId, int quantity);
    List<Product> GetOrderdProducts(int orderId);
    List<OrderHistory> OrderHistory(int customerId);
}