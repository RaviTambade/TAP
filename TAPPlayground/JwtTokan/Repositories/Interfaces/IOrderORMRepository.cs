using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;
public interface IOrderORMRepository{
 
    List<Order> GetAll();
   
}