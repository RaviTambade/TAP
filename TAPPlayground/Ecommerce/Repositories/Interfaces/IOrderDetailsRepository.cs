using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface IOrderDetailsRepository
{
    List<OrderDetails> GetAll();
    OrderDetails GetById(int orderDetailsId);
    
    List<OrderDetailsOrder> GetOrderDetailsByOrder(int orderId );

    bool Insert(OrderDetails orderDetails);     

    bool Update(OrderDetails orderDetails);

<<<<<<< HEAD
    bool DeleteByOrderDetailsId(int orderDetailsId);
    bool DeleteByOrderId(int orderId);
    List<OrderHistory> GetOrderHistory(int customerId);
=======
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
>>>>>>> 13f14108d8bf7351271f63c372606eaa47654f64
}