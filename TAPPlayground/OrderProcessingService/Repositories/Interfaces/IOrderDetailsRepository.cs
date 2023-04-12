using System.Collections;
using System.Net.Http.Headers;
using OrderProcessingService.Models;
namespace OrderProcessingService.Repositories.Interfaces;
public interface IOrderDetailsRepository
{
    Task<IEnumerable<OrderDetails>> GetAll();
    Task<OrderDetails> GetById(int orderDetailsId);
    Task<IEnumerable<OrderDetailsOrder>> GetOrderDetailsByOrder(int orderId );
    Task<bool> Insert(OrderDetails orderDetails);     
    Task<bool> DeleteByOrderDetailsId(int orderDetailsId);
    
    Task<IEnumerable<OrderHistory>> GetOrderHistory(int customerId);   
    Task<bool> Update(OrderDetails orderDetails);  
}