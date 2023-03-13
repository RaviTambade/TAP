

using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;

public class EmployeesService : IEmployeesService
{
    private readonly IEmployeeRepository _repo;

    public EmployeesService(IEmployeeRepository repo)
    {
        _repo = repo;
    }

    public List<Employees> GetAllEmployees() => _repo.GetAllEmployees();

   public Employees GetEmployeeById(int id)=> _repo.GetEmployeeById(id);

   
}