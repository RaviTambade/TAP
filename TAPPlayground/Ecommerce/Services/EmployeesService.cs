

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

    public List<Employee> GetAllEmployees() => _repo.GetAllEmployees();

   public Employee GetEmployeeById(int id)=> _repo.GetEmployeeById(id);

    public bool InsertEmp(Employee emp) => _repo.InsertEmp(emp);

    public bool UpdateEmp(Employee emp)=> _repo.UpdateEmp(emp);

    public bool DeleteEmp(int id)=>_repo.DeleteEmp(id);
}