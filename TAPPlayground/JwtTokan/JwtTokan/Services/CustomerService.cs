using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class CustomerService:ICustomerService{
    private readonly ICustomerRepository _repo;
    public CustomerService(ICustomerRepository repo){
        this._repo=repo;
    }

    public List<Customer> GetAll() => _repo.GetAll();
    public Customer GetByContactNumber(string contact_number) => _repo.GetByContactNumber(contact_number);
    public Customer GetById(int id)=> _repo.GetById(id);
    public bool Insert(Customer customer)=>_repo.Insert(customer);
    public bool Update(Customer customer)=> _repo.Update(customer);
    public bool Delete(int id)=>_repo.Delete(id);
}

 