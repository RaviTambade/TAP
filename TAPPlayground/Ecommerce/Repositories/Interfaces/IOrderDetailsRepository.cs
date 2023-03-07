using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface IOrderDetailsRepository
{
 bool InsertOrderdetails(int orderId,int productId,int quantity);
 }