using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface IOrderDetailsRepository
{
    List<OrderDetails> GetAllOrderDetails();
    OrderDetails GetOrderDetailById(int id);
    List<OrderDetails>  GetOrderDetails(int orderId);
    List<OrderDetailsOrder> GetProductsOfOrder(int orderId );


    bool InsertOrderdetails(OrderDetails orderDetails);    

    //this method dosent have to do anything with insert
    bool InsertOrderdetails(int orderId,int productId,int quantity);    

    bool UpdateOrderDetails(OrderDetails orderDetails);

    bool DeleteOrdeDetails(int id);

    List<Product> GetOrderdProducts(int orderId);
    List<OrderHistory> OrderHistory(int customerId);
}