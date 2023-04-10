using CRMService.Models;

namespace CRMService.Repositories.Interfaces;
public interface ICustomerRepository{

    List<Customer> GetAll();
    Customer GetById(int id);
    Customer GetByContactNumber(string contact);
    bool Insert(Customer customer);
    bool Update(Customer customer);
    bool Delete(int id);

}