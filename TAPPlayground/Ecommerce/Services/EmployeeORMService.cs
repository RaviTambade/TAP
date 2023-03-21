using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;

public class EmployeeORMService:IEmployeeORMService{
   
    private readonly IEmployeeRepository _repo;

    public EmployeeORMService(IEmployeeRepository repo){
        this._repo=repo;
    }
    public List<Employee> GetAll() => _repo.GetAll();
}

 