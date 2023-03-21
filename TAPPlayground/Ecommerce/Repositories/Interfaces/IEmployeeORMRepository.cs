using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;

public interface IEmployeeORMRepository{
 
    List<Employee> GetAll();
   
}