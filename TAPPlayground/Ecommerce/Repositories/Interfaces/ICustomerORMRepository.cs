using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;
public interface ICustomerORMRepository{
 
    List<Customer> GetAll();
   
}