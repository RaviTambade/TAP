
using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;
public interface ICustomerRepository{
    // bool InsertCustomer(Customer customer);
    List<Customer> GetAll();
    Customer GetById(int id);
    Customer GetByContactNumber(string contact);
    bool Insert(Customer customer);
    bool Update(Customer customer);
    bool Delete(int id);

}