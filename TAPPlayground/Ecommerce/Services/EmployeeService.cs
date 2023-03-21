using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repo;
    public EmployeeService(IEmployeeRepository repo)
    {
        _repo = repo;
    }
    public List<Employee> GetAll() => _repo.GetAll();
    public Employee GetById(int empId)=> _repo.GetById(empId);
    public bool Insert (Employee employee) => _repo.Insert(employee);
    public bool Update(Employee emp)=> _repo.Update(emp);
    public bool Delete(int id)=>_repo.Delete(id);
}