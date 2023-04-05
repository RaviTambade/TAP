using ECommerceApp.Repositories.Interfaces;
using MySql.EntityFrameworkCore;
using ECommerceApp.Models;
using ECommerceApp.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace ECommerceApp.Repositories;


public class EmployeeORMRepository : IEmployeeORMRepository
{
    public List<Employee> GetAll()
    {
        using (var context = new EmployeeContext())
        {
            var employees = from employee in context.employees select employee;
            return employees.ToList<Employee>();
        }
    }
}