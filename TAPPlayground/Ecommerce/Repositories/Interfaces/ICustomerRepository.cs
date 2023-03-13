
using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;
public interface ICustomerRepository{
    bool InsertCustomer(Customer customer);

    List<Customer> GetAllCustomers();
    Customer GetCustomerById(int id);
    Customer GetCustomer(string contact);
}