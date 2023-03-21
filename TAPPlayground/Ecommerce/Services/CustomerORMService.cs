using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class CustomerORMService:ICustomerORMService{
    private readonly ICustomerRepository _repo;
    public CustomerORMService(ICustomerRepository repo){
        this._repo=repo;
    }
    public List<Customer> GetAll() => _repo.GetAll();
}

 