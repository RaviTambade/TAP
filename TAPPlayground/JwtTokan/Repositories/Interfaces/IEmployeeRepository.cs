
using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;

public interface IEmployeeRepository
{
    List<Employee> GetAll();
    Employee GetById(int empId);
    bool Insert(Employee emp);
    bool Update(Employee emp);
    bool Delete(int empId);
    
}