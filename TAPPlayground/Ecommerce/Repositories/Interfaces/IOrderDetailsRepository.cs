using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface IOrderDetailsRepository
{
 bool InsertOrderdetails(int orderId,int productId,int quantity);
  List<Product> GetOrderdProducts(int orderId);
  List<OrderHistory> OrderHistory(int customerId);
 }