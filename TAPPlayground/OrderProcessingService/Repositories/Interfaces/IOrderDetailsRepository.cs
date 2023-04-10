using OrderProcessingService.Models;
namespace OrderProcessingService.Repositories.Interfaces;
public interface IOrderDetailsRepository
{
    List<OrderDetails> GetAll();
    OrderDetails GetById(int orderDetailsId);
    
    List<OrderDetailsOrder> GetOrderDetailsByOrder(int orderId );

    bool Insert(OrderDetails orderDetails);     
    
    bool DeleteByOrderDetailsId(int orderDetailsId);
    
    List<OrderHistory> GetOrderHistory(int customerId);   

    bool Update(OrderDetails orderDetails);

    
}