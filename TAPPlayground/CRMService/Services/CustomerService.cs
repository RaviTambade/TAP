using CRMService.Models;
using CRMService.Repositories.Interfaces;
using CRMService.Services.Interfaces;

namespace CRMService.Services;
public class CustomerService:ICustomerService{
    private readonly ICustomerRepository _repo;
    public CustomerService(ICustomerRepository repo){
        this._repo=repo;
    }

    public async Task<IEnumerable<Customer>> GetAll() => await _repo.GetAll();
    public Customer GetByContactNumber(string contact_number) => _repo.GetByContactNumber(contact_number);
    public async Task<Customer> GetById(int id)=>await _repo.GetById(id);
    public async Task<bool> Insert(Customer customer)=>await _repo.Insert(customer);
    public async Task<bool> Update(Customer customer)=>await  _repo.Update(customer);
    public async Task<bool>  Delete(int id)=>await _repo.Delete(id);
}

 