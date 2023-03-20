using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface IOrderDetailsRepository
{
    List<OrderDetails> AllOrderDetails();
    OrderDetails GetById(int id);
    
    List<OrderDetailsOrder> GetProductsOfOrder(int orderId );

    bool Insert(OrderDetails orderDetails);     

    bool Update(OrderDetails orderDetails);

<<<<<<< HEAD
    //this method dosent have to do anything with insert
    bool InsertOrderdetails(int orderId,int productId,int quantity);    

    bool UpdateOrderDetails(OrderDetails orderDetails);

    bool DeleteOrdeDetails(int id);

   // List<Product> GetOrderdProducts(int orderId);
=======
    bool Delete(int id);
    
>>>>>>> 40da76ae528d7e7ac4830e7816c257a56cf17f75
    List<OrderHistory> OrderHistory(int customerId);
}