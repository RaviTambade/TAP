using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class CustomerService:ICustomerService{
    private readonly ICustomerRepository _repo;
    public CustomerService(ICustomerRepository repo){
        this._repo=repo;
    }

    public Customer GetCustomer(string contact_number) => _repo.GetCustomer(contact_number);

    public bool InsertCustomer(Customer customer)=>_repo.InsertCustomer(customer);
}