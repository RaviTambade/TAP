
using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;
public interface ICustomerRepository{
    bool InsertCustomer(Customer customer);

    Customer GetCustomer(string contact);
}