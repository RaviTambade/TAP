using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class CustomerORMService:ICustomerORMService{
    private readonly ICustomerORMRepository _repo;
    public CustomerORMService(ICustomerORMRepository repo){
        this._repo=repo;
    }
    public List<Customer> GetAll() => _repo.GetAll();
    public bool Insert(Customer customer)=> _repo.Insert(customer);
}

 