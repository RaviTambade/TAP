
using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;

public interface IEmployeeRepository
{


    List<Employee> GetAllEmployees();
    Employee GetEmployeeById(int id);
    bool InsertEmp(Employee employee);
    bool UpdateEmp(Employee emp);
    bool DeleteEmp(int id);
}