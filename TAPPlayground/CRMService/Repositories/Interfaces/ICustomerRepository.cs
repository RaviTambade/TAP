using CRMService.Models;

namespace CRMService.Repositories.Interfaces;
public interface ICustomerRepository{

    Task<IEnumerable<Customer>> GetAll();
    Task<Customer> GetById(int id);
    Customer GetByContactNumber(string contact);
    Task<bool> Insert(Customer customer);
    Task<bool> Update(Customer customer);
    Task<bool> Delete(int id);

}