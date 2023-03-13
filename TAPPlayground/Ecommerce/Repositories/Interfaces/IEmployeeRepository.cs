
using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;

public interface IEmployeeRepository{

 
    List<Employees> GetAllEmployees();
    Employees GetEmployeeById(int id);
    

    
}