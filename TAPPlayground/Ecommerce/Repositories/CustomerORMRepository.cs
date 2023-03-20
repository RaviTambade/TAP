using ECommerceApp.Repositories.Interfaces;
using MySql.EntityFrameworkCore;
using ECommerceApp.Models;
using ECommerceApp.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace ECommerceApp.Repositories;


public class CustomerORMRepository : ICustomerORMRepository
{
    public List<Customer> GetAll()
    {
        using (var context = new CustomerContext())
        {
            var customers = from customer in context.customers select customer;
            return customers.ToList<Customer>();
        }
    }
}